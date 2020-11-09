using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctor_MaxOne_Four.DAL
{
    /// <summary>
    /// 常见问题以及答案
    /// </summary>
    public class QuestionAnswer
    {
        public int QuestionAnswerId	 { get; set; }
        public string QuestionAnswerTitle	 { get; set; }
        public string QuestionAnswerOk { get; set; }
    }
}
