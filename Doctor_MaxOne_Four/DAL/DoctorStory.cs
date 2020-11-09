using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctor_MaxOne_Four.DAL
{
    /// <summary>
    /// 就医故事
    /// </summary>
    public class DoctorStory
    {
        public int DoctorStoryId		 { get; set; }
        public string DoctorStoryImg		 { get; set; }
        public string DoctorStoryTitle	 { get; set; }
        public string DoctorStoryContent { get; set; }
    }
}
