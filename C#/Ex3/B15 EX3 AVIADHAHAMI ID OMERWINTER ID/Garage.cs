using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagmentSystem.GarageLogic
{
    public class Garage
    {
        private readonly static Dictionary<string, GarageInfo> m_VehicleInGarage = new Dictionary<string, GarageInfo>();

        internal static void UpdateStatus(string i_LicenseNumber, StatusType i_statusType)
        {
            GarageInfo garageInfo = m_VehicleInGarage[i_LicenseNumber];
            garageInfo.VehicleInfo.StatusType = i_statusType;
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
            m_VehicleInGarage.Add(i_GarageInfo.VehicleInfo.LicenseNumber, i_GarageInfo);
        }

        public void FillFuel(string i_LicenseNumber, FuelType i_FuelType, float i_FuelToFill)
        {


            if (CheckIfVehicleExists(i_LicenseNumber) && m_VehicleInGarage[i_LicenseNumber].Vehicle.MyEnergy is Fuel)
            {

                Fuel energySource = (Fuel)m_VehicleInGarage[i_LicenseNumber].Vehicle.MyEnergy;
                energySource.fillFuel(i_FuelToFill, i_FuelType);
            }

            else
            {
                throw new FormatException();
            }
        }

        public void FillCharger(string i_LicenseNumber, float i_FuelToFill)
        {


            if (CheckIfVehicleExists(i_LicenseNumber) && m_VehicleInGarage[i_LicenseNumber].Vehicle.MyEnergy is Electricity)
            {
                Electricity energySource = (Electricity)m_VehicleInGarage[i_LicenseNumber].Vehicle.MyEnergy;
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


        public static List<GarageInfo> GetFilteredInventory(FiltersType sortingType)
        {
            // Returns a list of garage info
            List<GarageInfo> io_FilteredList = new List<GarageInfo>();
            switch (sortingType)
            {
                case FiltersType.NONE:

                    // Just add them to the list
                    foreach (KeyValuePair<string, GarageInfo> entry in m_VehicleInGarage)
                    {
                        // do something with entry.Value or entry.Key
                        io_FilteredList.Add(entry.Value);
                    }
                    break;
                case FiltersType.FUELLEVEL:
                    break;
                case FiltersType.MANUFACTURER:
                    break;
                case FiltersType.COLOR:
                    break;
                case FiltersType.STATUS:
                    break;
                case FiltersType.TYPE:
                    break;
                case FiltersType.MODEL:
                    break;
                default:
                    break;
            }
            return io_FilteredList;
        }
    }
}
