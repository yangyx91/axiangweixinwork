using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using weixin.work.Request.webhook;
using weixin.work.Response;

namespace weixin.work.BLL
{
    /// <summary>
    /// 使用群机器人
    /// 当前自定义机器人支持文本（text）、markdown（markdown）、图片（image）、图文（news）四种消息类型。
    /// </summary>
    public class webhook
    {
        private static string sendurl =
            @"https://qyapi.weixin.qq.com/cgi-bin/webhook/send?key={0}";

        private static string uploadurl =
            @"https://qyapi.weixin.qq.com/cgi-bin/webhook/upload_media?key={0}&type=file";

        private static string _key = "";

        public webhook(string key)
        {
            _key = key;
        }


        #region 发送消息类型

        /// <summary>
        /// 发送文本消息
        /// </summary>
        /// <returns></returns>
        public async Task<Response_base> sendmsgtext(Request_msgtext req)
        {
            var result = new Response_base();
            try
            {
                var response = await HttpHelper.HttpPost(string.Format(sendurl, _key), JsonConvert.SerializeObject(req));
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
        /// 发送Markdown消息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<Response_base> sendmsgmarkdown(Request_msgmarkdown req)
        {
            var result = new Response_base();
            try
            {
                var response = await HttpHelper.HttpPost(string.Format(sendurl, _key), JsonConvert.SerializeObject(req));
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
        public async Task<Response_base> sendmsgimage(Request_msgimage req)
        {
            var result = new Response_base();
            try
            {
                var response = await HttpHelper.HttpPost(string.Format(sendurl, _key), JsonConvert.SerializeObject(req));
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
        /// 发送图文消息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<Response_base> sendmsgnews(Request_msgnews req)
        {
            var result = new Response_base();
            try
            {
                var response = await HttpHelper.HttpPost(string.Format(sendurl, _key), JsonConvert.SerializeObject(req));
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
        /// 发送文件消息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<Response_base> sendmsgfile(Request_msgfile req)
        {
            var result = new Response_base();
            try
            {
                var response = await HttpHelper.HttpPost(string.Format(sendurl, _key), JsonConvert.SerializeObject(req));
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

        #region  文件上传



        #endregion
    }
}
