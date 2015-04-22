using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace testLogin.Models
{
    public class Floorplan
    {
        public int id { get; set; }
        public int height { get; set; }
        public int width { get; set; }
        [Display(Name = "Number of tables")]
        public int numObjects { get; set; }
        public int restID { get; set; }
        [Display(Name = "Floorplan Name")]
        public string planName { get; set; }
        [Display(Name = "Active/Inactive")]
        public bool active { get; set; }

    }
}