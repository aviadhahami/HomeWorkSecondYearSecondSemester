﻿using System;
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

            // Suggest options
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
                    break;
                }
            }
            // If we reached this it means we have a legit number picked by the user

        }

        private static bool validateOptionNumber(int i_SingleCharConsoleInput)
        {
            int enumSize = Enum.GetNames(typeof(GarageOption)).Length;
            Console.WriteLine(i_SingleCharConsoleInput);
            return i_SingleCharConsoleInput >= 1 && i_SingleCharConsoleInput <= enumSize;
        }
    }
}
