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
        public int PaymentDoctorReservationId { get; set; }
        public string PaymentName			 { get; set; }
        public int PaymentDoctor		 { get; set; }
        public string PaymentTitle		 { get; set; }
        public string PaymentParticulars	 { get; set; }
        public int PaymentState		 { get; set; }
        public int PaymentPeople { get; set; }


        public int Reservationid { get; set; }
        public int ReservationName { get; set; }
        public string ReservationCottoms { get; set; }
        public string ReservationDescribe { get; set; }
        public string ReservationImg { get; set; }
        public int ReservationDoctor { get; set; }




        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string DoctorEducation { get; set; }
        public int DoctorDepartmentsId { get; set; }
        public int DoctorHospitalId { get; set; }
        public string DoctorPosition { get; set; }
        public int DoctorMoney { get; set; }

        public string DoctorGood { get; set; }
        public string DoctorWhy { get; set; }
        public string DoctorHonour { get; set; }

        public string DoctorExperience { get; set; }
        public int DoctorNowMoney { get; set; }
        public string DoctorPicture { get; set; }
        public int UserDoctorInfo { get; set; }
    }
}
