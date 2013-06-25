/*
 *名称：MyHttpsTest
 *功能：
 *创建人：吉桂昕
 *创建时间：2013-06-25 03:47:39
 *修改时间：
 *备注：
 */

using System;
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
            var client = new RestClient("https://passport.banggo.com/CASServer/login?service=http%3A%2F%2Fact.banggo.com%2FUser%2Flogin");
            request.AddHeader("Host", "passport.banggo.com");
            request.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
            request.AddHeader("Origin", "https://passport.banggo.com");
            request.AddHeader("User-Agent",
                              "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/27.0.1453.116 Safari/537.36");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Referer",
                              "https://passport.banggo.com/CASServer/login?service=http%3A%2F%2Fact.banggo.com%2FUser%2Flogin");
            request.AddHeader("Accept-Encoding", "gzip,deflate,sdch");
            request.AddHeader("Accept-Language", "zh-CN,zh;q=0.8");

            request.AddParameter("returnurl", "");
            request.AddParameter("username", "%E5%BC%A0%E6%A2%85zm");
            request.AddParameter("password", "zhangmei");
            request.AddParameter("rememberUsername", "on");
            request.AddParameter("lt", "e1s1");
            request.AddParameter("_eventId", "submit");
            request.AddParameter("loginType", "0");
            request.AddParameter("lastIp", "118.122.122.166");

            request.Credentials = System.Net.CredentialCache.DefaultCredentials;
            client.CookieContainer = new System.Net.CookieContainer();
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