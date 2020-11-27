using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctor_MaxOne_Four.DAL
{
    /// <summary>
    /// Users
    /// </summary>
    public class Users
    {
        public int UsersId		 { get; set; }
        public string UsersName	 { get; set; }
        public string UsersPwd	 { get; set; }
        public int UsersState	 { get; set; }
        public int UsersAdress	 { get; set; }
        public int UsersExam { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string DoctorEducation { get; set; }
        public int DoctorDepartmentsId { get; set; }
        public int DoctorHospitalId { get; set; }
        public string DoctorPosition { get; set; }




        public int PatientID { get; set; }
        public int PatientUsers { get; set; }
        public string PatientName { get; set; }
        public int PatientSex { get; set; }
        public int PatientAge { get; set; }
        public DateTime PatientBirthday { get; set; }


    }
}
