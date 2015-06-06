using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Test
{
    class InterfacesTest
    {
        Interfaces.MainMenu m_MainMenu;
        public InterfacesTest(string i_MenuTitle)
        {
            // Inject a main menu instance
            m_MainMenu = new Interfaces.MainMenu(i_MenuTitle);
        }
        public void InitMenu()
        {
            Interfaces.MenuItem menuItem1 = new Interfaces.MenuItem("Show date/time");
            menuItem1.AddMenuItem()
            m_MainMenu.AddMenuOption();
        }
        public void InvokeMenu()
        {
            m_MainMenu.Show();
        }
    }
}
