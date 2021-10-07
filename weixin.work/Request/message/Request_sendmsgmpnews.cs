using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Request.message
{
    public class Request_sendmsgmpnews:Request_sendmsgbase
    {
        public Request_sendmsgmpnews(int _agentid, List<string> _userids = null, List<string> _departmentids = null, List<string> _tags = null)
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

            this.msgtype = "mpnews";
        }
        /// <summary>
        /// 消息类型，此时固定为：mpnews
        /// </summary>
        public sendmsgmpnews mpnews { get; set; }

        public class sendmsgmpnews
        {
            /// <summary>
            /// 图文消息，一个图文消息支持1到8条图文
            /// </summary>
            public List<sendmsgmparticle> articles { get; set; }
        }

        public class sendmsgmparticle
        {
            /// <summary>
            /// 标题，不超过128个字节，超过会自动截断（支持id转译）
            /// </summary>
            public string title { get; set; }
            /// <summary>
            /// 图文消息缩略图的media_id, 可以通过素材管理接口获得。此处thumb_media_id即上传接口返回的media_id
            /// </summary>
            public string thumb_media_id { get; set; }
            /// <summary>
            /// 图文消息的作者，不超过64个字节
            /// </summary>
            public string author { get; set; }
            /// <summary>
            /// 图文消息点击“阅读原文”之后的页面链接
            /// </summary>
            public string content_source_url { get; set; }
            /// <summary>
            /// 图文消息的内容，支持html标签，不超过666 K个字节（支持id转译）
            /// </summary>
            public string content { get; set; }
            /// <summary>
            /// 图文消息的描述，不超过512个字节，超过会自动截断（支持id转译）
            /// </summary>
            public string digest { get; set; }

        }
    }
}
