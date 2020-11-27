using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctor_MaxOne_Four.DAL
{
    /// <summary>
    /// 创建按钮  管理员添加
    /// </summary>
    public class CreatePatient
    {
        public int PatientId		 { get; set; }
        public string PatientName		 { get; set; }
        public string PatientPhone	 { get; set; }
        public DateTime PatientBirthday	 { get; set; }
        public int PatientSex		 { get; set; }
        public int PatientCity { get; set; }
        public string PatientDiseaseName { get; set; }
        public string PatientProcess { get; set; }
        public string PatientPmg { get; set; }
        public int PatientPurpose { get; set; }
        public int PatientHospitalId { get; set; }
        public int PatientDiseaseId	 { get; set; }
        public int PatientDocoterNameId { get; set; }
      
        //科室表
        public int DepartmentsId { get; set; }
        public string Departmentsname { get; set; }
        //医院表
        public int HospitalId { get; set; }
        public string HospitalName { get; set; }
        //医生表
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        //地区表
        public int AddressId { get; set; }
        public string AddressName { get; set; }
    }
}
