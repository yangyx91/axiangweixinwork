using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Response.externaluser
{
    public class Response_listcontactway:Response_base
    {
        /// <summary>
        /// 分页参数，用于查询下一个分页的数据，为空时表示没有更多的分页
        /// </summary>
        public string next_cursor { get; set; }

        public List<contactwayconfig> contactway { get; set; }

        public class contactwayconfig
        {
            /// <summary>
            /// 联系方式的配置id
            /// </summary>
            public string config_id { get; set; } 
        }
    }
}
