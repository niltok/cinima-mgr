using System.Text.Json;
using cinima_mgr.Ali;
using cinima_mgr.Data;

namespace cinima_mgr.Ali;

public class Query
{
    public bool Enable { get; set; } = false;
    public string out_trade_no { get; set; }
    public int res;
    public bool yn = false;
    public void query()
    {
        if (!Enable) return;
        AlipayConfig m = new AlipayConfig();
        string jsonString = m.Query(out_trade_no);
        using (JsonDocument document = JsonDocument.Parse(jsonString))
        {
            JsonElement root = document.RootElement;
            JsonElement Element = root.GetProperty("alipay_trade_query_response");
            foreach (JsonProperty element in Element.EnumerateObject())
            {
                if (element.Name == "trade_status")
                {
                    if (element.Value.GetString() == "WAIT_BUYER_PAY") //等待买家付款
                    {
                        res = 1;
                        yn = true;
                        break;
                    }
                    else if (element.Value.GetString() == "TRADE_CLOSED") //未付款交易超时关闭，或支付完成后全额退款
                    {
                        res = 2;
                        yn = true;
                        break;
                    }
                    else if (element.Value.GetString() == "TRADE_SUCCESS") //交易支付成功
                    {
                        res = 3;
                        yn = true;
                        break;
                    }
                    else if (element.Value.GetString() == "TRADE_FINISHED") //交易结束，不可退款
                    {
                        res = 4;
                        yn = true;
                        break;
                    }
                }
            }
            changedb();
        }
    }

    private void changedb()
    {
        using var db = new MgrContext();
        var data = db.Orders
            .Where(t => t.Id == out_trade_no).SingleOrDefault();
        if(data.State == null)
        {
            Console.WriteLine("订单不存在");
        }
        else
        {
            //设置订单状态
            if (res == 1)
            {
                data.State = 0;
            }
            else if (res == 2)
            {
                data.State = 2;
            }
            else if (res == 3 || res == 4)
            {
                data.State = 1;
            }
        }
    }
}