using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessagingToolkit.QRCode.Codec;
using System.Drawing;
using MessagingToolkit.QRCode.Codec.Data;

namespace HolonetQrCode
{
    public class CodeManager
    {
		public static System.Drawing.Image GetPictureFromText(string code)
		{
			QRCodeEncoder encoder = new QRCodeEncoder();
			encoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE; //ALPHA_NUMERIC, nonostante il nome, non va bene per codificare un GUID.
			encoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
			encoder.QRCodeVersion = 3;

			return encoder.Encode(code);
		}

		public static System.Drawing.Image GetPictureFromGuid(Guid? uniqueCode)
		{
			return GetPictureFromText(uniqueCode.ToString());
		}

		public static string GetCodeFromPicture(Bitmap pic)
		{
			QRCodeDecoder decoder = new QRCodeDecoder();
			MessagingToolkit.QRCode.Codec.Data.QRCodeBitmapImage image = new QRCodeBitmapImage(pic);
			return decoder.Decode(image, Encoding.Unicode);
		}

		public static string GetCodeFromPicture(System.Drawing.Image pic)
		{
			Bitmap picture = new Bitmap(pic);
			return GetCodeFromPicture(picture);
		}
    }
}
