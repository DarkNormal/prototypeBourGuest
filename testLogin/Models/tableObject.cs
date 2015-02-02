using System;
using System.Collections.Generic;



namespace testLogin.Models
{
    public class tableObject
    {

        public int tableObjectID { get; set; }
        public int xcoord { get; set; }
        public int ycoord { get; set; }
        public int objType { get; set; }
        public bool available { get; set; }
        public int planID { get; set; }

        public virtual Floorplan Floorplan { get; set; }

    }
}
