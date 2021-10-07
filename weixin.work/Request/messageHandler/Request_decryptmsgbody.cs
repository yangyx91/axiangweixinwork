using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace weixin.work.Request.messageHandler
{
    public class Request_decryptmsgbody 
    {
        /// <summary>
        /// 开启接收消息模式后，企业成员在企业微信应用里发送消息时，企业微信会将消息同步到企业应用的后台。
        /// 以下出现的xml包仅是接收的消息包中的Encrypt参数解密后的内容说明
        /// </summary>
        /// <param name="xmlString"></param>
        public Request_decryptmsgbody(string xmlString)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlString);
            this.xmlNode = doc.FirstChild;
            this.AgentID= xmlNode["AgentID"].InnerText;
            this.MsgType = xmlNode["MsgType"].InnerText;
            this.MsgId= xmlNode["MsgId"].InnerText;
            this.ToUserName = xmlNode["ToUserName"].InnerText;
            this.FromUserName = xmlNode["FromUserName"].InnerText;
            this.CreateTime = xmlNode["CreateTime"].InnerText;
            this.FormatCreateTime = HttpHelper.NewChinaDate(Convert.ToInt64(this.CreateTime) );

            if (xmlNode["MsgType"].InnerText.ToLower() == "text")
            {
                this.resMessageText = new MessageText();
                this.resMessageText.Content = xmlNode["Content"].InnerText;
            }

            if (xmlNode["MsgType"].InnerText.ToLower() == "image")
            {
                this.resMessageImage = new MessageImage();
                this.resMessageImage.PicUrl = xmlNode["PicUrl"].InnerText;
                this.resMessageImage.MediaId = xmlNode["MediaId"].InnerText;
            }

            if (xmlNode["MsgType"].InnerText.ToLower() == "voice")
            {
                this.resMessageVoice = new MessageVoice();
                this.resMessageVoice.MediaId = xmlNode["MediaId"].InnerText;
                this.resMessageVoice.Format = xmlNode["Format"].InnerText;
            }

            if (xmlNode["MsgType"].InnerText.ToLower() == "video")
            {
                this.resMessageVideo = new MessageVideo();
                this.resMessageVideo.MediaId = xmlNode["MediaId"].InnerText;
                this.resMessageVideo.ThumbMediaId = xmlNode["ThumbMediaId"].InnerText;
            }
        }
        /// <summary>
        /// XML节点
        /// </summary>
        public XmlNode xmlNode { get; set; }

        /// <summary>
        /// 企业应用的id，整型。可在应用的设置页面查看
        /// </summary>
        public string AgentID { get; set; }
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
        /// <summary>
        /// 格式化时间
        /// </summary>
        public DateTime FormatCreateTime { get; set; }
        /// <summary>
        /// 消息id，64位整型
        /// </summary>
        public string MsgId { get; set; }
        /// <summary>
        /// 文本消息
        /// </summary>
        public MessageText resMessageText { get; set; }
        /// <summary>
        /// 图片消息
        /// </summary>
        public MessageImage resMessageImage { get; set; }
        /// <summary>
        /// 语音消息
        /// </summary>
        public MessageVoice resMessageVoice { get; set; }
        /// <summary>
        /// 视频消息
        /// </summary>
        public MessageVideo resMessageVideo { get; set; }
    }

    public class MessageText
    {
        /// <summary>
        /// 文本消息内容
        /// </summary>
        public string Content { get; set; }
    }

    public class MessageImage
    {
        //图片链接
        public string MediaId { get; set; }
        /// <summary>
        /// 图片媒体文件id，可以调用获取媒体文件接口拉取，仅三天内有效
        /// </summary>
        public string PicUrl { get; set; }
    }

    public class MessageVoice
    {
        /// <summary>
        /// 语音消息媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string MediaId { get; set; }
        /// <summary>
        /// 语音格式：amr
        /// </summary>
        public string Format { get; set; }
    }

    public class MessageVideo
    {
        /// <summary>
        /// 视频媒体文件id，可以调用获取媒体文件接口拉取数据，仅三天内有效
        /// </summary>
        public string MediaId { get; set; }
        /// <summary>
        /// 视频消息缩略图的媒体id，可以调用获取媒体文件接口拉取数据，仅三天内有效
        /// </summary>
        public string ThumbMediaId { get; set; }
    }
}
