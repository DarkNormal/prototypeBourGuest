using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace testLogin.Models
{
    public class tableObject
    {
        [Key]
        int userID { get; set; }

        int xcoord { get; set; }
        int ycoord { get; set; }
        int objType { get; set; }
        char available { get; set; }

    }
}
