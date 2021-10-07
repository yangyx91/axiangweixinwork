using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using weixin.mp.Response.token;

namespace weixin.mp.BLL
{
    public class gettoken
    {
        private static string _appid = "";

        private static string _appsecret = "";

        private static string gettokenurl =
            @"https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}";

        /// <summary>
        /// 公众号和小程序均可以使用AppID和AppSecret调用本接口来获取access_token
        /// </summary>
        /// <param name="appid">第三方用户唯一凭证</param>
        /// <param name="appsecret">第三方用户唯一凭证密钥，即appsecret</param>
        public gettoken(string appid, string appsecret)
        {
            _appid = appid;
            _appsecret = appsecret;
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
                var response = await HttpHelper.HttpGet(string.Format(gettokenurl, _appid, _appsecret));
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
