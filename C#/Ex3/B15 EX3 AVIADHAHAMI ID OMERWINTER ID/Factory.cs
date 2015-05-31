using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagmentSystem.GarageLogic
{
    class Factory
    {

        private Vehicle m_VehicleToBuild;

        public List<string> getVehicleType()
        {
            List<string> vehicleType = new List<string>();
            foreach (VehicleType type in Enum.GetValues(typeof (VehicleType)))
            {
                vehicleType.Add(type.ToString());
            }
            return vehicleType;
        }

        public List<string> initVehicleToBuild(int i_vehicleTobuild)
        {

            switch (i_vehicleTobuild)
            {
                case (int) VehicleType.Car :
                    m_VehicleToBuild = new Car();
                    Car carToBuild = (Car)m_VehicleToBuild;
                    carToBuild.Engine = new Fuel(EngineType.FuelEngine);
                    return carToBuild.getQuestions;
                    break;
                case (int)VehicleType.ElectricCar:
                    m_VehicleToBuild = new Car();
                    Car carToBuild = (Car)m_VehicleToBuild;
                    carToBuild.Engine = new Fuel(EngineType.ElectricEngine);
                    return carToBuild.getQuestions;
                    break;
                case (int)VehicleType.ElectricMotorcycle:
                    m_VehicleToBuild = new Motorcycle();
                    break;
                case (int)VehicleType.Motocycle:
                    m_VehicleToBuild = new Motorcycle();
                    break;
                case (int)VehicleType.Truck:
                    m_VehicleToBuild = new Truck();
                    break;
                default:
                    throw new ArgumentException();
            }

        }





/*       
        public void BuildVehicle()
        {
            if (Garage.Exist(i_VehicleInfo.LicenseNumber))
            {
                Garage.UpdateStatus(i_VehicleInfo.LicenseNumber, StatusType.Fixing);
                Console.WriteLine("Vehicle allready exist");
            }
            switch (i_VehicleInfo.VehicleType)
            {
                case VehicleType.Car:
                    electricOrFuel = EngineType.FuelEngine;
                    garageInfo = new GarageInfo(i_VehicleInfo, i_OwnerInfo, new Car(i_VehicleInfo.NumberOfDoors, i_VehicleInfo.Color, i_VehicleInfo.Tiers, electricOrFuel, i_VehicleInfo.Model, i_VehicleInfo.LicenseNumber, i_VehicleInfo.RemainingEnergy, i_VehicleInfo.TierManufacturer));
                    Garage.Insert(garageInfo);
                    break;

                case VehicleType.ElectricCar:
                    electricOrFuel = EngineType.ElectricEngine;
                    garageInfo = new GarageInfo(i_VehicleInfo, i_OwnerInfo, new Car(i_VehicleInfo.NumberOfDoors, i_VehicleInfo.Color, i_VehicleInfo.Tiers, electricOrFuel, i_VehicleInfo.Model, i_VehicleInfo.LicenseNumber, i_VehicleInfo.RemainingEnergy, i_VehicleInfo.TierManufacturer));
                    Garage.Insert(garageInfo);
                    break;

                case VehicleType.Truck:
                    garageInfo = new GarageInfo(i_VehicleInfo, i_OwnerInfo, new Truck(i_VehicleInfo.Model, i_VehicleInfo.LicenseNumber, i_VehicleInfo.Tiers, i_VehicleInfo.RemainingEnergy, i_VehicleInfo.TierManufacturer, i_VehicleInfo.DangerousChemical, i_VehicleInfo.Weight));
                    Garage.Insert(garageInfo);
                    break;

                case VehicleType.Motocycle:
                    electricOrFuel = EngineType.FuelEngine;
                    garageInfo = new GarageInfo(i_VehicleInfo, i_OwnerInfo, new Motorcycle(i_VehicleInfo.Model, i_VehicleInfo.Tiers, i_VehicleInfo.LicenseNumber, i_VehicleInfo.RemainingEnergy, i_VehicleInfo.TierManufacturer, electricOrFuel, i_VehicleInfo.EngineSize, i_VehicleInfo.LicenseType));
                    Garage.Insert(garageInfo);
                    break;

                case VehicleType.ElectricMotorcycle:
                    electricOrFuel = EngineType.ElectricEngine;
                    garageInfo = new GarageInfo(i_VehicleInfo, i_OwnerInfo, new Motorcycle(i_VehicleInfo.Model, i_VehicleInfo.Tiers, i_VehicleInfo.LicenseNumber, i_VehicleInfo.RemainingEnergy, i_VehicleInfo.TierManufacturer, electricOrFuel, i_VehicleInfo.EngineSize, i_VehicleInfo.LicenseType));
                    Garage.Insert(garageInfo);
                    break;
            }
        }*/
    }
}