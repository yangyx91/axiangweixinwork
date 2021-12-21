using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Request.externaluser
{
    public class Request_sendwelcomemsg
    {
        /// <summary>
        /// 通过添加外部联系人事件推送给企业的发送欢迎语的凭证，有效期为20秒
        /// 参考文档：https://open.work.weixin.qq.com/api/doc/90000/90135/92137
        /// </summary>
        public string welcome_code { get; set; }
        /// <summary>
        /// 文本内容
        /// </summary>
        public TextContent text { get; set; }

        public class TextContent
        {
            /// <summary>
            /// 消息文本内容,最长为4000字节
            /// </summary>
            public string content { get; set; }
        }

        /// <summary>
        /// 附件，最多可添加9个附件
        /// </summary>
        public List<object> attachments { get; set; }
    }
}
