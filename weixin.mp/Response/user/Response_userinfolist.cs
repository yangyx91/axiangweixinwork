using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.mp.Response.user
{
    public class Response_userinfolist:Response_base
    {
        public List<Response_userinfo> user_info_list { get; set; }
    }
}
