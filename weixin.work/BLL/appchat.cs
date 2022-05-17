using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using weixin.work.Request.appchat;
using weixin.work.Response.appchat;
using weixin.work.Response;

namespace weixin.work.BLL
{
    /// <summary>
    /// 发送消息到群聊会话
    /// 企业微信支持企业自建应用通过接口创建群聊并发送消息到群，让重要的消息可更及时推送给群成员，方便协同处理。应用消息仅限于发送到通过接口创建的内部群聊，不支持添加企业外部联系人进群。
    /// </summary>
    public class appchat
    {
        private static string sendurl =
            @"https://qyapi.weixin.qq.com/cgi-bin/appchat/send?access_token={0}";

        private static string createurl = 
            @"https://qyapi.weixin.qq.com/cgi-bin/appchat/create?access_token={0}";

        private static string updateurl =
            @"https://qyapi.weixin.qq.com/cgi-bin/appchat/update?access_token={0}";

        private static string geturl =
            @" https://qyapi.weixin.qq.com/cgi-bin/appchat/get?access_token={0}&chatid={1}";

        private static string _accesstoken = "";

        public appchat(string accesstoken)
        {
            _accesstoken = accesstoken;
        }

        #region  群聊会话

        /// <summary>
        /// 创建群聊会话
        /// 限制说明：只允许企业自建应用调用，且应用的可见范围必须是根部门；群成员人数不可超过管理端配置的“群成员人数上限”
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<Response_groupchatcreate> groupchatcreate(Request_groupchatcreate req)
        {
            var result = new Response_groupchatcreate();
            try
            {
                var response = await HttpHelper.HttpPost(string.Format(createurl, _accesstoken), JsonConvert.SerializeObject(req));
                if (!string.IsNullOrWhiteSpace(response))
                {
                    result = JsonConvert.DeserializeObject<Response_groupchatcreate>(response);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        /// <summary>
        /// 修改群聊会话
        /// 只允许企业自建应用调用，且应用的可见范围必须是根部门；
        /// chatid所代表的群必须是该应用所创建；
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<Response_base> groupchatupdate(Request_groupchatupdate req)
        {
            var result = new Response_base();
            try
            {
                var response = await HttpHelper.HttpPost(string.Format(updateurl, _accesstoken), JsonConvert.SerializeObject(req));
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
        /// 获取群聊会话
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<Response_groupchatget> groupchatget(Request_groupchatget req)
        { 
            var result = new Response_groupchatget();
            try
            {
                var response = await HttpHelper.HttpGet(string.Format(geturl, _accesstoken,req.chatid));
                if (!string.IsNullOrWhiteSpace(response))
                {
                    result = JsonConvert.DeserializeObject<Response_groupchatget>(response);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        #endregion

        #region 应用推送消息：文本、图片、视频、文件、图文等类型。

        /// <summary>
        /// 发送文本消息
        /// </summary>
        /// <returns></returns>
        public async Task<Response_base> sendmsgtext(Request_groupchatmsgtext req)
        {
            var result = new Response_base();
            try
            {
                var response = await HttpHelper.HttpPost(string.Format(sendurl, _accesstoken), JsonConvert.SerializeObject(req));
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
        /// 发送图片消息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<Response_base> sendmsgimage(Request_groupchatmsgimage req)
        {
            var result = new Response_base();
            try
            {
                var response = await HttpHelper.HttpPost(string.Format(sendurl, _accesstoken), JsonConvert.SerializeObject(req));
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
        /// 语音消息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<Response_base> sendmsgvoice(Request_groupchatmsgvoice req)
        {
            var result = new Response_base();
            try
            { 
                var response = await HttpHelper.HttpPost(string.Format(sendurl, _accesstoken), JsonConvert.SerializeObject(req));
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
        /// 视频消息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<Response_base> sendmsgvideo(Request_groupchatmsgvideo req)
        {
            var result = new Response_base(); 
            try
            {
                var response = await HttpHelper.HttpPost(string.Format(sendurl, _accesstoken), JsonConvert.SerializeObject(req));
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
        /// 文件消息
        /// </summary> 
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<Response_base> sendmsgfile(Request_groupchatmsgfile req)
        {
            var result = new Response_base();
            try
            {
                var response = await HttpHelper.HttpPost(string.Format(sendurl, _accesstoken), JsonConvert.SerializeObject(req));
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
        /// 文本卡片消息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<Response_base> sendmsgtextcard(
            Request_groupchatmsgtextcard req)
        {
            var result = new Response_base();
            try
            {
                var response = await HttpHelper.HttpPost(string.Format(sendurl, _accesstoken), JsonConvert.SerializeObject(req));
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
        /// 图文消息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<Response_base> sendmsgnews(Request_groupchatmsgnews req)
        {
            var result = new Response_base();
            try
            {
                var response = await HttpHelper.HttpPost(string.Format(sendurl, _accesstoken), JsonConvert.SerializeObject(req));
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
        /// markdown消息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<Response_base> sendmsgmarkdown(
            Request_groupchatmsgmarkdown req)
        {
            var result = new Response_base();
            try
            {
                var response = await HttpHelper.HttpPost(string.Format(sendurl, _accesstoken), JsonConvert.SerializeObject(req));
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

        #endregion
    }
}
