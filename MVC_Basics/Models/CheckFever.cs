using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics.Models
{
    public class CheckFever
    {
        public static string CalculateFever(float temperature, string tempChoice)
        {
            if (tempChoice == "fahrenheit")
            {
                temperature = (temperature - 32) * 5/9;
            }
            if (temperature > 46 || temperature < 20 )
            {
                return "You are dead!";
            }
            else if(temperature > 38)
            {
                return "You have fever!";
            }
            else if(temperature < 35)
            {
                return "You have Hypothermia!";
            }
            else
            {
                return "You do not have fever!";
            }
        }
    }
}
