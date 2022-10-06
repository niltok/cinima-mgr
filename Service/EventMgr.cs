using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json;
using cinima_mgr.Data;

namespace cinima_mgr.Service;

public class EventMgr : IAsyncDisposable
{
    [Serializable]
    private record TypedObject(string Type, string Object);
    [Serializable]
    private record ClosureCall(string ClassName, string MethodName, TypedObject? Caller, List<TypedObject> Parameters);
    
    private MgrContext _db = new MgrContext();
    
    
    private void EventCircle() {}

    public EventMgr()
    {
    }

    public async Task<string> Subscribe(DateTime triggerTime, Expression<Action> callback)
    {
        var id = Guid.NewGuid().ToString();
        var closure = SerializeAction(callback);
        _db.Events.Add(new Event
        {
            Id = id,
            TriggerTime = triggerTime,
            Closure = JsonSerializer.Serialize(closure)
        });
        await _db.SaveChangesAsync();
        return id;
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
    }
}