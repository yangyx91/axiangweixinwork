using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Request.msgaudit
{
    public class Request_getgroupchat
    {
        /// <summary>
        /// 待查询的群id,只支持内部群
        /// </summary>
        public string roomid { get; set; }
    }
}
