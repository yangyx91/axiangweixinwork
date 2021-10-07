using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Enums
{
    /// <summary>
    /// 添加客户的来源，有固定的值
    /// </summary>
    public enum externaluseraddwayEnums
    {
        /// <summary>
        /// 未知来源
        /// </summary>
        未知来源 = 0,
        /// <summary>
        /// 扫描二维码
        /// </summary>
        扫描二维码 = 1,
        /// <summary>
        /// 搜索手机号
        /// </summary>
        搜索手机号 = 2,
        /// <summary>
        /// 名片分享
        /// </summary>
        名片分享 = 3,
        /// <summary>
        /// 群聊
        /// </summary>
        群聊 = 4,
        /// <summary>
        /// 手机通讯录
        /// </summary>
        手机通讯录 = 5,
        /// <summary>
        /// 微信联系人
        /// </summary>
        微信联系人 = 6,
        /// <summary>
        /// 来自微信的添加好友申请
        /// </summary>
        来自微信的添加好友申请 = 7,
        /// <summary>
        /// 安装第三方应用时自动添加的客服人员
        /// </summary>
        安装第三方应用时自动添加的客服人员 = 8,
        /// <summary>
        /// 搜索邮箱
        /// </summary>
        搜索邮箱 = 9,
        /// <summary>
        /// 内部成员共享
        /// </summary>
        内部成员共享 = 201,
        /// <summary>
        /// 管理员负责人分配
        /// </summary>
        管理员负责人分配 = 202
    }
}
