using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace weixin.work.Request.messageHandler
{
    //<xml> 
   //<ToUserName><![CDATA[toUser]]></ToUserName>
   //<AgentID><![CDATA[toAgentID]]></AgentID>
   //<Encrypt><![CDATA[msg_encrypt]]></Encrypt>
   //</xml>
    public class Request_encryptmsgbody
    {
        public Request_encryptmsgbody(string sEncryptMsg)
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(sEncryptMsg);
                XmlNode root = doc.FirstChild;
                this.ToUserName = root["ToUserName"].InnerText;
                this.AgentID = root["AgentID"].InnerText;
                this.Encrypt = root["Encrypt"].InnerText;
                this.PostData = sEncryptMsg;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 企业微信的CorpID，当为第三方套件回调事件时，CorpID的内容为suiteid
        /// </summary>
        public string ToUserName { get; set; }

        /// <summary>
        /// 接收的应用id，可在应用的设置页面获取
        /// </summary>
        public string AgentID { get; set; }

        /// <summary>
        /// 消息结构体加密后的字符串
        /// </summary>
        public string Encrypt { get; set; }

        /// <summary>
        /// 原始密文
        /// </summary>
        public string PostData { get; set; }
    }
}
