using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_Basics.Models
{
    public class PersonViewModel
    {
        public static List<Person> personList = new List<Person>();

        [Required]
        public string Name { get; set; }

        [Required]
        public string Phonenumber { get; set; }

        [Required]
        public string City { get; set; }
    }
}
