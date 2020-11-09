using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctor_MaxOne_Four.DAL
{
    /// <summary>
    /// 支付表
    /// </summary>
    public class MoneyPayment
    {
        public int PaymentId			 { get; set; }
        public string PaymentName			 { get; set; }
        public int PaymentDoctor		 { get; set; }
        public string PaymentTitle		 { get; set; }
        public string PaymentParticulars	 { get; set; }
        public int PaymentState		 { get; set; }
        public int PaymentPeople { get; set; }
    }
}
