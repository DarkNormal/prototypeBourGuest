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
        public string appImage { get; set; }
        [Display(Name = "Restaurant Name: ")]
        [Required(ErrorMessage = "The  restaurant name is required")]
        public string restaurantName { get; set; }
        [Display(Name = "Latitude: ")]
        public double latitude { get; set; }
        [Display(Name = "Longitude: ")]
        public double longitude { get; set; }
        [Display(Name = "Wheelchair Accessible? ")]
        public bool wheelchair { get; set; }
        [Display(Name = "Vegan options? ")]
        public bool vegan { get; set; }
        [Display(Name = "Wi-Fi zone? ")]
        public bool wifi { get; set; }
        [Required(ErrorMessage = "At least 1 type is required")]
        [Display(Name = "Restaurant Type(s): ")]
        public string type1 { get; set; }
        [Display(Name = "Second type: (Optional)")]
        public string type2 { get; set; }
        [Display(Name = "Third type: (Optional)")]
        public string type3 { get; set; }
        [Required(ErrorMessage = "A restaurant bio is required")]
        [Display(Name = "Bio: ")]
        public string bio { get; set; }
        [Required(ErrorMessage = "Opening/Closing times are required")]
        [Display(Name = "Opening / Closing hours")]
        public string openClose { get; set; }

        //EMAIL should not be displayed to the user, will be set in controller instead to limit errors
        public string Email { get; set; }


        [Display(Name = "Restaurant Phone Number: ")]
        [Required(ErrorMessage = "The phone number is required")]
        public string phoneNum { get; set; }
    }
}