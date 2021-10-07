﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using weixin.work.Response.token;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            ///使用说明
            ///1、申明一个委托（获取Token=get）
            Func<Task<weixin.mp.Response.token.Response_gettoken>> funcGetWeiXinMPToken = () => new weixin.mp.BLL.gettoken("填写appid", "填写appsecret").get();
            ///从Cache里读取WeixinAccessToken，如不存在，则调用委托，写入后返回
            var weixinTokenResults = weixin.mp.Cache.tokenCache.GetOrAddAsync("weixinAccessToken", funcGetWeiXinMPToken).Result;

            ///可选，查询公众号有几个模板消息

            var templatelist = new weixin.mp.BLL.template(weixinTokenResults.access_token).getallprivatetemplate().Result;
            var item = templatelist.template_list;
            var template= item.Where(x => x.title.Trim() == "模板消息类型").FirstOrDefault();

            ///发送一个模板消息，可使用固定模板ID，和消息数据包DATA

            var send = new weixin.mp.BLL.template(weixinTokenResults.access_token).templatesendmessage(
                new weixin.mp.Request.template.Request_templatesendmessage()
                {
                    touser = "填写openid",
                    template_id = template.template_id,
                    url = "填写url",
                    miniprogram = null,
                    data = new
                    {
                        first = new { value = "填写first",color = "" },
                        keyword1 = new { value = "填写keyword1", color = "" },
                        keyword2 = new { value = "填写keyword2", color = "" },
                        keyword3 = new { value = "填写keyword3", color = "" },
                        keyword4 = new { value = "填写keyword4", color = "" },
                        remark = new { value = "填写remark", color = "" }
                    }
                }
                ).Result;

          

            //测试缓存获取值
            //diyTokenResults = weixin.work.Cache.tokenCache.GetOrAddAsync("diyAccessToken", funcGetDiyToken).Result;

            //externalUserTokenResult = weixin.work.Cache.tokenCache.GetOrAddAsync("externaluserAccessToken", funcGetExternalUserToken).Result;

            Console.WriteLine("Hello World!");
        }
    }
}
