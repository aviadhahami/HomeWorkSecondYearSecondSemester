using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagmentSystem.GarageLogic
{
    public class Garage
    {
        private static readonly Dictionary<string, GarageInfo> m_GarageInventory = new Dictionary<string, GarageInfo>();

        internal static void UpdateStatus(string i_LicenseNumber, StatusType i_statusType)
        {
            GarageInfo garageInfo = msr_GarageInventory[i_LicenseNumber];
            garageInfo.StatusType = i_statusType;
        }

        public static bool Exist(string i_LicenseNumber)
        {

            bool o_Exist = false;
            if (msr_GarageInventory.ContainsKey(i_LicenseNumber))
            {
                o_Exist = true;
            }
            return o_Exist;
        }

        internal static void Insert(GarageInfo i_GarageInfo)
        {
            msr_GarageInventory.Add(i_GarageInfo.Vehicle.LicenseNumber, i_GarageInfo);
        }

        public void FillFuel(string i_LicenseNumber, FuelType i_FuelType, float i_FuelToFill)
        {


            if (CheckIfVehicleExists(i_LicenseNumber) && msr_GarageInventory[i_LicenseNumber].Vehicle.Engine is Fuel)
            {

                //Fuel energySource = (Fuel)msr_GarageInventory[i_LicenseNumber].Vehicle.Engine;
                //energySource.fillFuel(i_FuelToFill, i_FuelType);
                (msr_GarageInventory[i_LicenseNumber].Vehicle.Engine as Fuel).fillFuel(i_FuelToFill, i_FuelType);
            }

            else
            {
                throw new FormatException();
            }
        }

        public void FillCharger(string i_LicenseNumber, float i_FuelToFill)
        {
            if (CheckIfVehicleExists(i_LicenseNumber) && msr_GarageInventory[i_LicenseNumber].Vehicle.Engine is Electricity)
            {
                //Electricity energySource = (Electricity)msr_GarageInventory[i_LicenseNumber].Vehicle.Engine;
                //energySource.fillElectricity(i_FuelToFill);
                (msr_GarageInventory[i_LicenseNumber].Vehicle.Engine as Electricity).fillElectricity(i_FuelToFill);
            }
            else
            {
                throw new FormatException();
            }
        }

        public void PumpAir(string i_LicenseNumber)
        {
            msr_GarageInventory[i_LicenseNumber].Vehicle.PumpAir();
        }

        public bool CheckIfVehicleExists(string io_LicenseNumber)
        {
            return Exist(io_LicenseNumber);
        }

        public static GarageInfo GetVehicleInfo(string i_LicenseNumber)
        {
            return msr_GarageInventory[i_LicenseNumber];
        }

        public static List<string> GetFilteredInventory(FiltersType i_FilterType)
        {
            // Returns a list of garage info
            List<string> io_FilteredList = new List<string>();

            foreach (KeyValuePair<string, GarageInfo> currentGarageEntry in msr_GarageInventory)
            {
                if (currentGarageEntry.Value.StatusType.Equals(i_FilterType))
                {
                    io_FilteredList.Add(currentGarageEntry.Key);
                }
            }
            return io_FilteredList;
        }
    }
}
