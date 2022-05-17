using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Request.appchat
{
    public class Request_groupchatmsgtext
    {
        public Request_groupchatmsgtext()
        {
            this.msgtype = "text";
            this.safe = 0;
        }

        /// <summary>
        /// 群聊id
        /// </summary>
        public string chatid { get; set; }
        /// <summary>
        /// 消息类型，此时固定为：text
        /// </summary>
        public string msgtype { get; set; }
        /// <summary>
        /// 表示是否是保密消息，0表示否，1表示是，默认0
        /// </summary>
        public int safe { get; set; }
        /// <summary>
        /// 文本消息
        /// </summary>
        public MsgText text { get; set; }

        public class MsgText
        {
            /// <summary>
            /// 消息内容，最长不超过2048个字节
            /// text参数的content字段可以支持换行，换行符请用转义过的'\n'。
            /// </summary>
            public string content { get; set; }
        }
    }
}
