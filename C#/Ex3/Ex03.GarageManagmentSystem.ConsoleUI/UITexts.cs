using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagmentSystem.ConsoleUI
{
    class UITexts
    {
        private const string k_LINE_SPAN = "                         ";
        private const string k_HALF_LINE_SPAN = "               ";
        private const string k_GREETINGS = "Hi, Welcome to Abu Ali's garage!";
        private const string k_DECORATED_LINE_SEPARATOR = "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";
        private const string k_PRESS_ANY_KEY = "Press any key to continue";
        private const string k_WHAT_WOULD_YOU_LIKE_TO_DO = "What would you like to do Sir?";

        internal void SayHi()
        {
            generateLineSpan();
            Console.WriteLine(k_GREETINGS);
            generateHalfLineSpan();
            Console.WriteLine(k_DECORATED_LINE_SEPARATOR);
        }

        private void generateHalfLineSpan()
        {
            Console.Write(k_HALF_LINE_SPAN);
        }

        private void generateLineSpan()
        {
            Console.Write(k_LINE_SPAN);
        }

        internal void HoldScreen()
        {
            Console.Write(k_PRESS_ANY_KEY);
            Console.Read();
        }

        internal void CallForAction()
        {
            Console.Write(k_WHAT_WOULD_YOU_LIKE_TO_DO);
        }
    }
}
