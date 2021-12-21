using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.BLL
{
    public class oauth2
    {
        private static string authorizeUrl =
            @"https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope=snsapi_base&state={2}#wechat_redirect";

        private static string _corpId;

        private static string _redirect_uri;

        public oauth2(string corpId,string redirect_uri,string state= "STATE")
        {
            _corpId = corpId;
            _redirect_uri = System.Web.HttpUtility.UrlEncode(redirect_uri, Encoding.UTF8);
            authorizeUrl = string.Format(_corpId, _redirect_uri,state);
        }

        /// <summary>
        /// 构造Oauth2网页授权链接
        /// </summary>
        /// <returns></returns>
        public string InitAuthorizeUrl()
        {
            return authorizeUrl;
        }
    }
}
