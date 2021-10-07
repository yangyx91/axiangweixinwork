using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using weixin.work.Request.externaluser;
using weixin.work.Response;
using weixin.work.Response.externaluser;

namespace weixin.work.BLL
{
    /// <summary>
    /// 企业微信》客户/外部联系人
    /// </summary>
    public class externalcontact
    {
        private static string listUrl =
           @"https://qyapi.weixin.qq.com/cgi-bin/externalcontact/list?access_token={0}&userid={1}";

        private static string getUrl =
           @"https://qyapi.weixin.qq.com/cgi-bin/externalcontact/get?access_token={0}&external_userid={1}";

        private static string getbyusersUrl =
            @"https://qyapi.weixin.qq.com/cgi-bin/externalcontact/batch/get_by_user?access_token={0}";

        private static string getfollowuserlistUrl =
            @"https://qyapi.weixin.qq.com/cgi-bin/externalcontact/get_follow_user_list?access_token={0}";

        private static string addcontactwayUrl =
            @"https://qyapi.weixin.qq.com/cgi-bin/externalcontact/add_contact_way?access_token={0}";

        private static string getcontactwayUrl =
            @"https://qyapi.weixin.qq.com/cgi-bin/externalcontact/get_contact_way?access_token={0}";

        private static string updatecontactwayUrl =
            @"https://qyapi.weixin.qq.com/cgi-bin/externalcontact/update_contact_way?access_token={0}";

        private static string delcontactwayUrl =
            @"https://qyapi.weixin.qq.com/cgi-bin/externalcontact/del_contact_way?access_token={0}";

        private static string listcontactwayUrl =
            @"https://qyapi.weixin.qq.com/cgi-bin/externalcontact/list_contact_way?access_token={0}";

        private static string remarkUrl =
            @"https://qyapi.weixin.qq.com/cgi-bin/externalcontact/remark?access_token={0}";

        private static string converttoopenidUrl =
            @"https://qyapi.weixin.qq.com/cgi-bin/externalcontact/convert_to_openid?access_token={0}";

        private static string _accessToken = "";

        public externalcontact(string accessToken)
        {
            _accessToken = accessToken;
        }

        /// <summary>
        /// 获取客户列表,请求方式： GET（HTTPS）
        /// 企业可通过此接口获取指定成员添加的客户列表。客户是指配置了客户联系功能的成员所添加的外部联系人。没有配置客户联系功能的成员，所添加的外部联系人将不会作为客户返回。
        /// </summary>
        /// <returns></returns>
        public async Task<Response_externaluserid> list(string userId)
        {
            var result = new Response_externaluserid();
            try
            {
                var response = await HttpHelper.HttpGet(string.Format(listUrl, _accessToken, userId));
                if (!string.IsNullOrWhiteSpace(response))
                {
                    result = JsonConvert.DeserializeObject<Response_externaluserid>(response);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        /// <summary>
        /// 获取客户详情。企业可通过此接口，根据外部联系人的userid，拉取客户详情。
        /// </summary>
        /// <returns></returns>
        public async Task<Response_externaluser> get(string external_userid)
        {
            var result = new Response_externaluser();
            try
            {
                var response = await HttpHelper.HttpGet(string.Format(getUrl, _accessToken, external_userid));
                if (!string.IsNullOrWhiteSpace(response))
                {
                    result = JsonConvert.DeserializeObject<Response_externaluser>(response);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        /// <summary>
        /// 批量获取客户详情。企业/第三方可通过此接口获取指定成员添加的客户信息列表。
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<Response_externaluserlist> getbyusers(Request_getbyuser req)
        {
            var result = new Response_externaluserlist();
            try
            {
                var response = await HttpHelper.HttpPost(string.Format(getbyusersUrl, _accessToken), JsonConvert.SerializeObject(req));
                if (!string.IsNullOrWhiteSpace(response))
                {
                    result = JsonConvert.DeserializeObject<Response_externaluserlist>(response);
                } 
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }


        /// <summary>
        /// 获取配置了客户联系功能的成员列表。企业和第三方服务商可通过此接口获取配置了客户联系功能的成员列表。
        /// </summary>
        /// <returns></returns>
        public async Task<Response_followuserid> getfollowuserlist()
        {
            var result = new Response_followuserid();
            try
            {
                var response = await HttpHelper.HttpGet(string.Format(getfollowuserlistUrl, _accessToken));
                if (!string.IsNullOrWhiteSpace(response))
                {
                    result = JsonConvert.DeserializeObject<Response_followuserid>(response);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return result; 
        }

        /// <summary>
        /// 修改客户备注信息。企业可通过此接口修改指定用户添加的客户的备注信息。
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<Response_base> remark(Request_remarkexternaluser req) 
        {
            var result = new Response_base();
            try
            {
                var response = await HttpHelper.HttpPost(string.Format(remarkUrl, _accessToken), JsonConvert.SerializeObject(req));
                if (!string.IsNullOrWhiteSpace(response))
                {
                    result = JsonConvert.DeserializeObject<Response_base>(response);
                }
            }
            catch (Exception ex)
            {

                throw ex;
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
                var response = await HttpHelper.HttpPost(string.Format(converttoopenidUrl, _accessToken), JsonConvert.SerializeObject(req));
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
        /// 配置客户联系「联系我」方式。
        /// 企业可通过此接口为具有客户联系功能的成员生成专属的「联系我」二维码或者「联系我」按钮。
        /// 注意:
        /// 通过API添加的「联系我」不会在管理端进行展示，每个企业可通过API最多配置50万个「联系我」。
        /// 用户需要妥善存储返回的config_id，config_id丢失可能导致用户无法编辑或删除「联系我」。
        /// 临时会话模式不占用「联系我」数量，但每日最多添加10万个，并且仅支持单人。
        /// 临时会话模式的二维码，添加好友完成后该二维码即刻失效。
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<Response_addcontactway> addcontactway(Request_addcontactway req)
        {
            var result = new Response_addcontactway();
            try
            {
                var response = await HttpHelper.HttpPost(string.Format(addcontactwayUrl, _accessToken), JsonConvert.SerializeObject(req));
                if (!string.IsNullOrWhiteSpace(response))
                {
                    result = JsonConvert.DeserializeObject<Response_addcontactway>(response);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        /// <summary>
        /// 获取企业已配置的「联系我」方式。获取企业配置的「联系我」二维码和「联系我」小程序按钮。
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<Response_getcontactway> getcontactway(Request_getcontactway req)
        {
            var result = new Response_getcontactway();
            try
            {
                var response = await HttpHelper.HttpPost(string.Format(getcontactwayUrl, _accessToken), JsonConvert.SerializeObject(req));
                if (!string.IsNullOrWhiteSpace(response))
                {
                    result = JsonConvert.DeserializeObject<Response_getcontactway>(response);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        /// <summary>
        /// 更新企业已配置的「联系我」方式。更新企业配置的「联系我」二维码和「联系我」小程序按钮中的信息，如使用人员和备注等。
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<Response_base> updatecontactway(Request_updatecontactway req)
        {
            var result = new Response_base();
            try
            {
                var response = await HttpHelper.HttpPost(string.Format(updatecontactwayUrl, _accessToken), JsonConvert.SerializeObject(req));
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
        /// 删除企业已配置的「联系我」方式。删除一个已配置的「联系我」二维码或者「联系我」小程序按钮。
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<Response_base> delcontactway(Request_getcontactway req)
        {
            var result = new Response_base();
            try
            {
                var response = await HttpHelper.HttpPost(string.Format(delcontactwayUrl, _accessToken), JsonConvert.SerializeObject(req));
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
        /// 获取企业已配置的「联系我」列表。获取企业配置的「联系我」二维码和「联系我」小程序插件列表。不包含临时会话。注意，该接口仅可获取2021年7月10日以后创建的「联系我」
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<Response_listcontactway> listcontactway(Request_listcontactway req)
        {
            var result = new Response_listcontactway();
            try
            {
                var response = await HttpHelper.HttpPost(string.Format(listcontactwayUrl, _accessToken), JsonConvert.SerializeObject(req));
                if (!string.IsNullOrWhiteSpace(response))
                {
                    result = JsonConvert.DeserializeObject<Response_listcontactway>(response);
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
