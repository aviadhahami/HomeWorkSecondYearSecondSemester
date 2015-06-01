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
            // Make sure screen is clean
            Console.Clear();

            // Show all data
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
                case GarageOption.Logout:
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

        internal void LicenseNumberDoesntExist(string io_licnsePlate)
        {
            Console.WriteLine(k_SORRY_NO_SUCH_VEHICLE + formatLicensePlate(io_licnsePlate));
        }

        private string formatLicensePlate(string io_licnsePlate)
        {
            return " <" + io_licnsePlate + ">";
        }

        internal string AskForLicenseNumber()
        {
            string o_UserInput;
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
                    Console.WriteLine(k_TRY_AGAIN);
                }
            }
            return o_UserInput;
        }

        internal void DisplayVehicleData(GarageLogic.GarageInfo i_VehicleDataBlock)
        {
            ShowDecoratedLineSeparator();

            // Show owner info
            DisplayOneLineProperty(k_OWNER_NAME, i_VehicleDataBlock.VehicleInfo.OwnerName);
            DisplayOneLineProperty(k_OWNER_PHONE, i_VehicleDataBlock.VehicleInfo.OwnerPhoneNumber);

            // Show vehicle type & model
            DisplayOneLineProperty(k_VEHICLE_TYPE, i_VehicleDataBlock.VehicleInfo.VehicleType);
            DisplayOneLineProperty(k_VEHICLE_MODEL, i_VehicleDataBlock.VehicleInfo.Model);

            // Show engine & fuel data
            DisplayOneLineProperty(k_VEHICLE_ENGINE_SIZE, i_VehicleDataBlock.VehicleInfo.EngineSize);
            DisplayOneLineProperty(k_VEHICLE_ENERGY, i_VehicleDataBlock.VehicleInfo.RemainingEnergy);

            // Show wheels air pressure & manufacturer
            DisplayOneLineProperty(k_TIERS_MANUFACTURER, i_VehicleDataBlock.VehicleInfo.TierManufacturer);
            int i = 1;
            foreach (float tier in i_VehicleDataBlock.VehicleInfo.Tiers)
            {
                Console.Write(i + ") ");
                DisplayOneLineProperty(k_WHEEL_PRESSURE, tier);
            }

            // Car only
            DisplayOneLineProperty(k_VEHICLE_AMOUNT_OF_DOORS, i_VehicleDataBlock.VehicleInfo.NumberOfDoors);
            DisplayOneLineProperty(k_VEHICLE_COLOR, i_VehicleDataBlock.VehicleInfo.Color);

            // Motorcycle only
            if (i_VehicleDataBlock.VehicleInfo.VehicleType == GarageLogic.VehicleType.Motocycle)
            {
                DisplayOneLineProperty(k_VEHICLE_LICENSE_TYPE, i_VehicleDataBlock.VehicleInfo.LicenseType);
            }

            // Truck only
            if (i_VehicleDataBlock.VehicleInfo.VehicleType == GarageLogic.VehicleType.Truck)
            {
                DisplayOneLineProperty(k_TRUCK_MAX_WEIGHT, i_VehicleDataBlock.VehicleInfo.Weight);

                // Check for toxic materials
                string o_TruckDanger = i_VehicleDataBlock.VehicleInfo.DangerousChemical ? k_TRUCK_DANGEROUS : k_TRUCK_NOT_DANGER;
                DisplayOneLineProperty(o_TruckDanger, i_VehicleDataBlock.VehicleInfo.DangerousChemical);
            }

            // Done, let's move on
            ShowDecoratedLineSeparator();
            HoldScreen();
        }

        private void DisplayOneLineProperty(string i_Property, object i_VehicleData)
        {
            Console.WriteLine(i_Property + " - " + i_VehicleData.ToString());
        }

        public void DisplayFilteringOptions()
        {
            Console.WriteLine(k_PLEASE_PICK_FILTERING_OPTION);
            foreach (GarageLogic.FiltersType filterType in Enum.GetValues(typeof(GarageLogic.FiltersType)))
            {
                Console.Write((int)filterType + ") ");
               // Console.WriteLine
            }
        }

    }
}


