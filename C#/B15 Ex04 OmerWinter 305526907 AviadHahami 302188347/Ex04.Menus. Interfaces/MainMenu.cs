using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        private string m_MethodTitle;
        private InfoMenu m_InfoMenu;
        private ShowDateOrTimeMenu m_DateOrTimeMenu;
        private List<Type> interfaces;
        private string m_MethodsMenue;

        public MainMenu()
        {
            m_MethodTitle = this.GetType().Name;
            m_InfoMenu = new InfoMenu();
            m_DateOrTimeMenu = new ShowDateOrTimeMenu();
            List<Type> interfaces = new List<Type>();
            interfaces.AddRange(m_InfoMenu.GetType().GetInterfaces());
            interfaces.AddRange(m_DateOrTimeMenu.GetType().GetInterfaces());
            int menuCounter = 0;
            m_MethodsMenue = "";
            foreach (Type iface in interfaces)
            {
                MethodInfo[] methods = iface.GetMethods();
                foreach (MethodInfo method in methods)
                {
                    m_MethodsMenue += ++menuCounter + ") " + method.Name + "\n";
                }
            }
        }

        public string MenuName
        {
            get
            {
                return this.m_MethodTitle;
            }
        }

        public string MethodsMenu
        {
            get
            {
                return this.m_MethodsMenue;
            }
        }
    }
}
