using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Aop.Api;
using Aop.Api.Domain;
using Aop.Api.Request;
using Aop.Api.Response;
using Aop.Api.Util;
using Microsoft.AspNetCore.Mvc;

namespace Doctor_MaxOne_Four_MVC.Controllers
{
    public class DoctorController : Controller
    {
        //登录页面
        public IActionResult Login()
        {
            return View();
        }

        //预约单
        public IActionResult Appointment()
        {
            return View();
        }

        //注册页面
        public IActionResult Register(int id)
        {
            //注册时候的调查问卷答对的数量
            ViewBag.ZhuCeNumQ = id;
            return View();
        }
        //调查问卷页面
        public IActionResult Questionnaire()
        {
            return View();
        }

        //医生端首页
        public IActionResult Index(int id)
        {
            //登录的用户id
            ViewBag.DoctorUsersId = id;
            return View();
        }
        //医生端的发现页面
        public IActionResult Find()
        {
            return View();
        }
        //医生端的发现界面的具体文章内容
        public IActionResult StoryContent(int id)
        {
            ViewBag.StoryContentid = id;
            return View();
        }
        //点击加入名医公益页面  
        public IActionResult DoctorPublicBenefit()
        {
            return View();
        }
        //医生端了解名医主刀  
        public IActionResult KnowDoctorPatient()
        {
            return View();
        }
        //点击医生端 查看名医签约专家
        public IActionResult LookDoctor()
        {
            return View();
        }
        //  查看医生的详情信息
        public IActionResult CreateInParticularsMessage(int id)
        {
            ViewBag.CreateInParticularsMessageId = id;
            return View();
        }
        //医生端 个人中心
        public IActionResult DoctorMyCenter(int id)
        {
            ViewBag.IndexToMyCenterId = id;
            return View();
        }
        //完善医生个人信息
        public IActionResult AddDoctorInfo(int id)
        {
            ViewBag.AddDoctorId = id;
            return View();
        }
        //医生个人中心的修改个人信息
        public IActionResult UpdateDoctorMySelf(int id)
        {
            ViewBag.UpdateDOctorMySelfId = id;
            return View();
        }
        //医生个人中心的我的账户
        public IActionResult DoctorMyMoney(int id)
        {
            ViewBag.DoctorMyMoneyId = id;
            return View();
        }
        //医生端成为签约专家页面   
        public IActionResult DoctorSignedExpert(int id)
        {
            ViewBag.DoctorSignedExpertId = id;
            return View();
        }
        //医生端常见问题
        public IActionResult DoctorCommonProblem()
        {
            return View();
        }
        //医生端个人中心查看协议
        public IActionResult DoctorLookProtocol()
        {
            return View();
        }
        //医生端创建按钮    
        public ActionResult Create()
        {
            
            return View();
        }
        //医生端  订单
        public IActionResult DoctorIndent(int id)
        {
            //id是医生的id
            ViewBag.DoctorIndentId = id;
            return View();
        }
        //dAY1124
        //成为签约成功侯的专家页面
        public IActionResult SignUpSuccess(int id)
        {
            //医生id
            ViewBag.SignUpSuccessId = id;
            return View();
        }
        //修改签约成功后的数据
        public IActionResult UpdSignUpSuccess(int id)
        {
            //
            ViewBag.Id = id;
            return View();
        }
        //患者端首页
        public IActionResult PatientIndex(int id)
        {
            //登录的用户id
            ViewBag.PatientIndexId = id;
            return View();
        }

        //科室显示
        public IActionResult Administrative( )
        {
            
            return View();
        }

        //跟据首页点击科室进入那些医院有这些科室
        public IActionResult DepartmentToHostal(int id,int PatientId)
        {
            //科室id
            ViewBag.DepartmentToHostalId = id;
            //患者id
            ViewBag.IndexPatientId = PatientId;
            return View();
        }
        ////点击医院查看介绍进行预约
        public IActionResult HospitalToIntroduce(int id,int Deparment,int Hospital)
        {
            //id      患者id
            //Deparment 科室id
            //Hospital  医院id
            ViewBag.PatientHospitalToIntroduceId = id;
            ViewBag.DeparmentHospitalToIntroduceId = Deparment;
            ViewBag.HospitalHospitalToIntroduceId = Hospital;
            return View();
        }
        //跟据科室填写预约单   预约单页面
        public IActionResult ReservationList(int id, int Deparment, int Hospital) 
        {
            //id      患者id
            //Deparment 科室id
            //Hospital  医院id
            ViewBag.PatientReservationListId = id;
            ViewBag.DeparmentReservationListId = Deparment;
            ViewBag.HospitalReservationListId = Hospital;
            return View();
        }
        //预约成功后跳转到     支付页面    查看预约单支付的详情
        public IActionResult ReservationDepartment(int id)
        {
            //患者id
            ViewBag.ReservationDepartmentId = id;
            return View();
        }
        //患者首页点击找名医   快速预约
        public IActionResult LoogFamousDoctor(int id)
        {
            //患者id
            ViewBag.LoogFamousDoctorId = id;
            return View();
        }
        //找名医  快速预约  查看名医详情  进行预约
        public IActionResult DoctorMessage(int  id,int doctorid)
        {
            //患者       医生
            ViewBag.DoctorMessageId = id;
            ViewBag.DoctorMessagedoctorid = doctorid;
            return View();
        }
        //找名医添加预约单
        public IActionResult HaveDoctorReservation(int id, int doctorid)
        {
            //患者       医生
            ViewBag.HaveDoctorReservationId = id;
            ViewBag.HaveDoctorReservationdoctorid = doctorid;
            return View();
        }
        //患者端公益手术   就是显示
        public IActionResult GoodOperation()
        {
            return View();
        }
        //患者端推荐医院
        public IActionResult RecommendHospital(int id)
        {
            //推荐医院的患者id
            ViewBag.RecommendHospitalId = id;
            return View();
        }
        //点击医院进入科室疾病的选择
        public IActionResult DepartmentChoose(int id,int patientid)
        {
            //医院id   患者id
            ViewBag.HospitalId = id;
            ViewBag.PatientId = patientid;
            return View();
        }
        //点击推荐医院的预约单
        public IActionResult HospitalToOrder(int id,int Hospitalid, int Department)
        {
            //患者    医院   科室
            ViewBag.HospitalToOrdePatien = id;
            ViewBag.HospitalToOrderHospitalId = Hospitalid;
            ViewBag.HospitalToOrderDepartmentId = Department;
            return View();
        }
        //患者端PatientFind  发现
        public IActionResult PatientFind()
        {
            return View();
        }
        //患者端  发现   手术专题的具体内容
        public IActionResult Surgery(int id)
        {
            ViewBag.SurgeryId = id;
            return View();
        }
        //患者端  发现   就医故事具体内容
        public IActionResult DoctorStory(int id)
        {
            ViewBag.DoctorStoryId = id;
            return View();
        }
        //患者端个人中心
        public IActionResult PatientMySelf(int id)
        {
            //患者id
            ViewBag.PatientMyselfId = id;
            return View();
        }
        //患者端常见问题
        public IActionResult PatientCommonProblem()
        {
            return View();
        }
        //患者端关于我们
        public IActionResult AboutUs()
        {
            return View();
        }
        //患者端全部订单
        public IActionResult PatientAllIndent(int id)
        {
            //患者id
            ViewBag.PatientAllIndentId = id;
            return View();
        }
        //患者端查看订单详情
        public IActionResult PatientLookIndent(int Usersid,int DingDanid)
        {
            ViewBag.Usersid = Usersid;
            ViewBag.DingDanid = DingDanid;
            return View();
        }
        //患者端跟据不同的状态查看不懂的订单
        public IActionResult PatientIndentState(int id,int State)
        {
            //患者id     状态
            ViewBag.PatientId = id;
            ViewBag.STateId = State;
            return View();
        }
        //患者端完善个人信息
        public IActionResult PatientMeStlf(int id)
        {
            //用户id
            ViewBag.USersid = id;
            return View();
        }
        //患者端修改个人信息
        public IActionResult UpdPatientMySelf(int id)
        {
            //患者id
            ViewBag.PatientId = id;
            return View();
        }
        //医生端首页文章1
        public IActionResult Sssnoe()
        {
            //患者id
            
            return View();
        }

        //医生端首页文章2
        public IActionResult Ssstwo()
        {
            //患者id
           
            return View();
        }
        //医生端首页文章3
        public IActionResult Sssthree()
        {
            //患者id
           
            return View();
        }
        //医生端首页文章4
        public IActionResult Sssfour()
        {
            //患者id
           
            return View();
        }
        //患者端首页文章1
        public IActionResult Hhhone()
        {
            //患者id

            return View();
        }
        //患者端首页文章2
        public IActionResult Hhhtwo()
        {
            //患者id

            return View();
        }
        //患者端首页文章3
        public IActionResult Hhhthree()
        {
            //患者id

            return View();
        }
        //患者端首页文章4
        public IActionResult Hhhfour()
        {
            //患者id

            return View();
        }






        //短信验证
        public static string PostUrl = "https://106.ihuyi.com/webservice/sms.php?method=Submit";

        public JsonResult Page_Load(string mobile/*,object sender, EventArgs e*/)
        {
            string account = "C18973664";//查看用户名 登录用户中心->验证码通知短信>产品总览->API接口信息->APIID
            string password = "e6939cede90cdd5c4507b9039d5337f4"; //查看密码 登录用户中心->验证码通知短信>产品总览->API接口信息->APIKEY
                                                                  // string mobile = HttpContext.Request.Query["mobile"];
            Random rad = new Random();
            int mobile_code = rad.Next(1000, 10000);
            string content = "[物联网大实训一第四组提醒您]您的验证码是：" + mobile_code + " 。请不要把验证码泄露给其他人。";

            //Session["mobile"] = mobile;
            //Session["mobile_code"] = mobile_code;

            string postStrTpl = "account={0}&password={1}&mobile={2}&content={3}";

            UTF8Encoding encoding = new UTF8Encoding();
            byte[] postData = encoding.GetBytes(string.Format(postStrTpl, account, password, mobile, content));

            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(PostUrl);
            myRequest.Method = "POST";
            myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.ContentLength = postData.Length;

            Stream newStream = myRequest.GetRequestStream();
            // Send the data.
            newStream.Write(postData, 0, postData.Length);
            newStream.Flush();
            newStream.Close();

            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            if (myResponse.StatusCode == HttpStatusCode.OK)
            {
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);

                //Response.Write(reader.ReadToEnd());

                string res = reader.ReadToEnd();
                int len1 = res.IndexOf("</code>");
                int len2 = res.IndexOf("<code>");
                string code = res.Substring((len2 + 6), (len1 - len2 - 6));
                //Response.Write(code);
                int len3 = res.IndexOf("</msg>");
                int len4 = res.IndexOf("<msg>");
                string msg = res.Substring((len4 + 5), (len3 - len4 - 5));
                return Json(mobile_code);
            }
            else
            {
                //访问失败
                return Json(new { msg = "发送失败" });
            }
        }



        //支付宝功能
        public JsonResult ReturnView()
        {
            //// 应用ID,您的APPID
            //string app_id = "2016110200785876";
            //// 支付宝网关
            //string gatewayUrl = "https://openapi.alipaydev.com/gateway.do";
            //// 商户私钥，您的原始格式RSA私钥
            //string private_key = "MIIEogIBAAKCAQEAnqbiWEAmoSSeKSZXg2v+okxekGyRRUoDcIMrZxUoagY2UCW9u1gfOIODKtXXssBHJZxtFXEu0t0WPaVRr8RgHgFm1XIPqc93iBtU+4xfpV7U0YsOBUJVz1/3edBYp2yN9ca5MHcePDuXCIgq948bV9wpQN6GgYMXOksxLxIKnxo5F5HNNF5pAshKR5eJXuWMQVfUCNiYHlrubJaSS9eKw3CLpGARdFf/cpypDvfTkgQl5dLVNmNXSmiacBb/lnoE2Kb+2c/5xcV4XoblMC43jlBKFOQsOqLnvki/6o5u9wC+zixoPHEOkZn04DejpkakYL+kiBTJ22LRE2Oc6s+VlwIDAQABAoIBAGi2zX5iGR0TBjEy1WAwz4hfz6qTfe61wz9n1CXdmSchooeT4X7d0v2CD/kd25hnwI3aiUU1xyn2Ms/NZfUVMDudwTnwZtY10TdMkvLU2+xSgzUrCr394pVVSgpksZ8Pz0MBPwn2FUa8Lhu7hGCRXALJlZDzTuP8mkAnkPb4eXo40k5/t0/4f1wqIfaUpEHi0tDYZxxJDWKRDKJHlEQT9TRHckB8B/q93vZnkQ4L2HHGPV+QCHxrqr5IJ+nhaLQsxE0P1l5FUMTt2VyzRmFDtSKmZ+fbUrM5HgzbSagacMDHDNnbqZWu30jrncMeeHgn3q3hhUgu+YWxh1IpExGxw4ECgYEA03CPYdLEHIYKT0Nl9dlpK1heYZkkyA7ONXagYC0e/ZiJA0V20D132txIH7DmC/JXp/skNKNDzqY/4pNKTvfo30gYmyrk1krKYe4RKKc5eHY2yMYH5SXhyqK/En+bssJ16ye/KWExoYLuhknw80CEo2gRXFmo81HNf8QMihQ3vQ8CgYEAwBZa+DCyBeoCByH7iaKDsHoeSFFmZF/bmxDUTfw0Tm7FZ6exMb1NvSh/AlnHgLak+Aj/uw/nGiviCpBgEBVTZ5oAPH3w34aKmoUHKk22u42LT1In06j44ToRbWLHyYmr74gTLEnwqP+kz7OCzBphhPxHJMGkaA0v64qdcjlgLvkCgYATrHuK7KOWy9oVuf24vHwOrnBJwIgtnUMOsnUFve0OR60oAsSlZ7LJSInleP5OykPhu3qI81AR4GI9YNsfMe4XKIwxk/IrBlaCejZahATS8pzyXYrKhZXW1wHUZM9F+NYkBVTCMur9TkOHd0XWPICa+8nxv936lff7FXDdQDhXfQKBgHkg38aodmpyUUsMK+F0ANUVfOkfo5DiPcqAB1ESHC3lfkhKH9v8wvvogIcL9Fl/U3IxwonEkngXehgtSNZ7jDfFjiaXSIC8B8U+4/DSRsvoixO+++xmHmNwybKP2uqFDU4kIesIyWDYrKZpTa7FZ/+DUp2kGreesTw4EecItVWJAoGAWk5N7I1rxLcdaPgc6oyAsQ0e6MDyyzk9tppHO5h2hIEyLXa19ewfCts/hyIU9+9MfUokKUiLueiaQMdei08cAXWKjFmkZ/1YT9jSoPrF+moptSStrwwmOSWfkFjUrC0ez7mueDO9GfYN5/fo+GoDv0CLOmVo2ZE4WONDZXivzRo=";
            //// 支付宝公钥,查看地址：https://openhome.alipay.com/platform/keyManage.htm 对应APPID下的支付宝公钥。
            string alipay_public_key = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAvIOTX12zAnMQ9nLQfEJgV2iRXR47XNLOhAo4+eZZHxQW67eSmUdDK99DEmLpxTueRaIeJQ4fGfuMBUZm8wl5LatJv0yty3gcyFS+LjfILvJsZ8MumkgiG97X0scGDJ62kaPG+s4cp+ydnYJfWceld0h3nLWFrjosnhAEP58JiKE1/Floc51ZBrhdjAssMPc+kdbD6rFhji+NIV5IAbHeBPT/L6xwsPrg0eRX7F39pD+zTvQdOFBrf1z8TWArjPPgDE7nU6lrjuCuxBT/bXIPyC9smgi6evUcn7TaAN0Dq4Jw+RMfR9UsldRo+3BSv9uuo6V1wtMvGrwSsjFdmF+m7QIDAQAB";
            // 签名方式
            string sign_type = "RSA2";
            // 编码格式
            string charset = "UTF-8";

            var req = Request.QueryString;
            Dictionary<string, string> sArray = GetRequestGet();

            if (sArray.Count != 0)
            {
                bool flag = AlipaySignature.RSACheckV1(sArray, alipay_public_key, charset, sign_type, false);
                if (flag)
                {
                    //Response.Write("同步验证通过");
                    return Json(new { msg = "1" });
                }
                else
                {
                    // Response.Write("同步验证失败");
                    return Json(new { msg = "0" });
                }
            }
            else
            {
                return Json(new { msg = "0" });
            }
        }

        public Dictionary<string, string> GetRequestGet()
        {
            int i = 0;
            Dictionary<string, string> sArray = new Dictionary<string, string>();
            NameValueCollection coll;
            coll = (NameValueCollection)Request.Form;
            // coll = Request.QueryString;
            String[] requestItem = coll.AllKeys;
            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], HttpContext.Request.Query[requestItem[i]]);
            }
            return sArray;

        }
        public ActionResult OrderCarts2(int Id,int money,int HZid)
        {
            DefaultAopClient client = new DefaultAopClient(zf.gatewayUrl,
                zf.app_id, zf.private_key, "json", "1.0",
                zf.sign_type, zf.alipay_public_key, zf.charset, false);

            // 外部订单号，商户网站订单系统中唯一的订单号
            string out_trade_no = System.DateTime.Now.ToString("yyyyMMddHHmmss") + "00000" + (new Random()).Next(1, 10000).ToString();

            // 订单名称
            string subject = "名称";

            // 付款金额
            int total_amout = money;

            // 商品描述
            string body = "描述描述描述";

            //string timeout_express = "请求超时";

            //组装业务参数model
            AlipayTradePagePayModel model = new AlipayTradePagePayModel();
            model.Body = body;
            model.Subject = subject;
            model.TotalAmount =total_amout.ToString();
            model.OutTradeNo = out_trade_no;
            model.ProductCode = "FAST_INSTANT_TRADE_PAY";
            AlipayTradePagePayRequest request = new AlipayTradePagePayRequest();

            // 设置同步回调地址
            request.SetReturnUrl("http://localhost:62090/Doctor/PatientAllIndent?id=" + HZid);
            // 设置异步通知接收地址
            request.SetNotifyUrl("");

            // 将业务model载入到request
            request.SetBizModel(model);

            AlipayTradePagePayResponse response = null;

            try
            {
                //这是空的   
                response = client.pageExecute(request, null, "post");
                //Response.Write(response.Body);
                return Json(response.Body);
            }
            catch (Exception exp)
            {
                return Json(exp.Message);
            }

        }


    }

}
