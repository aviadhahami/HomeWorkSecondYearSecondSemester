using System;
using System.Collections.Generic;
using System.Text;
using B15_EX3_AVIADHAHAMI_302188347_OMERWINTER_305526907;

namespace Ex03.GarageManagmentSystem.ConsoleUI
{
    class ConsoleUI
    {

        static void Main()
        {
            int singleCharConsoleInput;

            // Instansiate the UI
            UITexts m_UIStrings = new UITexts();

            // Greet the mofos
            m_UIStrings.SayHi();
            m_UIStrings.HoldScreen();

            //Suggest options
            while (true)
            {
                m_UIStrings.CallForAction();

                singleCharConsoleInput = m_UIStrings.ReadFromConsole();
                if (!validateOptionNumber(singleCharConsoleInput))
                {
                    m_UIStrings.WrongNumberPicked();
                }
                else
                {

                    break;
                }
            }
            // If we reached this it means we have a legit number picked by the user

        }

        private static bool validateOptionNumber(int singleCharConsoleInput)
        {
            return false;// throw new NotImplementedException();
        }
    }
}
