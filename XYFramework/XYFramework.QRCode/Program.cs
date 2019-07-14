using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using XYFramework.Authcode;

namespace XYFramework.QRCoder
{
    class Program
    {
        static void Main(string[] args)
        {
            var lst = new List<string>{
        "3983",
        "4000",
        "4003",
        "4005",
        "4007",
        "4009",
        "4011",
        "4017",
        "4018",
        "4019",
        "4020",
        "4021",
        "4022",
        "4023",
        "4024",
        "4026",
        "4027",
        "4028",
        "4029",
        "4030",
        "4031",
        "4032",
        "4033",
        "4035",
        "4036",
        "4037",
        "4038",
        "4039",
        "4040",
        "4041",
        "4042",
        "4044",
        "4045",
        "4046",
        "4047",
        "4048",
        "4049",
        "4050",
        "4051",
        "4053",
        "4054",
        "4055",
        "4056",
        "4057",
        "4058",
        "4059",
        "4060",
        "4063",
        "4064",
        "4065",
        "4066",
        "4067",
        "4070",
        "4071",
        "4072",
        "4073",
        "4074",
        "4078",
        "4079",
        "4080",
        "4081",
        "4084",
        "4085",
        "4086",
        "4087",
        "4088",
        "4089",
        "4090",
        "4091",
        "4092",
        "4101"
    };

            foreach (var item in lst)
            {
                string str = item;
                string key = "VincKenc";
                //str = Authcode.Authcode.DiscuzAuthcodeEncode(str, key);
                str = URLb64.Url_b64encode(str, key);
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(str, QRCodeGenerator.ECCLevel.Q);
                QRCode qrcode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrcode.GetGraphic(5, Color.Black, Color.White, null, 15, 6, false);
                MemoryStream ms = new MemoryStream();
                qrCodeImage.Save(ms, ImageFormat.Jpeg);
                qrCodeImage.Save(string.Format("{0}.jpg", item));
            }
        }
    }
}
