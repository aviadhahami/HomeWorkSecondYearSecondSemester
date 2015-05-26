using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageManagmentSystem.ConsoleUI
{
    class UITexts
    {
        private const string k_GREETINGS = "Hi, Welcome to our garage!";
        private const string k_DECORATED_LINE_SEPARATOR = "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";

        internal void sayHi()
        {
            Console.WriteLine(k_GREETINGS);
            Console.WriteLine(k_DECORATED_LINE_SEPARATOR);
        }

        internal void HoldScreen()
        {
            Console.WriteLine("Press any key to continue");
            Console.Read();
        }
    }
}
