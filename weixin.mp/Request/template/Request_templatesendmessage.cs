using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.mp.Request.template
{
    public class Request_templatesendmessage
    {
        /// <summary>
        /// 接收者openid
        /// </summary>
        public string touser { get; set; }
        /// <summary>
        /// 模板ID
        /// </summary>
        public string template_id { get; set; }
        /// <summary>
        /// 模板跳转链接（海外帐号没有跳转能力）
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 模板数据
        ///示例:{"first": {"value":"恭喜你购买成功！","color":"#173177"},"keyword1":{"value":"巧克力","color":"#173177"},"remark":{"value":"欢迎再次购买！","color":"#173177" }}
        ///</summary>
        public object data { get; set; }

        /// <summary>
        /// （可选）,跳小程序所需数据，不需跳小程序可不用传该数据
        /// </summary>
        public miniprogramattr miniprogram { get; set; }

        public class miniprogramattr
        {
            /// <summary>
            /// 所需跳转到的小程序appid（该小程序appid必须与发模板消息的公众号是绑定关联关系，暂不支持小游戏）
            /// </summary>
            public string appid { get; set; }
            /// <summary>
            /// 所需跳转到小程序的具体页面路径，支持带参数,（示例index?foo=bar），要求该小程序已发布，暂不支持小游戏
            /// </summary>
            public string pagepath { get; set; }
        }
    }
}
