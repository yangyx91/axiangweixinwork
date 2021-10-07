using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Response.externaluser
{
    public class Response_externaluserid : Response_base
    {
        /// <summary>
        /// 外部联系人的userid列表
        /// </summary>
        public List<string> external_userid { get; set; }
    }
}
