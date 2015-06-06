using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    class ShowDateOrTimeMenu : IShowDateOrTime
    {
        private const string k_DATE_FORMAT = "d";
        private const string k_TIME_FORMAT = "h:mm:ss tt";

        private readonly List<IPickObserver> m_PickingObservers = new List<IPickObserver>();

        public void ShowTime()
        {
            Console.WriteLine(DateTime.Now.ToString(k_TIME_FORMAT));
        }

        public void ShowDate()
        {
            Console.WriteLine(DateTime.Now.ToString(k_DATE_FORMAT));
        }

        internal void AttachPickObserver(IPickObserver i_PickObserver)
        {
            m_PickingObservers.Add(i_PickObserver);
        }
    }
}
