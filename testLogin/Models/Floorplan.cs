using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testLogin.Models
{
    public class Floorplan
    {
        public int id { get; set; }
        public int height { get; set; }
        public int width { get; set; }
        public int numObjects { get; set; }
        public int restID { get; set; }
    }
}