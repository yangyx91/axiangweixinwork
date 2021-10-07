using System;

namespace weixin.mp.BLL
{
    /// <summary>
    ///校验签名
    /// </summary>
    public static class checksignature
    { 
        /// <summary>
        /// 验证消息的确来自微信服务器
        /// </summary>
        /// <param name="signature">微信加密签名，signature结合了开发者填写的token参数和请求中的timestamp参数、nonce参数。</param>
        /// <param name="timestamp">时间戳</param>
        /// <param name="nonce">随机数</param>
        /// <param name="token">由开发者可以任意填写，用作生成签名</param>
        /// <returns></returns>
        public static bool Check(string signature, string timestamp, string nonce,string token)
        {
            return WXBizMsgCrypt.VerifySignature(token, timestamp, nonce, "", signature) == 0 ? true : false;
        }
    }
}
