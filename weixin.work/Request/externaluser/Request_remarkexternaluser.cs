using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Request.externaluser
{
    public class Request_remarkexternaluser
    {
        /// <summary>
        /// 企业成员的userid,必须
        /// </summary>
        public int userid { get; set; }
        /// <summary>
        /// 外部联系人userid,必须
        /// </summary>
        public int external_userid { get; set; }
        /// <summary>
        /// 此用户对外部联系人的备注，最多20个字符
        /// </summary>
        public int remark { get; set; }
        /// <summary>
        /// 此用户对外部联系人的描述，最多150个字符
        /// </summary>
        public int description { get; set; }
        /// <summary>
        /// 此用户对外部联系人备注的所属公司名称，最多20个字符
        /// </summary>
        public int remark_company { get; set; }
        /// <summary>
        /// 此用户对外部联系人备注的所属公司名称，最多20个字符
        /// </summary>
        public int remark_mobiles { get; set; }
        /// <summary>
        /// 备注图片的mediaid
        /// </summary>
        public int remark_pic_mediaid { get; set; }


    }
}
