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

        // Constructor
        // genereates new texts class
        public ConsoleUI()
        {
            m_UITexts = new UITexts();
        }

        // Deploys login screen sequence
        // Status : Done and tested
        internal void LoginScreenSequence()
        {
            // Show welcome message & login header
            m_UITexts.DisplayWelcomeSequence();
            m_UITexts.DisplayLoginHeader();

            m_CurrentUserName = requireUserName();
            m_CurrentUserPhone = requireUserPhone();
            mainMenuSequence();
        }

        // Main menue sequencer
        // Status :
        private void mainMenuSequence()
        {
            throw new NotImplementedException();
        }

        // Asks user for his phone
        // Status : 
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

        // Tests a string for digits only
        // Status : Done, tested
        private bool containsDigitsOnly(string i_Input)
        {
            bool o_TestResult = true;
            foreach (char currentChar in i_Input)
            {
                if (!char.IsDigit(currentChar))
                {
                    o_TestResult = false;
                }
            }
            return o_TestResult;
        }

        // Asks entering user for his name
        // Status : Done, tested
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

        // Verifies the string contains only letters and spaces
        // Status : Done, tested
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

        // Exists the application when invoked
        // Status : Done and tested
        private void leaveApplication()
        {
            m_UITexts.SayGoodbye();
            Environment.Exit(0);
        }

        // Tests the given string for exit token
        // Status : Done and tested
        private bool CheckExitToken(string o_UserInput)
        {
            return o_UserInput.ToUpper() == k_EXIT_TOKEN;
        }

    }
}
