﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagmentSystem.ConsoleUI
{
    class UITexts
    {
        private const string k_SORRY_NO_SUCH_VEHICLE = "We're sorry, we do not posses vehicle licensed with";
        private const string k_PLEASE_PICK_FILTERING_OPTION = "Please pick a filtering option";
        private const string k_INSERT_VEHICLE = "Insert a vehicle to the garage";
        private const string k_DISPLAY_INVENTORY = "Ask us what vehicles we currently posses";
        private const string k_CHANGE_VEHICLE_STATUS = "Change single vehicle's status (ONLY IF WE OWN IT)";
        private const string k_RECHARGE_ELECTRICAL = "Recharge an electric car (ONLY FOR ELECTRICAL ENGINED VEHICLES)";
        private const string k_DISPLAY_SINGLE_VEHICLE = "Check if we posses a specific car";
        private const string k_REFUEL_VEHICLE = "Refual a vehicle (ONLY FOR FUEL ENGINED VEHICLES)";
        private const string k_PUMP_AIR = "Pump air to a vehicle";
        private const string k_EXIT_PROGRAM = "Leave the application";
        private const string k_SAY_GOODBYE = "Thank you and have a bright day!\nAllah wakbar!";
        private const string k_PLEASE_CONTACT_ADMIN = "Something went wrong, contact system admin";
        private const string k_LINE_SPAN = "                         ";
        private const string k_HALF_LINE_SPAN = "               ";
        private const string k_THREE_QUARTERS_LINE_SPAN = "                      ";
        private const string k_GREETINGS = "Hi, Welcome to Abu Ali's garage!";
        private const string k_DECORATED_LINE_SEPARATOR = "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";
        private const string k_PRESS_ANY_KEY = "Press 'Enter' to continue";
        private const string k_PLEASE_ENTER_USERNAME = "Please state your name";
        private const string k_PEASE_ENTER_AMOUNT_OF_FUEL = "Please enter the amount of fuel to fuel your vehicle with";
        private const string k_PLEASE_ENTER_PHONE = "Please specify your phone number";
        private const string k_LOGIN_SCREEN_HEADER = "Abu Ali's garage login screen";
        private const string k_WHAT_WOULD_YOU_LIKE_TO_DO = "What would you like to do";
        private const string k_REMIND_EXIT_TOKEN = "Type \"Exit\" at any time to exit the app";
        private const string k_NO_SUCH_OPTION = "We're sorry, this options doesn't exist in our garage....";
        private const string k_TRY_AGAIN = "Please try again";
        private const string k_PLEASE_INSERT_LICENSE_NUMBER = "Please enter a valid license plate number";
        private const string k_LOG_OUT = "Log out";
        private const string k_PLEASE_PICK_VEHICLE = "Please pick a vehicle";
        private const string k_PLEASE_INSERT_FUEL_TYPE = "Please pick fuel type";

        internal void DisplayWelcomeSequence()
        {
            generateLineSpan();
            Console.WriteLine(k_GREETINGS);
            generateThreeQuartersLineSpan();
            Console.WriteLine(k_REMIND_EXIT_TOKEN);
            generateHalfLineSpan();
            ShowDecoratedLineSeparator();
            HoldScreen();
        }

        private void generateThreeQuartersLineSpan()
        {
            Console.Write(k_THREE_QUARTERS_LINE_SPAN);
        }

        public void ShowDecoratedLineSeparator()
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

        internal void LicenseNumberDoesntExist(string io_licnsePlate)
        {
            Console.WriteLine(k_SORRY_NO_SUCH_VEHICLE + formatLicensePlate(io_licnsePlate));
            HoldScreen();
        }

        private string formatLicensePlate(string io_licnsePlate)
        {
            return " <" + io_licnsePlate + ">";
        }

        internal void BadInput()
        {
            Console.WriteLine(k_TRY_AGAIN);
        }

        internal string AskUserForName()
        {
            string o_Input;
            Console.WriteLine(k_PLEASE_ENTER_USERNAME);
            while (true)
            {
                o_Input = Console.ReadLine();
                if (o_Input.Length > 0)
                {
                    return o_Input;
                }
            }


        }

        internal string AskUserForPhone()
        {
            string o_Userinput;
            Console.WriteLine(k_PLEASE_ENTER_PHONE);
            while (true)
            {
                o_Userinput = Console.ReadLine();
                if (o_Userinput.Length > 0)
                {
                    return o_Userinput;
                }
            }
        }

        internal void DisplayLoginHeader()
        {
            Console.WriteLine(k_LOGIN_SCREEN_HEADER);
            ShowDecoratedLineSeparator();
        }

        internal void IntroduceOptions(string i_GivenName)
        {
            Console.Clear();
            Console.WriteLine(k_WHAT_WOULD_YOU_LIKE_TO_DO + ", " + i_GivenName + "?");
            ShowDecoratedLineSeparator();
            int i = 0;
            foreach (GarageOption currentOption in Enum.GetValues(typeof(GarageOption)))
            {
                Console.Write((int)currentOption + ") ");
                switch (currentOption)
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
                    case GarageOption.Logout:
                        Console.WriteLine(k_LOG_OUT);
                        break;
                    default:
                        // No defualt
                        break;
                }
            }
        }

        internal void NoSuchOption()
        {
            Console.WriteLine(k_NO_SUCH_OPTION);
            Console.WriteLine(k_TRY_AGAIN);
            HoldScreen();
        }

        internal string AskForLicense()
        {
            string o_UserInput;
            Console.Clear();
            while (true)
            {
                Console.WriteLine(k_PLEASE_INSERT_LICENSE_NUMBER);
                o_UserInput = Console.ReadLine();
                if (o_UserInput.Length > 0)
                {
                    break;
                }
                else
                {
                    BadInput();
                }
            }
            return o_UserInput;
        }

        internal void DisplayVehicleTypes(List<string> i_VehiclesType)
        {
            Console.Clear();
            Console.WriteLine(k_PLEASE_PICK_VEHICLE);
            foreach (string currentVehicle in i_VehiclesType)
            {
                Console.WriteLine("-->" + currentVehicle);
            }
        }

        internal string AskQuestion(string i_GivenQuestion)
        {
            string o_UserInput;
            Console.Clear();

            while (true)
            {
                Console.WriteLine(i_GivenQuestion);
                o_UserInput = Console.ReadLine();
                if (o_UserInput.Length > 0)
                {
                    break;
                }
            }
            return o_UserInput;
        }

        internal void AskFilteringType(List<string> i_FiltertingType)
        {
            Console.Clear();
            Console.WriteLine(k_PLEASE_PICK_FILTERING_OPTION);
            foreach (string type in i_FiltertingType)
            {
                Console.WriteLine("--> " + type);
            }
        }

        internal string AskForFuelToFill()
        {
            string o_Input;
            Console.WriteLine(k_PEASE_ENTER_AMOUNT_OF_FUEL);
            while (true)
            {
                o_Input = Console.ReadLine();
                if (o_Input.Length > 0)
                {
                    return o_Input;
                }
            }
        }

        internal string AskForFuelType(string i_FuelOption)
        {
            string o_Input;
            Console.WriteLine(k_PLEASE_INSERT_FUEL_TYPE);
            Console.WriteLine(i_FuelOption);
            while (true)
            {
                o_Input = Console.ReadLine();
                if (o_Input.Length > 0)
                {
                    return o_Input;
                }
            }
        }
    }
}


