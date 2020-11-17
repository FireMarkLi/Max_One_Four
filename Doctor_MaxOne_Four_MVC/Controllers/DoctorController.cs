using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        //点击医生端创建按钮   
        public IActionResult CreateMessage()
        {
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
        public IActionResult DoctorSignedExpert()
        {
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
    }
}
