using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.mp.Request.user
{
    public class Request_userinfolist
    {
        public List<userOpenId> user_list { get; set; }

        public class userOpenId
        {
            /// <summary>
            /// 用户的标识，对当前公众号唯一
            /// </summary>
            public string openid { get; set; }

        }
    }
}
