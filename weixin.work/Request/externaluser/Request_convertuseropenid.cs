using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Request.externaluser
{
    public class Request_convertuseropenid
    {
        /// <summary>
        /// 外部联系人的userid，注意不是企业成员的帐号
        /// </summary>
        public string external_userid { get; set; }
    }
}
