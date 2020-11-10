using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctor_MaxOne_Four.DAL
{
    public class Departments
    {
        public int DepartmentsId	 { get; set; }
        public string Departmentsname	 { get; set; }
        public int DepartmentsFather { get; set; }
    }
}
