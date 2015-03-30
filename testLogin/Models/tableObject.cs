using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace testLogin.Models
{
    public class tableObject
    {

        public int id { get; set; }
        public int xcoord { get; set; }
        public int ycoord { get; set; }
        public int objType { get; set; }
        public bool available { get; set; }
        public int floorplanID { get; set; }

    }
}
