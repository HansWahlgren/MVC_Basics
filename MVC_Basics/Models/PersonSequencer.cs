using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics.Models
{
    public class PersonSequencer
    {
        private static int personId = 0;
        public static int NextPersonId()
        {
            return (++personId);
        }

        public static void Reset()
        {
            personId = 0;
        }
    }
}
