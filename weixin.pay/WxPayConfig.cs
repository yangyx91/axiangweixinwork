using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.pay
{
    public class WxPayConfig
    {
        //商户号
        public static readonly string APPID = "";//微信appId
        public static readonly string APPSecret = "";//微信Secret
        public static readonly string WxPay_Mch_ID = "";//微信支付商户号
        public static readonly string WxPay_Key = "";//商户平台 API安全里面设置的KEY  32位长度 
        public static readonly string Unified_OrderURL = "https://api.mch.weixin.qq.com/pay/unifiedorder";//微信支付Api
        
        public static readonly string WxPay_IP = "192.168.2.38";//服务器ID
        public static readonly string WxPay_Notifyurl = "https://example.com/CallBack/WeChatNotify";//微信支付后的通知/回调地址
    }
}
