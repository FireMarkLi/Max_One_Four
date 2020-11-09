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
        public string DoctorDepartments	 { get; set; }
        public string DoctorPosition		 { get; set; }
        public string DoctorHospital		 { get; set; }
        public string DoctorGood			 { get; set; }
        public string DoctorWhy			 { get; set; }
        public string DoctorHonour		 { get; set; }
        public int DoctorMoney			 { get; set; }
        public string DoctorExperience	 { get; set; }
        public int DoctorNowMoney { get; set; }
    }
}
