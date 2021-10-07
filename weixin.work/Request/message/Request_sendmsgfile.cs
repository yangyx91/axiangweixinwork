﻿using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Request.message
{
    public class Request_sendmsgfile:Request_sendmsgbase
    {
        public Request_sendmsgfile(int _agentid, List<string> _userids = null, List<string> _departmentids = null, List<string> _tags = null)
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

            this.msgtype = "file";
        }
        /// <summary>
        /// 消息类型，此时固定为：file
        /// </summary>
        public sendmsgfile file { get; set; }

        public class sendmsgfile
        {
            /// <summary>
            /// 文件id，可以调用上传临时素材接口获取
            /// </summary>
            public string media_id { get; set; }
        }
    }
}
