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
        private string k_NO_SUCH_OPTION = "We're sorry, this options doesn't exist in our garage....";
        private string k_TRY_AGAIN = "Please try again";

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
            Console.Clear();
        }

        internal void CallForAction()
        {
            Console.Write(k_WHAT_WOULD_YOU_LIKE_TO_DO);
            ShowSuggestions();
        }

        internal int ReadFromConsole()
        {
            return Console.Read();
        }

        internal void ShowSuggestions()
        {
            // TODO: Genreate seven options
            Console.WriteLine("some opt");
        }

        internal void WrongNumberPicked()
        {
            Console.WriteLine(k_NO_SUCH_OPTION);
            Console.WriteLine(k_TRY_AGAIN);
            HoldScreen();
        }
    }
}
