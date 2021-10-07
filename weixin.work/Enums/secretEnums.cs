using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace weixin.work.Enums
{
    /// <summary>
    /// 应用secret类型
    /// </summary>
    public enum secretEnums
    {
        /// <summary>
        /// 自建应用secret。在管理后台->“应用与小程序”->“应用”->“自建”，点进某个应用，即可看到。
        /// </summary>
        [Description("自建应用secret")]
        自建应用secret = 0, 
        /// <summary>
        /// 基础应用secret。某些基础应用（如“审批”“打卡”应用），支持通过API进行操作。在管理后台->“应用与小程序”->“应用->”“基础”，点进某个应用，点开“API”小按钮，即可看到。
        /// </summary>
        [Description("基础应用secret")]
        基础应用secret = 1,
        /// <summary>
        /// 通讯录管理secret。在“管理工具”-“通讯录同步”里面查看（需开启“API接口同步”）；
        /// </summary>
        [Description("通讯录管理secret")]
        通讯录管理secret = 2,
        /// <summary>
        /// 外部联系人/客户管理secret。在“客户联系”栏，点开“API”小按钮，即可看到。
        /// </summary>
        [Description("外部联系人/客户管理secret")]
        外部联系人secret = 3,
        /// <summary>
        /// 会话内容存档应用secret,在管理工具-会话内容存档，查看secret
        /// </summary>
        [Description("会话内容存档secret")]
        会话内容存档secret = 4
    }
}
