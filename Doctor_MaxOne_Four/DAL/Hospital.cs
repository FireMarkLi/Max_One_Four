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
        public string HospitalVip			 { get; set; }
        public string HospitalAbstract	 { get; set; }
        public int HospitalAddressId { get; set; }


        public int DepartmentsId { get; set; }
        public string Departmentsname { get; set; }
        public int DepartmentsFather { get; set; }


        public int DepartmentsHospitalId { get; set; }
        public string DepartmentsHospitalDepartmentsId { get; set; }                
        public int DepartmentsHospitalHospitalId { get; set; }


        public int AddressId { get; set; }
        public string AddressName { get; set; }
    }
}
