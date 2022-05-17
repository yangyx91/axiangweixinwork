using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Response.appchat
{
    public class Response_groupchatget:Response_base
    {
        public appchatinfo chat_info { get; set; }

        public class appchatinfo
        {
            /// <summary>
            /// 群聊名，最多50个utf8字符，超过将截断
            /// </summary>
            public string name { get; set; }

            /// <summary>
            /// 指定群主的id
            /// </summary>
            public string owner { get; set; }

            /// <summary>
            /// 群成员id列表
            /// </summary>
            public List<string> userlist { get; set; }

            /// <summary>
            /// 群聊的唯一标志
            /// </summary>
            public string chatid { get; set; }
        }
    }
}
