using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Request.appchat
{
    public class Request_groupchatmsgvoice
    {
        public Request_groupchatmsgvoice()
        {
            this.msgtype = "voice";
        }

        /// <summary>
        /// 群聊id
        /// </summary>
        public string chatid { get; set; }
        /// <summary>
        /// 消息类型，此时固定为：voice
        /// </summary>
        public string msgtype { get; set; }
        /// <summary>
        /// 语音消息
        /// </summary>
        public MsgVoice voice { get; set; }

        public class MsgVoice
        {
            /// <summary>
            /// 语音文件id，可以调用上传临时素材接口获取
            /// </summary>
            public string media_id { get; set; } 
        }
    }
}
