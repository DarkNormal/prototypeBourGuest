using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testLogin.Models
{
    public class Restaurant
    {
        public int RestaurantID { get; set; }
        public int latitude { get; set; }
        public int longitude { get; set; }
        public string bio { get; set; }

    }
}