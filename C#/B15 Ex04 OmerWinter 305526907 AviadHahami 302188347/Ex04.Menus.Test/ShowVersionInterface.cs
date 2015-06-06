using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Test
{
    class ShowVersionInterface : Interfaces.IPerformAction
    {
        public void performAction(string i_ActionToInvokes)
        {
            Console.WriteLine("Version: 15.2.4.0");
            Console.ReadLine();
        }
    }
}
