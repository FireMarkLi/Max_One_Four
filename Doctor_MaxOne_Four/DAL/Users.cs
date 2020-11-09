using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctor_MaxOne_Four.DAL
{
    /// <summary>
    /// Users
    /// </summary>
    public class Users
    {
        public int UsersId		 { get; set; }
        public string UsersName	 { get; set; }
        public string UsersPwd	 { get; set; }
        public int UsersState	 { get; set; }
        public int UsersAdress	 { get; set; }
        public int UsersExam { get; set; }
    }
}
