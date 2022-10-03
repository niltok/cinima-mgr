using Aop.Api;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace cinima_mgr.Pages
{
    public class moneyModel : PageModel 
    {
        public void OnGet()
        {

        }
       
       /*public void BtnAlipay_Click()
        {
            
        DefaultAopClient client = new DefaultAopClient(config.gatewayUrl, config.app_id, config.private_key, "json", "1.0", config.sign_type, config.alipay_public_key, config.charset, false);

        string WIDout_trade_no = "1";//待会要测试的订单编号,一次只能一个编号
                                     // 外部订单号，商户网站订单系统中唯一的订单号
        string out_trade_no = WIDout_trade_no.Trim();

        // 订单名称
        string subject = TextName.Text.Trim();

        // 付款金额
        string total_amount = TextPrice.Text.Trim();

        // 商品描述
        string body = TextADD.Text.Trim();

        // 组装业务参数model
        AlipayTradePagePayModel model = new AlipayTradePagePayModel();
        model.Body = body;
        model.Subject = subject;
        model.TotalAmount = total_amount;
        model.OutTradeNo = out_trade_no;
        model.ProductCode = "FAST_INSTANT_TRADE_PAY";

        AlipayTradePagePayRequest request = new AlipayTradePagePayRequest();
        // 设置同步回调地址
        request.SetReturnUrl("");
        // 设置异步通知接收地址
        request.SetNotifyUrl("");
        // 将业务model载入到request
        request.SetBizModel(model);

        AlipayTradePagePayResponse response = null;
        try
        {
            response = client.pageExecute(request, null, "post");
            Response.Write(response.Body);
        }
        catch (Exception exp)
        {
            throw exp;
        }
    }*/


    }

}

 