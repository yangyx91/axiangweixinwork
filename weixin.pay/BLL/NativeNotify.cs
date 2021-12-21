using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using weixin.pay.Tencent;

namespace weixin.pay.BLL
{
    public class NativeNotify
    {
        /// <summary>
        /// 接收从微信支付后台发送过来的数据并验证签名
        /// </summary>
        /// <returns>微信支付后台返回的数据</returns>
        public WxPayData GetNotifyData(Stream InputStream)
        {
            //接收从微信后台POST过来的数据
            System.IO.Stream s = InputStream;
            int count = 0;
            byte[] buffer = new byte[1024];
            StringBuilder builder = new StringBuilder();
            while ((count = s.Read(buffer, 0, 1024)) > 0)
            {
                builder.Append(Encoding.UTF8.GetString(buffer, 0, count));
            }
            s.Flush();
            s.Close();
            s.Dispose();

            //转换数据格式并验证签名
            WxPayData data = new WxPayData();
            try
            {
                data.FromXml(builder.ToString());
            }
            catch (Exception ex)
            {
                //若签名错误，则立即返回结果给微信支付后台
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", ex.Message);
            }
            return data;
        }

        public async Task<string> ProcessNotify(Stream InputStream)
        {
            WxPayData notifyData = GetNotifyData(InputStream);

            //检查openid和product_id是否返回
            if (!notifyData.IsSet("openid") || !notifyData.IsSet("product_id"))
            {
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "回调数据异常");
                return res.ToXml();
            }

            //调统一下单接口，获得下单结果
            string openid = notifyData.GetValue("openid").ToString();
            string product_id = notifyData.GetValue("product_id").ToString();
            WxPayData unifiedOrderResult = new WxPayData();
            try
            {
                unifiedOrderResult =await UnifiedOrder(openid, product_id);
            }
            catch (Exception ex)//若在调统一下单接口时抛异常，立即返回结果给微信支付后台
            {
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "统一下单失败");
                return res.ToXml();
            }

            //若下单失败，则立即返回结果给微信支付后台
            if (!unifiedOrderResult.IsSet("appid") || !unifiedOrderResult.IsSet("mch_id") || !unifiedOrderResult.IsSet("prepay_id"))
            {
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "统一下单失败");
                return res.ToXml();
            }

            //统一下单成功,则返回成功结果给微信支付后台
            WxPayData data = new WxPayData();
            data.SetValue("return_code", "SUCCESS");
            data.SetValue("return_msg", "OK");
            data.SetValue("appid", WxPayConfig.APPID);
            data.SetValue("mch_id", WxPayConfig.WxPay_Mch_ID);
            data.SetValue("nonce_str", WxPayApi.GenerateNonceStr());
            data.SetValue("prepay_id", unifiedOrderResult.GetValue("prepay_id"));
            data.SetValue("result_code", "SUCCESS");
            data.SetValue("err_code_des", "OK");
            data.SetValue("sign", data.MakeSign());
            return data.ToXml();
        }

        private async Task<WxPayData> UnifiedOrder(string openId, string productId)
        {
            //统一下单
            WxPayData req = new WxPayData();
            req.SetValue("body", "test");
            req.SetValue("attach", "test");
            req.SetValue("out_trade_no", WxPayApi.GenerateOutTradeNo());
            req.SetValue("total_fee", 1);
            req.SetValue("time_start", DateTime.Now.ToString("yyyyMMddHHmmss"));
            req.SetValue("time_expire", DateTime.Now.AddMinutes(10).ToString("yyyyMMddHHmmss"));
            req.SetValue("goods_tag", "test");
            req.SetValue("trade_type", "NATIVE");
            req.SetValue("openid", openId);
            req.SetValue("product_id", productId);
            WxPayData result =await WxPayApi.UnifiedOrder(req);
            return result;
        }
    }
}
