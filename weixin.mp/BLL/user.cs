using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using weixin.mp.Response.user;
using System.Threading.Tasks;
using weixin.mp.Request.user;

namespace weixin.mp.BLL
{
    public class user
    {
        private static string infoUrl =
           @"https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}&lang=zh_CN";

        private static string batchgetinfoUrl =
            @"https://api.weixin.qq.com/cgi-bin/user/info/batchget?access_token={0}";

        private static string getUrl =
            @"https://api.weixin.qq.com/cgi-bin/user/get?access_token={0}&next_openid={1}";
         
        private static string _accesstoken = "";

        public user(string accesstoken)
        {
            _accesstoken = accesstoken;
        }

        /// <summary>
        /// 获取用户基本信息（包括UnionID机制）,开发者可通过OpenID来获取用户基本信息,请求方式： GET（HTTPS）
        /// </summary>
        /// <returns></returns>
        public async Task<Response_userinfo> info(string openid)
        {
            var result = new Response_userinfo();
            try
            {
                var response = await HttpHelper.HttpGet(string.Format(infoUrl, _accesstoken, openid));
                if (!string.IsNullOrWhiteSpace(response))
                {
                    result = JsonConvert.DeserializeObject<Response_userinfo>(response);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        /// <summary>
        /// 批量获取用户基本信息。开发者可通过该接口来批量获取用户基本信息。最多支持一次拉取100条。
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<Response_userinfolist> batchgetinfo(Request_userinfolist req)
        {
            var result = new Response_userinfolist();
            try
            {
                var response = await HttpHelper.HttpPost(string.Format(batchgetinfoUrl, _accesstoken),JsonConvert.SerializeObject(req));
                if (!string.IsNullOrWhiteSpace(response))
                {
                    result = JsonConvert.DeserializeObject<Response_userinfolist>(response);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }


        /// <summary>
        /// 获取用户列表,请求方式： GET（HTTPS).公众号可通过本接口来获取帐号的关注者列表，关注者列表由一串OpenID（加密后的微信号，每个用户对每个公众号的OpenID是唯一的）组成。一次拉取调用最多拉取10000个关注者的OpenID，可以通过多次拉取的方式来满足需求。
        /// </summary>
        /// <returns></returns>
        public async Task<Response_getuser> get(string nextopenid="")
        {
            var result = new Response_getuser();
            try
            {
                var response = await HttpHelper.HttpGet(string.Format(getUrl, _accesstoken, nextopenid));
                if (!string.IsNullOrWhiteSpace(response))
                {
                    result = JsonConvert.DeserializeObject<Response_getuser>(response);
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
