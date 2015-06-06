using System;
using System.Collections.Generic;

using System.Text;
using System.Text.RegularExpressions;

namespace Ex04.Menus.Test
{
    class CountWordsInterface : Interfaces.IPerformAction
    {

        public void performAction(string i_ActionToInvokes)
        {
            string userInput = "";
            Console.WriteLine("Please enter a string");
            userInput = Console.ReadLine();
            MatchCollection collection = Regex.Matches(userInput, @"[\S]+");
            Console.WriteLine("Amount of words: " + collection.Count);
            Console.ReadLine();
        }
    }
}
