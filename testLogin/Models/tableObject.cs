using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testLogin.Models
{
    class tableObject
    {
        [key]
        int userID { get; set; }
        int xcoord { get; set; }
        int ycoord { get; set; }
        int objType { get; set; }
        char available { get; set; }

    }
}
