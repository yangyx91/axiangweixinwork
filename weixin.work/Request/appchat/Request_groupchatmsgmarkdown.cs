using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Request.appchat
{
    public class Request_groupchatmsgmarkdown
    {
        public Request_groupchatmsgmarkdown()
        {
            this.msgtype = "markdown";
        }

        /// <summary>
        /// 群聊id
        /// </summary>
        public string chatid { get; set; }
        /// <summary>
        /// 消息类型，此时固定为：markdown
        /// </summary>
        public string msgtype { get; set; }
        /// <summary>
        /// markdown消息
        /// </summary>
        public MsgMarkdown markdown { get; set; }

        public class MsgMarkdown
        {
            /// <summary>
            /// markdown内容，最长不超过2048个字节，必须是utf8编码
            /// https://developer.work.weixin.qq.com/document/path/90236#%E6%94%AF%E6%8C%81%E7%9A%84markdown%E8%AF%AD%E6%B3%95
            /// </summary>
            public string content { get; set; }
        }
    }
}
