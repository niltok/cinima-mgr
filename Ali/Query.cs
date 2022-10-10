using System.Text.Json;
using cinima_mgr.Ali;
using cinima_mgr.Data;
using Microsoft.EntityFrameworkCore;

namespace cinima_mgr.Ali;

public static class Query
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns>
    /// <para>1 : 等待买家付款</para>
    /// <para>2 : 未付款交易超时关闭，或支付完成后全额退款</para>
    /// <para>3 : 交易支付成功</para>
    /// <para>4 : 交易结束，不可退款</para>
    /// </returns>
    public static async Task<int> query(string out_trade_no)
    {
        var res = 0;
        var m = new AlipayConfig();
        var jsonString = m.Query(out_trade_no);
        using var document = JsonDocument.Parse(jsonString);
        var root = document.RootElement;
        var jsonElement = root.GetProperty("alipay_trade_query_response");
        foreach (var element in jsonElement.EnumerateObject()
                     .Where(element => element.Name == "trade_status"))
        {
            if (element.Value.GetString() == "WAIT_BUYER_PAY") //等待买家付款
            {
                res = 1;
            }
            else if (element.Value.GetString() == "TRADE_CLOSED") //未付款交易超时关闭，或支付完成后全额退款
            {
                res = 2;
            }
            else if (element.Value.GetString() == "TRADE_SUCCESS") //交易支付成功
            {
                res = 3;
            }
            else if (element.Value.GetString() == "TRADE_FINISHED") //交易结束，不可退款
            {
                res = 4;
            }
        }
        await Changedb(out_trade_no, res);
        return res;
    }

    private static async Task Changedb(string out_trade_no, int res)
    {
        await using var db = new MgrContext();
        var data = await db.Orders.SingleOrDefaultAsync(t => t.Id == out_trade_no);
        if(data is null)
        {
            throw new Exception("订单不存在");
        }

        switch (res)
        {
            //设置订单状态
            case 1:
                data.State = 0;
                break;
            case 2:
                data.State = 2;
                break;
            case 3:
            case 4:
                data.State = 1;
                break;
        }
    }
}