using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Request.message
{
    public class Request_sendmsgtextcard:Request_sendmsgbase
    {
        public Request_sendmsgtextcard(int _agentid, List<string> _userids = null, List<string> _departmentids = null, List<string> _tags = null)
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

            this.msgtype = "textcard";
        }
        /// <summary>
        /// 消息类型，此时固定为：textcard
        /// </summary>
        public sendmsgtextcard textcard { get; set; }

        /// <summary>
        /// 特殊说明：卡片消息的展现形式非常灵活，支持使用br标签或者空格来进行换行处理，也支持使用div标签来使用不同的字体颜色，目前内置了3种文字颜色：灰色(gray)、高亮(highlight)、默认黑色(normal)，将其作为div标签的class属性即可，具体用法请参考上面的示例。
        /// </summary>
        public class sendmsgtextcard
        {
            /// <summary>
            /// 点击后跳转的链接。最长2048字节，请确保包含了协议头(http/https)
            /// </summary>
            public string url { get; set; }
            /// <summary>
            /// 标题，不超过128个字节，超过会自动截断（支持id转译）
            /// </summary>
            public string title { get; set; }
            /// <summary>
            /// 描述，不超过512个字节，超过会自动截断（支持id转译）
            /// </summary>
            //示例： "<div class=\"gray\">2016年9月26日</div> <div class=\"normal\">恭喜你抽中iPhone 7一台，领奖码：xxxx</div><div class=\"highlight\">请于2016年10月10日前联系行政同事领取</div>"
            public string description { get; set; }
            /// <summary>
            /// 按钮文字。 默认为“详情”， 不超过4个文字，超过自动截断。
            /// </summary>
            public string btntxt { get; set; }
        }
    }
}
