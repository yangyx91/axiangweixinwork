using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using weixin.work.Request.user;
using weixin.work.Response;
using weixin.work.Response.user;

namespace weixin.work.BLL
{
    /// <summary>
    /// 企业微信》部门成员
    /// </summary>
    public class user 
    {
        private static string listUrl =
            @"https://qyapi.weixin.qq.com/cgi-bin/user/list?access_token={0}&department_id={1}";

        private static string simplelistUrl =
            @"https://qyapi.weixin.qq.com/cgi-bin/user/simplelist?access_token={0}&department_id={1}";

        private static string getUrl =
            @"https://qyapi.weixin.qq.com/cgi-bin/user/get?access_token={0}&userid={1}";

        private static string updateUrl =
            @"https://qyapi.weixin.qq.com/cgi-bin/user/update?access_token={0}";

        private static string deleteUrl =
           @"https://qyapi.weixin.qq.com/cgi-bin/user/delete?access_token={0}&userid={1}";

        private static string converttoopenidUrl =
            @"https://qyapi.weixin.qq.com/cgi-bin/user/convert_to_openid?access_token={0}";

        private static string converttouseridUrl =
            @"https://qyapi.weixin.qq.com/cgi-bin/user/convert_to_userid?access_token={0}";

        private static string _accesstoken = "";

        public user(string accesstoken)
        {
            _accesstoken = accesstoken;
        } 

        /// <summary>
        /// 获取部门成员列表详情,请求方式： GET（HTTPS）
        /// </summary>
        /// <returns></returns>
        public async Task<Response_userlist> list(string departmentId)
        {
            var result = new Response_userlist();
            try
            {
                var response = await HttpHelper.HttpGet(string.Format(listUrl, _accesstoken, departmentId));
                if (!string.IsNullOrWhiteSpace(response))
                {
                    result = JsonConvert.DeserializeObject<Response_userlist>(response);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        /// <summary>
        /// 获取部门成员：GET（HTTPS）
        /// </summary> 
        /// <returns></returns>
        public async Task<Response_usersimplelist> simplelist(string departmentId)
        {
            var result = new Response_usersimplelist();
            try
            {
                var response = await HttpHelper.HttpGet(string.Format(simplelistUrl, _accesstoken, departmentId));
                if (!string.IsNullOrWhiteSpace(response))
                {
                    result = JsonConvert.DeserializeObject<Response_usersimplelist>(response);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        /// <summary>
        /// 读取成员。在通讯录同步助手中此接口可以读取企业通讯录的所有成员的信息，而自建应用可以读取该应用设置的可见范围内的成员信息。
        /// </summary>
        /// <returns></returns>
        public async Task<Response_getuser> getuser(string userid)
        {
            var result = new Response_getuser(); 
            try
            {
                var response = await HttpHelper.HttpGet(string.Format(getUrl, _accesstoken, userid));
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

        /// <summary>
        /// 更新成员 POST（HTTPS）
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<Response_base> updateuser(Request_updateuser req)
        {
            var result = new Response_base();
            try
            {
                var response = await HttpHelper.HttpPost(string.Format(updateUrl, _accesstoken),JsonConvert.SerializeObject(req));
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


        /// <summary>
        /// 删除成员 GET（HTTPS）
        /// </summary>
        /// <returns></returns>
        public async Task<Response_base> deluser(string userid)
        {
            var result = new Response_base();
            try
            {
                var response = await HttpHelper.HttpGet(string.Format(deleteUrl, _accesstoken, userid));
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


        /// <summary>
        /// userid转openid,Post。该接口使用场景为企业支付，在使用企业红包和向员工付款时，需要自行将企业微信的userid转成openid。
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<Response_convertuseropenid> converttoopenid(Request_convertuseropenid req)
        {
            var result = new Response_convertuseropenid();
            try
            {
                var response = await HttpHelper.HttpPost(string.Format(converttoopenidUrl, _accesstoken), JsonConvert.SerializeObject(req));
                if (!string.IsNullOrWhiteSpace(response))
                {
                    result = JsonConvert.DeserializeObject<Response_convertuseropenid>(response);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        /// <summary>
        /// openid转userid。该接口主要应用于使用企业支付之后的结果查询。
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<Response_convertuserid> converttouserid(Request_convertuserid req)
        {
            var result = new Response_convertuserid();
            try
            {
                var response = await HttpHelper.HttpPost(string.Format(converttouseridUrl, _accesstoken), JsonConvert.SerializeObject(req));
                if (!string.IsNullOrWhiteSpace(response))
                {
                    result = JsonConvert.DeserializeObject<Response_convertuserid>(response);
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
