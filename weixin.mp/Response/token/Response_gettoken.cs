using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.mp.Response.token
{
    public class Response_gettoken:Response_base
    {
        /// <summary>
        /// 获取到的凭证，最长为512字节,正常情况下为7200秒（2小时），有效期内重复获取返回相同结果，过期后获取会返回新的access_token。
        /// </summary>
        public string access_token { get; set; }

        /// <summary>
        /// 凭证的有效时间（秒）
        /// </summary>
        public int expires_in { get; set; }
    }
}
