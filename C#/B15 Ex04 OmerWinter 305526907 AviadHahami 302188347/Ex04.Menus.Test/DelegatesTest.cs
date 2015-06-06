using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Ex04.Menus.Test
{
    class DelegatesTest
    {

        private Delegates.MainMenu m_MainMenu;

        public DelegatesTest(string i_MenuTitle)
        {
            m_MainMenu = new Delegates.MainMenu(i_MenuTitle);
        }

        public void InitMenu()
        {

            Delegates.MenuItem menuItem1 = new Delegates.MenuItem("Show date/time");
            menuItem1.AddMenuItem(new Delegates.MenuItem("Show Date", ShowDate));
            menuItem1.AddMenuItem(new Delegates.MenuItem("Show Time", ShowTime));
            m_MainMenu.AddOption(menuItem1);

            // Inite second menu
            Delegates.MenuItem menuItem2 = new Delegates.MenuItem("Show info");
            menuItem2.AddMenuItem(new Delegates.MenuItem("Count words", WordsCounter));
            menuItem2.AddMenuItem(new Delegates.MenuItem("Show version", ShowVersion));
            m_MainMenu.AddOption(menuItem2);
        }

        private void ShowVersion()
        {
            Console.WriteLine("Version: 15.2.4.0");
            Console.ReadLine();
        }

        private void WordsCounter()
        {
            string userInput = "";
            Console.WriteLine("Please enter a string");
            userInput = Console.ReadLine();
            MatchCollection collection = Regex.Matches(userInput, @"[\S]+");
            Console.WriteLine("Amount of words: " + collection.Count);
            Console.ReadLine();
        }

        private void ShowTime()
        {
            Console.WriteLine("Current time is: " + DateTime.Now.ToString("h:mm:ss tt"));
            Console.ReadLine();
        }

        private void ShowDate()
        {
            Console.WriteLine("Current date is: " + DateTime.Today);
            Console.ReadLine();
        }

        internal void InvokeMenu()
        {
            m_MainMenu.Show();
        }
    }
}
