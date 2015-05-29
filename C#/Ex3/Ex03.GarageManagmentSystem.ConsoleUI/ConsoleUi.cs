using System;
using System.Collections.Generic;
using System.Text;
using B15_EX3_AVIADHAHAMI_ID_OMERWINTER_ID;

namespace Ex03.GarageManagmentSystem.ConsoleUI
{
    class ConsoleUI
    {

        static void Main()
        {
            // Instansiate the UI
            UITexts m_UIStrings = new UITexts();
            
            // Greet the mofos
            m_UIStrings.sayHi();
            m_UIStrings.HoldScreen();


        }
    }
}
