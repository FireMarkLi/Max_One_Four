using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctor_MaxOne_Four_MVC.Controllers
{
    public class zf
    {
        public zf()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        // 应用ID,您的APPID
        public static string app_id = "2016110200788248";

        // 支付宝网关
        public static string gatewayUrl = "https://openapi.alipaydev.com/gateway.do";

        // 商户私钥，您的原始格式RSA私钥
        public static string private_key = "MIIEowIBAAKCAQEAxixhFSgLgqKPXwcgblDMqj61J8p9UUzoPF6uJ9TH+ZUvgYkxIha6wGqKJAeZfM6Zrg1cncHgwlx6vzwOJunV718EC6vlXE3AhBNUCKh1pL1XXabQBLV23mZWuo217fJLP6Nr788APpPdtMzBdt0YJmrRpgViJtpj1ueQdOcoNYylB8X4wJ0FjmFTNEc57EleNYMc6Z3N9Y/OldOVtsD3meBdW1B2goykQL+KMDnFLkJ7q0CV8SswaltP1fRkKe9w08bVQ5F0cae07pO1QykiVTG9dlUejrYnfGW+I7C0/R/Q2wJrf539VCdubD24Q9IUOfJGkNO3ESuBIEAq3moDfQIDAQABAoIBAQCptb++Gnkg+o3FV5kSX+els+X3mZUQVshbSsniGnrW5ke0qwSEqOptdc+vY0Kye0tontC92Rbd28zSkF+eO4qWX8xbIm5dScigUt0YPQvidLOo4/4oyi5t7z4+rLUsfN6sNQtuZttSu9aVyvOzE0xnOfsoLlwL4eK2W8B+HKd2kuW9Tj9NQ/v3uDdGcHohcbeyrQv24Pj/1zOe+rdQRD1Juc+ZPF43rYLymSxRfDh/salEdvz1US0yyElstwdPJV5qelJA0sDlZdxyHM+43kxJ7yd/ZdY8gZbwkHEoeNCBAQv4Nm0FjyqNaJVyjSVl/qqV+FVFVwh93pUcO6nJFUmRAoGBAOTKLelx9aBiLz4G00z7Ckqkol4+Vgb9VcnUGY2YdlXCYPjFc3J0cTrsJL6kyyF1TnovF31YSYrvfzu55CJikeHLT6Yg8+JqsyALzHU4FygqUF4mMh1Ce+4b12Dx9Ja29lhGUjhBv8AuTr7p/37Dq8yglZJ3uZebpeartT0xHr/3AoGBAN2+CoKHU7wc57zXAfZ1KSPuIFX+/FCuemijz9xjki7n1M+56o5tZ1F3EcvFDGXRBvCnMzc6zIHBewM1u4s5d/PbfMzjWrrgs11K4V58rLE0FBsjC+YoAuN8lW90I4c7JyrsSpYc8+VB7g5aEsO2dy0/+7cCefm0lPh146oXxyMrAoGANGyjco97UgHNg2/68PPBGvN4hRHRko5wHuwr4schrmr432gXGQ3XeEHt9YU7SnJfxh2OS1l0mJJiXCQvQzXE6bE1kgKQ/7ulSd2KPv3YSIrRmZE1AIFgdmIIyx0GB5brAbUzV9KxBm9V+ecSdVCOyDevrj0i2LuAm0eTIu9jdWcCgYBLy+RHzf5fdPn54Pz4w/+2GnXPL4QMCDgrgKNS0G5tvi1OfFyjJt6ESFE6+DZOr27R4DVvkZfKWtqztDBRXOmV39b/KlAfRSPKpgf3hmJ5iDW/OPGeUNr76+Ag4vAqD5xJ3c95FJiCK1E2cq+rWrnOK+rdGemb45Bwhcu2nr4hVQKBgHzu/HUpnW013DQx+4O22tWgr5jOrygspJVwlOk/9E09RBrddIbChrxLEVCrNzHZcPvrv7DpujRZIpEKHF5i849GZuyOV76ctQCtOZWBnEXHXNZVHGfzlwkkwlAyghf1a19Bk+0FF8gQM9v0f7VYcJc48XcnX8uNJZvf6VYS8CI5";

        // 支付宝公钥,查看地址：https://openhome.alipay.com/platform/keyManage.htm 对应APPID下的支付宝公钥。
        public static string alipay_public_key = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAvIOTX12zAnMQ9nLQfEJgV2iRXR47XNLOhAo4+eZZHxQW67eSmUdDK99DEmLpxTueRaIeJQ4fGfuMBUZm8wl5LatJv0yty3gcyFS+LjfILvJsZ8MumkgiG97X0scGDJ62kaPG+s4cp+ydnYJfWceld0h3nLWFrjosnhAEP58JiKE1/Floc51ZBrhdjAssMPc+kdbD6rFhji+NIV5IAbHeBPT/L6xwsPrg0eRX7F39pD+zTvQdOFBrf1z8TWArjPPgDE7nU6lrjuCuxBT/bXIPyC9smgi6evUcn7TaAN0Dq4Jw+RMfR9UsldRo+3BSv9uuo6V1wtMvGrwSsjFdmF+m7QIDAQAB";

        // 签名方式
        public static string sign_type = "RSA2";

        // 编码格式
        public static string charset = "UTF-8";
    }
}
