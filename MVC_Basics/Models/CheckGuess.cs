using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics.Models
{
    public class CheckGuess
    {
        public static int CreateNumber()
        {
            Random random = new Random();
            return random.Next(1,100);
        }

        public static string CompareGuess(int? userNumber, int? randomNumber)
        {
            if (userNumber < randomNumber)
            {
                return ("low");
            }
            else if (userNumber > randomNumber)
            {
                return ("high");
            }
            else
            {
                return ("correct");
            }
        }
    }
}
