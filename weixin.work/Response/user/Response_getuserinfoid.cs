using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Response.user
{
    public class Response_getuserinfoid:Response_base
    {
        /// <summary>
        /// 当用户为企业成员时（无论是否在应用可见范围之内）。
        /// 成员UserID。若需要获得用户详情信息，可调用通讯录接口：读取成员
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 手机设备号(由企业微信在安装时随机生成，删除重装会改变，升级不受影响)
        /// </summary>
        public string DeviceId { get; set; }

        /// <summary>
        /// 非企业成员的标识，对当前企业唯一。不超过64字节
        /// </summary>
        public string OpenId { get; set; }

        /// <summary>
        /// 外部联系人id，当且仅当用户是企业的客户，且跟进人在应用的可见范围内时返回。如果是第三方应用调用，针对同一个客户，同一个服务商不同应用获取到的id相同
        /// </summary>
        public string external_userid { get; set; }
    }
}
