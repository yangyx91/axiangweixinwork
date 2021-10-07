using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Request.message
{
    public class Request_sendmsgvideo:Request_sendmsgbase
    {
        public Request_sendmsgvideo(int _agentid, List<string> _userids = null, List<string> _departmentids = null, List<string> _tags = null)
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

            this.msgtype = "video";
        }
        /// <summary>
        /// 消息类型，此时固定为：video
        /// </summary>
        public sendmsgvideo video { get; set; }

        public class sendmsgvideo
        {
            /// <summary>
            /// 视频媒体文件id，可以调用上传临时素材接口获取
            /// </summary>
            public string media_id { get; set; }
            /// <summary>
            /// 视频消息的标题，不超过128个字节，超过会自动截断
            /// </summary>
            public string title { get; set; }
            /// <summary>
            /// 视频消息的描述，不超过512个字节，超过会自动截断
            /// </summary>
            public string description { get; set; }
        }
    }
}
