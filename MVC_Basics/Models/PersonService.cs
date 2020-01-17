using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics.Models
{
    public class PersonService
    {
        static PersonService()
        {
            Person.personList.Add(new Person() { Id = PersonSequencer.NextPersonId(), Name = "Max", PhoneNumber = "074873638", City = "Kalmardog" });
            Person.personList.Add(new Person() { Id = PersonSequencer.NextPersonId(), Name = "Phil", PhoneNumber = "073284743", City = "Växjö" });
            Person.personList.Add(new Person() { Id = PersonSequencer.NextPersonId(), Name = "Ivardog", PhoneNumber = "070214238", City = "Götet" });
            Person.personList.Add(new Person() { Id = PersonSequencer.NextPersonId(), Name = "Kurt", PhoneNumber = "52353523255", City = "Stockholm" });
            Person.personList.Add(new Person() { Id = PersonSequencer.NextPersonId(), Name = "Bert", PhoneNumber = "65765774", City = "dogtown" });
        }


        public Person Create(string name, string phoneNumber, string city)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(phoneNumber) || string.IsNullOrWhiteSpace(city))
            {
                return null;
            }

            Person person = new Person()
            {
                Id = PersonSequencer.NextPersonId(),
                Name = name,
                PhoneNumber = phoneNumber,
                City = city
            };

            Person.personList.Add(person);
            return person;
        }

        public Person Find(int id)
        {
            return Person.personList.SingleOrDefault(person => person.Id == id);
        }

        public List<Person> All()
        {
            return Person.personList;
        }

        bool Update(Person person)
        {
            return true;
        }
    }
}
