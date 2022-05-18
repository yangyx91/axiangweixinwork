using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Request.webhook
{
    public class Request_msgfile
    {
        public Request_msgfile()
        {
            this.msgtype = "file";
        }

        /// <summary>
        /// 消息类型，此时固定为：file
        /// </summary>
        public string msgtype { get; set; }
        /// <summary>
        /// 文件消息
        /// </summary>
        public MsgFile file { get; set; }

        public class MsgFile
        {
            /// <summary>
            /// 文件id，通过下文的文件上传接口获取
            /// </summary>
            public string media_id { get; set; }
        }
    }
}
