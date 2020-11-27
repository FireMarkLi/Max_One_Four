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
using Microsoft.AspNetCore.Cors;
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
        DBHelper db = new DBHelper();
        public DoctorController(IWebHostEnvironment _Iweb)
        {
            iweb = _Iweb;
        }
        //注册
        [HttpPost]
        [Route("Login")]
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
        [Route("Register")]
        public IActionResult Deng(Users ul)
        {
            var num = -1;
            string sql = $"select count(*) from Users where UsersName='{ul.UsersName}' and UsersPwd='{ul.UsersPwd}' and UsersState='{ul.UsersState}'";
            var dt = (int)db.Deng(sql);
            if (ul.UsersState == 2)
            {
                string sql2 = $"select * from Users    where UsersName='{ul.UsersName}' and UsersPwd='{ul.UsersPwd}' and UsersState='{ul.UsersState}'";
                //根据你登陆不同的状态登录进去不同的页面   患者 病人  管理员
                var dt2 = db.GetShow(sql2);
                string json = JsonConvert.SerializeObject(dt2);
                Users usersxinxiid = JsonConvert.DeserializeObject<List<Users>>(json).FirstOrDefault();
                if (usersxinxiid != null)
                {
                    num = usersxinxiid.UsersState;
                }
                return Ok(new { id = dt, usersxinxi = num, doctorid = usersxinxiid.UsersId });
            }
            else
            {
                string sql2 = $"select * from  users    where UsersName='{ul.UsersName}' and UsersPwd='{ul.UsersPwd}' and UsersState='{ul.UsersState}'";
                //根据你登陆不同的状态登录进去不同的页面   患者 病人  管理员
                var dt2 = db.GetShow(sql2);
                string json = JsonConvert.SerializeObject(dt2);
                Users usersxinxiid = JsonConvert.DeserializeObject<List<Users>>(json).FirstOrDefault();
                if (usersxinxiid != null)
                {
                    num = usersxinxiid.UsersState;
                }
                return Ok(new { id = dt, usersxinxi = num, doctorid = usersxinxiid.UsersId });
            }

            //根据你的账号密码   找到这个用户的id

            //  return Ok(new {id=dt,usersxinxi= num ,doctorid= usersxinxiid.DoctorId});
        }
        //根据登录的id   查看医生的信息
        [HttpGet]
        [Route("LoginDoctorId")]
        public IActionResult LoginDoctorId(int id)
        {
            string sql = $"select * from DoctorInfo join Users  on Users.UsersId=DoctorInfo.UserDoctorInfo where UsersId='{id}'";
            var dt = db.GetShow(sql);
            string json = JsonConvert.SerializeObject(dt);
            List<Users> list = JsonConvert.DeserializeObject<List<Users>>(json);
            return Ok(list);
        }
        //跟据登陆的id获取患者的id
        [HttpGet]
        [Route("LoginIdPatientId")]
        public IActionResult LoginIdPatientId(int id)
        {
            string sql = $"select * from Patient join Users on Users.UsersId=Patient.UserPatientId where UsersId={id}";
            var dt = db.GetShow(sql);
            string json = JsonConvert.SerializeObject(dt);
            List<Patient> list = JsonConvert.DeserializeObject<List<Patient>>(json);
            return Ok(list);
        }
        //患者个人添加资料    
        [HttpPost]
        [Route("PatientAddData")]
        public IActionResult PatientAddData(Patient p)
        {
            string sql = $"insert into Patient values('{p.PatientName}',{p.PatientSex},{p.PatientAge},'{p.PatientBirthday}')";
            var dt = db.CMD(sql);
            return Ok(dt);
        }
        //反填患者个人信息
        [HttpGet]
        [Route("FanPatientMessage")]
        public IActionResult FanPatientMessage(int id)
        {
            //id为患者id
            var sql = $"select * from Patient where PatientID='{id}'";
            var dt = db.GetShow(sql);
            string json = JsonConvert.SerializeObject(dt);
            Patient list = JsonConvert.DeserializeObject<List<Patient>>(json).FirstOrDefault();
            return Ok(list);

        }
        //患者修改添加资料    
        [HttpPost]
        [Route("PatientUpdateData")]
        public IActionResult PatientUpdateData(Patient p)
        {
            string sql = $"update Patient set PatientName='{p.PatientName}',PatientSex='{p.PatientSex}',PatientAge='{p.PatientAge}',PatientBirthday='{p.PatientBirthday}' where PatientID={p.PatientID}";
            var dt = db.CMD(sql);
            return Ok(dt);
        }
        //患者首页的科室
        [HttpGet]
        [Route("PatientShowDepartment")]
        public IActionResult PatientShowDepartment()
        {
            string sql = "select * from Departments where DepartmentsFather=0";
            var dt = db.GetShow(sql);
            string json = JsonConvert.SerializeObject(dt);
            List<Departments> list = JsonConvert.DeserializeObject<List<Departments>>(json);
            return Ok(list);
        }
        //根据科室id显示都有那些医院
        [HttpGet]
        [Route("PatientShowHospital")]
        public IActionResult PatientShowHospital(int id)
        {
            string sql = $"select * from Departments join DepartmentsHospital on Departments.DepartmentsId=DepartmentsHospital.DepartmentsHospitalDepartmentsId join Hospital on Hospital.HospitalId=DepartmentsHospital.DepartmentsHospitalHospitalId join Address on Address.AddressId=Hospital.HospitalAddressId where DepartmentsId={id} ";
            var dt = db.GetShow(sql);
            string json = JsonConvert.SerializeObject(dt);
            List<Hospital> list = JsonConvert.DeserializeObject<List<Hospital>>(json);
            return Ok(list);
        }
        //下拉框查询根据科室id显示都有那些医院
        [HttpGet]
        [Route("XLKPatientShowHospital")]
        public IActionResult XLKPatientShowHospital(int id, int xlkid)
        {
            string sql = $"select * from Departments join DepartmentsHospital on Departments.DepartmentsId=DepartmentsHospital.DepartmentsHospitalDepartmentsId join Hospital on Hospital.HospitalId=DepartmentsHospital.DepartmentsHospitalHospitalId join Address on Address.AddressId=Hospital.HospitalAddressId where DepartmentsId={id}  and AddressId={xlkid}";
            var dt = db.GetShow(sql);
            string json = JsonConvert.SerializeObject(dt);
            List<Hospital> list = JsonConvert.DeserializeObject<List<Hospital>>(json);
            return Ok(list);
        }
        //显示科室下有多少疾病   科室专长
        [HttpGet]
        [Route("DeparmentInDisease")]
        public IActionResult DeparmentInDisease(int id)
        {
            //科室id
            string sql = $"select * from Departments where Departments.DepartmentsFather={id}";
            var dt = db.GetShow(sql);
            string json = JsonConvert.SerializeObject(dt);
            List<Departments> list = JsonConvert.DeserializeObject<List<Departments>>(json);
            return Ok(list);

        }
        //医院介绍  医院id
        [HttpGet]
        [Route("IntroduceHospital")]
        public IActionResult IntroduceHospital(int id)
        {
            //医院id
            string sql = $"select * from Hospital where HospitalId={id}";
            var dt = db.GetShow(sql);
            string json = JsonConvert.SerializeObject(dt);
            List<Hospital> list = JsonConvert.DeserializeObject<List<Hospital>>(json);
            return Ok(list);
        }
        //预约表的科室和医院的显示
        [HttpGet]
        [Route("PatientShowHospitalss")]
        public IActionResult PatientShowHospitalss(int id, int ids)
        {
            string sql = $"select * from Departments join DepartmentsHospital on Departments.DepartmentsId=DepartmentsHospital.DepartmentsHospitalDepartmentsId join Hospital on Hospital.HospitalId=DepartmentsHospital.DepartmentsHospitalHospitalId join Address on Address.AddressId=Hospital.HospitalAddressId where DepartmentsId={id} and   HospitalId={ids} ";
            var dt = db.GetShow(sql);
            string json = JsonConvert.SerializeObject(dt);
            List<Hospital> list = JsonConvert.DeserializeObject<List<Hospital>>(json);
            return Ok(list);
        }
        //跟据患者id查看患者信息
        [HttpGet]
        [Route("PatientIdToPatientName")]
        public IActionResult PatientIdToPatientName(int id)
        {
            //患者id
            string sql = $"select * from Patient where PatientID={id}";
            var dt = db.GetShow(sql);
            string json = JsonConvert.SerializeObject(dt);
            List<Patient> list = JsonConvert.DeserializeObject<List<Patient>>(json);
            return Ok(list);
        }
        //跟据科室id获取科室name
        [HttpGet]
        [Route("DeparmentToDeparmentName")]
        public IActionResult DeparmentToDeparmentName(int id)
        {
            string sql = $"select * from Departments where DepartmentsId={id}";
            var dt = db.GetShow(sql);
            string json = JsonConvert.SerializeObject(dt);
            List<Departments> list = JsonConvert.DeserializeObject<List<Departments>>(json);
            return Ok(list);
        }
        //跟据科室id获取科室name
        [HttpGet]
        [Route("HospitalIdToHospitalName")]
        public IActionResult HospitalIdToHospitalName(int id)
        {
            string sql = $"select * from Hospital where HospitalId	={id}";
            var dt = db.GetShow(sql);
            string json = JsonConvert.SerializeObject(dt);
            List<Hospital> list = JsonConvert.DeserializeObject<List<Hospital>>(json);
            return Ok(list);
        }
        //填写预约单   预约科室  无医生
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
                    //保存到 wwwroot下面的img文件夹
                    var filePath = Path.Combine(wwwroot, item.FileName);
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        DoctorReservation dr = new DoctorReservation();
                        dr.ReservationImg = "/img/" + item.FileName;
                        //填写预约单sql语句
                        string sql1 = $"select * from Hospital join DepartmentsHospital on DepartmentsHospital.DepartmentsHospitalHospitalId=Hospital.HospitalId join Departments on Departments.DepartmentsId=DepartmentsHospital.DepartmentsHospitalDepartmentsId join DoctorInfo on DoctorInfo.DoctorDepartmentsId=Departments.DepartmentsId where HospitalId='{Request.Form["ReservationHospitalid"]}' and DepartmentsId='{Request.Form["ReservationCottomsId"]}'";
                        var list = db.GetShow(sql1);
                        string josn2 = JsonConvert.SerializeObject(list);
                        List<DoctorInfo> list0 = JsonConvert.DeserializeObject<List<DoctorInfo>>(josn2);
                        //查找所有该科室下的所有医生
                        var num = list0.Count;
                        if (num == 0)
                        {
                            return Ok(0);
                        }
                        //随机数
                        Random rd = new Random();
                        int a = rd.Next(1, num);
                        //添加预约单
                        var sql = $"insert into DoctorReservation values('{Request.Form["ReservationNameId"]}','{Request.Form["ReservationHospitalid"]}','{Request.Form["ReservationCottomsId"]}','{Request.Form["ReservationDescribe"]}','{dr.ReservationImg}','{a}')";
                        var dt = db.CMD(sql);
                        //查找这条预约单id
                        string sql3 = "select top 1 ReservationId from  DoctorReservation  order by ReservationId desc";
                        var DRid = db.GetShow(sql3);
                        string josn = JsonConvert.SerializeObject(DRid);
                        DoctorReservation Dr = JsonConvert.DeserializeObject<List<DoctorReservation>>(josn).FirstOrDefault();

                        //写完预约单自动添加一条  支付内容    默认为 未支付  点击支付才会修改账户
                        string sql2 = $"insert into MoneyPayment values('{"MP" + DateTime.Now.ToString("yyyyMMddhhmmss")}','{Dr.ReservationId}','{"该订单号为" + Dr.ReservationId}','刚发现','1')";
                        var list2 = db.CMD(sql2);
                        await item.CopyToAsync(stream);
                    }
                    var items = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());


                }
            }
            return Ok(1);
        }
        //立即支付   查看详情
        [HttpGet]
        [Route("LookPayment")]
        public IActionResult LookPayment()
        {
            string sql = "select top 1 * from MoneyPayment join DoctorReservation on DoctorReservation.ReservationId=MoneyPayment.Reservationid  join DoctorInfo on DoctorInfo.DoctorId= DoctorReservation.ReservationDoctorId   order by PaymentId desc";
            var dt = db.GetShow(sql);
            string json = JsonConvert.SerializeObject(dt);
            List<MoneyPayment> list = JsonConvert.DeserializeObject<List<MoneyPayment>>(json);
            return Ok(list);
        }
        //立即支付  
        [HttpGet]
        [Route("MoneyPayment")]
        public IActionResult MoneyPayment()
        {
            //id为支付单id  因为是点击订单 
            string sql2 = $"select top 1 * from MoneyPayment join DoctorReservation on DoctorReservation.ReservationId=MoneyPayment.Reservationid  join DoctorInfo on DoctorInfo.DoctorId= DoctorReservation.ReservationDoctorId   order by PaymentId desc";
            var dt = db.GetShow(sql2);
            //获取预约单的医生的id  进行对医生账户修改
            string json = JsonConvert.SerializeObject(dt);
            DoctorReservation list = JsonConvert.DeserializeObject<List<DoctorReservation>>(json).FirstOrDefault();
            //对医生账户进行修改
            string sql = $"update DoctorInfo set DoctorNowMoney=DoctorNowMoney+{list.DoctorMoney} where DoctorId={list.DoctorId}";
            var dt2 = db.CMD(sql);
            string sql1 = $"update MoneyPayment set PaymentState=3 where PaymentId='{list.PaymentId}'";
            var dt1 = db.CMD(sql1);
            return Ok(dt2);
        }
        //跟据科室的id获取该科室下的疾病
        [HttpGet]
        [Route("DepartmentInBing")]
        public IActionResult DepartmentInBing(int id)
        {
            string sql = $"select * from Departments where DepartmentsFather={id}";
            var dt = db.GetShow(sql);
            string json = JsonConvert.SerializeObject(dt);
            List<Departments> list = JsonConvert.DeserializeObject<List<Departments>>(json);
            return Ok(list);
        }
        //跟据医生id获取医院和科室的信息
        [HttpGet]
        [Route("DoctoridToHospitalDepartmentMEssage")]
        public IActionResult DoctoridToHospitalDepartmentMEssage(int id)
        {
            //医生id   
            string sql = $"select * from DoctorInfo join Departments on Departments.DepartmentsId=DoctorInfo.DoctorDepartmentsId join DepartmentsHospital on DepartmentsHospital.DepartmentsHospitalDepartmentsId=Departments.DepartmentsId join Hospital on Hospital.HospitalId=DepartmentsHospital.DepartmentsHospitalHospitalId where DoctorId={id} ";
            var dt = db.GetShow(sql);
            string json = JsonConvert.SerializeObject(dt);
            List<Hospital> list = JsonConvert.DeserializeObject<List<Hospital>>(json);
            return Ok(list);
        }
        //推荐医院   查看推荐医院   并且可以根据地区进行查看
        [HttpGet]
        [Route("Recommend")]
        public IActionResult Recommend()
        {
            //根据患者信息的地区查看当前地区的医院
            string sql = "select * from Hospital join Address on Hospital.HospitalAddressId=Address.AddressId  where Hospital.HospitalAddressId in (select Users.UsersAdress from Users where Users.UsersState=2)";
            var dt = db.GetShow(sql);
            string json = JsonConvert.SerializeObject(dt);
            List<Hospital> list = JsonConvert.DeserializeObject<List<Hospital>>(json);
            return Ok(list);
        }
        //绑定下拉框  地区;
        [HttpGet]
        [Route("XLKAddress")]
        public IActionResult XLKAddress()
        {
            string slq = "select * from Address";
            var dt = db.GetShow<Address>(slq);
            return Ok(dt);
        }
        //下拉框   地区表   根据下拉框查询医院
        [HttpGet]
        [Route("XLKRegion")]
        public IActionResult XLKRegion(int id)
        {
            string sql = $"select * from Hospital join Address on Address.AddressId=Hospital.HospitalAddressId where HospitalAddressId={id}";
            var dt = db.GetShow(sql);
            string json = JsonConvert.SerializeObject(dt);
            List<Hospital> list = JsonConvert.DeserializeObject<List<Hospital>>(json);
            return Ok(list);
        }
        //跟据医生id获取医院信息
        [HttpGet]
        [Route("DoctorIdHospitalMessage")]
        public IActionResult DoctorIdHospitalMessage(int id)
        {
            string sql = $"select * from Hospital where HospitalId={id}";
            var dt = db.GetShow(sql);
            string json = JsonConvert.SerializeObject(dt);
            List<Hospital> list = JsonConvert.DeserializeObject<List<Hospital>>(json);
            return Ok(list);
        }
        //根据地区下拉框  查询医生
        [HttpGet]
        [Route("XLKLookDoctor")]
        public IActionResult XLKLookDoctor(int id)
        {
            string sql = $"select * from DoctorInfo join Users on Users.UsersId=DoctorInfo.UserDoctorInfo join Address on Address.AddressId=Users.UsersAdress join  Departments on Departments.DepartmentsId=DoctorInfo.DoctorDepartmentsId  join Hospital on Hospital.HospitalId=DoctorInfo.DoctorHospitalId where AddressId='{id}' ";
            var dt = db.GetShow(sql);
            string json = JsonConvert.SerializeObject(dt);
            List<DoctorInfo> list = JsonConvert.DeserializeObject<List<DoctorInfo>>(json);
            return Ok(list);
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
                        string sql1 = $"select * from Hospital join DepartmentsHospital on DepartmentsHospital.DepartmentsHospitalHospitalId=Hospital.HospitalId join Departments on Departments.DepartmentsId=DepartmentsHospital.DepartmentsHospitalDepartmentsId join DoctorInfo on DoctorInfo.DoctorDepartmentsId=Departments.DepartmentsId where HospitalId='{Request.Form["ReservationHospitalid"]}' and DepartmentsId='{Request.Form["ReservationCottomsId"]}'";
                        var list = db.GetShow(sql1);
                        string josn2 = JsonConvert.SerializeObject(list);
                        List<DoctorInfo> list0 = JsonConvert.DeserializeObject<List<DoctorInfo>>(josn2);
                        //查找所有该科室下的所有医生
                        var num = list0.Count;
                        if (num == 0)
                        {
                            return Ok(0);
                        }
                        //随机数
                        Random rd = new Random();
                        int a = rd.Next(1, num);
                        //添加预约单
                        var sql = $"insert into DoctorReservation values('{Request.Form["ReservationNameId"]}','{Request.Form["ReservationHospitalid"]}','{Request.Form["ReservationCottomsId"]}','{Request.Form["ReservationDescribe"]}','{dr.ReservationImg}','{a}')";
                        var dt = db.CMD(sql);
                        //查找这条预约单id
                        string sql3 = "select top 1 ReservationId from  DoctorReservation  order by ReservationId desc";
                        var DRid = db.GetShow(sql3);
                        string josn = JsonConvert.SerializeObject(DRid);
                        DoctorReservation Dr = JsonConvert.DeserializeObject<List<DoctorReservation>>(josn).FirstOrDefault();
                        //写完预约单自动添加一条  支付内容    默认为 未支付  点击支付才会修改账户
                        string sql2 = $"insert into MoneyPayment values('{"MP" + DateTime.Now.ToString("yyyyMMddhhmmss")}','{Dr.ReservationId}','{"该订单号为" + Dr.ReservationId}','刚发现','1')";
                        var list2 = db.CMD(sql2);
                        await item.CopyToAsync(stream);
                    }
                    var items = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());


                }
            }
            return Ok(1);
        }

        //支付  推荐医院预约科室
        [HttpPost]
        [Route("RecommendMoneyPayment")]
        public IActionResult MoneyPayment2()
        {
            
            //id为支付单id  因为是点击订单 
            string sql2 = $"select top 1 * from MoneyPayment join DoctorReservation on DoctorReservation.ReservationId=MoneyPayment.Reservationid  join DoctorInfo on DoctorInfo.DoctorId= DoctorReservation.ReservationDoctorId   order by PaymentId desc";
            var dt = db.GetShow(sql2);
            //获取预约单的医生的id  进行对医生账户修改
            string json = JsonConvert.SerializeObject(dt);
            DoctorReservation list = JsonConvert.DeserializeObject<List<DoctorReservation>>(json).FirstOrDefault();
            //对医生账户进行修改
            string sql = $"update DoctorInfo set DoctorNowMoney=DoctorNowMoney+{list.DoctorMoney}  where DoctorId={list.DoctorId}";
            var dt2 = db.CMD(sql);
            string sql1 = $"update MoneyPayment set PaymentState=3 where PaymentId='{list.PaymentId}'";
            var dt1 = db.CMD(sql1);
            return Ok(dt2);
        }
        //根据找名医   分页显示医生  一页3个医生   直接预约医生
        //这个 找名医  页面可以用  layui实现
        [HttpGet]
        [Route("CHIUDoctor")]
        public IActionResult CHIUDoctor(int page = 1, int limit = 3)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("@pageindex", page);
            dic.Add("@pagesize", limit);
            dic.Add("@pagecount", 0);
            var dt = db.Proc("P_Doctor", dic, "@pagecount", out object id);
            var list = dt.Tables[1];
            string json = JsonConvert.SerializeObject(list);
            List<DoctorInfo> caigou = JsonConvert.DeserializeObject<List<DoctorInfo>>(json);
            return Ok(new { code = 0, msg = "ok", count = id, data = caigou });
        }
        //查看具体名医   点击查看是医生的个人信息、
        [HttpGet]
        [Route("LookDoctorMyXinxi")]
        public IActionResult LookDoctorMyXinxi(int id)
        {
            //id为   医生的个人id
            string sql = $"select * from DoctorInfo join Users on Users.UsersId=DoctorInfo.UserDoctorInfo join Address on Address.AddressId=Users.UsersAdress join  Departments on Departments.DepartmentsId=DoctorInfo.DoctorDepartmentsId  join Hospital on Hospital.HospitalId=DoctorInfo.DoctorHospitalId where DoctorId='{id}'";
            var dt = db.GetShow(sql);
            string json = JsonConvert.SerializeObject(dt);
            List<DoctorInfo> List = JsonConvert.DeserializeObject<List<DoctorInfo>>(json);
            return Ok(List);

        }
        //填写根据找名医  填写预约单
        [HttpPost]
        [Route("DoctorDoctorReservation")]
        public async Task<IActionResult> DoctorDoctorReservation()
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

                        //添加预约单
                        var sql = $"insert into DoctorReservation values('{Request.Form["ReservationNameId"]}','{Request.Form["ReservationHospitalid"]}','{Request.Form["ReservationCottomsId"]}','{Request.Form["ReservationDescribe"]}','{dr.ReservationImg}','{Request.Form["ReservationDoctorId"]}')";
                        var dt = db.CMD(sql);
                        //查找这条预约单id
                        string sql3 = "select top 1 ReservationId from  DoctorReservation  order by ReservationId desc";
                        var DRid = db.GetShow(sql3);
                        string josn = JsonConvert.SerializeObject(DRid);
                        DoctorReservation Dr = JsonConvert.DeserializeObject<List<DoctorReservation>>(josn).FirstOrDefault();
                        //写完预约单自动添加一条  支付内容    默认为 未支付  点击支付才会修改账户
                        string sql2 = $"insert into MoneyPayment values('{"MP" + DateTime.Now.ToString("yyyyMMddhhmmss")}','{Dr.ReservationId}','{"该订单号为" + Dr.ReservationId}','刚发现','1')";
                        var list2 = db.CMD(sql2);
                        await item.CopyToAsync(stream);
                    }
                    var items = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());


                }
            }
            return Ok();
        }
        //支付   根据找名医  修改医生账户
        [HttpPost]
        [Route("UpdateDoctorMoney")]
        public IActionResult UpdateDoctorMoney(int id)
        {
            //id为支付单id  因为是点击订单 
            string sql2 = $"select ReservationDoctorId from MoneyPayment join DoctorReservation on DoctorReservation.ReservationId=MoneyPayment.Reservationid where PaymentId={id} ";
            var dt = db.GetShow(sql2);
            //获取预约单的医生的id  进行对医生账户修改
            string json = JsonConvert.SerializeObject(dt);
            DoctorReservation list = JsonConvert.DeserializeObject<List<DoctorReservation>>(json).FirstOrDefault();
            //对医生账户进行修改
            string sql = $"update DoctorInfo set DoctorNowMoney=DoctorNowMoney+DoctorMoney where DoctorId={list}";
            var dt2 = db.CMD(sql);
            return Ok(dt2);
        }
        //患者的   全部订单
        [HttpGet]
        [Route("PatientIndent")]
        public IActionResult ShowAllDingDan(int id)
        {
            //根据患者的登录获取id  查看关于患者的所有订单  
            //患者id=id    
            string sql = $"select  * from DoctorReservation join MoneyPayment on MoneyPayment.Reservationid=DoctorReservation.ReservationId  join Patient on Patient.PatientID=DoctorReservation.ReservationNameId  join Hospital on Hospital.HospitalId= DoctorReservation.ReservationHospitalid join	DoctorInfo on DoctorInfo.DoctorId=DoctorReservation.ReservationDoctorId   where ReservationNameId={id}";
            var dt = db.GetShow(sql);
            string json = JsonConvert.SerializeObject(dt);
            List<DoctorReservation> list = JsonConvert.DeserializeObject<List<DoctorReservation>>(json);
            return Ok(list);
        }
        //查看订单详情  患者查看
        [HttpGet]
        [Route("IndentParticulars")]
        //id 订单id
        public IActionResult IndentParticulars(int Usersid, int DingDanid)
        {
            //用户id   订单id
            string sql = $"select  * from DoctorReservation join MoneyPayment on MoneyPayment.Reservationid=DoctorReservation.ReservationId  join Patient on Patient.PatientID=DoctorReservation.ReservationNameId  join Hospital on Hospital.HospitalId= DoctorReservation.ReservationHospitalid join	DoctorInfo on DoctorInfo.DoctorId=DoctorReservation.ReservationDoctorId   where ReservationNameId={Usersid} and DoctorReservation.ReservationId={DingDanid}";
            var dt = db.GetShow(sql);
            string json = JsonConvert.SerializeObject(dt);
            List<DoctorReservation> list = JsonConvert.DeserializeObject<List<DoctorReservation>>(json);
            return Ok(list);
        }
        //根据订单状态显示不同的订单
        [HttpGet]
        [Route("IndentState")]
        public IActionResult IndentState(int stateid, int usersid)
        {
            //状态id    患者id
            string sql = $"select  * from DoctorReservation join MoneyPayment on MoneyPayment.Reservationid=DoctorReservation.ReservationId  join Patient on Patient.PatientID=DoctorReservation.ReservationNameId  join Hospital on Hospital.HospitalId= DoctorReservation.ReservationHospitalid join	DoctorInfo on DoctorInfo.DoctorId=DoctorReservation.ReservationDoctorId where ReservationNameId={usersid} and PaymentState={stateid}";
            var dt = db.GetShow(sql);
            string json = JsonConvert.SerializeObject(dt);
            List<DoctorReservation> list = JsonConvert.DeserializeObject<List<DoctorReservation>>(json);
            return Ok(list);
        }
        //创建按钮点击后的一系列添加
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create()
        {
            var file = Request.Form.Files;
            foreach (var item in file)
            {
                if (item.Length > 0)
                {
                    var wwwroot = iweb.ContentRootPath + "/wwwroot/img/";
                    var filename = Path.Combine(wwwroot, item.FileName);
                    using (var straem = System.IO.File.Create(filename))
                    {
                        CreatePatient cp = new CreatePatient();
                        cp.PatientPmg = "/img/" + item.FileName;
                        string sql = $"insert into CreatePatient values('{Request.Form["PatientName"]}','{Request.Form["PatientPhone"]}','{Request.Form["PatientBirthday"]}','{Request.Form["PatientSex"]}','{Request.Form["PatientRecommend"]}','{Request.Form["PatientDiseaseName"]}','{Request.Form["PatientProcess"]}','{cp.PatientPmg}','{Request.Form["PatientPurpose"]}','{Request.Form["PatientDiseaseId"]}','{Request.Form["PatientHospitalId"]}','{Request.Form["PatientDocoterNameId"]}')";
                        var dt = db.CMD(sql);
                        await item.CopyToAsync(straem);

                    }
                }

            }
            return Ok();
        }
        //疾病显示
        [HttpGet]
        [Route("DiseaseShow")]
        public IActionResult ShowAllDisease()
        {
            string sql = $"select * from Disease where DiseaseFatherId=0 ";
            var dt = db.GetShow(sql);
            string json = JsonConvert.SerializeObject(dt);
            List<Disease> list = JsonConvert.DeserializeObject<List<Disease>>(json);
            return Ok(list);
        }
        //选择父级节点下面的具体疾病
        [HttpGet]
        [Route("FatherInDisease")]
        public IActionResult FatherInDisease(int id)
        {
            //id为父级id
            //select * from Disease where DiseaseFatherId={id}
            string sql = $"select * from Disease where DiseaseFatherId={id}";
            // string sql = $"select * from Disease d join Departments de on d.DiseaseFatherId=de.DepartmentsFather where de.DepartmentsId='{id}'";
            var dt = db.GetShow(sql);
            string json = JsonConvert.SerializeObject(dt);
            List<Disease> list = JsonConvert.DeserializeObject<List<Disease>>(json);
            return Ok(list);
        }
        //查看医生信息
        [HttpGet]
        [Route("ShowDoctorXinxi")]
        public IActionResult ShowDoctorXinxi(int id)
        {
            //id为医生的id
            string sql = $"select * from DoctorInfo where DoctorId={id}";
            var dt = db.GetShow(sql);
            string json = JsonConvert.SerializeObject(dt);
            List<DoctorInfo> list = JsonConvert.DeserializeObject<List<DoctorInfo>>(json);
            return Ok(list);
        }
        //支付
        [HttpPost]
        [Route("MoneyCreate")]
        public IActionResult MoneyCreate()
        {
            string sql = $"update DoctorInfo set DoctorNowMoney=DoctorNowMoney+300 where DoctorId=PatientDocoterNameId";
            //修改双方的金额
            var dt = db.CMD(sql);
            return Ok(dt);
        }
        //点击医生端个人信息  完善信息   完善是医生第一次登录注册  并没有该医生的信息
        //一种是你的账号和密码 类似qq什么的   个人是社会中的信息
        [HttpPost]
        [Route("AddDoctorInfoFirst")]
        public async Task<IActionResult> AddDoctorInfoFirst()
        {
            var file = Request.Form.Files;
            foreach (var item in file)
            {
                if (item.Length > 0)
                {
                    var wwwroot = iweb.ContentRootPath + "/wwwroot/img/";
                    var filename = Path.Combine(wwwroot, item.FileName);
                    using (var straem = System.IO.File.Create(filename))
                    {
                        DoctorInfo d = new DoctorInfo();
                        d.DoctorPicture = "/img/" + item.FileName;
                        string sql = $"insert into DoctorInfo values('{d.DoctorPicture}','{Request.Form["DoctorName"]}','{Request.Form["DoctorEducation"]}','{Request.Form["DoctorDepartmentsId"]}','{Request.Form["DoctorHospitalId"]}','{Request.Form["DoctorPosition"]}','{Request.Form["DoctorGood"]}','{Request.Form["DoctorWhy"]}','{Request.Form["DoctorHonour"]}','{Request.Form["DoctorMoney"]}','{Request.Form["DoctorMoney"]}','{Request.Form["DoctorNowMoney"]}','{Request.Form["UserDoctorInfo"]}')";
                        var dt = db.CMD(sql);
                        await item.CopyToAsync(straem);

                    }
                }

            }
            return Ok();

        }
        //根据登录的id获取登录信息
        [HttpGet]
        [Route("DoctorXinxiInName")]
        public IActionResult DoctorXinxiInName(int id)
        {
            //医生的id
            string sql = $"select * from DoctorInfo where DoctorId='{id}'";
            var dt2 = db.GetShow(sql);
            string json = JsonConvert.SerializeObject(dt2);
            List<DoctorInfo> usersxinxiid = JsonConvert.DeserializeObject<List<DoctorInfo>>(json);
            return Ok(usersxinxiid);
        }
        //反填医生的个人信息
        [HttpGet]
        [Route("FanDoctorMySelf")]
        public IActionResult FanDoctorMySelf(int id)
        {
            //id登陆后的id
            string sql = $"select * from DoctorInfo where DoctorId='{id}'";
            var dt = db.GetShow(sql);
            string json = JsonConvert.SerializeObject(dt);
            DoctorInfo list = JsonConvert.DeserializeObject<List<DoctorInfo>>(json).FirstOrDefault();
            return Ok(new { data = list, img = list.DoctorPicture });
        }
        //修改医生的个人信息
        [HttpGet]
        [Route("UpdateDoctorMySelf")]
        public async Task<IActionResult> ShowOneDoctor()
        {
            var file = Request.Form.Files;
            foreach (var item in file)
            {
                if (item.Length > 0)
                {
                    var wwwroot = iweb.ContentRootPath + "/wwwroot/img/";
                    var filename = Path.Combine(wwwroot, item.FileName);
                    using (var straem = System.IO.File.Create(filename))
                    {
                        DoctorInfo d = new DoctorInfo();
                        //id为医生的id  这是登陆后的  
                        d.DoctorPicture = "/img/" + item.FileName;
                        string sql = $"update  DoctorInfo set DoctorPicture='{d.DoctorPicture}',DoctorName='{Request.Form["DoctorName"]}',DoctorEducation='{Request.Form["DoctorEducation"]}',DoctorDepartmentsId='{Request.Form["DoctorDepartmentsId"]}',DoctorHospitalId='{Request.Form["DoctorHospitalId"]}',DoctorPosition='{Request.Form["DoctorPosition"]}',DoctorGood='{Request.Form["DoctorGood"]}',DoctorWhy='{Request.Form["DoctorWhy"]}',DoctorHonour='{Request.Form["DoctorHonour"]}',DoctorMoney='{Request.Form["DoctorMoney"]}',DoctorMoney='{Request.Form["DoctorMoney"]}',DoctorNowMoney='{Request.Form["DoctorNowMoney"]}',UserDoctorInfo='{Request.Form["UserDoctorInfo"]}' where DoctorId='{Request.Form["DoctorId"]}'";
                        var dt = db.CMD(sql);
                        await item.CopyToAsync(straem);

                    }
                }

            }
            return Ok();



        }
        //下拉框  医院
        [HttpGet]
        [Route("XLKHospital")]
        public IActionResult XLKHospital()
        {
            string sql = $"select * from Hospital";
            var dt = db.GetShow(sql);
            string json = JsonConvert.SerializeObject(dt);
            List<Hospital> list = JsonConvert.DeserializeObject<List<Hospital>>(json);
            return Ok(list);
        }
        //下拉框  科室
        [HttpGet]
        [Route("XLKDepartments")]
        public IActionResult XLKDepartments()
        {
            string sql = $"select * from Departments where DepartmentsFather=0";
            var dt = db.GetShow(sql);
            string json = JsonConvert.SerializeObject(dt);
            List<Departments> list = JsonConvert.DeserializeObject<List<Departments>>(json);
            return Ok(list);
        }
        //创建问卷调查表--给医生的
        [HttpGet]
        [Route("ExamSay")]
        public IActionResult ExamSay()
        {
            string sql = "select * from ExamSay";
            var dt = db.GetShow<ExamSay>(sql);
            //分数有ajax实现给值  这里不做传值   
            return Ok(dt);
        }
        //手术专题   纯显示
        [HttpGet]
        [Route("Surgery")]
        public IActionResult Surgery()
        {
            string sql = "select * from Surgery";
            var dt = db.GetShow<Surgery>(sql);
            return Ok(dt);
        }
        //手术专题   纯显示
        [HttpGet]
        [Route("SurgeryToId")]
        public IActionResult SurgeryId(int id)
        {
            //手术专题id   查看你具体的
            string sql = $"select * from Surgery where SurgeryId={id}";
            var dt = db.GetShow<Surgery>(sql);
            return Ok(dt);
        }
        //就医故事  纯显示
        [HttpGet]
        [Route("DoctorStory")]
        public IActionResult DoctorStory()
        {
            string sql = "select * from DoctorStory";
            var dt = db.GetShow<DoctorStory>(sql);
            return Ok(dt);
        }
        //就医故事  纯显示
        [HttpGet]
        [Route("DoctorStoryToId")]
        public IActionResult DoctorStoryId(int id)
        {
            string sql = $"select * from DoctorStory where DoctorStoryId={id}";
            var dt = db.GetShow<DoctorStory>(sql);
            return Ok(dt);
        }
        //医生查看都有那些患者给自己订单
        [HttpGet]
        [Route("ShowAllPatient")]
        public IActionResult SHowALLHuanZhe(int id)
        {
            string sql = $"select * from DoctorReservation join MoneyPayment on MoneyPayment.Reservationid=DoctorReservation.ReservationId join DoctorInfo on DoctorInfo.DoctorId=DoctorReservation.ReservationDoctorId join Hospital on Hospital.HospitalId= DoctorReservation.ReservationHospitalid join Patient on Patient.PatientID=DoctorReservation.ReservationNameId  where ReservationDoctorId={id}";
            var dt = db.GetShow(sql);
            string json = JsonConvert.SerializeObject(dt);
            List<DoctorReservation> list = JsonConvert.DeserializeObject<List<DoctorReservation>>(json);
            return Ok(list);
        }
        //医生查看都有那些患者给自己根据订单状态
        [HttpGet]
        [Route("ShowAllPatientTwo")]
        public IActionResult SHowALLHuanZheTwo(int id, int state)
        {
            string sql = $"select * from DoctorReservation join MoneyPayment on MoneyPayment.Reservationid=DoctorReservation.ReservationId join DoctorInfo on DoctorInfo.DoctorId=DoctorReservation.ReservationDoctorId join Hospital on Hospital.HospitalId= DoctorReservation.ReservationHospitalid join Patient on Patient.PatientID=DoctorReservation.ReservationNameId  where ReservationDoctorId={id} and PaymentState='{state}'";
            var dt = db.GetShow(sql);
            string json = JsonConvert.SerializeObject(dt);
            List<DoctorReservation> list = JsonConvert.DeserializeObject<List<DoctorReservation>>(json);
            return Ok(list);
        }
        //医生首页的发现主题
        [HttpGet]
        [Route("Story")]
        public IActionResult Story()
        {
            string sql = "select * from Story";
            var dt = db.GetShow<Story>(sql);
            return Ok(dt);
        }
        [HttpGet]
        [Route("StoryContent")]
        //医生首页具体的发现主题的文章
        public IActionResult StoryContent(int id)
        {
            string sql = $"select * from Story where StoryId='{id}'";
            var dt = db.GetShow<Story>(sql);
            return Ok(dt);
        }
        //个人中心   我的账户
        [HttpGet]
        [Route("DoctorMyMoney")]
        public IActionResult MyMoney(int id)
        {
            //id 为医生的id  
            string sql = $"select * from DoctorInfo where DoctorId={id}";
            var dt = db.GetShow(sql);
            string json = JsonConvert.SerializeObject(dt);
            DoctorInfo list = JsonConvert.DeserializeObject<List<DoctorInfo>>(json).FirstOrDefault();
            return Ok(list.DoctorNowMoney);
        }
        //根据用户ID获取患者个人信息
        [HttpGet]
        [Route("FanPatientMessages")]
        public IActionResult FanPatientMessages(int id)
        {
            //id为患者id
            var sql = $"select * from Patient p join Users u on p.UserPatientId=u.UsersId where u.UsersId={id}";
            var dt = db.GetShow(sql);
            string json = JsonConvert.SerializeObject(dt);
            Patient list = JsonConvert.DeserializeObject<List<Patient>>(json).FirstOrDefault();
            return Ok(list);

        }
        //客服 常见问题以及答案  只显示问题
        [HttpGet]
        [Route("AllWhy")]
        public IActionResult AllWhy()
        {
            string sql = "select * from QuestionAnswer";
            var dt = db.GetShow(sql);
            string json = JsonConvert.SerializeObject(dt);
            List<QuestionAnswer> list = JsonConvert.DeserializeObject<List<QuestionAnswer>>(json);
            return Ok(list);
        }
        //客服问题答案
        [HttpGet]
        [Route("Answer")]
        public IActionResult Answer(int id)
        {
            //id为问题标题id
            string sql = $"select * from QuestionAnswer where QuestionAnswerId='{id}'";
            var dt = db.GetShow(sql);
            string json = JsonConvert.SerializeObject(dt);
            QuestionAnswer list = JsonConvert.DeserializeObject<List<QuestionAnswer>>(json).FirstOrDefault();
            return Ok(list);
        }
        //点击签约专家去外地会诊信息 点击签约自动添加信息
        [HttpGet]
        [Route("Province")]
        public IActionResult Province(int id)
        {
            string sql2 = $"delete from Province where   ProvinceDoctorId=('{id}')";
            var dt2 = db.CMD(sql2);
            //id为登陆的医生id    其余的都是默认的  只有医生id市需要写的
            string sql = $"insert into Province(ProvinceDoctorId) values('{id}')";
            var dt = db.CMD(sql);
            return Ok(dt);
        }
        //根据医生id显示    签约的信息
        [HttpGet]
        [Route("ShowDoctorProvince")]
        public IActionResult ShowDoctorProvince(int id)
        {
            string sql = $"select * From Province where ProvinceDoctorId={id}";
            var dt = db.GetShow(sql);
            string json = JsonConvert.SerializeObject(dt);
            List<Province> list = JsonConvert.DeserializeObject<List<Province>>(json);
            return Ok(list);
        }
        //根据 签约的id   反填
        [HttpGet]
        [Route("FanDoctorProvince")]
        public IActionResult FanDoctorProvince(int id)
        {
            string sql = $"select * From Province where ProvinceId={id}";
            var dt = db.GetShow(sql);
            string json = JsonConvert.SerializeObject(dt);
            Province list = JsonConvert.DeserializeObject<List<Province>>(json).FirstOrDefault();
            return Ok(list);
        }
        //手动修改签约后的外地会诊信息
        [HttpPost]
        [Route("UpdateProvince")]
        public IActionResult UpdateProvince(Province p)
        {
            string sql = $"update Province set ProvinceNum='{p.ProvinceNum}',ProvinceTime='{p.ProvinceTime}',ProvinceDatetime='{p.ProvinceDatetime}',ProvinceCottoms='{p.ProvinceCottoms}',ProvinceMoney='{p.ProvinceMoney}',ProvinceDistrict='{p.ProvinceDistrict}',ProvinceRequire='{p.ProvinceRequire}' where ProvinceDoctorId='{p.ProvinceDoctorId}'";
            var dt = db.CMD(sql);
            return Ok(dt);
        }
        //医生收到预约未处理
        [HttpGet]
        [Route("NoDispose")]
        public IActionResult NoDispose(int id)
        {
            //id为医生id   查找未处理的
            string sql = $"select * from DoctorReservation join MoneyPayment on MoneyPayment.Reservationid=DoctorReservation.ReservationId where ReservationDoctorId='{id}' and PaymentState=1";

            var dt = db.GetShow<DoctorReservation>(sql);
            return Ok(dt);
        }
        //预约未处理  点击接收拒绝
        [HttpPost]
        [Route("YseNoDispose")]
        public IActionResult YseNoDispose()
        {
            //当点击同意 医生  状态修改  账户修改 
            string sql = "update DoctorInfo set DoctorNowMoney=DoctorNowMoney+10,PaymentState=2 where DoctorId=PatientDocoterNameId ";
            var dt = db.CMD(sql);
            return Ok(dt);
        }
        //所有题目
        [HttpGet]
        [Route("ExamSayShow")]
        public IActionResult ExamSayShow()
        {
            string sql = "select * from ExamSay ";
            var dt = db.GetShow<ExamSay>(sql);
            return Ok(dt);
        }
        //该题目所对应的选项
        [HttpGet]
        [Route("ExamOption")]
        public IActionResult ExamOption(int id)
        {
            string sql = $"select * from ExamSay join OptionMenu on ExamSay.ExamId=OptionMenu.QuestionId where ExamId='{id}'";
            var dt = db.GetShow(sql);
            string json = JsonConvert.SerializeObject(dt);
            List<OptionMenu> list = JsonConvert.DeserializeObject<List<OptionMenu>>(json);
            return Ok(list);
        }
        //完善患者的个人信息
        [HttpPost]
        [Route("AddPatientMySelf")]
        public IActionResult AddPatientMySelf(Patient p)
        {
            //添加前删除以前的信息  删除的话之前的数据没了   主键id   
            //string sql1 = $"delete from Patient where UserPatientId={p.UserPatientId}";
            //var dt1 = db.CMD(sql1);
            //登录用户id
            string sql = $"insert into Patient values('{p.PatientName}','{p.PatientSex}','{p.PatientAge}','{p.UserPatientId}','{p.PatientBirthday}')";
            var dt = db.CMD(sql) ;
            return Ok(dt);
        }
        //修改患者个人信息
        [HttpPost]
        [Route("UpdPatientMySelf")]
        public IActionResult UpdPatientMySelf(Patient p)
        {
            string sql = $"update Patient set PatientName='{p.PatientName}' ,PatientSex='{p.PatientSex}',PatientAge='{p.PatientAge}',UserPatientId='{p.UserPatientId}',PatientBirthday='{p.PatientBirthday}' where PatientID='{p.PatientID}'";
            var dt = db.CMD(sql);
            return Ok(dt);
        }
        //反填个人信息
        [HttpGet]
        [Route("FanPatientMySelf")]
        public IActionResult FanPatientMySelf(int id)
        {
            string sql = $"select * from Patient where PatientID='{id}'";
            var dt = db.GetShow(sql);
            string json = JsonConvert.SerializeObject(dt);
            Patient list = JsonConvert.DeserializeObject<List<Patient>>(json).FirstOrDefault();
            return Ok(list);
        }








    }
}
