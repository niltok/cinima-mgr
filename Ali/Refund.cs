using cinima_mgr.Data;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using  cinima_mgr.Data;

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
        bool _savefailed;
        do
        {
            _savefailed = false;
            var data = await db.Orders.Where(t => t.Id == out_trade_no)
                .Include(t => t.Tickets).ToListAsync();
            if (data.Count == 0)
            {
                throw new Exception("订单不存在");
            }

            await Task.WhenAll(data.Select(t => db
                .Entry(t.Tickets.First())
                .Reference(s => s.Show)
                .LoadAsync()));
            await Task.WhenAll(data.Select(t => db
                .Entry(t.Tickets.First().Show)
                .Reference(s => s.Room)
                .LoadAsync()));
            await Task.WhenAll(data.Select(t => db
                .Entry(t.Tickets.First().Show)
                .Reference(s => s.Movie)
                .LoadAsync()));

            char[,] _pos = PosStateHelper.Unpack(data.First().Tickets.First().Show.PosState,
                data.First().Tickets.First().Show.Room.Height,
                data.First().Tickets.First().Show.Room.Width);

            foreach (var t in data.First().Tickets)
            {
                t.Status = 0;
                _pos[t.Row, t.Column] = '0';
            }
            
            data.First().Tickets.First().Show.Movie.BoxOffice -= (long)(data.First().Price*100);
            data.First().Tickets.First().Show.PosState = (PosStateHelper.Pack(_pos));
            data.First().RefundTime = DateTime.Now;
            //设置订单信息：已退款
            data.First().State = 2;
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                _savefailed = true;
            }
        } while (_savefailed);
    }
}