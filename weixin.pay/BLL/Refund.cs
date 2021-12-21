using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using weixin.pay.Tencent;

namespace weixin.pay.BLL
{
    public class Refund
    {
        /***
        * 申请退款完整业务流程逻辑
        * @param transaction_id 微信订单号（优先使用）
        * @param out_trade_no 商户订单号
        * @param total_fee 订单总金额
        * @param refund_fee 退款金额
        * @return 退款结果（xml格式）
        */
        public async Task<WxPayData> Run(string transaction_id, string out_trade_no, double total_fee, double refund_fee)
        {
            WxPayData data = new WxPayData();
            if (!string.IsNullOrEmpty(transaction_id))//微信订单号存在的条件下，则已微信订单号为准
            {
                data.SetValue("transaction_id", transaction_id);
            }
            else//微信订单号不存在，才根据商户订单号去退款
            {
                data.SetValue("out_trade_no", out_trade_no);
            }

            data.SetValue("total_fee", Convert.ToInt32(total_fee*100));//订单总金额
            data.SetValue("refund_fee", Convert.ToInt32(refund_fee*100));//退款金额
            data.SetValue("out_refund_no", WxPayApi.GenerateOutTradeNo());//随机生成商户退款单号
            data.SetValue("refund_desc", "其他");//退款原因
            WxPayData result =await WxPayApi.Refund(data);//提交退款申请给API，接收返回数据
            return result;
        }
    }
}
