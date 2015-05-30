using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagmentSystem.ConsoleUI
{
    class ConsoleUI
    {
        UITexts m_UIStrings;
        private GarageLogic.Garage m_Garage;

        public void MainUIProcess()
        {
            // Instansiate the UI
            m_UIStrings = new UITexts();

            // Instansiate the garage
            m_Garage = new Ex03.GarageManagmentSystem.GarageLogic.Garage();

            // Greet the mofos
            m_UIStrings.SayHi();
            m_UIStrings.HoldScreen();
            while (true)
            {
                // Suggest options
                GarageOption userPick = suggestOptionsToUser();

                // If we reached this it means we have a legit number picked by the user
                Console.WriteLine("Goodie! we have valid pick");
                m_UIStrings.HoldScreen();
                deployAction(userPick);
            }

        }

        private void deployAction(GarageOption userPick)
        {
            switch (userPick)
            {
                case GarageOption.Insert:
                    insertVehicle();
                    break;
                case GarageOption.DisplayInventory:
                    displayInventory();
                    break;
                case GarageOption.ChangeVehicleStatus:
                    changeVehicleStatus();
                    break;
                case GarageOption.PumpAir:
                    pumpAirToVehicle();
                    break;
                case GarageOption.Refuel:
                    refuelVehicle();
                    break;
                case GarageOption.Recharge:
                    rechargeVehicle();
                    break;
                case GarageOption.DisplaySingleVehicle:
                    displaySingleVehicle();
                    break;
                case GarageOption.Exit:
                    exitApplication();
                    break;
                default:
                    m_UIStrings.DisplayAdminError();
                    exitApplication();
                    break;
            }
        }

        private void displaySingleVehicle()
        {
            string io_licensePlate;
            while (true)
            {
                io_licensePlate = m_UIStrings.AskForLicenseNumber();
                if (m_Garage.CheckIfVehicleExists(io_licensePlate))
                {
                    m_UIStrings.DisplayVehicleData(m_Garage.GetVehicleInfo(io_licensePlate));
                    break;
                }
                // Else vehicle doesnt exist
                else if (userAskedToQuitCurrentPick(io_licensePlate))
                {
                    break;
                }
                else
                {
                    m_UIStrings.LicenseNumberDoesntExist(io_licensePlate);
                    // Should ask if he wants to try again, otherwise pop to main screen
                }
            }
            m_UIStrings.ShowSuggestions();
        }

        private bool userAskedToQuitCurrentPick(string i_UserInput)
        {
            return i_UserInput == "exit" || i_UserInput == "EXIT";
        }

        private void rechargeVehicle()
        {
            throw new NotImplementedException();
        }

        private void refuelVehicle()
        {
            throw new NotImplementedException();
        }

        private void pumpAirToVehicle()
        {
            throw new NotImplementedException();
        }

        private void changeVehicleStatus()
        {
            throw new NotImplementedException();
        }

        private void displayInventory()
        {
            throw new NotImplementedException();
        }

        private void insertVehicle()
        {
            throw new NotImplementedException();
        }

        private void exitApplication()
        {
            m_UIStrings.SayGoodbye();
            System.Environment.Exit(0);
        }

        private static GarageOption suggestOptionsToUser()
        {
            int singleCharConsoleInput;
            UITexts m_UIStrings = new UITexts();
            while (true)
            {
                m_UIStrings.CallForAction();
                singleCharConsoleInput = m_UIStrings.ReadUserOptionPick();
                if (!validateOptionNumber(singleCharConsoleInput))
                {
                    m_UIStrings.WrongNumberPicked();
                }
                else
                {
                    // Delete this when done
                    Console.WriteLine("User picked " + (GarageOption)singleCharConsoleInput);
                    return (GarageOption)singleCharConsoleInput;
                }
            }
        }

        private static bool validateOptionNumber(int i_SingleCharConsoleInput)
        {
            int enumSize = Enum.GetNames(typeof(GarageOption)).Length;
            return i_SingleCharConsoleInput >= 1 && i_SingleCharConsoleInput <= enumSize;
        }
    }
}
