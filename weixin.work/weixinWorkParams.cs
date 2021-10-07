using System;

namespace weixin.work
{
    /// <summary>
    /// 企业微信常用术语
    /// </summary>
    public class weixinWorkParams
    {
        /// <summary>
        /// 每个企业都拥有唯一的corpid，获取此信息可在管理后台“我的企业”－“企业信息”下查看“企业ID”（需要有管理员权限）
        /// </summary>
        public string corpid { get; set; }

        /// <summary>
        /// 每个成员都有唯一的userid，即所谓“帐号”。在管理后台->“通讯录”->点进某个成员的详情页，可以看到。
        /// </summary>
        public string userid { get; set; }

        /// <summary>
        /// 每个部门都有唯一的id，在管理后台->“通讯录”->“组织架构”->点击某个部门右边的小圆点可以看到
        /// </summary>
        public string departmentid { get; set; }

        /// <summary>
        /// 每个标签都有唯一的标签id，在管理后台->“通讯录”->“标签”，选中某个标签，在右上角会有“标签详情”按钮，点击即可看到
        /// </summary>
        public string tagid { get; set; }

        /// <summary>
        /// 每个应用都有唯一的agentid。在管理后台->“应用与小程序”->“应用”，点进某个应用，即可看到agentid。
        /// </summary>
        public string agentid { get; set; }

        /// <summary>
        /// secret是企业应用里面用于保障数据安全的“钥匙”，每一个应用都有一个独立的访问密钥
        /// </summary>
        public string secret { get; set; }

        /// <summary>
        /// access_token是企业后台去企业微信的后台获取信息时的重要票据，由corpid和secret产生。所有接口在通信时都需要携带此信息用于验证接口的访问权限
        /// </summary>
        public string access_token { get; set; }
    }
}
