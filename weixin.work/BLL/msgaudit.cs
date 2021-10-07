using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using weixin.work.Request.msgaudit;
using weixin.work.Response.msgaudit;

namespace weixin.work.BLL
{
    public class msgaudit
    {
        private static string getpermituserlistUrl =
           @"https://qyapi.weixin.qq.com/cgi-bin/msgaudit/get_permit_user_list?access_token={0}";

        private static string groupchatUrl =
            @"https://qyapi.weixin.qq.com/cgi-bin/msgaudit/groupchat/get?access_token={0}";

        private static string _accessToken = "";

        public msgaudit(string accessToken)
        {
            _accessToken = accessToken;
        }

        /// <summary>
        /// 获取会话内容存档开启成员列表,请求方式： GET（HTTPS）
        /// 企业可通过此接口，获取企业开启会话内容存档的成员列表
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<Response_getpermituserlist> getpermituserlist(Request_getpermituserlist req)
        {
            var result = new Response_getpermituserlist();
            try
            {
                var response = await HttpHelper.HttpPost(string.Format(getpermituserlistUrl, _accessToken),JsonConvert.SerializeObject(req));
                if (!string.IsNullOrWhiteSpace(response))
                {
                    result = JsonConvert.DeserializeObject<Response_getpermituserlist>(response);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        /// <summary>
        /// 获取会话内容存档内部群信息。企业可通过此接口，获取会话内容存档本企业的内部群信息，包括群名称、群主id、公告、群创建时间以及所有群成员的id与加入时间。
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<Response_getgroupchat> getgroupchat(Request_getgroupchat req)
        {
            var result = new Response_getgroupchat();
            try
            {
                var response = await HttpHelper.HttpPost(string.Format(groupchatUrl, _accessToken), JsonConvert.SerializeObject(req));
                if (!string.IsNullOrWhiteSpace(response))
                {
                    result = JsonConvert.DeserializeObject<Response_getgroupchat>(response);
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
