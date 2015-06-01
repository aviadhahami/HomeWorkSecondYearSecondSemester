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
        // Status : Done and tested
        private void mainMenuSequence()
        {
            // Default this to exit code
            string i_UserChoice = "8";
            int io_ParsedInt;
            bool parseResult;
            while (true)
            {
                // Display options
                m_UITexts.IntroduceOptions(m_CurrentUserName);
                i_UserChoice = Console.ReadLine();
                if (CheckExitToken(i_UserChoice))
                {
                    logOutSequence();
                }
                parseResult = int.TryParse(i_UserChoice, out io_ParsedInt);
                if (parseResult && testValidMenueOption(io_ParsedInt))
                {
                    // If valid
                    Console.WriteLine("Legit!");
                    m_UITexts.HoldScreen();
                    break;
                }
                else
                {
                    // Not valid
                    m_UITexts.NoSuchOption();
                }
            }
            invokeGarageAction(io_ParsedInt);
        }

        // Invokes the proper method according to a given option
        // Status : UC
        private void invokeGarageAction(int i_OpCode)
        {
            Console.WriteLine("Picked" + i_OpCode);
            m_UITexts.HoldScreen();
        }

        // Tests whetther the given string can be found whithin the menue enum
        // Status : done and tested
        private bool testValidMenueOption(int i_GivenInput)
        {
            bool o_TestResult = false;
            foreach (GarageOption currentOption in Enum.GetValues(typeof(GarageOption)))
            {
                if ((int)currentOption == i_GivenInput)
                {
                    o_TestResult = true;
                }
            }
            return o_TestResult;
        }

        // Logs the current user out & returns to login screen
        // Status : Done, not tested
        private void logOutSequence()
        {
            m_UITexts.SayGoodbye();
            m_CurrentUserPhone = "";
            m_CurrentUserName = "";
            LoginScreenSequence();
        }

        // Asks user for his phone
        // Status : Done & tested
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
        private bool containsLettersAndSpacesOnly(string i_UserInput)
        {
            bool o_testResult = true;
            foreach (char currentChar in i_UserInput)
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
        private bool CheckExitToken(string i_UserInput)
        {
            return i_UserInput.ToUpper() == k_EXIT_TOKEN;
        }

    }
}
