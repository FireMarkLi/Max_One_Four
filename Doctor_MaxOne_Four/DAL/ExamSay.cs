using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctor_MaxOne_Four.DAL
{
    /// <summary>
    /// 调查问卷
    /// </summary>
    public class ExamSay
    {
        public int ExamId		 { get; set; }
        public string ExamName	 { get; set; }
        public string ExamAnswer	 { get; set; }
        public int ExamNum { get; set; }
        public string RealAnswer { get; set; }
    }
}
