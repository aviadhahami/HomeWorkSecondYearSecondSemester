using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    class ShowDateOrTimeMenu : IShowDateOrTime
    {
        private const string k_DATE_FORMAT = "d";
        private const string k_TIME_FORMAT = "h:mm:ss tt";

        public void ShowTime()
        {
            Console.WriteLine(DateTime.Now.ToString(k_TIME_FORMAT));
        }

        public void ShowDate()
        {
            Console.WriteLine(DateTime.Now.ToString(k_DATE_FORMAT));
        }
    }
}
