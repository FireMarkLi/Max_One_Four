using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctor_MaxOne_Four.DAL
{
    public class OptionMenu
    {
        public int OptionMenuId { get; set; }
        public int QuestionId { get; set; }
        public string OptionContent { get; set; }
        public bool IsTure { get; set; }
        public int Grade { get; set; }
        public string ExamQuestion { get; set; }
        public int ExamType { get; set; }


        public int ExamId { get; set; }

    }
}
