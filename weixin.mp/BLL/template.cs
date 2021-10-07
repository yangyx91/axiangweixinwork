using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using weixin.mp.Response;
using weixin.mp.Response.template;
using weixin.mp.Request.template;

namespace weixin.mp.BLL
{
    public class template
    {
        private static string gettemplateUrl =
           @"https://api.weixin.qq.com/cgi-bin/template/get_all_private_template?access_token={0}";

        private static string deltemplateUrl =
           @"https://api.weixin.qq.com/cgi-bin/template/del_private_template?access_token={0}";

        private static string templatesendmessageUrl =
           @"https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}";

        private static string _accesstoken = "";

        public template(string accesstoken)
        {
            _accesstoken = accesstoken;
        }

        /// <summary>
        /// 获取模板列表。获取已添加至帐号下所有模板列表，可在微信公众平台后台中查看模板列表信息。为方便第三方开发者，提供通过接口调用的方式来获取帐号下所有模板信息，具体如下:,请求方式： GET（HTTPS）
        /// </summary>
        /// <returns></returns>
        public async Task<Response_templatelist> getallprivatetemplate()
        {
            var result = new Response_templatelist();
            try
            {
                var response = await HttpHelper.HttpGet(string.Format(gettemplateUrl, _accesstoken));
                if (!string.IsNullOrWhiteSpace(response))
                {
                    result = JsonConvert.DeserializeObject<Response_templatelist>(response);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        /// <summary>
        /// 删除模板。删除模板可在微信公众平台后台完成，为方便第三方开发者，提供通过接口调用的方式来删除某帐号下的模板
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<Response_base> delprivatetemplate(Request_deltemplate req)
        {
            var result = new Response_base();
            try
            {
                var response = await HttpHelper.HttpPost(string.Format(deltemplateUrl, _accesstoken),JsonConvert.SerializeObject(req));
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
        /// 发送模板消息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<Response_templatesendmessage> templatesendmessage(Request_templatesendmessage req)
        {
            var result = new Response_templatesendmessage();
            try
            {
                var response = await HttpHelper.HttpPost(string.Format(templatesendmessageUrl, _accesstoken), JsonConvert.SerializeObject(req));
                if (!string.IsNullOrWhiteSpace(response))
                {
                    result = JsonConvert.DeserializeObject<Response_templatesendmessage>(response);
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
