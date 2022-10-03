//using System.Collections.Specialized;
using Aop.Api;
using Aop.Api.Domain;
using Aop.Api.Request;
using Aop.Api.Response;
using Newtonsoft.Json;

namespace cinima_mgr.Ali;

public class AlipayConfig
{
    //APPID
    public static string appId = "2021000121668629";
    //支付宝网关
    public static string gateway = "https://openapi.alipaydev.com/gateway.do";
    //用户私钥
    public static string privateKey = "MIIEowIBAAKCAQEAk2VsNKwzG7lpAX/I6RGbs7VX4aj7AOfN6zsTOBL3R58mYu/bYB1t" +
            "CV+Jz+/uuBtS5gBGTX8ShD/WvY0PuxDhZ99v+qlAWYCRiqLeqsNOrviJTnTnd53Flo+ozsI7ySV3EE+BPXpLQTKzl" +
            "o8HEjVrokWYrKxboo0oA/ZlpduLPIN+bkGdFr7pk5UQ6xi1WnkVSsQFdMAFsAFtcEDOXRVsUWvX/3kjrs4CE8Q6iY" +
            "U8UepJXRWGKI3wQ6sEoIZgyC9sedB+Ra5E+Uzp4dGVUAZ6mwV+B0NHr2DyM2li9RvA51m83C14f0QJni/y6DMJfI" +
            "TjBcUYH5EDvhmhIfAgkJgazQIDAQABAoIBAA20qqEjOgVj8j2vcjEp7/5/6FIVcnGdHGq5LYpTSSchx2H/x7hiRBd" +
            "RCPGK7/myoLy+Xcsq+7/MZ91sVoAgi7Uq87CtOEyaRe5MQsRCMPjYJ3xiJnva8dqUNTA0o3aKw02C9xOOYZ0IZ+a" +
            "iGhg5W27VZeL4i/TLh2MG8GDBz2qq814tR0GDegmhX7HZ7QmZ0E/9kYK+BGiL2yLO4rW26jqEqLJPCVwzR+oZRpD" +
            "pIKVoL+NDESUfA2gfF474/uxg+NHkLrYQIF2tiQPK1QV7Tgzl7/sFYFuQVlsNvOaADneympniOgCcRa2rdF9umjb" +
            "X/Ks3QpaCOK9VYQHa+VpAxoECgYEAxq4PfLxtdKYU2VNl1/KSHf61Id5asUgjt3hbQFWDHw+pDmhzkIsK9IcJI7wG" +
            "xZ/FvKGeU1eTPdzhI9ULQ+2V6H7KDkHx5JFTuaU8+p0L5Ryafda6VOYOQjaXs7XyKMBuThcTYaH8/zhztKXk0FBu" +
            "t/SdoTYSXMl7NWEqRQtTBFECgYEAveuwgwoimBWaCet6ycQIfhGWWHEyMvF5k2jQkh8HLAKK8vg9oMhTDajpGj1V" +
            "Zd64iI3451xw4v/uRVxNlG+7/weAZ6/EghrvE8h5r0UnowMU2KlLY9V57UL4KpLjJbsqLk7wa/BA+rBLfZIUr75a" +
            "ExJVWJd1x72rQt5ug1XLe70CgYBmFoxYsM2hUbGG1iaPptHT3cwe4g1B6OqJXKuuzAG7FSXuBFfVXsy7RyO4G+Zy" +
            "550IRxd+hZJgCD4bVl4agls0Auo6F0J/Cvm1e6VwtP+ms2Li5FIMS8Xp2flrW0NaEz7am1rXIRBJ6Cz0FwYS0DGE" +
            "Dopsisc2rETF8e5xWddHcQKBgF8ZFVmISao9ptQwxVsifd4ikFXY2HoJ0AawBUAlqUGwRENFahaIOI4udgpdi9Vm" +
            "oKA/9tJix2PjIzw36+DX0hrxdqp0qME9G1mcmNHanu5RLK8Qll93FYZocjtfMb5C6ewmOtzRgLgGbsaBzznw5smF" +
            "9JZXwPIzVv40wsGgxDNBAoGBAINYK9v0W45+zIGHMZPXP7Kyn/AreNTuD98wO/o0kx29AWUY/qc8a8FUN5h9xs2y" +
            "HXp6PHnGayyyJdc/JWw24GkgxvOWreZiM+eLySiZU43DASbTeRTkDJaRylKQiVTiDe1ZabnZTe7H+WDjUyWWoO+4E" +
            "QMpVHUkhheRtlgsSUHw";
    //支付宝公钥
    public static string alipayPublicKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAmGUeIwcV08FmUF8kBz5+q7r1Plg" +
                                             "gs/j50zHOZW4NahkHVFWGL/W0SQZZijR9NGbADmDnGbrvZrFSIMGmlcOqpAQ9wjMbmeJgX72cRByYQTyEr9/38SHi" +
                                             "vW9g8y8tVTzd/2QOgIUGvkmrj6ZuC5b/Iwwt0gzFjoOICAfBMKhdniD+53+PgHsqG7YUAnSwtTuslbD+VTliXl14L" +
                                             "d5fZWdlkCbGodSpDGqGfdV6BdQ5EH2mUSZFznrxEE1JbTZ5AYLS+1Gh5thpjjyCYsRqLHLyYJh0YQQlohvOxNAMpf" +
                                             "cz+8vQuddy+hdqJDzyrDPTvfPX7IhlbsKs7DYAGiOngKsSLQIDAQAB";
    //支付成功的回调地址
    public static string returnURL = "";
    // 签名方式  
    public static string sign_type = "RSA2";
    // 编码格式  
    public static string charset = "UTF-8";

    private static string generateOrderNumber()
    {
        return DateTime.Now.ToString("yyyyMMddHHmmssfff");
    }

    /*
     * 创建支付model
     * price：商品价格
     * title：商品标题
     * description：商品描述
     * **/
    public static AlipayTradePagePayModel creatModel(string price, string title, string description)
    {
        AlipayTradePagePayModel model = new AlipayTradePagePayModel();
        model.Body = description;
        model.Subject = title;
        //付款金额
        model.TotalAmount = price;
        //商户网站中唯一订单号
        model.OutTradeNo = generateOrderNumber();
        model.ProductCode = "FAST_INSTANT_TRADE_PAY";
        return model;
    }

    /*public void pay()
    {
        IAopClient client = new DefaultAopClient(AlipayConfig.gateway, AlipayConfig.appId, AlipayConfig.privateKey, "json", "1.0", AlipayConfig.sign_type, AlipayConfig.alipayPublicKey, AlipayConfig.charset, false);
        AlipayTradePagePayRequest request = new AlipayTradePagePayRequest();
        request.SetNotifyUrl("");
        request.SetReturnUrl("https://m.alipay.com/Gk8NF23");
        Dictionary<string, object> bizContent = new Dictionary<string, object>();
        bizContent.Add("out_trade_no", "20210817010101004");
        bizContent.Add("total_amount", 0.01);
        bizContent.Add("subject", "测试商品");
        bizContent.Add("qr_pay_mode", "2");
        bizContent.Add("product_code", "FAST_INSTANT_TRADE_PAY");

        string Contentjson = JsonConvert.SerializeObject(bizContent);
        request.BizContent = Contentjson;
        AlipayTradePagePayResponse response = client.pageExecute(request);
        Console.WriteLine(response.Body);

    }*/

    public string Index()
    {
        DefaultAopClient client = new DefaultAopClient(AlipayConfig.gateway, AlipayConfig.appId, AlipayConfig.privateKey, "json", "1.0", AlipayConfig.sign_type, AlipayConfig.alipayPublicKey, AlipayConfig.charset, false);
        //金额格式必须是小数点后两位数或是正整数且不是金额格式（即$123.00），以及非常重要的一个原则，传递的参数要么不传递这个参数（即传递的众多参数中，这个参数完全不存在
        AlipayTradePagePayModel model = AlipayConfig.creatModel("9.90", "测试商品", "测试商品支付");
        
        AlipayTradePagePayRequest request = new AlipayTradePagePayRequest();
        //支付成功的回调地址
        request.SetReturnUrl("");
        // 设置异步通知接收地址，需要公网能够访问
        request.SetNotifyUrl("xxxxxxxxxx");
        // 将业务model载入到request
        request.SetBizModel(model);
        //String form = client.pageExecute(request).Body;//调用SDK生成表单
        //httpResponse.ContentType = "text/html;charset=UTF-8";
        //httpResponse.Write(form);//直接将完整的表单html输出到页面
        //httpResponse.flush();
        //httpResponse.getWriter().close();
        AlipayTradePagePayResponse response = null;

        try
        {
            response = client.pageExecute(request);
            
            Console.Write(response.Body);
            return response.Body;
        }
        catch (Exception exp)
        {
            throw exp;
        }

    }
    /*
    public void notify()
    {
        Dictionary<string, string> sArray = GetRequestPost();
        if (sArray.Count > 0)
        {


            //调用SDK验签方法
            bool signVerified = AlipaySignature.RSACheckV1(sArray, AlipayConfig.alipayPublicKey, AlipayConfig.charset);
            //此判断结果中书写业务逻辑代码
            if (signVerified)   //验证支付发过来的消息，签名是否正确
            {
                //商户订单号
                string out_trade_no = Request.Form["out_trade_no"];

                //支付宝交易号
                string trade_no = Request.Form["trade_no"];

                //交易状态
                string trade_status = Request.Form["trade_status"];


                if (Request.Form["trade_status"] == "TRADE_FINISHED")
                {
                    //判断该笔订单是否在商户网站中已经做过处理
                    //如果没有做过处理，根据订单号（out_trade_no）在商户网站的订单系统中查到该笔订单的详细，并执行商户的业务程序
                    //如果有做过处理，不执行商户的业务程序

                    //注意：
                    //退款日期超过可退款期限后（如三个月可退款），支付宝系统发送该交易状态通知
                }
                else if (Request.Form["trade_status"] == "TRADE_SUCCESS")
                {
                    //判断该笔订单是否在商户网站中已经做过处理
                    //如果没有做过处理，根据订单号（out_trade_no）在商户网站的订单系统中查到该笔订单的详细，并执行商户的业务程序
                    //如果有做过处理，不执行商户的业务程序

                    //注意：
                    //付款完成后，支付宝系统发送该交易状态通知

                    //请在这里加上商户的业务逻辑程序代码

                }
                else
                {
                }
                Response.Write("success");     //返回给支付宝消息，成功,这里不要动！！！
            }
            else
            {
                Response.Write("fail");
            }
        }

    }

    public Dictionary<string, string> GetRequestPost()
    {
        int i = 0;
        Dictionary<string, string> sArray = new Dictionary<string, string>();
        System.Collections.Specialized.NameValueCollection coll;
        coll = request.Form;
        String[] requestItem = coll.AllKeys;
        for (i = 0; i < requestItem.Length; i++)
        {
            sArray.Add(requestItem[i], Request.Form[requestItem[i]]);
        }
        return sArray;

    }*/
}
