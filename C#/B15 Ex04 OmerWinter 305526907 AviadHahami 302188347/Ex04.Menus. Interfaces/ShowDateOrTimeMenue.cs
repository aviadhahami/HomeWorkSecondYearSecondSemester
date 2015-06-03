using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    class ShowDateOrTimeMenue : IShowDateOrTime
    {
        public void ShowTime()
        {
            Console.WriteLine(DateTime.Now.ToString("h:mm:ss tt"));
        }

        public void ShowDate()
        {
            Console.WriteLine(DateTime.Now.ToString("d"));
        }
    }
}
