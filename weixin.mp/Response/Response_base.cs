using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.mp.Response
{
    public class Response_base
    {
        /// <summary>
        /// 出错返回码，为0表示成功，非0表示调用失败
        /// </summary>
        public int errcode { get; set; }

        /// <summary>
        /// 返回码提示语
        /// </summary>
        public string errmsg { get; set; }
    }
}
