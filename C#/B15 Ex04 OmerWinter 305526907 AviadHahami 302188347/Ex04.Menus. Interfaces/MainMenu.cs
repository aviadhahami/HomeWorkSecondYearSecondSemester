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

        }

        // Inherited
        public void NotifyPick()
        {

        }
    }
}
