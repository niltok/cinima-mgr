using System;
using Alipay.EasySDK.Factory;
using Alipay.EasySDK.Kernel;
using Alipay.EasySDK.Kernel.Util;
using Alipay.EasySDK.Payment.Page.Models;
using Alipay.EasySDK.Payment.Common.Models;
namespace cinima_mgr.Ali;

public class Models
{
    public void pay()
    {
        // 1. 设置参数（全局只需设置一次）
        Factory.SetOptions(GetConfig());
        try
        {
            AlipayTradeCreateResponse response = Factory.Payment.Common()
                .Optional("qr_pay_mode", "1")
                .Create("Apple iPhone11 128G", "2234567234890", "5799.00", "2088622987776105");
            //AlipayTradePagePayResponse response =Factory.Payment.Page().Pay
             //       ("Apple iPhone11 128G", "2234567234890", "5799.00", "/");

            if (ResponseChecker.Success(response))
            {
                Console.WriteLine("调用成功");
            }
            else
            {
                Console.WriteLine("调用失败，原因：" +response.Code);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("调用遭遇异常，原因：" + ex.Message);
            throw;
        }
    }
    static private Config GetConfig()
    {
        return new Config()
        {
            Protocol = "https",
            GatewayHost = "openapi.alipaydev.com",
            SignType = "RSA2",
            AppId = "2021000121668629",
            // 为避免私钥随源码泄露，推荐从文件中读取私钥字符串而不是写入源码中应用私钥
            MerchantPrivateKey = "MIIEowIBAAKCAQEAk2VsNKwzG7lpAX/I6RGbs7VX4aj7AOfN6zsTOBL3R58mYu/bYB1t" +
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
            "QMpVHUkhheRtlgsSUHw",
            AlipayPublicKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAmGUeIwcV08FmUF8kBz5+q7r1Plg" +
            "gs/j50zHOZW4NahkHVFWGL/W0SQZZijR9NGbADmDnGbrvZrFSIMGmlcOqpAQ9wjMbmeJgX72cRByYQTyEr9/38SHi" +
            "vW9g8y8tVTzd/2QOgIUGvkmrj6ZuC5b/Iwwt0gzFjoOICAfBMKhdniD+53+PgHsqG7YUAnSwtTuslbD+VTliXl14L" +
            "d5fZWdlkCbGodSpDGqGfdV6BdQ5EH2mUSZFznrxEE1JbTZ5AYLS+1Gh5thpjjyCYsRqLHLyYJh0YQQlohvOxNAMpf" +
            "cz+8vQuddy+hdqJDzyrDPTvfPX7IhlbsKs7DYAGiOngKsSLQIDAQAB"
            //可设置异步通知接收服务地址（可选）
            //NotifyUrl = "<-- 请填写您的支付类接口异步通知接收服务地址，例如：https://www.test.com/callback -->",
            //可设置AES密钥，调用AES加解密相关接口时需要（可选）
            //EncryptKey = "<-- 请填写您的AES密钥，例如：aa4BtZ4tspm2wnXLb1ThQA== -->"
        };
    }
}