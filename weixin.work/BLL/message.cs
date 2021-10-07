using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using weixin.work.Request.message;
using weixin.work.Response.message;

namespace weixin.work.BLL
{
    /// <summary>
    /// 企业微信》自建应用》主动发送应用消息：企业后台调用接口通过应用向指定成员发送单聊消息
    /// </summary>
    public class message
    {
        /// <summary>
        /// 获取指定的应用详情 URL
        /// </summary>
        private static string sendurl =
            @"https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token={0}";

        private static string _accesstoken = "";

        public message(string accesstoken)
        {
            _accesstoken = accesstoken;
        }

        /// <summary>
        /// 发送文本消息：（应用支持推送文本、图片、视频、文件、图文等类型）
        /// </summary>
        /// <returns></returns>
        public async Task<Response_sendmsg> sendmsgtext(Request_sendmsgtext req)
        {
            var result = new Response_sendmsg();
            try
            {
                var response = await HttpHelper.HttpPost(string.Format(sendurl, _accesstoken),JsonConvert.SerializeObject(req));
                if (!string.IsNullOrWhiteSpace(response))
                {
                    result = JsonConvert.DeserializeObject<Response_sendmsg>(response);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        /// <summary>
        ///  发送图片消息：（应用支持推送文本、图片、视频、文件、图文等类型）
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<Response_sendmsg> sendmsgimage(Request_sendmsgimage req)
        {
            var result = new Response_sendmsg(); 
            try
            {
                var response = await HttpHelper.HttpPost(string.Format(sendurl, _accesstoken), JsonConvert.SerializeObject(req));
                if (!string.IsNullOrWhiteSpace(response))
                {
                    result = JsonConvert.DeserializeObject<Response_sendmsg>(response);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        /// <summary>
        ///  发送语音消息：（应用支持推送文本、图片、视频、文件、图文等类型）
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<Response_sendmsg> sendmsgvoice(Request_sendmsgvoice req)
        {
            var result = new Response_sendmsg(); 
            try
            {
                var response = await HttpHelper.HttpPost(string.Format(sendurl, _accesstoken), JsonConvert.SerializeObject(req));
                if (!string.IsNullOrWhiteSpace(response))
                {
                    result = JsonConvert.DeserializeObject<Response_sendmsg>(response);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        /// <summary>
        ///  发送视频消息：（应用支持推送文本、图片、视频、文件、图文等类型）
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<Response_sendmsg> sendmsgvideo(Request_sendmsgvideo req)
        {
            var result = new Response_sendmsg();
            try
            {
                var response = await HttpHelper.HttpPost(string.Format(sendurl, _accesstoken), JsonConvert.SerializeObject(req));
                if (!string.IsNullOrWhiteSpace(response))
                {
                    result = JsonConvert.DeserializeObject<Response_sendmsg>(response);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        /// <summary>
        ///  发送文件消息：（应用支持推送文本、图片、视频、文件、图文等类型）
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<Response_sendmsg> sendmsgfile(Request_sendmsgfile req)
        {
            var result = new Response_sendmsg();
            try
            {
                var response = await HttpHelper.HttpPost(string.Format(sendurl, _accesstoken), JsonConvert.SerializeObject(req));
                if (!string.IsNullOrWhiteSpace(response))
                {
                    result = JsonConvert.DeserializeObject<Response_sendmsg>(response);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        /// <summary>
        ///  发送文本卡片消息：（应用支持推送文本、图片、视频、文件、图文等类型）
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<Response_sendmsg> sendmsgtextcard(Request_sendmsgtextcard req)
        {
            var result = new Response_sendmsg();
            try
            {
                var response = await HttpHelper.HttpPost(string.Format(sendurl, _accesstoken), JsonConvert.SerializeObject(req));
                if (!string.IsNullOrWhiteSpace(response))
                {
                    result = JsonConvert.DeserializeObject<Response_sendmsg>(response);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        /// <summary>
        ///  发送普通图文消息：（应用支持推送文本、图片、视频、文件、图文等类型）
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<Response_sendmsg> sendmsgnews(Request_sendmsgnews req)
        {
            var result = new Response_sendmsg();
            try
            {
                var response = await HttpHelper.HttpPost(string.Format(sendurl, _accesstoken), JsonConvert.SerializeObject(req));
                if (!string.IsNullOrWhiteSpace(response))
                {
                    result = JsonConvert.DeserializeObject<Response_sendmsg>(response);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        /// <summary>
        ///  发送（mpnews）图文消息：（应用支持推送文本、图片、视频、文件、图文等类型）.
        ///  mpnews类型的图文消息，跟普通的图文消息一致，唯一的差异是图文内容存储在企业微信。
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<Response_sendmsg> sendmsgmpnews(Request_sendmsgmpnews req)
        {
            var result = new Response_sendmsg();
            try
            {
                var response = await HttpHelper.HttpPost(string.Format(sendurl, _accesstoken), JsonConvert.SerializeObject(req));
                if (!string.IsNullOrWhiteSpace(response))
                {
                    result = JsonConvert.DeserializeObject<Response_sendmsg>(response);
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
