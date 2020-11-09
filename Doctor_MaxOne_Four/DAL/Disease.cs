using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctor_MaxOne_Four.DAL
{
    /// <summary>
    /// 疾病科室
    /// </summary>
    public class Disease
    {
        public int DiseaseId			 { get; set; }
        public string DiseaseDepartments	 { get; set; }
        public int DiseaseFatherId { get; set; }
    }
}
