using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace testLogin.Models
{
    public class Restaurant
    {
        public int id { get; set; }
        [Display(Name= "Restaurant Name")]
        [Required(ErrorMessage = "The  restaurant name is required")]
        public string restaurantName { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        [Display(Name = "Wheelchair accessible? ")]
        public bool wheelchair { get; set; }
        public bool vegetarian { get; set; }
        [Required(ErrorMessage = "At least 1 type is required")]
        [Display(Name = "Restaurant Type(s):")]
        public string type1 { get; set; }
        public string type2 { get; set; }
        public string type3 { get; set; }
        [Required(ErrorMessage = "A restaurant bio is required")]
        public string bio { get; set; }
        [Required(ErrorMessage = "Opening/Closing times are required")]
        [Display(Name = "Opening / Closing hours")]
        public string openClose { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }


        [Display(Name = "Restaurant Phone Number")]
        [Required(ErrorMessage = "The phone number is required")]
        public string phoneNum { get; set; }
    }
}