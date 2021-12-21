using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using weixin.pay.Tencent;

namespace weixin.pay.BLL
{
    public class DownloadBill
    {
        /***
         * 下载对账单完整业务流程逻辑
         * @param bill_date 下载对账单的日期（格式：20140603，一次只能下载一天的对账单）
         * @param bill_type 账单类型
         *      ALL，返回当日所有订单信息，默认值 
         *      SUCCESS，返回当日成功支付的订单 
         *      REFUND，返回当日退款订单 
         *      REVOKED，已撤销的订单 
         * @return 对账单结果（xml格式）
         */
        public async Task<string> Run(string bill_date, string bill_type)
        {
            WxPayData data = new WxPayData();
            data.SetValue("bill_date", bill_date);//账单日期
            data.SetValue("bill_type", bill_type);//账单类型
            WxPayData result =await WxPayApi.DownloadBill(data);//提交下载对账单请求给API，接收返回结果
            return result.ToPrintStr();
        }
    }
}
