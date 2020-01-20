using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics.Models
{
    public interface IPersonService
    {
        Person Create(PersonViewModel person);
        Person Find(int id);
        List<Person> All();
        Person Update(PersonViewModel person, int id);
    }
}
