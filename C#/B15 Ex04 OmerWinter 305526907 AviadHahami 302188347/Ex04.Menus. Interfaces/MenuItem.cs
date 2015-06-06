using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem
    {
        private List<MenuItem> m_SubMenuItems;
        private IPerformAction m_ActionToInvoke;
        private string m_MenuTitle;

        public MenuItem(string i_MenuTitle)
        {
            // Give it the proper name
            m_MenuTitle = i_MenuTitle;

            // Generate an empty list
            m_SubMenuItems = new List<MenuItem>();
        }

        public MenuItem(string i_MenuTitle, IPerformAction i_ActionToInvoke)
        {
            m_MenuTitle = i_MenuTitle;
            m_ActionToInvoke = i_ActionToInvoke;
        }

        public bool IsMenu()
        {
            return m_ActionToInvoke == null;
        }

        public List<MenuItem> GetMenuItems()
        {
            return m_SubMenuItems;
        }

        public void AddMenuItem(MenuItem i_MenuItem)
        {
            m_SubMenuItems.Add(i_MenuItem);
        }

        public void InvokeAction()
        {
            m_ActionToInvoke.performAction(m_MenuTitle);
        }

        public string Title { get { return m_MenuTitle; } }
    }
}
