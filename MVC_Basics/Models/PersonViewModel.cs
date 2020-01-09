using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_Basics.Models
{
    public class PersonViewModel
    {
        public static List<Person> personList = new List<Person>();

        [Required]
        [StringLength(60, MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 1)]
        public string City { get; set; }
    }
}
