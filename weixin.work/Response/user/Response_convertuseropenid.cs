using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Response.user
{
    public class Response_convertuseropenid:Response_base
    {
        /// <summary>
        /// 企业微信成员userid对应的openid
        /// </summary>
        public string openid { get; set; }
    }
}
