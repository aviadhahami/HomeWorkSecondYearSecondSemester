using System;
using System.Collections.Generic;
using System.Text;

namespace B15_EX3_AVIADHAHAMI_302188347_OMERWINTER_305526907
{
    class Garage
    {
        private readonly static Dictionary<string, OwnerInfo> m_VehicleInGarage = new Dictionary<string,OwnerInfo>();

        public static void AppdateStatus(string i_LicenseNumber, StatusType i_statusType)
        {
            OwnerInfo ownerInfo = m_VehicleInGarage[i_LicenseNumber];
            ownerInfo.StatusType = i_statusType;
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

        internal static void Insert(string i_UserPhoneNumber, string i_UserName, StatusType i_StatusType, Vehicle i_Vehicle)
        {
            OwnerInfo ownerInfo = new OwnerInfo(i_Vehicle, i_UserName, i_UserPhoneNumber, i_StatusType);
            m_VehicleInGarage.Add(i_Vehicle.LicenseNumber, ownerInfo);
        }

        public void FillEnergy(string i_LicenseNumber, FuelType i_FuelType, float i_FuelToFill)
        {
            Energy energyOfChoosenVehicle = m_VehicleInGarage[i_LicenseNumber].Vehicle.MyEnergy as Fuel;
            var currentVehicle = m_VehicleInGarage[i_LicenseNumber].Vehicle;

            if (energyOfChoosenVehicle != null)
            {
                energyOfChoosenVehicle.
            } 
            else
            {
                Electricity electricity = (Electricity)energyOfChoosenVehicle;
                electricity.fillElectricity(i_FuelToFill);
            }
        }

        public void PumpAir(string i_LicenseNumber)
        {
            m_VehicleInGarage[i_LicenseNumber].Vehicle.PumpAir();
            Console.WriteLine("Pump it up");
        }
    }
}
