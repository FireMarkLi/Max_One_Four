using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctor_MaxOne_Four.DAL
{
    /// <summary>
    /// 点击签约专家去外地会诊信息
    /// </summary>
    public class Province
    {
        public int ProvinceId		 { get; set; }
        public int ProvinceNum		 { get; set; }
        public string ProvinceTime	 { get; set; }
        public string ProvinceDatetime { get; set; }
        public string ProvinceCottoms	 { get; set; }
        public string ProvinceMoney	 { get; set; }
        public string ProvinceDistrict { get; set; }
        public string ProvinceRequire { get; set; }
    }
}
