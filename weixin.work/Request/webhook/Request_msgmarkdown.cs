using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Request.webhook
{
    public class Request_msgmarkdown
    {
        public Request_msgmarkdown()
        {
            this.msgtype = "markdown";
        }

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
            /// markdown内容，最长不超过4096个字节，必须是utf8编码
            /// 参考文档：https://developer.work.weixin.qq.com/document/path/91770
            /// </summary>
            public string content { get; set; }
        }
    }
}
