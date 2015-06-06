using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{

    public delegate void ActionToInvoke();
    public class MenuItem
    {
        private readonly List<MenuItem> r_SubmenuItems;
        private string m_MenuTitle;
        private event ActionToInvoke m_ActionToInvoke;

        public MenuItem(string i_MenuTitle)
        {
            m_MenuTitle = i_MenuTitle;
            r_SubmenuItems = new List<MenuItem>();
        }

        public MenuItem(string i_MenuTitle, ActionToInvoke i_ActionToInvoke)
        {
            m_MenuTitle = i_MenuTitle;
            r_SubmenuItems = new List<MenuItem>();

            // We must remember to add to the delegate, not override!
            m_ActionToInvoke += i_ActionToInvoke;
        }

        public void AddMenuItem(MenuItem i_MenuItem)
        {
            r_SubmenuItems.Add(i_MenuItem);
        }

        public void InvokeAction()
        {
            if (m_ActionToInvoke != null)
            {
                m_ActionToInvoke.Invoke();
            }
            else
            {
                throw new Exception("Could not invoke: " + m_ActionToInvoke.ToString());
            }
        }

        public void SetInvokationAction(ActionToInvoke i_ActionToInvoke)
        {
            m_ActionToInvoke = i_ActionToInvoke;
        }

        internal List<MenuItem> SubMenuItemsList
        {
            get
            {
                return r_SubmenuItems;
            }
        }

        internal string MenuItemTitle
        {
            get
            {
                return m_MenuTitle;
            }
        }

        public bool IsMenu()
        {
            return m_ActionToInvoke == null;
        }
    }
}
