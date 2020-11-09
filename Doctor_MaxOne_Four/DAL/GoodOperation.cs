using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctor_MaxOne_Four.DAL
{
    /// <summary>
    /// 公益手术
    /// </summary>
    public class GoodOperation
    {
        public int GoodOperationId		 { get; set; }
        public string GoodOperationWhy	 { get; set; }
        public string GoodOperationAnswer { get; set; }
    }
}
