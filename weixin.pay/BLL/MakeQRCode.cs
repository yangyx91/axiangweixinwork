using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using ThoughtWorks.QRCode.Codec;

namespace weixin.pay.BLL
{
    public class MakeQRCode
    {
        public byte[] NewQrCode(string str) 
        {
            //初始化二维码生成工具
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            qrCodeEncoder.QRCodeVersion = 0;
            qrCodeEncoder.QRCodeScale = 6; 

            //将字符串生成二维码图片
            Bitmap bimage=qrCodeEncoder.Encode(str, Encoding.Default);

            //保存为PNG到内存流  
            MemoryStream ms = new MemoryStream();
            bimage.Save(ms, ImageFormat.Jpeg);

            return ms.GetBuffer();
        }
    }
}
