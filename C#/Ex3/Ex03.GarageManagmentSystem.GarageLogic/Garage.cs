using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagmentSystem.GarageLogic
{
    public class Garage
    {
        private static readonly Dictionary<string, GarageInfo> m_VehicleInGarage;

        internal static void UpdateStatus(string i_LicenseNumber, StatusType i_statusType)
        {
            GarageInfo garageInfo = m_VehicleInGarage[i_LicenseNumber];
            garageInfo.StatusType = i_statusType;
        }

        internal static bool Exist(string i_LicenseNumber)
        {

            bool exist = false;
            if (m_VehicleInGarage.ContainsKey(i_LicenseNumber))
            {
                exist = true;
            }
            return exist;
        }

        internal static void Insert(GarageInfo i_GarageInfo)
        {
            m_VehicleInGarage.Add(i_GarageInfo.Vehicle.LicenseNumber, i_GarageInfo);
        }

        public void FillFuel(string i_LicenseNumber, FuelType i_FuelType, float i_FuelToFill)
        {


            if (CheckIfVehicleExists(i_LicenseNumber) && m_VehicleInGarage[i_LicenseNumber].Vehicle.Engine is Fuel)
            {

                Fuel energySource = (Fuel)m_VehicleInGarage[i_LicenseNumber].Vehicle.Engine;
                energySource.fillFuel(i_FuelToFill, i_FuelType);
            }

            else
            {
                throw new FormatException();
            }
        }

        public void FillCharger(string i_LicenseNumber, float i_FuelToFill)
        {


            if (CheckIfVehicleExists(i_LicenseNumber) && m_VehicleInGarage[i_LicenseNumber].Vehicle.Engine is Electricity)
            {
                Electricity energySource = (Electricity)m_VehicleInGarage[i_LicenseNumber].Vehicle.Engine;
                energySource.fillElectricity(i_FuelToFill);
            }
            else
            {
                throw new FormatException();
            }
        }

        public void PumpAir(string i_LicenseNumber)
        {
            m_VehicleInGarage[i_LicenseNumber].Vehicle.PumpAir();
            Console.WriteLine("Pump it up");
        }

        public bool CheckIfVehicleExists(string io_LicenseNumber)
        {
            return Exist(io_LicenseNumber);
        }

        public GarageInfo GetVehicleInfo(string i_LicenseNumber)
        {
            return m_VehicleInGarage[i_LicenseNumber];
        }


        public static List<GarageInfo> GetFilteredInventory(FiltersType filterType)
        {
            // Returns a list of garage info
            List<GarageInfo> io_FilteredList = new List<GarageInfo>();
            switch (filterType)
            {
                case FiltersType.NONE:
                    foreach (KeyValuePair<string, GarageInfo> vehicle in m_VehicleInGarage)
                    {
                        io_FilteredList.Add(vehicle.Value);
                    }
                    break;
                case FiltersType.ACTIVE:
                    break;
                case FiltersType.NONACTIVE:
                    break;
                default:
                    break;
            }
            return io_FilteredList;
        }
    }
}
