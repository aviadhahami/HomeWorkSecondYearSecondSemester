using System;
using System.Collections.Generic;
using System.Text;
using B15_EX3_AVIADHAHAMI_302188347_OMERWINTER_305526907;

namespace Ex03.GarageManagmentSystem.ConsoleUI
{
    class ConsoleUI
    {
        UITexts m_UIStrings;
        public void MainUIProcess()
        {

            // Instansiate the UI
            m_UIStrings = new UITexts();

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
                    Console.WriteLine("Something went wrong, contact system admin");
                    break;
            }
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
