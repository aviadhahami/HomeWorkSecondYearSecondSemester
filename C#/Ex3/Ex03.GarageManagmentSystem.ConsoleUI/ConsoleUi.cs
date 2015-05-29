using System;
using System.Collections.Generic;
using System.Text;
using B15_EX3_AVIADHAHAMI_302188347_OMERWINTER_305526907;

namespace Ex03.GarageManagmentSystem.ConsoleUI
{
    class ConsoleUI
    {
        UITexts m_UIStrings;
        public void MainUIProcess()
        {

            // Instansiate the UI
            UITexts m_UIStrings = new UITexts();

            // Greet the mofos
            m_UIStrings.SayHi();
            m_UIStrings.HoldScreen();

            // Suggest options
            GarageOption userPick = suggestOptionsToUser();

            // If we reached this it means we have a legit number picked by the user
            Console.WriteLine("Goodie! we have valid pick");
            m_UIStrings.HoldScreen();
        }

        private static GarageOption suggestOptionsToUser()
        {
            int singleCharConsoleInput;
            UITexts m_UIStrings = new UITexts();
            while (true)
            {
                m_UIStrings.CallForAction();
                singleCharConsoleInput = m_UIStrings.ReadUserOptionPick();
                if (!validateOptionNumber(singleCharConsoleInput))
                {
                    m_UIStrings.WrongNumberPicked();
                }
                else
                {

                    // Delete this when done
                    Console.WriteLine("User picked " + (GarageOption)singleCharConsoleInput);
                    return (GarageOption)singleCharConsoleInput;
                }
            }
        }

        private static bool validateOptionNumber(int i_SingleCharConsoleInput)
        {
            int enumSize = Enum.GetNames(typeof(GarageOption)).Length;
            return i_SingleCharConsoleInput >= 1 && i_SingleCharConsoleInput <= enumSize;
        }
    }
}
