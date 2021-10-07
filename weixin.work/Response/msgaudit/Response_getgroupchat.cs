using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Response.msgaudit
{
    public class Response_getgroupchat:Response_base
    {
        /// <summary>
        /// 群名称
        /// </summary>
        public string roomname { get; set; }
        /// <summary>
        /// 群创建者，userid
        /// </summary>
        public string creator { get; set; }
        /// <summary>
        /// 群创建时间
        /// </summary>
        public long room_create_time { get; set; }
        /// <summary>
        /// 群公告
        /// </summary>
        public string notice { get; set; }
        /// <summary>
        /// 群成员列表
        /// </summary>
        public List<member> members { get; set; }

        public class member
        {
            /// <summary>
            /// 群成员的id，userid
            /// </summary>
            public string memberid { get; set; }
            /// <summary>
            /// 群成员的入群时间
            /// </summary>
            public long jointime { get; set; }

        }
    }
}
