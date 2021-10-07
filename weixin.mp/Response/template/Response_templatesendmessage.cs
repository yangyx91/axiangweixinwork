using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.mp.Response.template
{
    public class Response_templatesendmessage:Response_base
    {
        /// <summary>
        /// 模板消息ID
        /// </summary>
        public string msgid { get; set; }
    }
}
