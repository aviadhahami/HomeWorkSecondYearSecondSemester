using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Ex04.Menus.Interfaces
{
    class InfoMenu : IInfo
    {
        private const string k_VERSION_STRING = "Version: 15.2.4.0";
        private const string k_ASK_FOR_STRIGN = "Please enter a string";
        private const string k_AMOUNT_OF_WORDS = "Amount of words: ";
        private const string k_WHITE_SPACE_REGEX = @"[\S]+";

        public void ShowVersion()
        {
            Console.WriteLine(k_VERSION_STRING);
        }

        public void CountWords()
        {
            Console.WriteLine(k_ASK_FOR_STRIGN);
            string userInput = Console.ReadLine();
            MatchCollection collection = Regex.Matches(userInput, k_WHITE_SPACE_REGEX);
            Console.WriteLine(k_AMOUNT_OF_WORDS + collection.Count);
        }
    }
}
