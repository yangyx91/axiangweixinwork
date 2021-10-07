using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Request.user
{
    public class Request_convertuserid
    {
        /// <summary>
        /// 在使用企业支付之后，返回结果的openid
        /// </summary>
        public string openid { get; set; }
    }
}
