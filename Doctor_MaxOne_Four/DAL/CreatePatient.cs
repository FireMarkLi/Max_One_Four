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
        public int PatientCity		 { get; set; }
        public string PatientDisease	 { get; set; }
        public string PatientProcess	 { get; set; }
        public string PatientPmg		 { get; set; }
        public int PatientPurpose	 { get; set; }
        public int PatientRecommend { get; set; }
        public int PatientHospital { get; set; }
    }
}
