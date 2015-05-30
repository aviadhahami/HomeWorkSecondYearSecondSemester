using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagmentSystem.GarageLogic
{
    class Factory
    {
        public void BuildVehicle(VehicleInfo i_VehicleInfo, OwnerInfo i_OwnerInfo)
        {
            GarageInfo garageInfo;
            VehicleType electricOrFuel;
            if (Garage.Exist(i_VehicleInfo.LicenseNumber))
            {
                Garage.UpdateStatus(i_VehicleInfo.LicenseNumber, StatusType.Fixing);
                Console.WriteLine("Vehicle allready exist");
            }
            switch (i_VehicleInfo.VihecleType)
            {
                case VehicleType.Car:
                    electricOrFuel = VehicleType.Car;
                    garageInfo = new GarageInfo(i_VehicleInfo, i_OwnerInfo, new Car(i_VehicleInfo.NumberOfDors, i_VehicleInfo.Color, i_VehicleInfo.Tiers, electricOrFuel, i_VehicleInfo.Model, i_VehicleInfo.LicenseNumber, i_VehicleInfo.RemainingEnergy, i_VehicleInfo.TierManufacturer));
                    Garage.Insert(garageInfo);
                    break;

                case VehicleType.ElectricCar:
                    electricOrFuel = VehicleType.ElectricCar;
                    garageInfo = new GarageInfo(i_VehicleInfo, i_OwnerInfo, new Car(i_VehicleInfo.NumberOfDors, i_VehicleInfo.Color, i_VehicleInfo.Tiers, electricOrFuel, i_VehicleInfo.Model, i_VehicleInfo.LicenseNumber, i_VehicleInfo.RemainingEnergy, i_VehicleInfo.TierManufacturer));
                    Garage.Insert(garageInfo);
                    break;

                case VehicleType.Truck:
                    garageInfo = new GarageInfo(i_VehicleInfo, i_OwnerInfo, new Truck(i_VehicleInfo.Model, i_VehicleInfo.LicenseNumber, i_VehicleInfo.Tiers, i_VehicleInfo.RemainingEnergy, i_VehicleInfo.TierManufacturer, i_VehicleInfo.DangerousChemical, i_VehicleInfo.Wight));
                    Garage.Insert(garageInfo);
                    break;

                case VehicleType.Motocycle:
                    electricOrFuel = VehicleType.Motocycle;
                    garageInfo = new GarageInfo(i_VehicleInfo, i_OwnerInfo, new Motorcycle(i_VehicleInfo.Model, i_VehicleInfo.Tiers, i_VehicleInfo.LicenseNumber, i_VehicleInfo.RemainingEnergy, i_VehicleInfo.TierManufacturer, electricOrFuel, i_VehicleInfo.EngineSize, i_VehicleInfo.LicenseType));
                    Garage.Insert(garageInfo);
                    break;

                case VehicleType.ElectricMotorcycle:
                    electricOrFuel = VehicleType.ElectricMotorcycle;
                    garageInfo = new GarageInfo(i_VehicleInfo, i_OwnerInfo, new Motorcycle(i_VehicleInfo.Model, i_VehicleInfo.Tiers, i_VehicleInfo.LicenseNumber, i_VehicleInfo.RemainingEnergy, i_VehicleInfo.TierManufacturer, electricOrFuel, i_VehicleInfo.EngineSize, i_VehicleInfo.LicenseType));
                    Garage.Insert(garageInfo);
                    break;
            }
        }
    }
}