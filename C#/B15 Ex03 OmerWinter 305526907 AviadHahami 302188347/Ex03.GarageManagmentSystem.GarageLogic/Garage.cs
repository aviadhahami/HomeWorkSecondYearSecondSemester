using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagmentSystem.GarageLogic
{
    public class Garage
    {
        private static Dictionary<string, GarageInfo> m_GarageInventory = new Dictionary<string, GarageInfo>();
        internal static void UpdateStatus(string i_LicenseNumber, StatusType i_statusType)
        {
            GarageInfo garageInfo = m_GarageInventory[i_LicenseNumber];
            garageInfo.StatusType = i_statusType;
        }
        public static bool Exist(string i_LicenseNumber)
        {

            bool o_Exist = false;
            if (m_GarageInventory.ContainsKey(i_LicenseNumber))
            {
                o_Exist = true;
            }
            return o_Exist;
        }
        public static void Insert(GarageInfo i_GarageInfo)
        {
            m_GarageInventory.Add(i_GarageInfo.Vehicle.LicenseNumber, i_GarageInfo);
        }
        public static void FillFuel(string i_LicenseNumber, int i_FuelType, float i_FuelToFill)
        {
            FuelType o_FuelType = (FuelType)i_FuelType;
            if (m_GarageInventory[i_LicenseNumber].Vehicle.Engine is Fuel)
            {
                (m_GarageInventory[i_LicenseNumber].Vehicle.Engine as Fuel).fillFuel(i_FuelToFill, o_FuelType);
            }
            else
            {
                throw new FormatException();
            }
        }
        public static void FillCharger(string i_LicenseNumber, float i_FuelToFill)
        {
            if (m_GarageInventory[i_LicenseNumber].Vehicle.Engine is Electricity)
            {
                //Electricity energySource = (Electricity)m_GarageInventory[i_LicenseNumber].Vehicle.Engine;
                //energySource.fillElectricity(i_FuelToFill);
                (m_GarageInventory[i_LicenseNumber].Vehicle.Engine as Electricity).fillElectricity(i_FuelToFill);
            }
            else
            {
                throw new FormatException();
            }
        }
        public static void PumpAir(string i_LicenseNumber)
        {
            m_GarageInventory[i_LicenseNumber].Vehicle.PumpAir();
        }
        public bool CheckIfVehicleExists(string io_LicenseNumber)
        {
            return Exist(io_LicenseNumber);
        }
        public static GarageInfo GetVehicleInfo(string i_LicenseNumber)
        {
            //  return m_GarageInventory.
            return m_GarageInventory[i_LicenseNumber];
        }
        public static List<string> GetFilteredInventory(StatusType i_FilterType)
        {
            // Returns a list of garage info
            List<string> io_FilteredList = new List<string>();
            if (i_FilterType == StatusType.PAID)
            {
                foreach (KeyValuePair<string, GarageInfo> vehicle in m_GarageInventory)
                {
                    io_FilteredList.Add(vehicle.Key);
                }
            }
            else
            {
                foreach (KeyValuePair<string, GarageInfo> currentGarageEntry in m_GarageInventory)
                {
                    if (currentGarageEntry.Value.StatusType.Equals(i_FilterType))
                    {
                        io_FilteredList.Add(currentGarageEntry.Key);
                    }
                }
            }

            return io_FilteredList;
        }
        public static StatusType GetFilterTypeFromString(string i_FilterTypeString)
        {
            // Defulat to none
            StatusType o_ChosedStatusType = StatusType.PAID;
            foreach (StatusType type in Enum.GetValues(typeof(StatusType)))
            {
                if (type.ToString() == i_FilterTypeString)
                {
                    o_ChosedStatusType = type;
                }
            }
            return o_ChosedStatusType;
        }
        public static void ChangeVehicleStatus(string i_LicenseNumber)
        {
            StatusType io_currentStatus = m_GarageInventory[i_LicenseNumber].StatusType;
            StatusType o_NewStatus = StatusType.FIXED;
            switch (io_currentStatus)
            {
                case StatusType.FIXING:
                    o_NewStatus = StatusType.FIXED;
                    break;
                case StatusType.FIXED:
                    // Is default
                    break;
                case StatusType.PAID:
                    o_NewStatus = StatusType.FIXING;
                    break;
                default:
                    break;
            }
            m_GarageInventory[i_LicenseNumber].StatusType = o_NewStatus;
        }

        public static string GetFuelTypes()
        {
            string o_FuelTypes = "";
            foreach (FuelType type in Enum.GetValues(typeof(FuelType)))
            {
                o_FuelTypes += (int)type + ") " + type.ToString() + "\n";
            }
            return o_FuelTypes;
        }

        public static bool ValidateFuelType(string i_InputFuelType)
        {
            bool o_testResult = false;
            foreach (FuelType type in Enum.GetValues(typeof(FuelType)))
            {
                if (type.ToString() == i_InputFuelType)
                {
                    o_testResult = true;
                }
            }
            return o_testResult;
        }

        public static int GetFuelTypeByString(string io_FuelType)
        {
            int o_EnumValue = 0;

            foreach (FuelType type in Enum.GetValues(typeof(FuelType)))
            {
                if (type.ToString() == io_FuelType)
                {
                    o_EnumValue = (int)type;
                }
            }
            return o_EnumValue;
        }
    }
}
