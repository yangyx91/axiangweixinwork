using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using weixin.work.Response.token;
using Newtonsoft.Json;

namespace weixin.work.BLL
{
    /// <summary>
    /// 企业微信》获取accessToken
    /// </summary>
    public class gettoken
    {
        private static string _corpid = "";

        private static string _corpsecret = "";

        private static string gettokenurl = 
            @"https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid={0}&corpsecret={1}";

        public gettoken(string corpid,string corpsecret)
        {
            _corpid = corpid;
            _corpsecret = corpsecret;
        }

        /// <summary>
        /// 获取access_token,请求方式： GET（HTTPS）
        /// </summary>
        /// <returns></returns>
        public async Task<Response_gettoken> get()
        {
            var result = new Response_gettoken();
            try
            {
                var response =await HttpHelper.HttpGet(string.Format(gettokenurl, _corpid, _corpsecret));
                if (!string.IsNullOrWhiteSpace(response))
                {
                   result = JsonConvert.DeserializeObject<Response_gettoken>(response);
                }
            }
            catch (Exception)
            {

                throw;
            }
            
            return result;
        }


    }


}
