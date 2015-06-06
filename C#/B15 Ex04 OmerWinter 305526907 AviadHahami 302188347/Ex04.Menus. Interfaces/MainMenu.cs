using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        private const string k_Exit = "Exit";
        private const string k_Back = "Back";
        private const int k_LeaveMenuOptionIndex = 0;
        private const string k_EnterOption = "Enter valid index option";
        private const string k_EnterProperInput = "Make sure to enter a proper input";
        private const string k_NoSuchOption = "No such option in this menu...retry";

        private readonly List<MenuItem> r_MenuItems = new List<MenuItem>();
        private string m_MenuTitle;

        public MainMenu(string i_MenuTitle)
        {
            m_MenuTitle = i_MenuTitle;
        }

        public void Show()
        {
            displayMenu(r_MenuItems, k_Back);
        }

        private void displayMenu(List<MenuItem> i_MenuItems, string i_ExitWord)
        {

            int userInput;
            bool userChoseToLeave = false;
            StringBuilder menu = new StringBuilder();
            int menuItemIndex = k_LeaveMenuOptionIndex;
            menu.Append(generateMenuTitle(m_MenuTitle));
            do
            {
                clearscreen();

                // Inject title
                menu.Append(generateOption(menuItemIndex, i_ExitWord));
                menuItemIndex++;
                // Append menu items
                foreach (MenuItem menuItem in i_MenuItems)
                {
                    menu.Append(generateOption(++menuItemIndex, menuItem.Title));
                }

                Console.WriteLine(menu);

                userInput = getUserInput(i_MenuItems);

                invokeUserSelection(userInput, i_MenuItems, out userChoseToLeave);
                // Re-init the stuff
                menu.Length = 0;
                menuItemIndex = k_LeaveMenuOptionIndex;

                // All this unless user wants out
            } while (!userChoseToLeave);

        }

        private int getUserInput(List<MenuItem> i_MenuItems)
        {
            int parsedValue;
            string userInput;
            bool parsingFalg = false;
            while (true)
            {
                Console.WriteLine(k_EnterOption);
                userInput = Console.ReadLine();
                parsingFalg = int.TryParse(userInput, out parsedValue);
                if (parsingFalg)
                {
                    if (parsedValue >= 0 && parsedValue <= i_MenuItems.Count)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine(k_NoSuchOption);
                    }
                }
                else
                {
                    // Wrong input type (not int anyways)
                    Console.WriteLine(k_EnterProperInput);
                }
            }
            return parsedValue;
        }

        private string generateMenuTitle(string m_MenuTitle)
        {
            return ("~+~+~+~+~+~+" + m_MenuTitle + "~+~+~+~+~+~+\n");
        }

        private string generateOption(int i_OptionIndex, string i_OptionText)
        {
            return (i_OptionIndex + ") " + i_OptionText + "\n");
        }

        private void clearscreen()
        {
            Console.Clear();
        }

        private void invokeUserSelection(int i_UserChoice, List<MenuItem> i_MenuItems, out bool io_UserWantsBack)
        {
            if (i_UserChoice == k_LeaveMenuOptionIndex)
            {
                io_UserWantsBack = true;
            }
            else if (i_MenuItems[i_UserChoice - 1].IsMenu())
            {
                displayMenu(i_MenuItems[i_UserChoice - 1].GetMenuItems(), k_Back);
                io_UserWantsBack = false;
            }
            else
            {
                clearScreen();
                i_MenuItems[i_UserChoice - 1].InvokeAction();
                io_UserWantsBack = false;
            }
        }

        private void clearScreen()
        {
            Console.Clear();
        }

        public void AddOption(MenuItem i_MenuItem)
        {
            r_MenuItems.Add(i_MenuItem);
        }
    }
}
