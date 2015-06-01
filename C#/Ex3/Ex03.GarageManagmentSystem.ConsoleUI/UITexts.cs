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
        private const string k_EXIT_PROGRAM = "Leave the application";
        private const string k_SAY_GOODBYE = "Thank you and have a bright day!\nAllah wakbar!";
        private const string k_PLEASE_CONTACT_ADMIN = "Something went wrong, contact system admin";
        private const string k_SORRY_NO_SUCH_VEHICLE = "We're sorry, we do not posses vehicle licensed with";
        private const string k_PLEASE_INSERT_LICENSE_NUMBER = "Please enter a valid license plate number or type \"exit\" to go back";
        private const string k_OWNER_NAME = "Owner name : ";
        private const string k_OWNER_PHONE = "Owner phone number is: ";
        private const string k_VEHICLE_TYPE = "Type: ";
        private const string k_VEHICLE_MODEL = "Model : ";
        private const string k_VEHICLE_ENGINE_SIZE = "Engine size : ";
        private const string k_VEHICLE_AMOUNT_OF_DOORS = "Amount of doors: ";
        private const string k_VEHICLE_COLOR = "Color: ";
        private const string k_VEHICLE_LICENSE_TYPE = "License type: ";
        private const string k_TRUCK_MAX_WEIGHT = "Max weight: ";
        private const string k_TRUCK_DANGEROUS = "Contains dangerous materials";
        private const string k_TRUCK_NOT_DANGER = "Doesn't contain dangerous materials";
        private const string k_VEHICLE_ENERGY = "Energy status: ";
        private const string k_TIERS_MANUFACTURER = "Tiers manufacturer: ";
        private const string k_WHEEL_PRESSURE = "Pressure: ";
        private const string k_PLEASE_PICK_FILTERING_OPTION = "Please pick a filtering option";
        private const string k_NO_FILTER = "Display without sorting";
        private const string k_FILTER_BY_ACTIVE = "Display active vehicles";
        private const string k_FILTER_BY_NONACTIVE = "Display non-active vehicles";
        private string k_PLEASE_ENTER_USERNAME = "Please state your name";
        private string k_PLEASE_ENTER_PHONE = "Please specify your phone number";

        internal void DisplayWelcomeSequence()
        {
            generateLineSpan();
            Console.WriteLine(k_GREETINGS);
            generateHalfLineSpan();
            ShowDecoratedLineSeparator();
            HoldScreen();
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

        internal void LicenseNumberDoesntExist(string io_licnsePlate)
        {
            Console.WriteLine(k_SORRY_NO_SUCH_VEHICLE + formatLicensePlate(io_licnsePlate));
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
    }
}


