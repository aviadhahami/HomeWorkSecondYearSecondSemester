using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagmentSystem.GarageLogic
{
    class Factory
    {
        public void BuildVehicle(VehicleInfo i_VehicleInfo)
        {
            VehicleType electricOrFuel;
            if (Garage.Exist(i_VehicleInfo.LicenseNumber))
            {
                Garage.UpdateStatus(i_VehicleInfo.LicenseNumber, StatusType.Fixing);
                Console.WriteLine("Vehicle allready exist");
            }
            switch (i_VehicleInfo.VehicleType)
            {
                case VehicleType.Car:
                    electricOrFuel = VehicleType.Car;
                    i_VehicleInfo.Vehicle = new Car(i_VehicleInfo.NumberOfDoors, i_VehicleInfo.Color, i_VehicleInfo.Tiers, electricOrFuel, i_VehicleInfo.Model, i_VehicleInfo.LicenseNumber, i_VehicleInfo.RemainingEnergy, i_VehicleInfo.TierManufacturer);
                    Garage.Insert(i_VehicleInfo);
                    break;

                case VehicleType.ElectricCar:
                    electricOrFuel = VehicleType.ElectricCar;
                    i_VehicleInfo.Vehicle = new Car(i_VehicleInfo.NumberOfDoors, i_VehicleInfo.Color, i_VehicleInfo.Tiers, electricOrFuel, i_VehicleInfo.Model, i_VehicleInfo.LicenseNumber, i_VehicleInfo.RemainingEnergy, i_VehicleInfo.TierManufacturer);
                    Garage.Insert(i_VehicleInfo);
                    break;

                case VehicleType.Truck:
                    i_VehicleInfo.Vehicle = new Truck(i_VehicleInfo.Model, i_VehicleInfo.LicenseNumber, i_VehicleInfo.Tiers, i_VehicleInfo.RemainingEnergy, i_VehicleInfo.TierManufacturer, i_VehicleInfo.DangerousChemical, i_VehicleInfo.Weight);
                    Garage.Insert(i_VehicleInfo);
                    break;

                case VehicleType.Motocycle:
                    electricOrFuel = VehicleType.Motocycle;
                    i_VehicleInfo.Vehicle = new Motorcycle(i_VehicleInfo.Model, i_VehicleInfo.Tiers, i_VehicleInfo.LicenseNumber, i_VehicleInfo.RemainingEnergy, i_VehicleInfo.TierManufacturer, electricOrFuel, i_VehicleInfo.EngineSize, i_VehicleInfo.LicenseType);
                    Garage.Insert(i_VehicleInfo);
                    break;

                case VehicleType.ElectricMotorcycle:
                    electricOrFuel = VehicleType.ElectricMotorcycle;
                    i_VehicleInfo.Vehicle = new Motorcycle(i_VehicleInfo.Model, i_VehicleInfo.Tiers, i_VehicleInfo.LicenseNumber, i_VehicleInfo.RemainingEnergy, i_VehicleInfo.TierManufacturer, electricOrFuel, i_VehicleInfo.EngineSize, i_VehicleInfo.LicenseType);
                    Garage.Insert(i_VehicleInfo);
                    break;
            }
        }
    }
}