using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Request.appchat
{
    public class Request_groupchatmsgvideo
    {
        public Request_groupchatmsgvideo()
        {
            this.msgtype = "video";
            this.safe = 0;
        }

        /// <summary>
        /// 群聊id
        /// </summary>
        public string chatid { get; set; }
        /// <summary>
        /// 消息类型，此时固定为：video
        /// </summary>
        public string msgtype { get; set; }
        /// <summary>
        /// 表示是否是保密消息，0表示否，1表示是，默认0
        /// </summary>
        public int safe { get; set; }
        /// <summary>
        /// 视频消息
        /// </summary>
        public MsgVideo video { get; set; }

        public class MsgVideo 
        {
            /// <summary>
            /// 视频媒体文件id，可以调用上传临时素材接口获取
            /// </summary>
            public string media_id { get; set; }
            /// <summary>
            /// 视频消息的描述，不超过512个字节，超过会自动截断
            /// </summary>
            public string description { get; set; }
            /// <summary>
            /// 视频消息的标题，不超过128个字节，超过会自动截断
            /// </summary>
            public string title { get; set; }
        }
    }
}
