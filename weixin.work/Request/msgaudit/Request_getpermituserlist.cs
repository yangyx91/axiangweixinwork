using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Request.msgaudit
{
    public class Request_getpermituserlist
    {
        /// <summary>
        /// 拉取对应版本的开启成员列表。1表示办公版；2表示服务版；3表示企业版。非必填，不填写的时候返回全量成员列表。
        /// </summary>
        public int type { get; set; }
    }
}
