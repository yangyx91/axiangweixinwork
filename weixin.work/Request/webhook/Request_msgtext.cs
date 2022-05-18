using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Request.webhook
{
    public class Request_msgtext
    { 
        public Request_msgtext()
        {
            this.msgtype = "text";
        }

        /// <summary>
        /// 消息类型，此时固定为：text
        /// </summary>
        public string msgtype { get; set; }
        /// <summary>
        /// 文本消息
        /// </summary>
        public MsgText text { get; set; }

        public class MsgText
        {
            /// <summary>
            /// 文本内容，最长不超过2048个字节，必须是utf8编码
            /// text参数的content字段可以支持换行，换行符请用转义过的'\n'。
            /// </summary>
            public string content { get; set; }
            /// <summary>
            /// userid的列表，提醒群中的指定成员(@某个成员)，@all表示提醒所有人，如果开发者获取不到userid，可以使用mentioned_mobile_list
            /// 示例：["wangqing","@all"]
            /// </summary>
            //public List<string> mentioned_list { get; set; }

            /// <summary>
            /// 手机号列表，提醒手机号对应的群成员(@某个成员)，@all表示提醒所有人
            /// 示例：["13800001111","@all"]
            /// </summary>
            //public List<string> mentioned_mobile_list { get; set; }
        }
    }
}
