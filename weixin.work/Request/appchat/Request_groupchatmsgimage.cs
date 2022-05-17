using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Request.appchat
{
    public class Request_groupchatmsgimage
    {
        public Request_groupchatmsgimage()
        {
            this.msgtype = "image";
            this.safe = 0;
        }

        /// <summary>
        /// 群聊id
        /// </summary>
        public string chatid { get; set; }
        /// <summary>
        /// 消息类型，此时固定为：image
        /// </summary>
        public string msgtype { get; set; }
        /// <summary>
        /// 表示是否是保密消息，0表示否，1表示是，默认0
        /// </summary>
        public int safe { get; set; }
        /// <summary>
        /// 图片消息
        /// </summary>
        public MsgImage image { get; set; }

        public class MsgImage
        {
            /// <summary>
            /// 图片媒体文件id，可以调用上传临时素材接口获取
            /// </summary>
            public string media_id { get; set; }
        }
    }
}
