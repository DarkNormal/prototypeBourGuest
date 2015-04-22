using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace testLogin.Models
{
    public class Bookings
    {
        public int id { get; set; }
        [Display(Name = "Number of tables booked")]
        public int numTables { get; set; }
        [Display(Name = "User email")]
        public string userID { get; set; }
        public int numPeople { get; set; }
        public int day { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public int time { get; set; }
        public int restID { get; set; }

    }
}