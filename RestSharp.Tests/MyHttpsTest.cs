/*
 *名称：MyHttpsTest
 *功能：
 *创建人：吉桂昕
 *创建时间：2013-06-25 03:47:39
 *修改时间：
 *备注：
 */

using System;
using System.IO;
using System.Net;
using System.Text;
using NUnit.Framework;
using RestSharp.Contrib;

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

            GetLoginPage();

            return;

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

        private void GetLoginPage()
        {

            string url =
                "https://passport.banggo.com/CASServer/login?service=http%3A%2F%2Fact.banggo.com%2FUser%2Flogin.shtml%3Freturn_url%3Dhttp%3A%2F%2Fmember.banggo.com%2FMember%2Findex.shtml";

            var request = new RestRequest(Method.GET);
            var client = new RestClient(url);
            request.AddHeader("Host", "passport.banggo.com");
            request.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
            request.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.31 (KHTML, like Gecko) Chrome/26.0.1410.64 Safari/537.31");
            request.AddHeader("Referer", "http://www.banggo.com/");
            request.AddHeader("Accept-Encoding", "gzip,deflate,sdch");
            request.AddHeader("Accept-Language", "zh-CN,zh;q=0.8"); 
            request.AddHeader("Accept-Charset", "GBK,utf-8;q=0.7,*;q=0.3");
            client.CookieContainer = new CookieContainer();

//            client.ClientCertificates = new System.Security.Cryptography.X509Certificates.X509CertificateCollection();
//
//            client.ClientCertificates.Add(new System.Security.Cryptography.X509Certificates.X509Certificate(@"C:\Users\Administrator\Desktop\bg.cer"));
//
//            ServicePointManager.ServerCertificateValidationCallback +=
//        (sender, certificate, chain, sslPolicyErrors) => true;

            var response = client.Execute(request); 

            //才该的不实例货RestClient
            //client =
            //    new RestClient("https://passport.banggo.com/CASServer/login?service=http%3A%2F%2Fact.banggo.com%2FUser%2Flogin%3Freturn_url%3Dhttp%3A%2F%2Fmember.banggo.com%2FMember%2Findex.shtml");

            client.BaseUrl =
                "https://passport.banggo.com/CASServer/login?service=http%3A%2F%2Fact.banggo.com%2FUser%2Flogin%3Freturn_url%3Dhttp%3A%2F%2Fmember.banggo.com%2FMember%2Findex.shtml";
             
            request = new RestRequest(Method.POST);
            request.AddHeader("Host", "passport.banggo.com");
             request.AddHeader("Cache-Control", "max-age=0");
            request.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
            request.AddHeader("Origin", "https://passport.banggo.com");
            request.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.31 (KHTML, like Gecko) Chrome/26.0.1410.64 Safari/537.31"); 
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded"); 
            request.AddHeader("Referer", "https://passport.banggo.com/CASServer/login?service=http%3A%2F%2Fact.banggo.com%2FUser%2Flogin%3Freturn_url%3Dhttp%3A%2F%2Fmember.banggo.com%2FMember%2Findex.shtml");
            request.AddHeader("Accept-Encoding", "gzip,deflate,sdch");
            request.AddHeader("Accept-Language", "zh-CN,zh;q=0.8");
            request.AddHeader("Accept-Charset", "GBK,utf-8;q=0.7,*;q=0.3");
            
            //client.CookieContainer = new CookieContainer();



//           client.CookieContainer
//            client.ClientCertificates = new System.Security.Cryptography.X509Certificates.X509CertificateCollection();
//
//            client.ClientCertificates.Add(new System.Security.Cryptography.X509Certificates.X509Certificate(@"C:\Users\Administrator\Desktop\bg.cer"));
//
//            ServicePointManager.ServerCertificateValidationCallback +=
//        (sender, certificate, chain, sslPolicyErrors) => true;

            var cookies1 = response.Cookies;

            foreach (var restResponseCookie in response.Cookies)
            {
                request.AddCookie(restResponseCookie.Name, restResponseCookie.Value);
            }

            request.AddParameter("returnurl", "");
            request.AddParameter("username", "张梅zm");
            request.AddParameter("password", "zhangmei");
            request.AddParameter("rememberUsername", "on");
            request.AddParameter("lt", "e1s1");
            request.AddParameter("_eventId", "submit");
            request.AddParameter("loginType", "0");
            request.AddParameter("lastIp", "171.221.114.139");
             
            response = client.Execute(request);

            //Console.WriteLine(response.Content);

            //client =
            //    new RestClient(string.Format("http://act.banggo.com/Ajax/sing_in/?callback=jsonp{0}",DateTime.Now.Ticks));

            client.BaseUrl = string.Format("http://act.banggo.com/Ajax/sing_in/?callback=jsonp{0}", DateTime.Now.Ticks);
             
            request = new RestRequest(Method.GET);
            request.AddHeader("Host", "act.banggo.com");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.31 (KHTML, like Gecko) Chrome/26.0.1410.64 Safari/537.31");
            request.AddHeader("Referer", "http://member.banggo.com/Member/index.shtml");
            request.AddHeader("Accept-Encoding", "gzip,deflate,sdch");
            request.AddHeader("Accept-Language", "zh-CN,zh;q=0.8");
            request.AddHeader("Accept-Charset", "GBK,utf-8;q=0.7,*;q=0.3");

            //client.CookieContainer = new CookieContainer();

            foreach (var restResponseCookie in response.Cookies)
            {
                request.AddCookie(restResponseCookie.Name, restResponseCookie.Value);
            }

            foreach (var restResponseCookie in cookies1)
            {
                request.AddCookie(restResponseCookie.Name, restResponseCookie.Value); 
            }

            //todo：能登录，便获取不到Cookie
           // request.AddCookie("bg_user_id", "%22%5Cu5f20%5Cu6885zm%22");

            response = client.Execute(request);
              
            Console.WriteLine(response.Content);
             
             
        }


        public static string Login(String url, String paramList, string MyEncode, ref string myCookieContainer, string refer)
        {
            HttpWebResponse res = null;
            string strResult = string.Empty; ;
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";
                req.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.2; Trident/4.0; .NET CLR 1.1.4322; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET4.0C; .NET4.0E; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
                if (!string.IsNullOrEmpty(refer))
                {
                    req.Referer = refer;
                }
                req.AllowAutoRedirect = false;
                CookieContainer cookieCon = new CookieContainer();
                req.CookieContainer = cookieCon;
                StringBuilder UrlEncoded = new StringBuilder();
                Char[] reserved = { '?', '=', '&' };
                byte[] SomeBytes = null;
                if (paramList != null)
                {
                    int i = 0, j;
                    while (i < paramList.Length)
                    {
                        j = paramList.IndexOfAny(reserved, i);
                        if (j == -1)
                        {
                            UrlEncoded.Append(HttpUtility.UrlEncode(paramList.Substring(i, paramList.Length - i)));
                            break;
                        }
                        UrlEncoded.Append(HttpUtility.UrlEncode(paramList.Substring(i, j - i)));
                        UrlEncoded.Append(paramList.Substring(j, 1));
                        i = j + 1;
                    }
                    SomeBytes = Encoding.UTF8.GetBytes(UrlEncoded.ToString());
                    req.ContentLength = SomeBytes.Length;
                    Stream newStream = req.GetRequestStream();
                    newStream.Write(SomeBytes, 0, SomeBytes.Length);
                    newStream.Close();
                }
                else
                {
                    req.ContentLength = 0;
                }

                res = (HttpWebResponse)req.GetResponse();

                //MessageBox.Show(((int)res.StatusCode)+"");

                myCookieContainer = req.CookieContainer.GetCookieHeader(new Uri(url));
                if (res.StatusCode == HttpStatusCode.Redirect)
                {
                    //MessageBox.Show(res.Headers["Location"]);
                    string cookies = res.Headers["Set-Cookie"].Replace(",", "%2c");
                    cookies = cookies.Replace("httponly%2c", "");
                    //MessageBox.Show(cookies);
                    return SendDataByGet(res.Headers["Location"], "", "utf-8", cookies, refer);
                }

                Stream ReceiveStream = res.GetResponseStream();
                Encoding encode = System.Text.Encoding.GetEncoding(MyEncode);
                StreamReader sr = new StreamReader(ReceiveStream, encode);
                Char[] read = new Char[256];
                int count = sr.Read(read, 0, 256);
                while (count > 0)
                {
                    String str = new String(read, 0, count);
                    strResult += str;
                    count = sr.Read(read, 0, 256);
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
                throw new Exception("Web.Login：/r/n" + e.ToString());
            }
            finally
            {
                if (res != null)
                {
                    res.Close();
                }
            }
            return strResult;
        }



        public static string SendDataByGet(string url, string data, string encode, string cookies, string refer)
        {
            string retString = string.Empty;
            HttpWebResponse response = null;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + (data == "" ? "" : "?") + data);
                string host = string.Empty;
                Uri uri = new Uri(url);
                host = uri.Scheme + "://" + uri.Authority + "/";
                CookieContainer cc = new CookieContainer();
                string[] SegCookie = new string[] { };
                SegCookie = cookies.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < SegCookie.Length; i++)
                {
                    string[] tmp = new string[] { };
                    tmp = SegCookie[i].Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                    if (tmp.Length == 2)
                    {
                        Cookie c = new Cookie();
                        c.Name = tmp[0].Trim();
                        c.Value = tmp[1];
                        cc.Add(new Uri(host), c);
                    }
                }
                request.CookieContainer = cc;

                request.Method = "GET";
                request.ContentType = "text/html;charset=" + encode;
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.2; Trident/4.0; .NET CLR 1.1.4322; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET4.0C; .NET4.0E; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
                if (!string.IsNullOrEmpty(refer))
                {
                    request.Referer = refer;
                }
                else
                {
                    request.Referer = url;
                }
                response = (HttpWebResponse)request.GetResponse();

                string abc = string.Empty;
                for (int i = 0; i < response.Headers.Count; i++)
                {
                    abc += response.Headers.Keys[i].ToString() + "=====>" + response.Headers[response.Headers.Keys[i].ToString()] + "/r/n";
                }
                //MessageBox.Show(abc);

                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding(encode));
                retString = myStreamReader.ReadToEnd();

                myStreamReader.Close();
                myResponseStream.Close();
                request.Abort();
                response.Close();
                return retString;
            }
            catch (Exception ex) { throw new Exception("Web.SendDataByGet：/r/n" + ex.ToString()); }
            finally
            {
                if (response != null)
                    response.Close();
            }

        }
    }
}