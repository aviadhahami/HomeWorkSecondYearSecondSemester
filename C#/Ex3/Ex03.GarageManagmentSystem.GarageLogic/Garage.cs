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

        public void FillFuel(string i_LicenseNumber, FuelType i_FuelType, float i_FuelToFill)
        {


            if (CheckIfVehicleExists(i_LicenseNumber) && m_GarageInventory[i_LicenseNumber].Vehicle.Engine is Fuel)
            {

                //Fuel energySource = (Fuel)m_GarageInventory[i_LicenseNumber].Vehicle.Engine;
                //energySource.fillFuel(i_FuelToFill, i_FuelType);
                (m_GarageInventory[i_LicenseNumber].Vehicle.Engine as Fuel).fillFuel(i_FuelToFill, i_FuelType);
            }

            else
            {
                throw new FormatException();
            }
        }

        public void FillCharger(string i_LicenseNumber, float i_FuelToFill)
        {
            if (CheckIfVehicleExists(i_LicenseNumber) && m_GarageInventory[i_LicenseNumber].Vehicle.Engine is Electricity)
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

        public void PumpAir(string i_LicenseNumber)
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
    }
}
