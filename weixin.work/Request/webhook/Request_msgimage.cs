using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Request.webhook
{
    public class Request_msgimage
    {
        public Request_msgimage()
        {
            this.msgtype = "image";
        }

        /// <summary>
        /// 消息类型，此时固定为：image
        /// </summary>
        public string msgtype { get; set; }
        /// <summary>
        /// 图片消息,图片（base64编码前）最大不能超过2M，支持JPG,PNG格式
        /// </summary>
        public MsgImage image { get; set; }

        public class MsgImage
        {
            /// <summary>
            /// 图片内容的base64编码
            /// </summary>
            public string base64 { get; set; }
            /// <summary>
            /// 图片内容（base64编码前）的md5值
            /// </summary>
            public string md5 { get; set; }

        }
    }
}
