using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Request.message
{
    public class Request_sendmsgtext : Request_sendmsgbase
    {
        public Request_sendmsgtext(int _agentid, List<string> _userids = null, List<string> _departmentids = null, List<string> _tags = null)
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
            
            this.msgtype = "text";
        }
        /// <summary>
        /// 消息类型，此时固定为：text
        /// </summary>
        public sendmsgtext text { get; set; }

        public class sendmsgtext
        {

            /// <summary>
            /// 消息内容，最长不超过2048个字节，超过将截断（支持id转译）
            /// 特殊说明：其中text参数的content字段可以支持换行、以及A标签，即可打开自定义的网页（可参考以上示例代码）(注意：换行符请用转义过的\n)
            /// </summary>
            //示例："你的快递已到，请携带工卡前往邮件中心领取。\n出发前可查看<a href=\"http:///work.weixin.qq.com\">邮件中心视频实况</a>，聪明避开排队。"
            public string content { get; set; }
        }
    }
}
