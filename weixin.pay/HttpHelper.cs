using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace weixin.pay
{
    public static class HttpHelper
    {
        public static async Task<string> HttpGet(string url)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return "";
        }

        public static async Task<string> HttpPost(string url, string postData)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            using (HttpContent httpContent = new StringContent(postData, Encoding.UTF8))
            {
                var response = await client.PostAsync(url, httpContent);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
            }
            return "";
        }

        public static async Task<string> HttpsPost(string url, string postData)
        {
            var path = Path.Combine(AppContext.BaseDirectory, "cert\\apiclient_cert.p12");
            var cert = new X509Certificate2(path, WxPayConfig.WxPay_Mch_ID);
            //判断证书是否过期
            if (cert.NotAfter > DateTime.Now)
            {
                var handler = new HttpClientHandler
                {
                    ClientCertificateOptions = ClientCertificateOption.Manual,
                    SslProtocols = SslProtocols.Tls12,
                    ServerCertificateCustomValidationCallback = (x, y, z, m) => true,
                };

                handler.ClientCertificates.Add(cert);

                var client = new HttpClient(handler);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                   new MediaTypeWithQualityHeaderValue("application/json"));

                using (HttpContent httpContent = new StringContent(postData, Encoding.UTF8))
                {
                    var response = await client.PostAsync(url, httpContent);
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                }
                return "";
            }
            return await HttpPost(url,postData);
        }

        /// <summary>
        /// 根据时间戳timestamp（单位毫秒）计算日期
        /// </summary>
        public static DateTime NewUtcDate(long timestamp)
        {
            DateTime dt1970 = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            return dt1970.AddSeconds(timestamp);
        }

        /// <summary>
        /// 根据时间戳timestamp（单位毫秒）计算中国区日期
        /// </summary>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        public static DateTime NewChinaDate(long timestamp)
        {
            DateTime dt1970 = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            TimeZoneInfo chinaZone = TimeZoneInfo.FindSystemTimeZoneById("China Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(dt1970.AddSeconds(timestamp), chinaZone);
        }



        /// <summary>
        /// 根据日期计算时间戳timestamp（单位毫秒）
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static long NewDateTimeStamp(DateTime dateTime)
        {
            return (dateTime.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
        }
    }
}
