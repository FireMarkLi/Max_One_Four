using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctor_MaxOne_Four.DAL
{
    /// <summary>
    /// 医生首页的发现主题
    /// </summary>
    public class Story
    {
        public int StoryId		 { get; set; }
        public string StoryImg	 { get; set; }
        public string StoryContent { get; set; }
    }
}
