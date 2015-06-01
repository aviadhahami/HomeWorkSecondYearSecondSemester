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
        GarageLogic.Factory m_VehiclesFactory;
        string m_CurrentUserName;
        string m_CurrentUserPhone;

        // Constructor
        // genereates new texts class
        public ConsoleUI()
        {
            m_UITexts = new UITexts();
            m_VehiclesFactory = new GarageLogic.Factory();
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
                    break;
                }
                else
                {
                    // Not valid
                    m_UITexts.NoSuchOption();
                }
            }
            // If we reached here we have a valid user pick, defualt is exit code
            invokeGarageAction(io_ParsedInt);
        }

        // Invokes the proper method according to a given option
        // Status : UC
        private void invokeGarageAction(int i_OpCode)
        {
            GarageOption recievedOption = (GarageOption)i_OpCode;
            switch (recievedOption)
            {
                case GarageOption.Insert:
                    insertVehicle();
                    break;
                case GarageOption.DisplayInventory:
                    //displayInventory();
                    break;
                case GarageOption.ChangeVehicleStatus:
                    changeVehicleStatus();
                    break;
                case GarageOption.PumpAir:
                    //pumpAir();
                    break;
                case GarageOption.Refuel:
                    //refuel();
                    break;
                case GarageOption.Recharge:
                    //  recharge();
                    break;
                case GarageOption.DisplaySingleVehicle:
                    displaySingleVehicle();
                    break;
                case GarageOption.Logout:
                    logOutSequence();
                    break;
                default:
                    m_UITexts.DisplayAdminError();
                    logOutSequence();
                    break;
            }
            // Go back to main menu
            mainMenuSequence();
        }

        // Changes vehicle status
        // Stus : UC
        private void changeVehicleStatus()
        {
            string io_UserInput = m_UITexts.AskForLicense();
            if (CheckExitToken(io_UserInput))
            {
                LoginScreenSequence();
            }
            // Keep verification
        }

        private void insertVehicle()
        {
            string io_userInput = "exit";
            while (true)
            {
                m_UITexts.DisplayVehicleTypes(m_VehiclesFactory.getVehicleType());
                io_userInput = Console.ReadLine();
                if (CheckExitToken(io_userInput))
                {
                    logOutSequence();
                }
                if (m_VehiclesFactory.getVehicleType().Contains(io_userInput))
                {
                    break;
                }
                else
                {
                    m_UITexts.BadInput();
                    m_UITexts.HoldScreen();
                }
            }
            List<string> io_Questions = m_VehiclesFactory.initVehicleToBuild((int)m_VehiclesFactory.GetVehicleTypeFromString(io_userInput));
            //instansiateVehicle((GarageLogic.VehicleType)io_ParsedInt);
            // Questions should come here
        }


        // Displays single vehicle from inventory
        // Status : Done, not tested
        private void displaySingleVehicle()
        {
            string io_GivenLicense;
            while (true)
            {
                io_GivenLicense = m_UITexts.AskForLicense();
                if (CheckExitToken(io_GivenLicense))
                {
                    mainMenuSequence();
                }

                // If the license number isn't exist
                else if (!validLicenseNumber(io_GivenLicense))
                {
                    m_UITexts.BadInput();
                }

                // Else -> number is legit
                else
                {
                    if (checkVehicleExistance(io_GivenLicense))
                    {
                        // retrieve vehicle
                        GarageLogic.GarageInfo io_RetrievedVehicle = GarageLogic.Garage.GetVehicleInfo(io_GivenLicense);

                        break;
                    }
                    else
                    {
                        // We aint got this
                        m_UITexts.LicenseNumberDoesntExist(io_GivenLicense);
                        break;
                    }
                }
            }
            mainMenuSequence();
        }

        // Returns whether a vehicle exists
        // Status : done, not tested
        private bool checkVehicleExistance(string io_GivenLicense)
        {
            return GarageLogic.Garage.Exist(io_GivenLicense);
        }

        // Validates a given license number to contain only letters and digits
        // Status : Done, not tested
        private bool validLicenseNumber(string i_GivenPlate)
        {
            bool o_testResult = true;
            foreach (char currentChar in i_GivenPlate)
            {
                if (!char.IsLetterOrDigit(currentChar))
                {
                    o_testResult = false;
                }
            }
            return o_testResult;
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
