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

            foreach (var item in test)
            {
                Console.WriteLine(item.GetType().FullName);
            }
        }
    }
}
