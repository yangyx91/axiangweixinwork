using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace weixin.work.BLL
{
    /// <summary>
    /// 企业微信在推送消息给企业时，会对消息内容做AES加密，以XML格式POST到企业应用的URL上。
    /// 企业在被动响应时，也需要对数据加密，以XML格式返回给企业微信。
    /// </summary>
    public static class encryptdecrypt
    {
        /// <summary>
        /// 签名校验+解密数据包，得到明文消息结构体
        /// </summary>
        ///<param name="msg_signature">企业微信加密签名，msg_signature计算结合了企业填写的token、请求中的timestamp、nonce、加密的消息体</param>
        ///<param name="timestamp">时间戳。与nonce结合使用，用于防止请求重放攻击。</param>
        ///<param name="nonce">随机数。与timestamp结合使用，用于防止请求重放攻击。</param>
        ///<param name="echostr">加密的字符串。需要解密得到消息内容明文，解密后有random、msg_len、msg、receiveid四个字段，其中msg即为消息内容明文</param>
        ///<param name="token">由开发者可以任意填写，用作生成签名</param>
        ///<param name="encodingKey">用于消息体的加密，长度固定为43个字符，从a-z, A-Z, 0-9共62个字符中选取，是AESKey的Base64编码</param>
        ///<param name="receiveId">加解密库里，ReceiveId 在各个场景的含义不同：1,企业应用的回调，表示corpid；2,第三方事件的回调，表示suiteid</param>
        /// <returns></returns>
        public static string DecryptMsg(string msg_signature, string timestamp, string nonce, string echostr, string token,string encodingKey,string receiveId)
        {
            var wXBizMsgCrypt = new WXBizMsgCrypt(token, encodingKey, receiveId);
            string decryptmsg = "";
            wXBizMsgCrypt.DecryptMsg(msg_signature, timestamp, nonce, echostr,ref decryptmsg);
            return decryptmsg;
        }

        /// <summary>
        /// 企业微信回复用户的消息加密打包
        /// </summary>
        /// <param name="timestamp">时间戳，可以自己生成，也可以用URL参数的timestamp</param>
        /// <param name="nonce">随机串，可以自己生成，也可以用URL参数的nonce</param>
        /// <param name="replymsg">企业微信待回复用户的消息，xml格式的字符串</param>
        ///<param name="token">由开发者可以任意填写，用作生成签名</param>
        ///<param name="encodingKey">用于消息体的加密，长度固定为43个字符，从a-z, A-Z, 0-9共62个字符中选取，是AESKey的Base64编码</param>
        ///<param name="receiveId">加解密库里，ReceiveId 在各个场景的含义不同：1,企业应用的回调，表示corpid；2,第三方事件的回调，表示suiteid</param>
        /// <returns></returns>
        public static string EncryptMsg(string replymsg, string token, string encodingKey, string receiveId)
        {
            var wXBizMsgCrypt = new WXBizMsgCrypt(token, encodingKey, receiveId);
            string encryptmsg = "";
            wXBizMsgCrypt.EncryptMsg(replymsg, GetTimestamp(), GetNoncestr(), ref encryptmsg);
            return encryptmsg;
        }


        /// <summary>
        /// 获取微信时间格式
        /// </summary>
        /// <returns></returns>
        private static string GetTimestamp()
        {
            TimeSpan ts = DateTime.Now - new DateTimeOffset(1970, 1, 1, 0, 0, 0, 0, TimeSpan.Zero);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }


        /// <summary>
        /// 随机生成Noncestr
        /// </summary>
        /// <returns></returns>
        private static string GetNoncestr()
        {
            string retStr;
            var m5 = MD5.Create();
            //创建md5对象
            byte[] inputBye;
            byte[] outputBye;

            //使用GB2312编码方式把字符串转化为字节数组．
            try
            {
                inputBye = Encoding.UTF8.GetBytes(Guid.NewGuid().ToString());
            }
            catch (Exception ex)
            {
                inputBye = Encoding.GetEncoding("GB2312").GetBytes(Guid.NewGuid().ToString());
            }
            outputBye = m5.ComputeHash(inputBye);

            retStr = BitConverter.ToString(outputBye);
            retStr = retStr.Replace("-", "").ToUpper();
            return retStr;
        }

    }
}
