using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctor_MaxOne_Four.DAL
{
    /// <summary>
    /// 预约科室
    /// </summary>
    public class SubscribeSection
    {
        public int SubscribeSectionId				 { get; set; }
        public string SubscribeSectionSpecial			 { get; set; }
        public string SubscribeSectionRecommend		 { get; set; }
        public int SubscribeSectionDoctor			 { get; set; }
        public int SubscribeSectionUsersid			 { get; set; }
        public string SubscribeSectionName			 { get; set; }
        public string SubscribeSectionDescribe		 { get; set; }
        public string SubscribeSectionImg				 { get; set; }
        public int SubscribeSectionMoney			 { get; set; }
        public string SubscribeSectionIndent			 { get; set; }
        public string SubscribeSectionTitle			 { get; set; }
        public string SubscribeSectionParticulars		 { get; set; }
        public int SubscribeSectionState { get; set; }
    }
}
