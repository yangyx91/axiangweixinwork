using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace weixin.mp.Enums
{
    /// <summary>
    /// 用户关注的渠道来源
    /// </summary>
    public enum subscribesceneEnums
    {
        [Description("公众号搜索")]
        ADD_SCENE_SEARCH,
        [Description("公众号迁移")]
        ADD_SCENE_ACCOUNT_MIGRATION,
        [Description("名片分享")]
        ADD_SCENE_PROFILE_CARD,
        [Description("扫描二维码")]
        ADD_SCENE_QR_CODE,
        [Description("图文页内名称点击")]
        ADD_SCENE_PROFILE_LINK,
        [Description("图文页右上角菜单")]
        ADD_SCENE_PROFILE_ITEM,
        [Description("支付后关注")]
        ADD_SCENE_PAID,
        [Description("微信广告")]
        ADD_SCENE_WECHAT_ADVERTISEMENT,
        [Description("其他")]
        ADD_SCENE_OTHERS 
    }
}
