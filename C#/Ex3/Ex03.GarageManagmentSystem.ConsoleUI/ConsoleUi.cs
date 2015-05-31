using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagmentSystem.ConsoleUI
{
    class ConsoleUI
    {
        UITexts m_UIWorker;
        private GarageLogic.Garage m_Garage;

        public void MainUIProcess()
        {
            // Instansiate the UI
            m_UIWorker = new UITexts();

            // Instansiate the garage
            m_Garage = new GarageLogic.Garage();

            // Greet the mofos
            m_UIWorker.SayHi();
            m_UIWorker.HoldScreen();
            while (true)
            {
                // Suggest options
                GarageOption userPick = suggestOptionsToUser();

                // If we reached this it means we have a legit number picked by the user
                Console.WriteLine("Goodie! we have valid pick");
                m_UIWorker.HoldScreen();
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
                    m_UIWorker.DisplayAdminError();
                    exitApplication();
                    break;
            }
        }

        private void displaySingleVehicle()
        {
            string io_licensePlate;
            while (true)
            {
                io_licensePlate = m_UIWorker.AskForLicenseNumber();
                if (m_Garage.CheckIfVehicleExists(io_licensePlate))
                {
                    m_UIWorker.DisplayVehicleData(m_Garage.GetVehicleInfo(io_licensePlate));
                    break;
                }
                // Else vehicle doesnt exist
                else if (userAskedToQuitCurrentPick(io_licensePlate))
                {
                    break;
                }
                else
                {
                    m_UIWorker.LicenseNumberDoesntExist(io_licensePlate);
                    // Should ask if he wants to try again, otherwise pop to main screen
                }
            }
            m_UIWorker.ShowSuggestions();
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
            m_UIWorker.DisplaySortingOptions();
            int io_userPick;
            while (true)
            {
                io_userPick = m_UIWorker.ReadUserOptionPick();
                if (!validateFilteringMenuOptionNumber(io_userPick))
                {
                    m_UIWorker.WrongNumberPicked();
                }
                else
                {
                    // Delete this when done
                    Console.WriteLine("User picked " + (GarageLogic.FiltersType)io_userPick);
                    break;
                }
                DisplayInventoryPostSort(GarageLogic.Garage.GetFilteredInventory((GarageLogic.FiltersType)io_userPick));
            }

            // Should display sorted stuff according to user pick

            m_UIWorker.HoldScreen();
        }

        private void DisplayInventoryPostSort(List<GarageLogic.GarageInfo> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("End of inventory");
            m_UIWorker.HoldScreen();
        }

        private bool validateFilteringMenuOptionNumber(int i_SingleCharConsoleInput)
        {
            int enumSize = Enum.GetNames(typeof(GarageLogic.FiltersType)).Length;
            return i_SingleCharConsoleInput >= 1 && i_SingleCharConsoleInput <= enumSize;
        }

        private void insertVehicle()
        {
            throw new NotImplementedException();
        }

        private void exitApplication()
        {
            m_UIWorker.SayGoodbye();
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
                if (!validateMainMenuOptionNumber(singleCharConsoleInput))
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

        private static bool validateMainMenuOptionNumber(int i_SingleCharConsoleInput)
        {
            int enumSize = Enum.GetNames(typeof(GarageOption)).Length;
            return i_SingleCharConsoleInput >= 1 && i_SingleCharConsoleInput <= enumSize;
        }
    }
}
