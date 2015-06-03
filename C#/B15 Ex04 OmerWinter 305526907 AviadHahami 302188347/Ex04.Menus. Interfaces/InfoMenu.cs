using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Ex04.Menus.Interfaces
{
    class InfoMenu : IInfo
    {
        private const string k_VERSION_STRING = "Version: 15.2.4.0";

        public void ShowVersion()
        {
            Console.WriteLine(k_VERSION_STRING);
        }

        public void CountWords()
        {
            Console.WriteLine("Please enter a string");
            string userInput = Console.ReadLine();
            MatchCollection collection = Regex.Matches(userInput, @"[\S]+");
            Console.WriteLine("Amount of words: " + collection.Count);
        }
    }
}
