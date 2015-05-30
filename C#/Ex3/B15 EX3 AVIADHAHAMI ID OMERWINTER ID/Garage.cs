using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagmentSystem.GarageLogic
{
    public class Garage
    {


        private readonly static Dictionary<string, VehicleInfo> m_VehicleInGarage = new Dictionary<string,VehicleInfo>();

        public static void UpdateStatus(string i_LicenseNumber, StatusType i_statusType)

        {
            VehicleInfo vehicleInfo = m_VehicleInGarage[i_LicenseNumber];
            vehicleInfo.StatusType = i_statusType;
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

        internal static void Insert(VehicleInfo i_VehicleInfo)
        {
            m_VehicleInGarage.Add(i_VehicleInfo.LicenseNumber, i_VehicleInfo);
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

        public VehicleInfo getVehicleInfo(string i_LicenseNumber)
        {
            return m_VehicleInGarage[i_LicenseNumber];
        }
    }
}
