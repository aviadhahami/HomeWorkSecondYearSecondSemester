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
            // Create submenu, then inject it to main
            Interfaces.MenuItem menuItem1 = new Interfaces.MenuItem("Show date/time");
            menuItem1.AddMenuItem(new Menus.Interfaces.MenuItem("Show Date", new ShowDateInterface()));
            menuItem1.AddMenuItem(new Menus.Interfaces.MenuItem("Show Time", new ShowTimeInterface()));
            m_MainMenu.AddOption(menuItem1);

            // Repeat stage one with the second menu
        }
        public void InvokeMenu()
        {
            m_MainMenu.Show();
        }
    }
}
