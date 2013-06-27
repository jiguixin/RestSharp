/*
 *名称：MyHttpsTest
 *功能：
 *创建人：吉桂昕
 *创建时间：2013-06-25 03:47:39
 *修改时间：
 *备注：
 */

using System;
using System.Net;
using System.Text;
using NUnit.Framework;

namespace RestSharp.Tests
{
    [TestFixture]
    public class MyHttpsTest
    {
        /// <summary>
        /// 为整个TestFixture初始化资源
        /// </summary>
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
        }

        /// <summary>
        /// 为整个TestFixture释放资源
        /// </summary>
        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
        }

        /// <summary>
        /// 为每个Test方法创建资源
        /// </summary>
        [SetUp]
        public void Initialize()
        {
        }

        /// <summary>
        /// 为每个Test方法释放资源
        /// </summary>
        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void HttpsTest()
        {
            string url = "http://member.banggo.com/Member/index.shtml";

            var request = new RestRequest(Method.POST);
            var client = new RestClient("https://passport.banggo.com/CASServer/login?service=http%3A%2F%2Fact.banggo.com%2FUser%2Flogin%3Freturn_url%3Dhttp%3A%2F%2Fmember.banggo.com%2FMember%2Findex.shtml");
            request.AddHeader("Host", "passport.banggo.com");
            request.AddHeader("Cache-Control", "max-age=0");    
            request.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
            request.AddHeader("Origin", "https://passport.banggo.com");
            request.AddHeader("User-Agent",
                              "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/27.0.1453.116 Safari/537.36");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Referer",
                              "https://passport.banggo.com/CASServer/login?service=http%3A%2F%2Fact.banggo.com%2FUser%2Flogin%3Freturn_url%3Dhttp%3A%2F%2Fmember.banggo.com%2FMember%2Findex.shtml");
            request.AddHeader("Accept-Encoding", "gzip,deflate,sdch");
            request.AddHeader("Accept-Language", "zh-CN,zh;q=0.8");

            request.AddHeader("Cookie",
                              "JSESSIONID=175386048A945B23EF548C26018D0C1E; userName=%E5%BC%A0%E6%A2%85zm; loginType=0; stati_client_mark_code=1355468680418; cpsVerify=emar%7C5858%7CNTk3MTcwfDAwNDE4MzAwZGFjYTc2OTE1OWE1; sexType=man; bg_user_pref=39c50cee7df189bc484860a7d6b6e675%7Cbc%3AMB%3A31.11%2Ccid%3A1%3A32.59%7C1371626628; bg_user_ip=8%7C118.122.122.166%7C%E5%9B%9B%E5%B7%9D%7C23%7C%E6%88%90%E9%83%BD%7C287%7C%7C; bg_uid=016551f1f30744e0f22ccd323d7fbff4; banggo_think_language=zh-CN; PHPSESSID=ST194554eaWruduepdjizhaWWzu1passportbanggocom01; bg_sid=ST194554eaWruduepdjizhaWWzu1passportbanggocom01; bg_user_id=%22%5Cu5f20%5Cu6885zm%22; bg_time=1372212476; __utma=4343212.2067767875.1355468680.1372208629.1372212478.144; __utmc=4343212; __utmz=4343212.1372054189.138.10.utmcsr=member.banggo.com|utmccn=(referral)|utmcmd=referral|utmcct=/MemberTrade/order_info; Hm_lvt_0600094e16cec594db18b43c878d459f=1372040549,1372059359,1372142174,1372208629; Hm_lpvt_0600094e16cec594db18b43c878d459f=1372212478; old_session_id=ST194554eaWruduepdjizhaWWzu1passportbanggocom01; NSC_58.215.174.172=ffffffff0958113a45525d5f4f58455e445a4a42378b");


            request.AddParameter("returnurl", "");
            request.AddParameter("username", "张梅zm");
            request.AddParameter("password", "zhangmei");
            request.AddParameter("rememberUsername", "on");
            request.AddParameter("lt", "e1s1");
            request.AddParameter("_eventId", "submit");
            request.AddParameter("loginType", "0");
            request.AddParameter("lastIp", "118.122.122.166");


            request.Credentials = System.Net.CredentialCache.DefaultCredentials;
            client.CookieContainer = new System.Net.CookieContainer();

            client.ClientCertificates = new System.Security.Cryptography.X509Certificates.X509CertificateCollection();

            client.ClientCertificates.Add(new System.Security.Cryptography.X509Certificates.X509Certificate(@"C:\Users\Administrator\Desktop\bg.cer"));

            ServicePointManager.ServerCertificateValidationCallback +=
        (sender, certificate, chain, sslPolicyErrors) => true;

            var response = client.Execute(request);
             var cookie = response.Cookies;
            
             
            Console.WriteLine(response.Content);

            request = new RestRequest();
            client = new RestClient(url); 
             

            foreach (var c in cookie)
            {
                request.AddCookie(c.Name, c.Value);
            }
             
            response = client.Execute(request); 

            Console.WriteLine(response.Content);
             
        }

    }
}