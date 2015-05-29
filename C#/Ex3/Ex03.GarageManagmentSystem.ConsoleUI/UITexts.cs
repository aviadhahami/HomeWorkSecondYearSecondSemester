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
        private const string k_NO_SUCH_OPTION = "We're sorry, this options doesn't exist in our garage....";
        private const string k_TRY_AGAIN = "Please try again";
        private const string k_INSERT_VEHICLE = "Insert a vehicle to the garage";
        private const string k_DISPLAY_INVENTORY = "Ask us what vehicles we currently posses";
        private const string k_CHANGE_VEHICLE_STATUS = "Change single vehicle's status (ONLY IF WE OWN IT)";
        private const string k_RECHARGE_ELECTRICAL = "Recharge an electric car (ONLY FOR ELECTRICAL ENGINED VEHICLES)";
        private const string k_DISPLAY_SINGLE_VEHICLE = "Check if we posses a specific car";
        private const string k_REFUEL_VEHICLE = "Refual a vehicle (ONLY FOR FUEL ENGINED VEHICLES)";
        private const string k_PUMP_AIR = "Pump air to a vehicle";
        private string k_EXIT_PROGRAM = "Leave the application";
        private string k_SAY_GOODBYE = "Thank you and have a bright day!\nAllah wakbar!";
        private string k_PLEASE_CONTACT_ADMIN = "Something went wrong, contact system admin";

        internal void SayHi()
        {
            generateLineSpan();
            Console.WriteLine(k_GREETINGS);
            generateHalfLineSpan();
            ShowDecoratedLineSeparator();
        }

        private void ShowDecoratedLineSeparator()
        {
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
            Console.ReadLine();
            Console.Clear();
        }

        internal void CallForAction()
        {
            Console.WriteLine(k_WHAT_WOULD_YOU_LIKE_TO_DO);
            ShowDecoratedLineSeparator();
            ShowSuggestions();
        }

        internal int ReadUserOptionPick()
        {
            string userInput;
            int integerOutput;

            // Iterate until we're satisfied with user input
            while (true)
            {
                userInput = Console.ReadLine();
                // Make sure it's not a line feed (ASCII Code 10)
                if (userInput.Length > 0)
                {
                    // Try to parse an int, if we didn't succeed we tell them to input again
                    if (int.TryParse(userInput, out integerOutput))
                    {
                        return integerOutput;
                    }
                    else
                    {
                        Console.WriteLine(k_TRY_AGAIN);
                    }
                }
            }
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
            // First we display the enum int value
            Console.Write((int)i_GarageOption + ") ");

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
                case GarageOption.Exit:
                    Console.WriteLine(k_EXIT_PROGRAM);
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

        internal void SayGoodbye()
        {
            Console.Clear();
            Console.WriteLine(k_SAY_GOODBYE);
            HoldScreen();
        }

        internal void DisplayAdminError()
        {
            Console.WriteLine(k_PLEASE_CONTACT_ADMIN);
        }
    }
}
