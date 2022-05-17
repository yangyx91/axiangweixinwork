using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Request.appchat
{
    public class Request_groupchatmsgtextcard
    {
        public Request_groupchatmsgtextcard()
        { 
            this.msgtype = "textcard";
            this.safe = 0;
        }

        /// <summary>
        /// 群聊id
        /// </summary>
        public string chatid { get; set; }
        /// <summary>
        /// 消息类型，此时固定为：textcard
        /// </summary>
        public string msgtype { get; set; }
        /// <summary>
        /// 表示是否是保密消息，0表示否，1表示是，默认0
        /// </summary>
        public int safe { get; set; }
        /// <summary>
        /// 文件卡片消息
        /// </summary>
        public MsgTextCard textcard { get; set; }

        public class MsgTextCard 
        {
            /// <summary>
            /// 标题，不超过128个字节，超过会自动截断
            /// </summary>
            public string title { get; set; }
            /// <summary>
            /// 描述，不超过512个字节，超过会自动截断
            /// 支持使用br标签或者空格来进行换行处理，也支持使用div标签来使用不同的字体颜色
            /// </summary>
            public string description { get; set; }
            /// <summary>
            /// 点击后跳转的链接。
            /// </summary>
            public string url { get; set; }
            /// <summary>
            /// 按钮文字。 默认为“详情”， 不超过4个文字，超过自动截断。
            /// </summary>
            public string btntxt { get; set; }
        }
    }
}
