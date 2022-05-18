﻿using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Request.webhook
{
    public class Request_msgnews
    {
        public Request_msgnews()
        {
            this.msgtype = "news";
        }

        /// <summary>
        /// 消息类型，此时固定为：news
        /// </summary>
        public string msgtype { get; set; }
        /// <summary>
        /// 图文消息
        /// </summary>
        public MsgNews news { get; set; }

        public class MsgNews
        {
            /// <summary>
            /// 图文消息，一个图文消息支持1到8条图文
            /// </summary>
            public List<Msg_article> articles { get; set; }
        }

        public class Msg_article
        {
            /// <summary>
            /// 标题，不超过128个字节，超过会自动截断
            /// </summary>
            public string title { get; set; }
            /// <summary>
            /// 描述，不超过512个字节，超过会自动截断
            /// </summary>
            public string description { get; set; }
            /// <summary>
            /// 点击后跳转的链接。
            /// </summary>
            public string url { get; set; }
            /// <summary>
            /// 图文消息的图片链接，支持JPG、PNG格式，较好的效果为大图1068*455，小图150*150
            /// </summary>
            public string picurl { get; set; }
        }
    }
}
