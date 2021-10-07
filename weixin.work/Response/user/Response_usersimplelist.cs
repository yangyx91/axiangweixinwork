using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Response.user
{
    public class Response_usersimplelist : Response_base
    {
        /// <summary>
        /// 成员列表
        /// </summary>
        public List<userSimpleDetail> userlist { get; set; }

        public class userSimpleDetail
        {
            /// <summary>
            /// 成员UserID。对应管理端的帐号
            /// </summary>
            public string userid { get; set; }
            /// <summary>
            /// 成员名称，代开发自建应用需要管理员授权才返回；此字段从2019年12月30日起，对新创建第三方应用不再返回真实name，使用userid代替name
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// 成员所属部门列表。列表项为部门ID，32位整型
            /// </summary>
            public List<int> department { get; set; }
            /// <summary>
            /// 全局唯一。对于同一个服务商，不同应用获取到企业内同一个成员的open_userid是相同的，最多64个字节。仅第三方应用可获取
            /// </summary>
            public string open_userid { get; set; }
        }
    }
}
