using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics.Models
{
    interface IPersonService
    {
        Person Create(PersonViewModel person);
        Person Find(int id);
        List<Person> All();
        bool Update(PersonViewModel person);
    }
}
