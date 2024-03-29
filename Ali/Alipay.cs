﻿using Aop.Api;
using Aop.Api.Domain;
using Aop.Api.Request;
using Aop.Api.Response;
using Newtonsoft.Json;
using cinima_mgr.Data;
using Microsoft.EntityFrameworkCore;

namespace cinima_mgr.Ali;

public class AlipayConfig
{
    public static string appId = "2021000121668629";
    public static string gateway = "https://openapi.alipaydev.com/gateway.do";
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
    public static string alipayPublicKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAmGUeIwcV08FmUF8kBz5+q7r1Plg" +
                                             "gs/j50zHOZW4NahkHVFWGL/W0SQZZijR9NGbADmDnGbrvZrFSIMGmlcOqpAQ9wjMbmeJgX72cRByYQTyEr9/38SHi" +
                                             "vW9g8y8tVTzd/2QOgIUGvkmrj6ZuC5b/Iwwt0gzFjoOICAfBMKhdniD+53+PgHsqG7YUAnSwtTuslbD+VTliXl14L" +
                                             "d5fZWdlkCbGodSpDGqGfdV6BdQ5EH2mUSZFznrxEE1JbTZ5AYLS+1Gh5thpjjyCYsRqLHLyYJh0YQQlohvOxNAMpf" +
                                             "cz+8vQuddy+hdqJDzyrDPTvfPX7IhlbsKs7DYAGiOngKsSLQIDAQAB";
    public static string returnURL = "";
    public static string sign_type = "RSA2";
    public static string charset = "UTF-8";

    public  AlipayTradePagePayModel creatModel(string out_trade_no,string price,string subject )
    {
        AlipayTradePagePayModel model = new AlipayTradePagePayModel();
        model.Body = "电影";
        model.Subject = subject;
        model.TotalAmount = price;
        model.OutTradeNo = out_trade_no;
        model.ProductCode = "FAST_INSTANT_TRADE_PAY";
        model.TimeExpire = DateTime.Now.AddMinutes(17).ToString("yyyy-MM-dd HH:mm:ss");
        return model;
    }

    public string Pay(AlipayTradePagePayModel model, string taskID)
    {
        IAopClient client = new DefaultAopClient(AlipayConfig.gateway, AlipayConfig.appId, AlipayConfig.privateKey, "json", "1.0", AlipayConfig.sign_type, AlipayConfig.alipayPublicKey, AlipayConfig.charset, false); 
        AlipayTradePagePayRequest request = new AlipayTradePagePayRequest();
        request.SetReturnUrl($"https://localhost:7220/AlreadyPay/{model.OutTradeNo}/{taskID}");
        request.SetBizModel(model);
        AlipayTradePagePayResponse response = null;
        try
        {
            response = client.pageExecute(request);
            return response.Body;
        }
        catch (Exception exp)
        {
            throw exp;
        }

    }

    public string Query(string out_trade_no)
    {
        IAopClient client = new DefaultAopClient(AlipayConfig.gateway, AlipayConfig.appId, AlipayConfig.privateKey, "json", "1.0", AlipayConfig.sign_type, AlipayConfig.alipayPublicKey, AlipayConfig.charset, false);
        AlipayTradeQueryRequest  request= new AlipayTradeQueryRequest() ;
        Dictionary<string, object> bizContent = new Dictionary<string, object>();
        bizContent.Add("out_trade_no", out_trade_no);
        string Contentjson = JsonConvert.SerializeObject(bizContent);
        request.BizContent = Contentjson;
        AlipayTradeQueryResponse response= null;
        try
        {
            response = client.Execute(request);
            Console.WriteLine(response.Body);
            return response.Body;
        }
        catch (Exception exp)
        {
            throw exp;
        }
    }
    public string Refund(string out_trade_no,string price)
    {
        IAopClient client = new DefaultAopClient(AlipayConfig.gateway, AlipayConfig.appId, AlipayConfig.privateKey, "json", "1.0", AlipayConfig.sign_type, AlipayConfig.alipayPublicKey, AlipayConfig.charset, false);
        string refund_amount = price;
        string refund_reason = "正常退款";
        // 退款单号，同一笔多次退款需要保证唯一，部分退款该参数必填。
        string out_request_no = out_trade_no;
        AlipayTradeRefundModel model = new AlipayTradeRefundModel();
        model.OutTradeNo = out_trade_no;
        //model.TradeNo = trade_no;
        model.RefundAmount = refund_amount;
        model.RefundReason = refund_reason;
        model.OutRequestNo = out_request_no;
        AlipayTradeRefundRequest request = new AlipayTradeRefundRequest();
        request.SetBizModel(model);
        AlipayTradeRefundResponse response = null;
        try
        {
            response = client.Execute(request);
            return response.Body;
        }
        catch (Exception exp)
        {
            throw exp;
        }
    }

    public string RefundQuery(string out_trade_no)
    {
        DefaultAopClient client = new DefaultAopClient(AlipayConfig.gateway, AlipayConfig.appId, AlipayConfig.privateKey, "json", "1.0", AlipayConfig.sign_type, AlipayConfig.alipayPublicKey, AlipayConfig.charset, false);
        // 请求退款接口时，传入的退款号，如果在退款时未传入该值，则该值为创建交易时的商户订单号，必填。
        string out_request_no = out_trade_no;
        AlipayTradeFastpayRefundQueryModel model = new AlipayTradeFastpayRefundQueryModel();
        model.OutTradeNo = out_trade_no;
        //model.TradeNo = trade_no;
        model.OutRequestNo = out_request_no;
        AlipayTradeFastpayRefundQueryRequest request = new AlipayTradeFastpayRefundQueryRequest();
        request.SetBizModel(model);
        AlipayTradeFastpayRefundQueryResponse response = null;
        try
        {
            response = client.Execute(request);
            return response.Body;
        }
        catch (Exception exp)
        {
            throw exp;
        }
    }

    public string Close(string out_trade_no)
    {
        IAopClient client = new DefaultAopClient(AlipayConfig.gateway, AlipayConfig.appId, AlipayConfig.privateKey, "json", "1.0", AlipayConfig.sign_type, AlipayConfig.alipayPublicKey, AlipayConfig.charset, false);
        AlipayTradeCloseRequest  request= new AlipayTradeCloseRequest() ;
        Dictionary<string, object> bizContent = new Dictionary<string, object>();
        bizContent.Add("trade_no", out_trade_no);
        string Contentjson = JsonConvert.SerializeObject(bizContent);
        request.BizContent = Contentjson;
        AlipayTradeCloseResponse response = null;
        try
        {
            response = client.Execute(request);
            Console.WriteLine(response.Body);
            return response.Body;
        }
        catch (Exception exp)
        {
            throw exp;
        }
    }
    
}
