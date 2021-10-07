using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Response.externaluser
{
    public class Response_addcontactway:Response_base
    {
        /// <summary>
        /// 新增联系方式的配置id
        /// </summary>
        public string config_id { get; set; }

        /// <summary>
        /// 联系我二维码链接，仅在scene为2时返回
        /// </summary>
        public string qr_code { get; set; }
    }
}
