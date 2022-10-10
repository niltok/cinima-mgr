using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json;
using cinima_mgr.Data;
using Microsoft.EntityFrameworkCore;

namespace cinima_mgr.Service;

public class EventMgr : IAsyncDisposable
{
    [Serializable]
    private record TypedObject(string Type, string Object);
    [Serializable]
    private record ClosureCall(string ClassName, string MethodName, TypedObject? Caller, List<TypedObject> Parameters);
    
    private readonly PeriodicTimer _timer = new(TimeSpan.FromMilliseconds(100));

    private static object? RecoverObject(TypedObject obj)
    {
        var t = Type.GetType(obj.Type)!;
        return JsonSerializer.Deserialize(obj.Object, t);
    }

    private MgrContext _db = new();

    private async Task EventCircle()
    {
        while (await _timer.WaitForNextTickAsync())
        {
            var run = true;
            while (run) {
                var recent = await _db.Events.OrderBy(r => r.TriggerTime).FirstOrDefaultAsync();
                if (recent is null || recent.TriggerTime > DateTime.Now) run = false;
                else
                {
                    _db.Events.Remove(recent);
                    await _db.SaveChangesAsync();
                    var closure = JsonSerializer.Deserialize<ClosureCall>(recent.Closure)!;
                    var method = Type.GetType(closure.ClassName)!
                        .GetMethod(closure.MethodName, 
                            BindingFlags.Public | 
                            BindingFlags.NonPublic | 
                            BindingFlags.Static )!;
                    method.Invoke(
                        closure.Caller is null ? null : RecoverObject(closure.Caller), 
                        closure.Parameters
                            .Select(RecoverObject)
                            .ToArray());
                }
            }
        }
    }

    public EventMgr()
    {
        EventCircle();
    }

    /// <summary>
    /// 注册事件
    /// </summary>
    /// <param name="triggerTime">
    /// 触发时间
    /// </param>
    /// <param name="callback">
    /// 必须是一个没有参数的 Lambda 表达式，函数体只能是一个函数调用。
    /// 函数调用的调用者以及参数必须是可序列化的（静态函数没有调用者）。
    /// 当注册函数被调用时调用者以及参数将会被计算（请不要写入任何带副作用的内容）。
    /// </param>
    /// <returns>
    /// 事件编号（用于取消）
    /// </returns>
    /// <example>
    /// <code>
    /// await EventMgr.Subscribe(
    ///     DateTime.Now + TimeSpan.FromSeconds(5),
    ///     () => Console.WriteLine("{0}", Math.Sin(1))
    /// );
    /// </code>
    /// </example>
    public async Task<string> Subscribe(DateTime triggerTime, Expression<Action> callback)
    {
        var id = Guid.NewGuid().ToString();
        var closure = SerializeAction(callback);
        await using var db = new MgrContext();
        db.Events.Add(new Event
        {
            Id = id,
            TriggerTime = triggerTime,
            Closure = JsonSerializer.Serialize(closure)
        });
        await db.SaveChangesAsync();
        return id;
    }

    public async Task Cancel(string id)
    {
        await using var db = new MgrContext();
        db.Events.Remove(await db.Events.SingleAsync(e => e.Id == id));
        await db.SaveChangesAsync();
    }

    [Obsolete]
    private static object? Evaluate(Expression e)
    {
        return e switch
        {
            ConstantExpression ce => ce.Value,
            NewExpression ne => ne.Constructor?.Invoke(ne.Arguments.Select(Evaluate).ToArray()),
            MemberExpression me => me.Expression is null ? null : me.Member switch
            {
                FieldInfo fi => fi.GetValue(Evaluate(me.Expression)),
                PropertyInfo pi => pi.GetValue(Evaluate(me.Expression)),
                _ => throw new ArgumentException($"Unsupported Expression {me.Member.MemberType}")
            },
            _ => throw new ArgumentException($"Unsupported Expression {e.NodeType}")
        };
    }

    private static string TypeName(Type type)
    {
        return type.FullName ?? type.Name;
    }

    private static Expression RemoveConvert(Expression e)
    {
        if (e is UnaryExpression {NodeType: ExpressionType.Convert} ue) 
            return RemoveConvert(ue.Operand);
        return e;
    }

    private static TypedObject SerializeExpression(Expression e)
    {
        var rce = RemoveConvert(e);
        return new TypedObject(TypeName(rce.Type),
            JsonSerializer.Serialize(Expression.Lambda(rce).Compile().DynamicInvoke(), rce.Type));
    }

    private static ClosureCall SerializeAction(Expression<Action> f)
    {
        if (f.Body is not MethodCallExpression call) 
            throw new ArgumentException($"Unsupported Expression {f.Body.NodeType}");
        return new ClosureCall(TypeName(call.Method.DeclaringType!), call.Method.Name,
            call.Object is null ? null : SerializeExpression(call.Object),
            call.Arguments.Select(SerializeExpression).ToList());
    }

    public async ValueTask DisposeAsync()
    {
        await _db.DisposeAsync();
        _timer.Dispose();
    }
}