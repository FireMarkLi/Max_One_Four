using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctor_MaxOne_Four.DAL
{
    /// <summary>
    /// 医生表
    /// </summary>
    public class DoctorInfo
    {
        public int DoctorId			 { get; set; }
        public string DoctorName			 { get; set; }
        public string DoctorEducation		 { get; set; }
        public int DoctorDepartmentsId { get; set; }
        public int DoctorHospitalId { get; set; }
        public string DoctorPosition		 { get; set; }
      
        public string DoctorGood			 { get; set; }
        public string DoctorWhy			 { get; set; }
        public string DoctorHonour		 { get; set; }
        public int DoctorMoney			 { get; set; }
        public string DoctorExperience	 { get; set; }
        public int DoctorNowMoney { get; set; }
        public string DoctorPicture { get; set; }
        public int UserDoctorInfo { get; set; }

        //医院
        public int HospitalId { get; set; }
        public string HospitalName { get; set; }
        public string HospitalVip { get; set; }
        public string HospitalAbstract { get; set; }
        public int HospitalAddressId { get; set; }
        //科室
        public int DepartmentsId { get; set; }
        public string Departmentsname { get; set; }
        public int DepartmentsFather { get; set; }
        //用户
        public int UsersId { get; set; }
        public string UsersName { get; set; }
        public string UsersPwd { get; set; }
        public int UsersState { get; set; }
        public int UsersAdress { get; set; }
        public int UsersExam { get; set; }
        //地区
        public int AddressId { get; set; }
        public string AddressName { get; set; }
    }
}
