using cinima_mgr.Data;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace cinima_mgr.Ali;

public static class Refund
{
    public static async Task<bool> refund(string out_trade_no, string price)
    {
        var m = new AlipayConfig();
        var res = m.Refund(out_trade_no, price);
        //var jsonString = m.RefundQuery(out_trade_no);

        using var document = JsonDocument.Parse(res);
        var root = document.RootElement;
        var jsonElement = root.GetProperty("alipay_trade_refund_response");

        if (jsonElement
            .EnumerateObject()
            .Where(element => element.Name == "fund_change")
            .All(element => element.Value.GetString() != "Y")) 
            return false;
        await Changedb(out_trade_no);
        return true;

    }

    private static async Task Changedb(string out_trade_no)
    {
        await using var db = new MgrContext();
        var data = await db.Orders.SingleOrDefaultAsync(t => t.Id == out_trade_no);
        if(data is null)
        {
            throw new Exception("订单不存在");
        }

        //设置订单信息：已退款
        data.State = 2;
    }
}