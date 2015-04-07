using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testLogin.Models
{
    public class tableObjectBookings
    {
        public int id { get; set; }
        public int day { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public int tabObjID { get; set; }
        public int time { get; set; }
        public int depart { get; set; }
        public string uzer { get; set; }
    }
}