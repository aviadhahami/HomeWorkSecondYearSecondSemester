using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu : IPickObserver
    {
        private const string k_WRONG_INPUT_TYPE = "Please type a proper choice's index";
        private const string k_HEADER_SEPARATOR = "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";
        private const string k_PLEASE_PICK_AN_INDEX = "Please pick a choice's index";
        private const string k_SAY_BYE = "Thank you and goodbye!";
        private const string k_NO_SUCH_OPTION = "There isn't such an option, retry";
        private const string k_CONTACT_ADMIN = "Something happened, please contant support";
        private const string k_EXIT_APP = "0) Exit application";
        private const string k_GO_BACK = "0) Go back";

        // Classes members
        private readonly List<object> m_MenuItem = new List<object>();

        public MainMenu()
        {
            // Add "workers" to "company"
            InfoMenu infoMenu = new InfoMenu();
            infoMenu.AttachPickObserver(this as IPickObserver);
            m_MenuItem.Add(infoMenu);

            ShowDateOrTimeMenu showDateMenu = new ShowDateOrTimeMenu();
            showDateMenu.AttachPickObserver(this as IPickObserver);
            m_MenuItem.Add(showDateMenu);
        }

        // Main show method
        public void Show()
        {
            int i;
            string userInput;
            bool parsingFlag = false;
            int parsedValue = -1;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(this.GetType().Name);
                Console.WriteLine(k_HEADER_SEPARATOR);
                i = 0;
                Console.WriteLine(i + ") Exit");
                foreach (object item in m_MenuItem)
                {
                    Console.WriteLine(++i + ") " + item.GetType().Name);
                }
                userInput = Console.ReadLine();
                parsingFlag = int.TryParse(userInput, out parsedValue);
                if (parsingFlag)
                {
                    if (validIndexRange(parsedValue))
                    {
                        // If we reached here, we should invoke something
                        Console.WriteLine("Good good");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine(k_NO_SUCH_OPTION);
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine(k_WRONG_INPUT_TYPE);
                    Console.ReadLine();
                }
            }
        }

        private bool validIndexRange(int i_Index)
        {
            return i_Index >= 0 && i_Index <= m_MenuItem.Count;
        }


        // Inherited
        public void NotifyPick()
        {

        }
    }
}
