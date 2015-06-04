using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu
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
        private InfoMenu m_InfoMenu;
        private ShowDateOrTimeMenu m_DateOrTimeMenu;

        public MainMenu()
        {
            // Call relevant methods
            m_InfoMenu = new InfoMenu();
            m_DateOrTimeMenu = new ShowDateOrTimeMenu();
        }

        // Main show method
        public void Show()
        {
            object[] classesArray = { m_DateOrTimeMenu, m_InfoMenu };
            string userInput = "";
            int parsedVal = -1;
            bool parseFlag = false;
            // use 'this' for first iteration
            object currentMethod = this;
            while (true)
            {
                Console.WriteLine(currentMethod.GetType().Name);
                Console.WriteLine(k_HEADER_SEPARATOR);
                Console.WriteLine(k_EXIT_APP);
                for (int i = 0; i < classesArray.Length; i++)
                {
                    Console.WriteLine(i + 1 + ") " + classesArray[i].GetType().Name);
                }
                Console.WriteLine(k_PLEASE_PICK_AN_INDEX);
                userInput = Console.ReadLine();

                // if he didn't want to leave, we can go on
                parseFlag = int.TryParse(userInput, out parsedVal);
                if (parseFlag)
                {
                    if (parsedVal == 0)
                    {
                        Console.WriteLine(k_SAY_BYE);
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                    try
                    {
                        Console.WriteLine(classesArray[parsedVal - 1].GetType().Name);
                        displayClass(classesArray[parsedVal - 1].GetType().FullName);
                    }
                    catch (IndexOutOfRangeException)
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

                // Make sure he read the info & pressed something
                // Console.Read();
                Console.Clear();
            }

            // Safe fallback
            Console.WriteLine(k_CONTACT_ADMIN);
            Console.ReadKey();
        }

        private void displayClass(string i_className)
        {
            Type classType = Type.GetType(i_className);
            MethodInfo[] methodsInfo;

            // Instansiate to defaults
            string userInput = "";
            int parsedVal = -1;
            bool parsedFlag = false;

            while (true)
            {
                Console.Clear();
                Console.WriteLine(classType.Name);
                Console.WriteLine(k_HEADER_SEPARATOR);
                Console.WriteLine(k_GO_BACK);
                // Get the methods info, filtered by only public, instance members & declared at this level (no inheritance)
                methodsInfo = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                for (int i = 0; i < methodsInfo.Length; i++)
                {
                    Console.WriteLine((i + 1) + ") " + methodsInfo[i].Name);
                }
                Console.WriteLine(k_PLEASE_PICK_AN_INDEX);
                userInput = Console.ReadLine();
                parsedFlag = int.TryParse(userInput, out parsedVal);
                if (parsedFlag)
                {
                    if (parsedVal == 0)
                    {
                        Console.Clear();
                        break;
                    }
                    try
                    {
                        object classInstance = Activator.CreateInstance(classType, null);
                        methodsInfo[parsedVal - 1].Invoke(classInstance, null);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine(k_NO_SUCH_OPTION);
                    }
                }
                else
                {
                    Console.WriteLine(k_WRONG_INPUT_TYPE);
                }
                Console.ReadKey();
            }
        }
    }
}
