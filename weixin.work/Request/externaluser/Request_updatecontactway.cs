using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Request.externaluser
{
    public class Request_updatecontactway
    {
        /// <summary>
        /// 企业联系方式的配置id
        /// </summary>
        public string config_id { get; set; }

        /// <summary>
        /// 在小程序中联系时使用的控件样式，详见附表
        /// </summary>
        public int style { get; set; }

        /// <summary>
        /// 联系方式的备注信息，用于助记，不超过30个字符
        /// </summary>
        public string remark { get; set; }

        /// <summary>
        /// 外部客户添加时是否无需验证，默认为true
        /// </summary>
        public bool skip_verify { get; set; }
        /// <summary>
        /// 企业自定义的state参数，用于区分不同的添加渠道，在调用“获取外部联系人详情”时会返回该参数值，不超过30个字符
        /// </summary>
        public string state { get; set; }
        /// <summary>
        /// 使用该联系方式的用户userID列表，在type为1时为必填，且只能有一个
        /// </summary>
        public List<string> user { get; set; }
        /// <summary>
        /// 使用该联系方式的部门id列表，只在type为2时有效
        /// </summary>
        public List<int> party { get; set; }
        /// <summary>
        /// 临时会话二维码有效期，以秒为单位。该参数仅在is_temp为true时有效，默认7天，最多为14天
        /// </summary>
        public long expires_in { get; set; }
        /// <summary>
        /// 临时会话有效期，以秒为单位。该参数仅在is_temp为true时有效，默认为添加好友后24小时，最多为14天
        /// </summary>
        public long chat_expires_in { get; set; }
        /// <summary>
        /// 可进行临时会话的客户unionid，该参数仅在is_temp为true时有效，如不指定则不进行限制
        /// </summary>
        public string unionid { get; set; }
        /// <summary>
        /// 结束语，会话结束时自动发送给客户，可参考“结束语定义”，仅在is_temp为true时有效
        /// </summary>
        public object conclusions { get; set; }
    }
}
