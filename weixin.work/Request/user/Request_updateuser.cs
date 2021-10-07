using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Request.user
{
    public class Request_updateuser
    {
        /// <summary>
        /// 成员UserID。对应管理端的帐号
        /// </summary>
        public string userid { get; set; }
        /// <summary>
        ///成员名称； 第三方不可获取，调用时返回userid以代替name；代开发自建应用需要管理员授权才返回
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 手机号码，代开发自建应用需要管理员授权才返回；第三方仅通讯录应用可获取；对于非第三方创建的成员，第三方通讯录应用也不可获取
        /// </summary>
        public string mobile { get; set; }
        /// <summary>
        /// 成员所属部门id列表，仅返回该应用有查看权限的部门id
        /// </summary>
        public List<int> department { get; set; }

        /// <summary>
        /// 部门内的排序值，默认为0。数量必须和department一致，数值越大排序越前面。值范围是[0, 2^32)
        /// </summary>
        public List<int> order { get; set; }

        /// <summary>
        /// 职务信息；代开发自建应用需要管理员授权才返回；第三方仅通讯录应用可获取；对于非第三方创建的成员，第三方通讯录应用也不可获取
        /// </summary>
        public string position { get; set; }

        /// <summary>
        /// 性别。0表示未定义，1表示男性，2表示女性
        /// </summary>
        public string gender { get; set; }
        /// <summary>
        /// 邮箱，代开发自建应用需要管理员授权才返回；第三方仅通讯录应用可获取；对于非第三方创建的成员，第三方通讯录应用也不可获取
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// 表示在所在的部门内是否为上级。0-否；1-是。是一个列表，数量必须与department一致。第三方仅通讯录应用可获取；对于非第三方创建的成员，第三方通讯录应用也不可获取
        /// </summary>
        public List<string> is_leader_in_dept { get; set; }
        /// <summary>
        /// 成员头像的mediaid，通过素材管理接口上传图片获得的mediaid
        /// https://open.work.weixin.qq.com/api/doc/90000/90135/90197#10112
        /// </summary>
        public string avatar_mediaid { get; set; }
        /// <summary>
        /// 启用/禁用成员。1表示启用成员，0表示禁用成员
        /// </summary>
        public int enable { get; set; }
        /// <summary>
        /// 座机。代开发自建应用需要管理员授权才返回；第三方仅通讯录应用可获取；对于非第三方创建的成员，第三方通讯录应用也不可获取
        /// </summary>
        public string telephone { get; set; }
        /// <summary>
        /// 别名；第三方仅通讯录应用可获取；对于非第三方创建的成员，第三方通讯录应用也不可获取
        /// </summary>
        public string alias { get; set; }
        /// <summary>
        /// 扩展属性，代开发自建应用需要管理员授权才返回；第三方仅通讯录应用可获取；对于非第三方创建的成员，第三方通讯录应用也不可获取
        /// </summary>
        public object extattr { get; set; }
        /// <summary>
        /// 成员对外属性，字段详情见对外属性；代开发自建应用需要管理员授权才返回；第三方仅通讯录应用可获取；对于非第三方创建的成员，第三方通讯录应用也不可获取
        /// </summary>
        public string external_profile { get; set; }
        /// <summary>
        /// 对外职务，如果设置了该值，则以此作为对外展示的职务，否则以position来展示。代开发自建应用需要管理员授权才返回；第三方仅通讯录应用可获取；对于非第三方创建的成员，第三方通讯录应用也不可获取
        /// </summary>
        public int external_position { get; set; }

        /// <summary>
        /// 地址。代开发自建应用需要管理员授权才返回；第三方仅通讯录应用可获取；对于非第三方创建的成员，第三方通讯录应用也不可获取
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// 主部门
        /// </summary>
        public int main_department { get; set; }
    }
}
