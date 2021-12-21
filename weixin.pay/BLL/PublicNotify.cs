using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using weixin.pay.Tencent;

namespace weixin.pay.BLL
{
    public class PublicNotify
    {
        /// <summary>
        /// 接收从微信支付后台发送过来的数据并验证签名
        /// </summary>
        /// <returns>微信支付后台返回的数据</returns>
        public WxPayData GetNotifyData(string xml)
        {
            //转换数据格式并验证签名
            WxPayData data = new WxPayData();
            try
            {
                data.FromXml(xml);
            }
            catch (Exception ex)
            {
                //若签名错误，则立即返回结果给微信支付后台
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", ex.Message);
                return res;
            }
            return data;
        }

        public async Task<WxPayData> ProcessNotify(string xml)
        {
            WxPayData notifyData = GetNotifyData(xml);

            //检查支付结果中transaction_id是否存在
            if (!notifyData.IsSet("transaction_id"))
            {
                //若transaction_id不存在，则立即返回结果给微信支付后台
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "支付结果中微信订单号不存在");
                return res;
            }

            string transaction_id = notifyData.GetValue("transaction_id").ToString();

            //查询订单，判断订单付款是否成功
            if (!await QueryOrder(transaction_id))
            {
                //若订单查询失败，则立即返回结果给微信支付后台
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "订单查询失败");
                return res;
            }
            //查询订单成功
            else
            {
                notifyData.SetValue("trade_state", "SUCCESS");
                return notifyData;
            }
        }

        //查询订单
        private async Task<bool> QueryOrder(string transaction_id)
        {
            WxPayData req = new WxPayData();
            req.SetValue("transaction_id", transaction_id);
            WxPayData res =await WxPayApi.OrderQuery(req);
            if (res.GetValue("return_code").ToString() == "SUCCESS" 
                && res.GetValue("result_code").ToString() == "SUCCESS"
                && res.GetValue("trade_state").ToString() == "SUCCESS"
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
