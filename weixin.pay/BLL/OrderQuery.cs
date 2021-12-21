using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using weixin.pay.Tencent;

namespace weixin.pay.BLL
{
    public class OrderQuery
    {
        /***
        * 订单查询完整业务流程逻辑
        * @param transaction_id 微信订单号（优先使用）
        * @param out_trade_no 商户订单号
        * @return 订单查询结果（xml格式）
        */
        public async Task<WxPayData> Run(string out_trade_no)
        {
            WxPayData data = new WxPayData();
            if (!string.IsNullOrEmpty(out_trade_no))//微信订单号不存在，才根据商户订单号去查单
            {
                data.SetValue("out_trade_no", out_trade_no);
            }

            //提交订单查询请求给API，接收返回数据
            WxPayData result =await WxPayApi.OrderQuery(data);

            return result;
        }
    }
}
