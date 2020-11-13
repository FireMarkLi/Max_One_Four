using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Doctor_MaxOne_Four_MVC.Controllers
{
    public class DoctorController : Controller
    {
        //医生端首页
        public IActionResult Index()
        {
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
        //点击加入名医公益页面  纯显示
        public IActionResult DoctorPublicBenefit()
        {
            return View();
        }
        //医生端了解名医主刀  纯显示
        public IActionResult KnowDoctorPatient()
        {
            return View();
        }
    }
}
