using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace testLogin.Models
{
    public class Restaurant
    {
        public int RestaurantID { get; set; }
        [Display(Name= "Restaurant Name")]
        public string restaurantName { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        [Display(Name = "Wheelchair accessible? ")]
        public bool wheelchair { get; set; }
        public bool vegetarian { get; set; }
        public string type { get; set; }
        public string bio { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        public virtual ICollection<Floorplan> Floorplans { get; set; }
    }
}