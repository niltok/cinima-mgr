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

        string WIDout_trade_no = "1";//����Ҫ���ԵĶ������,һ��ֻ��һ�����
                                     // �ⲿ�����ţ��̻���վ����ϵͳ��Ψһ�Ķ�����
        string out_trade_no = WIDout_trade_no.Trim();

        // ��������
        string subject = TextName.Text.Trim();

        // ������
        string total_amount = TextPrice.Text.Trim();

        // ��Ʒ����
        string body = TextADD.Text.Trim();

        // ��װҵ�����model
        AlipayTradePagePayModel model = new AlipayTradePagePayModel();
        model.Body = body;
        model.Subject = subject;
        model.TotalAmount = total_amount;
        model.OutTradeNo = out_trade_no;
        model.ProductCode = "FAST_INSTANT_TRADE_PAY";

        AlipayTradePagePayRequest request = new AlipayTradePagePayRequest();
        // ����ͬ���ص���ַ
        request.SetReturnUrl("");
        // �����첽֪ͨ���յ�ַ
        request.SetNotifyUrl("");
        // ��ҵ��model���뵽request
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

 