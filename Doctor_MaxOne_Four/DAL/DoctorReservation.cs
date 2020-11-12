﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctor_MaxOne_Four.DAL
{
    /// <summary>
    /// 预约单
    /// </summary>
    public class DoctorReservation
    {
        public int Reservationid			 { get; set; }
        public int ReservationName			 { get; set; }
        public string ReservationCottoms		 { get; set; }
        public string ReservationDescribe		 { get; set; }
        public string ReservationImg			 { get; set; }
        public int ReservationDoctor { get; set; }


        public int PaymentId { get; set; }
        public int PaymentDoctorReservationId { get; set; }
        public string PaymentName { get; set; }
        public int PaymentDoctor { get; set; }
        public string PaymentTitle { get; set; }
        public string PaymentParticulars { get; set; }
        public int PaymentState { get; set; }
        public int PaymentPeople { get; set; }
    }
}
