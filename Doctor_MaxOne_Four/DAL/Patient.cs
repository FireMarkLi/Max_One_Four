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
        public int UserPatientId { get; set; }



        public int UsersId { get; set; }
        public string UsersName { get; set; }
        public string UsersPwd { get; set; }
        public int UsersState { get; set; }
        public int UsersAdress { get; set; }
        public int UsersExam { get; set; }
    }
}
