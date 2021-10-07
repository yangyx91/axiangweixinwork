using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Request.externaluser
{
    public class Request_getbyuser
    {
        /// <summary>
        /// 企业成员的userid列表，字符串类型，最多支持100个
        /// </summary>
        public List<string> userid_list { get; set; }
        /// <summary>
        /// 用于分页查询的游标，字符串类型，由上一次调用返回，首次调用可不填
        /// </summary>
        public string cursor { get; set; }
        /// <summary>
        /// 返回的最大记录数，整型，最大值100，默认值50，超过最大值时取最大值
        /// </summary>
        public int limit { get; set; }
    }
}
