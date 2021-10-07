using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using weixin.work.Request.agent;
using weixin.work.Response;
using weixin.work.Response.agent;

namespace weixin.work.BLL
{
    /// <summary>
    /// 获取企业微信》自建应用
    /// </summary>
    public class agent
    {
        /// <summary>
        /// 获取指定的应用详情 URL
        /// </summary>
        private static string geturl =
            @"https://qyapi.weixin.qq.com/cgi-bin/agent/get?access_token={0}&agentid={1}";

        private static string listurl =
           @"https://qyapi.weixin.qq.com/cgi-bin/agent/list?access_token={0}";

        private static string seturl =
            @"https://qyapi.weixin.qq.com/cgi-bin/agent/set?access_token={0}";

        private static string _accesstoken = "";

        public agent(string accesstoken)
        {
            _accesstoken = accesstoken;
        }

        /// <summary>
        /// 获取指定的应用详情,请求方式： GET（HTTPS）.
        /// 企业仅可获取当前凭证对应的应用；第三方仅可获取被授权的应用。
        /// </summary>
        /// <returns></returns>
        public async Task<Response_agent> get(string agentid= "1000002")
        {
            var result = new Response_agent();
            try
            {
                var response = await HttpHelper.HttpGet(string.Format(geturl, _accesstoken, agentid));
                if (!string.IsNullOrWhiteSpace(response))
                {
                    result = JsonConvert.DeserializeObject<Response_agent>(response);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        /// <summary>
        /// 获取access_token对应的应用列表：GET（HTTPS，企业仅可获取当前凭证对应的应用；第三方仅可获取被授权的应用。
        /// </summary>
        /// <returns></returns>
        public async Task<Response_agentlist> list()
        {
            var result = new Response_agentlist();
            try
            {
                var response = await HttpHelper.HttpGet(string.Format(listurl, _accesstoken));
                if (!string.IsNullOrWhiteSpace(response))
                {
                    result = JsonConvert.DeserializeObject<Response_agentlist>(response);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        /// <summary>
        /// 设置应用. 请求方式：POST（HTTPS）
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<Response_base> set(Request_agent req)
        {
            var result = new Response_base();
            try
            {
                var response = await HttpHelper.HttpPost(string.Format(seturl, _accesstoken),JsonConvert.SerializeObject(req));
                if (!string.IsNullOrWhiteSpace(response))
                {
                    result = JsonConvert.DeserializeObject<Response_base>(response);
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
