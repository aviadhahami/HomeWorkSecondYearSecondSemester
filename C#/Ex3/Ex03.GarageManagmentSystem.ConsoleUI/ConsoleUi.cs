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

        private const string k_EXIT_TOKEN = "EXIT";


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

            invokeMainMenuSequence();
        }

        private string requireUserPhone()
        {
            string o_UserInput;
            while (true)
            {
                o_UserInput = m_UITexts.AskUserForPhone();
                if (o_UserInput.Length > 0)
                {
                    if (CheckExitToken(o_UserInput))
                    {
                        leaveApplication();
                    }
                    else if (containsDigitsOnly(o_UserInput))
                    {
                        return o_UserInput;
                    }
                    else
                    {
                        m_UITexts.BadInput();
                    }
                }
            }
        }

        private string requireUserName()
        {
            string o_UserInput;
            while (true)
            {
                o_UserInput = m_UITexts.AskUserForName();
                if (o_UserInput.Length > 0)
                {
                    if (CheckExitToken(o_UserInput))
                    {
                        leaveApplication();
                    }
                    else if (containsLettersAndSpacesOnly(o_UserInput))
                    {
                        return o_UserInput;
                    }
                    else
                    {
                        m_UITexts.BadInput();
                    }
                }
            }
        }

        private bool containsLettersAndSpacesOnly(string o_UserInput)
        {
            bool o_testResult = true;
            foreach (char currentChar in o_UserInput)
            {
                // If the current char is not a letter neither a whitespace
                if (!char.IsLetter(currentChar) && !char.IsWhiteSpace(currentChar))
                {
                    o_testResult = false;
                }
            }
            return o_testResult;
        }

        private void leaveApplication()
        {
            m_UITexts.SayGoodbye();
            Environment.Exit(0);
        }

        private bool CheckExitToken(string o_UserInput)
        {
            return o_UserInput.ToUpper() == k_EXIT_TOKEN;
        }

    }
}
