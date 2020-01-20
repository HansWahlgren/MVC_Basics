using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics.Models
{
    public class PersonService : IPersonService
    {
        static PersonService()
        {
            Person.personList.Add(new Person() { Id = PersonSequencer.NextPersonId(), Name = "Max", PhoneNumber = "074873638", City = "Kalmardog" });
            Person.personList.Add(new Person() { Id = PersonSequencer.NextPersonId(), Name = "Phil", PhoneNumber = "073284743", City = "Växjö" });
            Person.personList.Add(new Person() { Id = PersonSequencer.NextPersonId(), Name = "Ivardog", PhoneNumber = "070214238", City = "Götet" });
            Person.personList.Add(new Person() { Id = PersonSequencer.NextPersonId(), Name = "Kurt", PhoneNumber = "52353523255", City = "Stockholm" });
            Person.personList.Add(new Person() { Id = PersonSequencer.NextPersonId(), Name = "Bert", PhoneNumber = "65765774", City = "dogtown" });
        }


        public Person Create(PersonViewModel person)
        {
            if (string.IsNullOrWhiteSpace(person.Name) || string.IsNullOrWhiteSpace(person.PhoneNumber) || string.IsNullOrWhiteSpace(person.City))
            {
                return null;
            }

            Person newPerson = new Person()
            {
                Id = PersonSequencer.NextPersonId(),
                Name = person.Name,
                PhoneNumber = person.PhoneNumber,
                City = person.City
            };

            Person.personList.Add(newPerson);
            return newPerson;
        }

        public Person Find(int id)
        {
            return Person.personList.SingleOrDefault(person => person.Id == id);
        }

        public List<Person> All()
        {
            return Person.personList;
        }

        public Person Update(PersonViewModel person, int id)
        {
            if (string.IsNullOrWhiteSpace(person.Name) || string.IsNullOrWhiteSpace(person.PhoneNumber) || string.IsNullOrWhiteSpace(person.City))
            {
                return null;
            }

            Person oldPerson = Find(id);

            oldPerson.Name = person.Name;
            oldPerson.PhoneNumber = person.PhoneNumber;
            oldPerson.City = person.City;

            return oldPerson;
        }
    }
}
