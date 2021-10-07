using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Response.agent
{
    public class Response_agent:Response_base
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
        /// 企业应用方形头像
        /// </summary>
        public string square_logo_url { get; set; }

        /// <summary>
        /// 企业应用详情
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// 企业应用可见范围（人员），其中包括userid
        /// </summary>
        public allowuserinfo allow_userinfos { get; set; }

        /// <summary>
        /// 企业应用可见范围（部门）
        /// </summary>
        public allowparty allow_partys { get; set; }

        /// <summary>
        /// 企业应用可见范围（标签）
        /// </summary>
        public allowtag allow_tags { get; set; }

        /// <summary>
        /// 企业应用是否被停用
        /// </summary>
        public int close { get; set; }

        /// <summary>
        /// 企业应用可信域名
        /// </summary>
        public string redirect_domain { get; set; }

        /// <summary>
        /// 企业应用是否打开地理位置上报 0：不上报；1：进入会话上报；
        /// </summary>
        public int report_location_flag { get; set; }

        /// <summary>
        /// 是否上报用户进入应用事件。0：不接收；1：接收
        /// </summary>
        public int isreportenter { get; set; }

        /// <summary>
        /// 应用主页url
        /// </summary>
        public string home_url { get; set; }

        public class allowuserinfo
        {
            public List<userId> user { get; set; }
        }

        public class userId
        {
            public string userid { get; set; }
        }

        public class allowparty
        {
            public List<int> partyid { get; set; }
        }

        public class allowtag
        {
            public List<int> tagid { get; set; } 
        }
    }
}
