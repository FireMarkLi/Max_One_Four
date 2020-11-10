using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Doctor_MaxOne_Four.DAL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Doctor_MaxOne_Four.Controllers
{
    [Route("Doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        //DBHelper  注入IWebHostEnvironment注入
        IWebHostEnvironment iweb;
        DBHelper db;
        public DoctorController(DBHelper _db,IWebHostEnvironment _Iweb)
        {
            db = _db;
            iweb = _Iweb;
        }
        //注册
        [HttpPost]
        [Route("login")]
        public IActionResult ZhuCe(Users users)
        {
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@UsersName",users.UsersName),
                new SqlParameter("@UsersPwd",users.UsersPwd),
                new SqlParameter("@UsersState",users.UsersState),
                new SqlParameter("@UsersAdress",users.UsersAdress),
                new SqlParameter("@UsersExam",users.UsersExam),
            };
            var dt = db.ExecuteNonQuery("P_Login", sqlParameters, System.Data.CommandType.StoredProcedure);
            return Ok(dt);
        }
        //登录       
        [HttpPost]
        [Route("register")]
        public IActionResult Deng(Users ul)
        {
            string sql = $"select count(*) from Users where UsersName='{ul.UsersName}' and UsersPwd='{ul.UsersPwd}' and UsersState='{ul.UsersState}'";
            var dt = (int)db.Deng(sql);
            //根据你登陆不同的状态登录进去不同的页面   患者 病人  管理员
            return Ok(dt);
        }
        //患者个人添加资料    
        [HttpPost]
        [Route("PatientAddData")]
        public IActionResult PatientAddData()
        {
            string sql = "";
            var dt = db.CMD(sql);
            return Ok(dt);
        }
        //患者修改添加资料    
        [HttpPost]
        [Route("PatientUpdateData")]
        public IActionResult PatientUpdateData()
        {
            string sql = "";
            var dt = db.CMD(sql);
            return Ok(dt);
        }
        //患者首页的科室
        [HttpGet]
        [Route("PatientShowDepartment")]
        public IActionResult PatientShowDepartment()
        {
            string sql = "select * from Departments";
            var dt = db.GetShow<Departments>(sql);
            return Ok(dt);
        }
        //点击患者首页的科室进入医生显示页面
        [HttpGet]
        [Route("PatientShowHospital")]
        public IActionResult PatientShowHospital(int id)
        {
            string sql = $"select * from Hospital join DepartmentsHospital on DepartmentsHospital.DepartmentsHospitalHospitalId=Hospital.HospitalDepartments join Departments on Departments.DepartmentsId=DepartmentsHospital.DepartmentsHospitalDepartmentsId where DepartmentsId={id}";
            var dt = db.GetShow<Hospital>(sql);
            return Ok(dt);
        }
        //填写预约单 
        [HttpPost]
        [Route("DoctorReservation")]
        public async Task<IActionResult> DoctorReservation()
        {
            var file = Request.Form.Files;
            foreach (var item in file)
            {
                if (item.Length > 0)
                {
                    string wwwroot = iweb.ContentRootPath + "/wwwroot/img/";
                    //文件夹
                    if (!Directory.Exists(wwwroot))
                    {
                        Directory.CreateDirectory(wwwroot);
                    }
                    var filePath = Path.Combine(wwwroot, item.FileName);
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        DoctorReservation dr = new DoctorReservation();
                        dr.ReservationImg = "/img/" + item.FileName;
                        //填写预约单sql语句
                        var sql = $"";

                        var dt = db.CMD(sql);
                        await item.CopyToAsync(stream);
                    }
                    var items = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());


                }
            }
            return Ok();
        }
        //立即支付  患者
        [HttpPost]
        [Route("MoneyPayment")]
        public IActionResult MoneyPayment()
        {
            //添加一张支付表的内容
            //对医生或者科室的账户进行修改
            return Ok();
        }
        //推荐医院
        [HttpGet]
        [Route("Recommend")]
        public IActionResult Recommend()
        {
            //根据患者信息的地区查看当前地区的医院
            string sql = "select * from Hospital join Address on Address.AddressId=Hospital.HospitalAddress join Users on Users.UsersAdress=Address.AddressId";
            var dt = db.GetShow(sql);
            return Ok(dt);
        }
        //根据你推荐预约医院点进去后进行预约科室
        [HttpPost]
        [Route("ReservationRecommend")]
        public async Task<IActionResult> DoctorReservation2()
        {
            var file = Request.Form.Files;
            foreach (var item in file)
            {
                if (item.Length > 0)
                {
                    string wwwroot = iweb.ContentRootPath + "/wwwroot/img/";
                    //文件夹
                    if (!Directory.Exists(wwwroot))
                    {
                        Directory.CreateDirectory(wwwroot);
                    }
                    var filePath = Path.Combine(wwwroot, item.FileName);
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        DoctorReservation dr = new DoctorReservation();
                        dr.ReservationImg = "/img/" + item.FileName;
                        //填写预约单sql语句
                        var sql = $"";

                        var dt = db.CMD(sql);
                        await item.CopyToAsync(stream);
                    }
                    var items = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());


                }
            }
            return Ok();
        }
        //支付  推荐医院预约科室
        [HttpPost]
        [Route("RecommendMoneyPayment")]
        public IActionResult MoneyPayment2()
        {
            //添加一张支付表的内容
            //对医生或者科室的账户进行修改
            return Ok();
        }
        //患者的   全部订单
        [HttpGet]
        [Route("PatientIndent")]
        public IActionResult ShowAllDingDan(int id)
        {
            //根据患者的登录获取id  查看关于患者的所有订单  一般一个
            //患者id=id
            string sql = $"select * from DoctorReservation where ReservationName={id}";
            var dt = db.GetShow(sql);
            return Ok();
        }
        //查看订单详情
        [HttpGet]
        [Route("IndentParticulars")]
        //id 订单id
        public IActionResult IndentParticulars(int Usersid,int DingDanid)
        {
            //用户id   订单id
            string sql = $"select * from DoctorReservation where ReservationName={Usersid} and Reservationid={DingDanid}";
            var dt = db.GetShow(sql);
            return Ok(dt);
        }
        //根据订单状态显示不同的订单
        [HttpGet]
        [Route("IndentState")]
        public IActionResult IndentState(int stateid,int usersid)
        {
            string sql = $"select * from DoctorReservation d join MoneyPayment m on m.PaymentDoctorReservationId=d.Reservationid where ReservationName={usersid} and PaymentState={stateid}";
            var dt = db.GetShow(sql);
            return Ok(dt);
        }
        //创建按钮点击后的一系列添加
        [HttpPost]
        [Route("Create")]
        public IActionResult Create()
        {
            return Ok();
        }
        //疾病显示
        [HttpGet]
        [Route("DiseaseShow")]
        public IActionResult ShowAllDisease()
        {
            string sql = $"select * from Disease where DiseaseFatherId=0 ";
            var dt = db.GetShow(sql);
            return Ok(dt);
        }
        //选择父级节点下面的具体疾病
        [HttpGet]
        [Route("FatherInDisease")]
        public IActionResult FatherInDisease(int id)
        {
            //id为父级id
            string sql = $"select * from Disease where DiseaseFatherId={id}";
            var dt = db.GetShow(sql);
            return Ok(dt);
        }
        //查看医生信息
        [HttpGet]
        [Route("ShowDoctorXinxi")]
        public IActionResult ShowDoctorXinxi(int id)
        {
            //id为医生的id
            string sql = $"select * from DoctorInfo where DoctorId={id}";
            var dt = db.GetShow(sql);
            return Ok(dt);
        }
        //支付
        [HttpPost]
        [Route("MoneyCreate")]
        public IActionResult MoneyCreate()
        {
            //吧订单信息添加到支付表上
            //修改双方的金额
            return Ok();
        }
        //修改医生的个人信息
        [HttpGet]
        [Route("ShowOneDoctor")]
        public IActionResult ShowOneDoctor(int id)
        {
            //id为医生的id
            string sql = $"";
            var dt = db.GetShow(sql);
            return Ok(dt);
        }
        //创建问卷调查表--给医生的
        [HttpGet]
        [Route("ExamSay")]
        public IActionResult ExamSay()
        {
            string sql = "";
            var dt = db.GetShow(sql);
            //分数有ajax实现给值  这里不做传值   
            return Ok(dt);
        }
        //手术专题   纯显示
        [HttpGet]
        [Route("Surgery")]
        public IActionResult Surgery()
        {
            string sql = "";
            var dt = db.GetShow(sql);
            return Ok(dt);
        }
        //就医故事  纯显示
        [HttpGet]
        [Route("DoctorStory")]
        public IActionResult DoctorStory()
        {
            string sql = "";
            var dt = db.GetShow(sql);
            return Ok(dt);
        }
        //医生查看都有那些患者给自己订单
        [HttpGet]
        [Route("ShowAllPatient")]
        public IActionResult SHowALLHuanZhe(int id)
        {
            //id为医生的id   登陆后就是医生  这是医生端的  所以获取就好了
            string sql = $"";
            var dt = db.GetShow(sql);
            return Ok(dt);
        }
        //医生首页的发现主题
        [HttpGet]
        [Route("Story")]
        public IActionResult Story()
        {
            string sql = "";
            var dt = db.GetShow(sql);
            return Ok(dt);
        }
        //个人中心   我的账户
        [HttpGet]
        [Route("MyMoney")]
        public IActionResult MyMoney(int id)
        {
            //id 为医生的id  
            string sql = "";
            var dt = db.GetShow(sql);
            return Ok(dt);
        }
        //客服 常见问题以及答案  只显示问题
        [HttpGet]
        [Route("AllWhy")]
        public IActionResult AllWhy()
        {
            string sql = "";
            var dt = db.GetShow(sql);
            return Ok(dt);
        }
        //客服问题答案
        [HttpGet]
        [Route("Answer")]
        public IActionResult Answer()
        {
            string sql = "";
            var dt = db.GetShow(sql);
            return Ok(dt);
        }
        //点击签约专家去外地会诊信息 点击签约自动添加信息
        [HttpPost]
        [Route("Province")]
        public IActionResult Province()
        {
            string sql = "";
            var dt = db.CMD(sql);
            return Ok(dt);
        }
        //手动修改签约后的外地会诊信息
        [HttpPost]
        [Route("UpdateProvince")]
        public IActionResult UpdateProvince(int id)
        {
            //id为医生id
            string sql = "";
            var dt = db.CMD(sql);
            return Ok(dt);
        }
        //医生收到预约未处理
        [HttpGet]
        [Route("NoDispose")]
        public IActionResult NoDispose(int id)
        {
            //id为医生id   查找未处理的
            string sql = "";
            var dt = db.GetShow(sql);
            return Ok(dt);
        }
        //预约未处理  点击接收拒绝
        [HttpPost]
        [Route("YseNoDispose")]
        public IActionResult YseNoDispose()
        {
            //当点击同意 医生  状态修改  账户修改 
            string sql = "";
            //点击拒绝   客户 账户修改   
            var dt = db.CMD(sql);
            return Ok(dt);
        }
        //找回密码   
        [HttpPost]
        [Route("RetrievePassword")]
        public IActionResult RetrievePassword()
        {
            //  手机号等   麻烦一下   延申内容
            return Ok();
        }

    }
}
