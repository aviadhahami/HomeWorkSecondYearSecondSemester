using System;
using System.Collections.Generic;
using System.Text;

namespace B15_EX3_AVIADHAHAMI_ID_OMERWINTER_ID
{
    class Factory
    {
        public void BuildVehicle(VihecleInf i_VehicleInfo)
        {
            bool electricOrFuel = false;
            if (Garage.Exist(i_VehicleInfo.LicenseNumber))
            {
                Garage.AppdateStatus(i_VehicleInfo.LicenseNumber, StatusType.Fixing);
                Console.WriteLine("Vehicle allready exist");
            }
            switch (i_VehicleInfo.VihecleType)
            {
                case VihecleType.Car:
                    Garage.Insert(i_VehicleInfo.UserPhoneNumber, i_VehicleInfo.UserName, StatusType.Fixing, new Car(i_VehicleInfo.NumberOfDors, i_VehicleInfo.Color, i_VehicleInfo.Tiers, electricOrFuel, i_VehicleInfo.Model, i_VehicleInfo.LicenseNumber, i_VehicleInfo.RemainingEnergy, i_VehicleInfo.TierManufacturer));
                    break;

                case VihecleType.ElectricCar:
                    electricOrFuel = true;
                    Garage.Insert(i_VehicleInfo.UserPhoneNumber, i_VehicleInfo.UserName, StatusType.Fixing, new Car(i_VehicleInfo.NumberOfDors, i_VehicleInfo.Color, i_VehicleInfo.Tiers, electricOrFuel, i_VehicleInfo.Model, i_VehicleInfo.LicenseNumber, i_VehicleInfo.RemainingEnergy, i_VehicleInfo.TierManufacturer));
                    break;

                case VihecleType.Truck:
                    Garage.Insert(i_VehicleInfo.UserPhoneNumber, i_VehicleInfo.UserName, StatusType.Fixing, new Truck(i_VehicleInfo.Model, i_VehicleInfo.LicenseNumber, i_VehicleInfo.Tiers, i_VehicleInfo.RemainingEnergy, i_VehicleInfo.TierManufacturer, i_VehicleInfo.DangerousChemical, i_VehicleInfo.Wight));
                    break;

                case VihecleType.Motocycle:
                    Garage.Insert(i_VehicleInfo.UserPhoneNumber, i_VehicleInfo.UserName, StatusType.Fixing, new Motorcycle(i_VehicleInfo.Model, i_VehicleInfo.Tiers, i_VehicleInfo.LicenseNumber, i_VehicleInfo.RemainingEnergy, i_VehicleInfo.TierManufacturer, electricOrFuel, i_VehicleInfo.EngineSize, i_VehicleInfo.LicenseType));
                    break;

                case VihecleType.ElectricMotorcycle:
                    electricOrFuel = true;
                    Garage.Insert(i_VehicleInfo.UserPhoneNumber, i_VehicleInfo.UserName, StatusType.Fixing, new Motorcycle(i_VehicleInfo.Model, i_VehicleInfo.Tiers, i_VehicleInfo.LicenseNumber, i_VehicleInfo.RemainingEnergy, i_VehicleInfo.TierManufacturer, electricOrFuel, i_VehicleInfo.EngineSize, i_VehicleInfo.LicenseType));
                    break;
            }
        }
    }
}
