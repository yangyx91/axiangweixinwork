using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace weixin.pay.Tencent
{
    public class WxPayApi
    {
        /**
        *    
        * 查询订单
        * @param WxPayData inputObj 提交给查询订单API的参数
        * @param int timeOut 超时时间
        * @throws Exception
        * @return 成功时返回订单查询结果，其他抛异常
        */
        public static async Task<WxPayData> OrderQuery(WxPayData inputObj)
        {
            //检测必填参数
            if (!inputObj.IsSet("out_trade_no") && !inputObj.IsSet("transaction_id"))
            {
                throw new Exception("订单查询接口中，out_trade_no、transaction_id至少填一个！");
            }

            inputObj.SetValue("appid", WxPayConfig.APPID);//公众账号ID
            inputObj.SetValue("mch_id", WxPayConfig.WxPay_Mch_ID);//商户号
            inputObj.SetValue("nonce_str", GenerateNonceStr());//随机字符串
            inputObj.SetValue("sign", inputObj.MakeSign(WxPayData.SIGN_TYPE_MD5));//签名
            string xml = inputObj.ToXml();  
            var response = await HttpHelper.HttpPost(WxPayConfig.Query_OrderURL, xml);//调用HTTP通信接口提交数据
            //将xml格式的数据转化为对象以返回
            WxPayData result = new WxPayData();
            result.FromXml(response);
            return result;
        }

        /**
        * 
        * 申请退款
        * @param WxPayData inputObj 提交给申请退款API的参数
        * @param int timeOut 超时时间
        * @throws Exception
        * @return 成功时返回接口调用结果，其他抛异常
        */
        public static async Task<WxPayData> Refund(WxPayData inputObj)
        {
            string url = "https://api.mch.weixin.qq.com/secapi/pay/refund";
            //检测必填参数
            if (!inputObj.IsSet("out_trade_no") && !inputObj.IsSet("transaction_id"))
            {
                throw new Exception("退款申请接口中，out_trade_no、transaction_id至少填一个！");
            }
            else if (!inputObj.IsSet("out_refund_no"))
            {
                throw new Exception("退款申请接口中，缺少必填参数out_refund_no！");
            }
            else if (!inputObj.IsSet("total_fee"))
            {
                throw new Exception("退款申请接口中，缺少必填参数total_fee！");
            }
            else if (!inputObj.IsSet("refund_fee"))
            {
                throw new Exception("退款申请接口中，缺少必填参数refund_fee！");
            }

            inputObj.SetValue("appid", WxPayConfig.APPID);//公众账号ID
            inputObj.SetValue("mch_id", WxPayConfig.WxPay_Mch_ID);//商户号
            inputObj.SetValue("nonce_str", GenerateNonceStr());//随机字符串
            inputObj.SetValue("sign", inputObj.MakeSign(WxPayData.SIGN_TYPE_MD5));//签名

            string xml = inputObj.ToXml();
            var response = await HttpHelper.HttpsPost(url, xml);//调用HTTP通信接口提交数据
            //将xml格式的数据转化为对象以返回
            WxPayData result = new WxPayData();
            result.FromXml(response);
            return result;
        }


        /**
	    * 
	    * 查询退款
	    * 提交退款申请后，通过该接口查询退款状态。退款有一定延时，
	    * 用零钱支付的退款20分钟内到账，银行卡支付的退款3个工作日后重新查询退款状态。
	    * out_refund_no、out_trade_no、transaction_id、refund_id四个参数必填一个
	    * @param WxPayData inputObj 提交给查询退款API的参数
	    * @param int timeOut 接口超时时间
	    * @throws Exception
	    * @return 成功时返回，其他抛异常
	    */
        public static async Task<WxPayData> RefundQuery(WxPayData inputObj)
        {
            string url = "https://api.mch.weixin.qq.com/pay/refundquery";
            //检测必填参数
            if (!inputObj.IsSet("out_refund_no") && !inputObj.IsSet("out_trade_no") &&
                !inputObj.IsSet("transaction_id") && !inputObj.IsSet("refund_id"))
            {
                throw new Exception("退款查询接口中，out_refund_no、out_trade_no、transaction_id、refund_id四个参数必填一个！");
            }

            inputObj.SetValue("appid", WxPayConfig.APPID);//公众账号ID
            inputObj.SetValue("mch_id", WxPayConfig.WxPay_Mch_ID);//商户号
            inputObj.SetValue("nonce_str", GenerateNonceStr());//随机字符串
            inputObj.SetValue("sign", inputObj.MakeSign(WxPayData.SIGN_TYPE_MD5));//签名

            string xml = inputObj.ToXml();
            var response = await HttpHelper.HttpPost(url, xml);//调用HTTP通信接口提交数据
            //将xml格式的数据转化为对象以返回
            WxPayData result = new WxPayData();
            result.FromXml(response);
            return result;
        }


        /**
        * 下载对账单
        * @param WxPayData inputObj 提交给下载对账单API的参数
        * @param int timeOut 接口超时时间
        * @throws Exception
        * @return 成功时返回，其他抛异常
        */
        public static async Task<WxPayData> DownloadBill(WxPayData inputObj)
        {
            string url = "https://api.mch.weixin.qq.com/pay/downloadbill";
            //检测必填参数
            if (!inputObj.IsSet("bill_date"))
            {
                throw new Exception("对账单接口中，缺少必填参数bill_date！");
            }

            inputObj.SetValue("appid", WxPayConfig.APPID);//公众账号ID
            inputObj.SetValue("mch_id", WxPayConfig.WxPay_Mch_ID);//商户号
            inputObj.SetValue("nonce_str", GenerateNonceStr());//随机字符串
            inputObj.SetValue("sign", inputObj.MakeSign(WxPayData.SIGN_TYPE_MD5));//签名

            string xml = inputObj.ToXml();
            var response = await HttpHelper.HttpPost(url, xml);//调用HTTP通信接口提交数据
            WxPayData result = new WxPayData();
            //若接口调用失败会返回xml格式的结果
            if (response.Substring(0, 5) == "<xml>")
            {
                result.FromXml(response);
            }
            //接口调用成功则返回非xml格式的数据
            else
                result.SetValue("result", response);

            return result;
        }


        /**
	    * 
	    * 转换短链接
	    * 该接口主要用于扫码原生支付模式一中的二维码链接转成短链接(weixin://wxpay/s/XXXXXX)，
	    * 减小二维码数据量，提升扫描速度和精确度。
	    * @param WxPayData inputObj 提交给转换短连接API的参数
	    * @param int timeOut 接口超时时间
	    * @throws Exception
	    * @return 成功时返回，其他抛异常
	    */
        public static async Task<WxPayData> ShortUrl(WxPayData inputObj)
        {
            string url = "https://api.mch.weixin.qq.com/tools/shorturl";
            //检测必填参数
            if (!inputObj.IsSet("long_url"))
            {
                throw new Exception("需要转换的URL，签名用原串，传输需URL encode！");
            }

            inputObj.SetValue("appid", WxPayConfig.APPID);//公众账号ID
            inputObj.SetValue("mch_id", WxPayConfig.WxPay_Mch_ID);//商户号
            inputObj.SetValue("nonce_str", GenerateNonceStr());//随机字符串	
            inputObj.SetValue("sign", inputObj.MakeSign(WxPayData.SIGN_TYPE_MD5));//签名
            string xml = inputObj.ToXml();
            var response = await HttpHelper.HttpPost(url, xml);//调用HTTP通信接口提交数据
            WxPayData result = new WxPayData();
            result.FromXml(response);
            return result;
        }


        /**
        * 
        * 统一下单
        * @param WxPaydata inputObj 提交给统一下单API的参数
        * @param int timeOut 超时时间
        * @throws Exception
        * @return 成功时返回，其他抛异常
        */
        public static async Task<WxPayData> UnifiedOrder(WxPayData inputObj)
        {
            //检测必填参数
            if (!inputObj.IsSet("out_trade_no"))
            {
                throw new Exception("缺少统一支付接口必填参数out_trade_no！");
            }
            else if (!inputObj.IsSet("body"))
            {
                throw new Exception("缺少统一支付接口必填参数body！");
            }
            else if (!inputObj.IsSet("total_fee"))
            {
                throw new Exception("缺少统一支付接口必填参数total_fee！");
            }
            else if (!inputObj.IsSet("trade_type"))
            {
                throw new Exception("缺少统一支付接口必填参数trade_type！");
            }

            //关联参数
            if (inputObj.GetValue("trade_type").ToString() == "JSAPI" && !inputObj.IsSet("openid"))
            {
                throw new Exception("统一支付接口中，缺少必填参数openid！trade_type为JSAPI时，openid为必填参数！");
            }
            if (inputObj.GetValue("trade_type").ToString() == "NATIVE" && !inputObj.IsSet("product_id"))
            {
                throw new Exception("统一支付接口中，缺少必填参数product_id！trade_type为JSAPI时，product_id为必填参数！");
            }

            //异步通知url未设置，则使用配置文件中的url
            if (!inputObj.IsSet("notify_url"))
            {
                inputObj.SetValue("notify_url", WxPayConfig.WxPay_Notifyurl);//异步通知url
            }

            inputObj.SetValue("appid", WxPayConfig.APPID);//公众账号ID
            inputObj.SetValue("mch_id", WxPayConfig.WxPay_Mch_ID);//商户号
            inputObj.SetValue("spbill_create_ip", WxPayConfig.WxPay_IP);//终端ip	  	    
            inputObj.SetValue("nonce_str", GenerateNonceStr());//随机字符串
            inputObj.SetValue("sign", inputObj.MakeSign(WxPayData.SIGN_TYPE_MD5)); //签名
            string xml = inputObj.ToXml();
            var response =await HttpHelper.HttpPost(WxPayConfig.Unified_OrderURL, xml);//调用HTTP通信接口提交数据
            WxPayData result = new WxPayData();
            result.FromXml(response);
            return result;
        }


        /**
	    * 
	    * 关闭订单
	    * @param WxPayData inputObj 提交给关闭订单API的参数
	    * @param int timeOut 接口超时时间
	    * @throws Exception
	    * @return 成功时返回，其他抛异常
	    */
        public static async Task<WxPayData> CloseOrder(WxPayData inputObj, int timeOut = 6)
        {
            string url = "https://api.mch.weixin.qq.com/pay/closeorder";
            //检测必填参数
            if (!inputObj.IsSet("out_trade_no"))
            {
                throw new Exception("关闭订单接口中，out_trade_no必填！");
            }

            inputObj.SetValue("appid", WxPayConfig.APPID);//公众账号ID
            inputObj.SetValue("mch_id", WxPayConfig.WxPay_Mch_ID);//商户号
            inputObj.SetValue("nonce_str", GenerateNonceStr());//随机字符串		
            inputObj.SetValue("sign", inputObj.MakeSign(WxPayData.SIGN_TYPE_MD5));//签名
            string xml = inputObj.ToXml();
            var response = await HttpHelper.HttpPost(url, xml);//调用HTTP通信接口提交数据
            WxPayData result = new WxPayData();
            result.FromXml(response);
            return result;
        }


        /**
        * 根据当前系统时间加随机序列来生成订单号
         * @return 订单号
        */
        public static string GenerateOutTradeNo()
        {
            var ran = new Random();
            return string.Format("{0}{1}{2}", WxPayConfig.WxPay_Mch_ID, DateTime.Now.ToString("yyyyMMddHHmmss"), ran.Next(999));
        }

        /**
        * 生成时间戳，标准北京时间，时区为东八区，自1970年1月1日 0点0分0秒以来的秒数
         * @return 时间戳
        */
        public static string GenerateTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        /**
        * 生成随机串，随机串包含字母或数字
        * @return 随机串
        */
        public static string GenerateNonceStr()
        {
            RandomGenerator randomGenerator = new RandomGenerator();
            return randomGenerator.GetRandomUInt().ToString();
        }
    }
}
