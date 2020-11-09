using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctor_MaxOne_Four.DAL
{
    /// <summary>
    /// 医院表
    /// </summary>
    public class Hospital
    {
        public int HospitalId			 { get; set; }
        public string HospitalName		 { get; set; }
        public int HospitalVip			 { get; set; }
        public string HospitalAbstract	 { get; set; }
        public string HospitalDepartments	 { get; set; }
        public int HospitalDoctor { get; set; }
    }
}
