using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.BLL
{
    /// <summary>
    ///校验签名
    /// </summary>
    public static class checksignature
    {
        /// <summary>
        /// 请求验证URL有效性。GET请求
        /// 1、对收到的请求，解析上述的各个参数值（参数值需要做Urldecode处理）
        /// 2、根据已有的token，结合第1步获取的参数timestamp, nonce, echostr重新计算签名，然后与参数msg_signature检查是否一致，确认调用者的合法性。计算方法参考：消息体签名检验
        ///3、解密echostr参数得到消息内容（即msg字段）
        ///4、在1秒内响应GET请求，响应内容为上一步得到的明文消息内容（不能加引号，不能带bom头，不能带换行符）
        /// </summary>
        ///<param name="msg_signature">企业微信加密签名，msg_signature计算结合了企业填写的token、请求中的timestamp、nonce、加密的消息体</param>
        ///<param name="timestamp">时间戳。与nonce结合使用，用于防止请求重放攻击。</param>
        ///<param name="nonce">随机数。与timestamp结合使用，用于防止请求重放攻击。</param>
        ///<param name="echostr">加密的字符串。需要解密得到消息内容明文，解密后有random、msg_len、msg、receiveid四个字段，其中msg即为消息内容明文</param>
        ///<param name="token">由开发者可以任意填写，用作生成签名</param>
        ///<param name="encodingKey">用于消息体的加密，长度固定为43个字符，从a-z, A-Z, 0-9共62个字符中选取，是AESKey的Base64编码</param>
        ///<param name="receiveId">加解密库里，ReceiveId 在各个场景的含义不同：1,企业应用的回调，表示corpid；2,第三方事件的回调，表示suiteid</param>
        /// <returns></returns>
        public static string Check(string msg_signature, string timestamp, string nonce,string echostr,string token, string encodingKey, string receiveId)
        {
            var sReplyEchoStr = "";
            var wXBizMsgCrypt = new WXBizMsgCrypt(token, encodingKey, receiveId);
            wXBizMsgCrypt.VerifyURL(msg_signature, timestamp, nonce, echostr, ref sReplyEchoStr);
            return sReplyEchoStr;
        }

        /// <summary>
        /// 请求验证URL有效性。
        /// 1、对收到的请求，解析上述的各个参数值（参数值需要做Urldecode处理）
        /// 2、根据已有的token，结合第1步获取的参数timestamp, nonce, echostr重新计算签名，然后与参数msg_signature检查是否一致，确认调用者的合法性。计算方法参考：消息体签名检验
        ///3、解密echostr参数得到消息内容（即msg字段）
        ///4、在1秒内响应GET请求，响应内容为上一步得到的明文消息内容（不能加引号，不能带bom头，不能带换行符）
        /// </summary>
        ///<param name="msg_signature">企业微信加密签名，msg_signature计算结合了企业填写的token、请求中的timestamp、nonce、加密的消息体</param>
        ///<param name="timestamp">时间戳。与nonce结合使用，用于防止请求重放攻击。</param>
        ///<param name="nonce">随机数。与timestamp结合使用，用于防止请求重放攻击。</param>
        ///<param name="echostr">加密的字符串。需要解密得到消息内容明文，解密后有random、msg_len、msg、receiveid四个字段，其中msg即为消息内容明文</param>
        ///<param name="token">由开发者可以任意填写，用作生成签名</param>
        /// <returns></returns>
        public static bool Check(string msg_signature, string timestamp, string nonce, string echostr, string token)
        {
            return WXBizMsgCrypt.VerifySignature(token, timestamp, nonce, echostr, msg_signature) == 0?true:false;
        }
    }
}
