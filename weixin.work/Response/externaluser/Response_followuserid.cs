using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Response.externaluser
{
    public class Response_followuserid : Response_base
    {
        /// <summary>
        /// 配置了客户联系功能的成员userid列表
        /// </summary>
        public List<string> follow_user { get; set; }
    }
}
