using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace weixin.mp.Enums
{
    /// <summary>
    /// 性别枚举
    /// </summary>
    public enum genderEnums
    {
        /// <summary>
        /// 未知
        /// </summary>
        [Description("未知")]
        未知 = 0,
        /// <summary>
        /// 男性
        /// </summary>
        [Description("男性")]
        男性 = 1,
        /// <summary>
        /// 女性
        /// </summary>
        [Description("女性")]
        女性 = 2
    }
}
