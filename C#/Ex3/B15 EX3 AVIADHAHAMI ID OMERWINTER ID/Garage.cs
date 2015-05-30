using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagmentSystem.GarageLogic
{
    public class Garage
    {


        private readonly static Dictionary<string, GarageInfo> m_VehicleInGarage = new Dictionary<string,GarageInfo>();

        internal static void UpdateStatus(string i_LicenseNumber, StatusType i_statusType)

        {
            GarageInfo garageInfo = m_VehicleInGarage[i_LicenseNumber];
            garageInfo.VihecleInfo.StatusType = i_statusType;
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
            m_VehicleInGarage.Add(i_GarageInfo.VihecleInfo.LicenseNumber, i_GarageInfo);
        }

        public void FillFuel(string i_LicenseNumber, FuelType i_FuelType, float i_FuelToFill)
        {


            if (CheckIfVehicleExists(i_LicenseNumber) && m_VehicleInGarage[i_LicenseNumber].Vihecle.MyEnergy is Fuel)
            {

                Fuel energySource = (Fuel)m_VehicleInGarage[i_LicenseNumber].Vihecle.MyEnergy;
                energySource.fillFuel(i_FuelToFill, i_FuelType);
            } 

            else
            {
                throw new FormatException();
            }
        }
        
        public void FillCharger(string i_LicenseNumber, float i_FuelToFill)
        {


            if (CheckIfVehicleExists(i_LicenseNumber) && m_VehicleInGarage[i_LicenseNumber].Vihecle.MyEnergy is Electricity)
            {
                Electricity energySource = (Electricity)m_VehicleInGarage[i_LicenseNumber].Vihecle.MyEnergy;
                energySource.fillElectricity(i_FuelToFill);
            }
            else
            {
                throw new FormatException();
            }
        }

        public void PumpAir(string i_LicenseNumber)
        {
            m_VehicleInGarage[i_LicenseNumber].Vihecle.PumpAir();
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
    }
}
