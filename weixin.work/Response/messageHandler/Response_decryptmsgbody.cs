using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Response.messageHandler
{
    /// <summary>
    /// 当企业后台收到推送过来的普通消息或事件消息后，可以在响应里带上被动回复消息
    /// </summary>
    public class Response_decryptmsgbody
    {
        /// <summary>
        /// 消息类型
        /// </summary>
        public string MsgType { get; set; }
        /// <summary>
        /// 企业微信CorpID
        /// </summary>
        public string ToUserName { get; set; }
        /// <summary>
        /// 成员UserID
        /// </summary>
        public string FromUserName { get; set; }
        /// <summary>
        /// 消息创建时间（整型）
        /// </summary>
        public string CreateTime { get; set; }
    }


    public class Response_MessageText:Response_decryptmsgbody
    {
        public Response_MessageText()
        {
            this.CreateTime = HttpHelper.NewDateTimeStamp(DateTime.Now).ToString();
            this.MsgType = "text";
        }
        /// <summary>
        /// 文本消息内容
        /// </summary>
        public string Content { get; set; }
    }

    public class Response_MessageImage : Response_decryptmsgbody
    {
        public Response_MessageImage()
        {
            this.CreateTime = HttpHelper.NewDateTimeStamp(DateTime.Now).ToString();
            this.MsgType = "image";
        }
        public MessageImage Image { get; set; }

        public class MessageImage
        {
            /// <summary>
            /// 图片媒体文件id，可以调用获取媒体文件接口拉取
            /// </summary>
            public string MediaId { get; set; }
        }
    }

    public class Response_MessageVoice : Response_decryptmsgbody
    {
        public Response_MessageVoice()
        {
            this.CreateTime = HttpHelper.NewDateTimeStamp(DateTime.Now).ToString();
            this.MsgType = "voice";
        }
        public MessageVoice Voice { get; set; }

        public class MessageVoice
        {
            /// <summary>
            /// 语音文件id，可以调用获取媒体文件接口拉取
            /// </summary>
            public string MediaId { get; set; }
        }
    }

    public class Response_MessageVideo : Response_decryptmsgbody
    {
        public Response_MessageVideo()
        {
            this.CreateTime = HttpHelper.NewDateTimeStamp(DateTime.Now).ToString();
            this.MsgType = "video";
        }
        public MessageVideo Video { get; set; }

        public class MessageVideo
        {
            /// <summary>
            /// 视频文件id，可以调用获取媒体文件接口拉取
            /// </summary>
            public string MediaId { get; set; }
            /// <summary>
            /// 视频消息的标题,不超过128个字节，超过会自动截断
            /// </summary>
            public string Title { get; set; }
            /// <summary>
            /// 视频消息的描述,不超过512个字节，超过会自动截断
            /// </summary>
            public string Description { get; set; }
        }
    }



    public class Response_MessageNews : Response_decryptmsgbody
    {
        public Response_MessageNews()
        {
            this.CreateTime = HttpHelper.NewDateTimeStamp(DateTime.Now).ToString();
            this.MsgType = "news";
        }

        /// <summary>
        /// 图文消息的数量
        /// </summary>
        public string ArticleCount { get; set; }
        public List<Article> Articles { get; set; }
    }

   
    public class Article
    {
        /// <summary>
        /// 标题，不超过128个字节，超过会自动截断
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 描述，不超过512个字节，超过会自动截断
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 图文消息的图片链接，支持JPG、PNG格式，较好的效果为大图640320，小图8080。
        /// </summary>
        public string PicUrl { get; set; }
        /// <summary>
        /// 点击后跳转的链接。
        /// </summary>
        public string Url { get; set; }
    }


    public class Response_MessageMpNews : Response_decryptmsgbody
    {

    }

}
