﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctor_MaxOne_Four.DAL
{
    /// <summary>
    /// 医院科室配置
    /// </summary>
    public class DepartmentsHospital
    {
        public int DepartmentsHospitalId			 { get; set; }
        public string DepartmentsHospitalDepartmentsId { get; set; }
        public int DepartmentsHospitalHospitalId { get; set; }
    }
}
