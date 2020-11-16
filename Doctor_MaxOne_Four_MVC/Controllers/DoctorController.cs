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
    }
}
