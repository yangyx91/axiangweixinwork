using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Request.externaluser
{
    public class Request_listcontactway
    {
        /// <summary>
        /// 「联系我」创建起始时间戳, 默认为90天前
        /// </summary>
        public long start_time { get; set; }

        /// <summary>
        /// 「联系我」创建结束时间戳, 默认为当前时间
        /// </summary>
        public long end_time { get; set; }

        /// <summary>
        /// 分页查询使用的游标，为上次请求返回的 next_cursor
        /// </summary>
        public string cursor { get; set; }

        /// <summary>
        /// 每次查询的分页大小，默认为100条，最多支持1000条
        /// </summary>
        public int limit { get; set; }
    }
}
