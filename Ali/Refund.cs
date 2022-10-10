using cinima_mgr.Data;
using System.Text.Json;
namespace cinima_mgr.Ali;

public class Refund
{
    public bool Enable { get; set; } = false;
    public string out_trade_no { get; set; }
    public string price { get; set; }
    public bool yn = false; //当值为true时，成功

    public void refund()
    {
        if (!Enable) return;
        AlipayConfig m = new AlipayConfig();
        string res = m.Refund(out_trade_no, price);
        string jsonString = m.RefundQuery(out_trade_no);

        int n = 0, v = 0;
        using(JsonDocument document = JsonDocument.Parse(jsonString))
        {
            JsonElement root = document.RootElement;
            JsonElement Element = root.GetProperty("alipay_trade_fastpay_refund_query_response");

            foreach(JsonProperty element in Element.EnumerateObject())
            {
                if (element.Name == "refund_status")
                {
                    if(element.Value.GetString() == "REFUND_SUCCESS")
                    {
                        changedb();
                        yn = true;
                        break;
                    }
                }
            }
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
            //设置订单信息：已退款
            data.State = 2;
        }
    }
}