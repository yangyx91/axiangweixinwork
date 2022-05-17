using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Response.appchat
{
    public class Response_groupchatcreate:Response_base
    {
        /// <summary>
        /// 群聊的唯一标志
        /// </summary>
        public string chatid { get; set; }
    }
}
