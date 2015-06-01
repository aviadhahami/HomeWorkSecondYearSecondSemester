using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagmentSystem.GarageLogic
{
    public class Garage
    {
        private static readonly Dictionary<string, GarageInfo> m_GarageInventory;

        internal static void UpdateStatus(string i_LicenseNumber, StatusType i_statusType)
        {
            GarageInfo garageInfo = m_GarageInventory[i_LicenseNumber];
            garageInfo.StatusType = i_statusType;
        }

        internal static bool Exist(string i_LicenseNumber)
        {

            bool exist = false;
            if (m_GarageInventory.ContainsKey(i_LicenseNumber))
            {
                exist = true;
            }
            return exist;
        }

        internal static void Insert(GarageInfo i_GarageInfo)
        {
            m_GarageInventory.Add(i_GarageInfo.Vehicle.LicenseNumber, i_GarageInfo);
        }

        public void FillFuel(string i_LicenseNumber, FuelType i_FuelType, float i_FuelToFill)
        {


            if (CheckIfVehicleExists(i_LicenseNumber) && m_GarageInventory[i_LicenseNumber].Vehicle.Engine is Fuel)
            {

                Fuel energySource = (Fuel)m_GarageInventory[i_LicenseNumber].Vehicle.Engine;
                energySource.fillFuel(i_FuelToFill, i_FuelType);
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
                Electricity energySource = (Electricity)m_GarageInventory[i_LicenseNumber].Vehicle.Engine;
                energySource.fillElectricity(i_FuelToFill);
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

        public GarageInfo GetVehicleInfo(string i_LicenseNumber)
        {
            return m_GarageInventory[i_LicenseNumber];
        }

        public static List<string> GetFilteredInventory(FiltersType filterType)
        {
            // Returns a list of garage info
            List<string> io_FilteredList = new List<string>();

            foreach (KeyValuePair<string, GarageInfo> currentGarageEntry in m_GarageInventory)
            {
                if (currentGarageEntry.Value.StatusType.Equals(filterType))
                {
                    io_FilteredList.Add(currentGarageEntry.Key);
                }
            }
            return io_FilteredList;
        }
    }
}
