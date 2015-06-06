using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Test
{
    class ShowTimeInterface : Menus.Interfaces.IPerformAction
    {
        public void performAction(string i_ActionToInvokes)
        {
            Console.WriteLine("Current time is: " + DateTime.Now.ToString("h:mm:ss tt"));
        }
    }
}
