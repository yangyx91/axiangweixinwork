using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using weixin.pay.Tencent;

namespace weixin.pay.BLL
{
    public class AppPay
    {
        /**
        * 微信生成的预支付会话标识，用于后续接口调用中使用，该值有效期为2小时
        */
        public async Task<string> GetPrePayUrl(string out_trade_no, double total_amount, string subject)
        {
            WxPayData data = new WxPayData();
            data.SetValue("body", subject);//商品描述
            data.SetValue("attach", subject);//附加数据
            data.SetValue("out_trade_no", out_trade_no);//随机字符串
            data.SetValue("total_fee", Convert.ToInt32(total_amount * 100));
            //总金额,单位：分
            //data.SetValue("time_start", DateTime.Now.ToString("yyyyMMddHHmmss"));//交易起始时间
            //data.SetValue("time_expire", DateTime.Now.AddMinutes(10).ToString("yyyyMMddHHmmss"));//交易结束时间
            data.SetValue("trade_type", "APP");//交易类型
            WxPayData result = await WxPayApi.UnifiedOrder(data);//调用统一下单接口
            if (result != null && result.IsSet("prepay_id"))
            {
                string prepay_id = result.GetValue("prepay_id").ToString();
                //获得微信生成的预支付会话标识
                return prepay_id;
            }
            return "";
        }

        public async Task<WxPayData> GetPayJson(string prepay_id)
        { 
            WxPayData data = new WxPayData(); 
            data.SetValue("appid", WxPayConfig.APPID);//公众帐号id
            data.SetValue("partnerid", WxPayConfig.WxPay_Mch_ID);//商户号
            data.SetValue("time_stamp", WxPayApi.GenerateTimeStamp());//时间戳
            data.SetValue("nonce_str", WxPayApi.GenerateNonceStr());//随机字符串
            data.SetValue("package", WxPayConfig.WxPay_PackageValue);//扩展字段
            data.SetValue("prepayid", prepay_id);//微信返回的支付交易会话ID
            data.SetValue("sign", data.MakeSign(WxPayData.SIGN_TYPE_MD5));//签名
            return data;
        }

        /*示例
       {
         "appid": "wx499********7c70e",  // 应用ID（AppID）
         "partnerid": "148*****52",      // 商户号（PartnerID）
         "prepayid": "wx202254********************fbe90000", // 预支付交易会话ID
         "package": "Sign=WXPay",        // 固定值
         "noncestr": "c5sEwbaNPiXAF3iv", // 随机字符串
         "timestamp": 1597935292,        // 时间戳（单位：秒）
         "sign": "A842B45937F6EFF60DEC7A2EAA52D5A0" // 签名，这里用的 MD5 签名
       }
       */
    }
}

