using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics.Models
{
    public class Person
    {
        public static List<Person> personList = new List<Person>();
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }

        public static void RemovePerson(int id)
        {
            for (int i = 0; i < personList.Count; i++)
            {
                if (personList[i].Id == id)
                {
                    personList.RemoveAt(i);
                    break;
                }
            }
        }

        public static void FilterPeople(string userInput)
        {


        }
    }
}
