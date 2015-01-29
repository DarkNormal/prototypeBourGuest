using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace testLogin.Models
{
    public class Floorplan
    {
        [Key]public int userID { get; set; }
        public int tableHeight { get; set; }
        public int tableWidth { get; set; }
        //public ICollection<tableObject> tableObjects { get; set; }

    }
}