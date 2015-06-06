using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Test
{
    class ShowDateInterface : Interfaces.IPerformAction
    {
        public void performAction(string i_ActionToInvokes)
        {
            Console.WriteLine("Current date is: " + DateTime.Today);
        }
    }
}
