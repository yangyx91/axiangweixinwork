using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Response.user
{
    public class Response_convertuserid:Response_base
    {
        /// <summary>
        /// 该openid在企业微信对应的成员userid
        /// </summary>
        public string userid { get; set; }
    }
}
