using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Request.message
{
    public class Request_sendmsgnews:Request_sendmsgbase
    {
        public Request_sendmsgnews(int _agentid, List<string> _userids = null, List<string> _departmentids = null, List<string> _tags = null)
        {
            this.agentid = _agentid;

            if (_userids != null && _userids.Count > 0)
            {
                this.touser = string.Join("|", _userids.ToArray());
            }
            if (_departmentids != null && _departmentids.Count > 0)
            {
                this.toparty = string.Join("|", _departmentids.ToArray());
            }
            if (_tags != null && _tags.Count > 0)
            {
                this.totag = string.Join("|", _tags.ToArray());
            }

            this.msgtype = "news";
        }
        /// <summary>
        /// 消息类型，此时固定为：news
        /// </summary>
        public sendmsgnews news { get; set; }

        public class sendmsgnews
        {
            /// <summary>
            /// 图文消息，一个图文消息支持1到8条图文
            /// </summary>
            public List<sendmsgarticle> articles { get; set; }
        }

        public class sendmsgarticle
        {
            /// <summary>
            /// 标题，不超过128个字节，超过会自动截断（支持id转译）
            /// </summary>
            public string title { get; set; }
            /// <summary>
            /// 描述，不超过512个字节，超过会自动截断（支持id转译）
            /// </summary>
            public string description { get; set; }
            /// <summary>
            /// 点击后跳转的链接。 最长2048字节，请确保包含了协议头(http/https)，小程序或者url必须填写一个
            /// </summary>
            public string url { get; set; }
            /// <summary>
            /// 图文消息的图片链接，支持JPG、PNG格式，较好的效果为大图 1068*455，小图150*150。
            /// </summary>
            public string picurl { get; set; }
            /// <summary>
            /// 可选：小程序appid，必须是与当前应用关联的小程序，appid和pagepath必须同时填写，填写后会忽略url字段
            /// </summary>
            public string appid { get; set; }
            /// <summary>
            /// 可选：点击消息卡片后的小程序页面，仅限本小程序内的页面。appid和pagepath必须同时填写，填写后会忽略url字段
            /// </summary>
            public string pagepath { get; set; }
        }
    }
}
