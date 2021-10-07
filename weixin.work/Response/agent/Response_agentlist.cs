using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Response.agent
{
    public class Response_agentlist:Response_base
    {
        /// <summary>
        /// 当前凭证可访问的应用列表
        /// </summary>
        public List<agentitem> agentlist { get; set; }

        public class agentitem
        {
            /// <summary>
            /// 企业应用id
            /// </summary>
            public int agentid { get; set; }
            /// <summary>
            /// 企业应用名称
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// 企业应用方形头像url
            /// </summary>
            public string square_logo_url { get; set; }
        }
    }
}
