using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagmentSystem.ConsoleUI
{
    class ConsoleUI
    {
        // Display login screen

        // Display main menu

        // Insert

        // Display inventory

        // Change vehicle status

        // Pump air

        // Refuel

        // Recharge

        // DisplaySingleVehicle

        //Logout
        UITexts m_UITexts;
        string m_CurrentUserName;
        string m_CurrentUserPhone;

        public ConsoleUI()
        {
            m_UITexts = new UITexts();
        }

        internal void ShowLoginScreen()
        {
            m_UITexts.DisplayWelcomeSequence();

            m_CurrentUserName = requireUserName();

            m_CurrentUserPhone = requireUserPhone();

            showMainMenu();
        }

    }
}
