using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using weixin.pay.Tencent;

namespace weixin.pay.BLL
{
    public class CloseOrder
    {
        /// <summary>
        /// 关闭微信支付订单
        /// </summary>
        /// <param name="out_trade_no"></param>
        /// <returns></returns>
        public async Task<WxPayData> Run(string out_trade_no)
        {
            WxPayData data = new WxPayData();
            if (!string.IsNullOrEmpty(out_trade_no))
            {
                data.SetValue("out_trade_no", out_trade_no);//商户订单号，优先级最低
            }

            WxPayData result = await WxPayApi.CloseOrder(data);//提交退款查询给API，接收返回数据
            return result;
        }
    }
}
