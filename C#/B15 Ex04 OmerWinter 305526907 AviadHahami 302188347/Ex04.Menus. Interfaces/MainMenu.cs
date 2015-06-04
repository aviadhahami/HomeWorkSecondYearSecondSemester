using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        private InfoMenu m_InfoMenu;
        private ShowDateOrTimeMenu m_DateOrTimeMenu;

        public MainMenu()
        {
            m_InfoMenu = new InfoMenu();
            m_DateOrTimeMenu = new ShowDateOrTimeMenu();
        }
        public void Show()
        {
            object[] test = { m_DateOrTimeMenu, m_InfoMenu };
            string userInput;
            int parsedVal = 0;
            bool parseFlag = false;
            object currentMethod = this;
            while (true)
            {
                Console.WriteLine(currentMethod.GetType().Name);
                Console.WriteLine("~~~~~~~~~~~~~~~~~~");
                for (int i = 0; i < test.Length; i++)
                {
                    Console.WriteLine(i + 1 + ") " + test[i].GetType().Name);
                }
                Console.WriteLine("\nPlease pick method (numeric index)");
                userInput = Console.ReadLine();
                parseFlag = int.TryParse(userInput, out parsedVal);
                if (parseFlag)
                {
                    try
                    {
                        Console.WriteLine(test[parsedVal - 1].GetType().Name);
                        displayClass(test[parsedVal - 1].GetType().Name);
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        Console.WriteLine(e);
                    }
                }
                else
                {
                    Console.WriteLine("oops!");
                }
                Console.ReadKey();
                Console.Clear();
            }
            Console.WriteLine("OOL");
            Console.ReadKey();
        }

        private void displayClass(string i_className)
        {
            Type t = Type.GetType(i_className);
            MethodInfo[] mi = t.GetMethods();
            foreach (var m in mi)
            {
                Console.WriteLine(m.Name);
            }
        }
    }
}
