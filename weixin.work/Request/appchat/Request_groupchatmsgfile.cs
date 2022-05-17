using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Request.appchat
{
    public class Request_groupchatmsgfile
    {
        public Request_groupchatmsgfile()
        {
            this.msgtype = "file";
            this.safe = 0;
        }

        /// <summary>
        /// 群聊id
        /// </summary>
        public string chatid { get; set; }
        /// <summary>
        /// 消息类型，此时固定为：file
        /// </summary>
        public string msgtype { get; set; }
        /// <summary>
        /// 表示是否是保密消息，0表示否，1表示是，默认0
        /// </summary>
        public int safe { get; set; }
        /// <summary>
        /// 文件消息
        /// </summary>
        public MsgFile file { get; set; }

        public class MsgFile
        {
            /// <summary>
            /// 文件id，可以调用上传临时素材接口获取
            /// </summary>
            public string media_id { get; set; }
        }
    }
}
