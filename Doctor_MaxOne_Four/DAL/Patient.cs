using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctor_MaxOne_Four.DAL
{
    /// <summary>
    /// 病人患者表
    /// </summary>
    public class Patient
    {
        public int PatientID		 { get; set; }
        public string PatientName		 { get; set; }
        public int PatientSex		 { get; set; }
        public int PatientAge		 { get; set; }
        public DateTime PatientBirthday { get; set; }
    }
}
