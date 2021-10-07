using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Response.message
{
    public class Response_sendmsg:Response_base
    {
        /// <summary>
        /// 消息id，用于撤回应用消息
        /// </summary>
        public string msgid { get; set; }
        /// <summary>
        /// 仅消息类型为“按钮交互型”，“投票选择型”和“多项选择型”的模板卡片消息返回，应用可使用response_code调用更新模版卡片消息接口，24小时内有效，且只能使用一次
        /// </summary>
        public string response_code { get; set; }
        /// <summary>
        /// 不合法的userid，不区分大小写，统一转为小写,多个用‘|’分隔
        /// </summary>
        public string invaliduser { get; set; }
        /// <summary>
        /// 不合法的partyid,多个用‘|’分隔
        /// </summary>
        public string invalidparty { get; set; }
        /// <summary>
        /// 不合法的标签id,多个用‘|’分隔
        /// </summary>
        public string invalidtag { get; set; }
    }
}
