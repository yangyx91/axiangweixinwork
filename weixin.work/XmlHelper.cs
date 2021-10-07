using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using weixin.work.Response.messageHandler;

namespace weixin.work
{
    public static class XmlHelper
    {
        /// <summary>
        /// string字符串转XMLNode
        /// </summary>
        /// <param name="xmlString"></param>
        /// <returns></returns>
        public static XmlNode ReadXmlNode(string xmlString)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlString);
            XmlNode root = doc.FirstChild;
            //示例使用
            //string nonce = root["Nonce"].InnerText;
            return root;
        }

		/// <summary>
		/// 将实体转为XML字符串
		/// </summary>
		/// <typeparam name="T">RequestMessage或ResponseMessage</typeparam>
		/// <param name="entity">实体</param>
		/// <returns></returns>
		public static string ConvertEntityToXmlString<T>(this T entity) where T : class, new()
		{
			return entity.ConvertEntityToXml().ToString();
		}

		/// <summary>
		/// 将实体转为XML
		/// </summary>
		/// <typeparam name="T">RequestMessage或ResponseMessage</typeparam>
		/// <param name="entity">实体</param>
		/// <returns></returns>
		public static XDocument ConvertEntityToXml<T>(this T entity) where T : class, new()
		{
			entity = entity ?? new T();
			var doc = new XDocument();
			doc.Add(new XElement("xml"));
			var root = doc.Root;

            //	/* 注意！
            //           * 经过测试，微信对字段排序有严格要求，这里对排序进行强制约束
            //          */
            var propNameOrder = new List<string>() { "ToUserName", "FromUserName", "CreateTime", "MsgType" };
            //不同返回类型需要对应不同特殊格式的排序
            if (entity is Response_MessageNews)
            {
                propNameOrder.AddRange(new[] { "ArticleCount", "Articles", "FuncFlag",/*以下是Atricle属性*/ "Title ", "Description ", "PicUrl", "Url" });
            }
            else if (entity is Response_MessageMpNews)
            {
                propNameOrder.AddRange(new[] { "MpNewsArticleCount", "MpNewsArticles", "FuncFlag",/*以下是MpNewsAtricle属性*/ "Title ", "Description ", "PicUrl", "Url" });
            }
            else if (entity is Response_MessageImage)
            {
                propNameOrder.AddRange(new[] { "Image",/*以下是Image属性*/ "MediaId " });
            }
            else if (entity is Response_MessageVoice)
            {
                propNameOrder.AddRange(new[] { "Voice",/*以下是Voice属性*/ "MediaId " });
            }
            else if (entity is Response_MessageVideo)
            {
                propNameOrder.AddRange(new[] { "Video",/*以下是Video属性*/ "MediaId ", "Title", "Description" });
            }
            else if (entity is Response_MessageText)
            {
                //如Text类型
                propNameOrder.AddRange(new[] { "Content" });
            }

            propNameOrder.AddRange(new[] { "AgentID" });

            Func<string, int> orderByPropName = propNameOrder.IndexOf;

            var props = entity.GetType().GetProperties().OrderBy(p => orderByPropName(p.Name)).ToList();
            foreach (var prop in props)
            {
                var propName = prop.Name;
                if (propName == "Articles")
                {
                    //文章列表
                    var atriclesElement = new XElement("Articles");
                    var articales = prop.GetValue(entity, null) as List<Article>;
                    foreach (var articale in articales)
                    {
                        var subNodes = ConvertEntityToXml(articale).Root.Elements();
                        atriclesElement.Add(new XElement("item", subNodes));
                    }
                    root.Add(atriclesElement);
                }
                else if (propName == "MpNewsArticles")
                {
                    //var mpNewsAtriclesElement = new XElement("MpNewsArticles");
                    //var mpNewsAtricles = prop.GetValue(entity, null) as List<MpNewsArticle>;
                    //foreach (var mpNewsArticale in mpNewsAtricles)
                    //{
                    //    var subNodes = ConvertEntityToXml(mpNewsArticale).Root.Elements();
                    //    mpNewsAtriclesElement.Add(subNodes);
                    //}

                    //root.Add(mpNewsAtriclesElement);
                }
                else if (propName == "Image" || propName == "Video" || propName == "Voice")
                {
                    //图片、视频、语音格式
                    var musicElement = new XElement(propName);
                    var media = prop.GetValue(entity, null);
                    var subNodes = ConvertEntityToXml(media).Root.Elements();
                    musicElement.Add(subNodes);
                    root.Add(musicElement);
                }
                else if (propName == "KfAccount")
                {
                    root.Add(new XElement(propName, prop.GetValue(entity, null).ToString().ToLower()));
                }
                else
                {
                    switch (prop.PropertyType.Name)
                    {
                        case "String":
                            root.Add(new XElement(propName,
                                             new XCData(prop.GetValue(entity, null) as string ?? "")));
                            break;
                        case "DateTime":
                            root.Add(new XElement(propName, HttpHelper.NewDateTimeStamp((DateTime)prop.GetValue(entity, null))));
                            break;
                        default:
                            root.Add(new XElement(propName, prop.GetValue(entity, null)));
                            break;
                    }
                }
            }
            return doc;
		}
	}
}
