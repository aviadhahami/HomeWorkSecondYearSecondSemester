using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagmentSystem.ConsoleUI
{
    class UITexts
    {
        private const string k_LINE_SPAN = "                         ";
        private const string k_HALF_LINE_SPAN = "               ";
        private const string k_GREETINGS = "Hi, Welcome to Abu Ali's garage!";
        private const string k_DECORATED_LINE_SEPARATOR = "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";
        private const string k_PRESS_ANY_KEY = "Press any key to continue";
        private const string k_WHAT_WOULD_YOU_LIKE_TO_DO = "What would you like to do Sir?";
        private string k_NO_SUCH_OPTION = "We're sorry, this options doesn't exist in our garage....";
        private string k_TRY_AGAIN = "Please try again";
        private string k_INSERT_VEHICLE = "Insert a vehicle to the garage";
        private string k_DISPLAY_INVENTORY = "Ask us what vehicles we currently posses";
        private string k_CHANGE_VEHICLE_STATUS = "Change single vehicle's status (ONLY IF WE OWN IT)";
        private string k_RECHARGE_ELECTRICAL = "Recharge an electric car (ONLY FOR ELECTRICAL ENGINED VEHICLES)";
        private string k_DISPLAY_SINGLE_VEHICLE = "Check if we posses a specific car";
        private string k_REFUEL_VEHICLE = "Refual a vehicle (ONLY FOR FUEL ENGINED VEHICLES)";
        private string k_PUMP_AIR = "Pump air to a vehicle";

        internal void SayHi()
        {
            generateLineSpan();
            Console.WriteLine(k_GREETINGS);
            generateHalfLineSpan();
            Console.WriteLine(k_DECORATED_LINE_SEPARATOR);
        }

        private void generateHalfLineSpan()
        {
            Console.Write(k_HALF_LINE_SPAN);
        }

        private void generateLineSpan()
        {
            Console.Write(k_LINE_SPAN);
        }

        internal void HoldScreen()
        {
            Console.Write(k_PRESS_ANY_KEY);
            Console.Read();
            Console.Clear();
        }

        internal void CallForAction()
        {
            Console.WriteLine(k_WHAT_WOULD_YOU_LIKE_TO_DO);
            ShowSuggestions();
        }

        internal int ReadFromConsole()
        {
            return Console.Read();
        }

        internal void ShowSuggestions()
        {
            foreach (GarageOption o_GarageOption in Enum.GetValues(typeof(GarageOption)))
            {
                ShowFullOption(o_GarageOption);
            }
        }

        private void ShowFullOption(GarageOption i_GarageOption)
        {
            switch (i_GarageOption)
            {
                case GarageOption.Insert:
                    Console.WriteLine(k_INSERT_VEHICLE);
                    break;
                case GarageOption.DisplayInventory:
                    Console.WriteLine(k_DISPLAY_INVENTORY);
                    break;
                case GarageOption.ChangeVehicleStatus:
                    Console.WriteLine(k_CHANGE_VEHICLE_STATUS);
                    break;
                case GarageOption.PumpAir:
                    Console.WriteLine(k_PUMP_AIR);
                    break;
                case GarageOption.Refuel:
                    Console.WriteLine(k_REFUEL_VEHICLE);
                    break;
                case GarageOption.Recharge:
                    Console.WriteLine(k_RECHARGE_ELECTRICAL);
                    break;
                case GarageOption.DisplaySingleVehicle:
                    Console.WriteLine(k_DISPLAY_SINGLE_VEHICLE);
                    break;
                default:

                    // Noting is defaulted
                    break;
            }
        }

        internal void WrongNumberPicked()
        {
            Console.WriteLine(k_NO_SUCH_OPTION);
            Console.WriteLine(k_TRY_AGAIN);
            HoldScreen();
        }
    }
}
