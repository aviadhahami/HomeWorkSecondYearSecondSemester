﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagmentSystem.GarageLogic
{
    class Factory
    {

        private Vehicle m_VehicleToBuild;
        private Garage m_Garage;


        public List<string> getVehicleType()
        {
            List<string> vehicleType = new List<string>();
            foreach (VehicleType type in Enum.GetValues(typeof(VehicleType)))
            {
                vehicleType.Add(type.ToString());
            }
            return vehicleType;
        }

        public List<string> initVehicleToBuild(int i_vehicleTobuild)
        {
            List<string> o_Questions;
            switch (i_vehicleTobuild)
            {
                case (int)VehicleType.Car:
                    m_VehicleToBuild = new Car();
                    (m_VehicleToBuild as Car).EngineType = EngineType.FuelEngine;
                    o_Questions = (m_VehicleToBuild as Car).Questions;
                    break;
                case (int)VehicleType.ElectricCar:
                    m_VehicleToBuild = new Car();
                    (m_VehicleToBuild as Car).EngineType = EngineType.ElectricEngine;
                    o_Questions = (m_VehicleToBuild as Car).Questions;
                    break;
                case (int)VehicleType.ElectricMotorcycle:
                    m_VehicleToBuild = new Motorcycle();
                    (m_VehicleToBuild as Motorcycle).EngineType = EngineType.ElectricEngine;
                    o_Questions = (m_VehicleToBuild as Motorcycle).Questions;
                    break;
                case (int)VehicleType.Motocycle:
                    m_VehicleToBuild = new Motorcycle();
                    (m_VehicleToBuild as Motorcycle).EngineType = EngineType.FuelEngine;
                    o_Questions = (m_VehicleToBuild as Motorcycle).Questions;
                    break;
                case (int)VehicleType.Truck:
                    m_VehicleToBuild = new Truck();
                    o_Questions = (m_VehicleToBuild as Truck).Questions;
                    break;
                default:
                    throw new ArgumentException();
            }
            return o_Questions;

        }

        // Returns boolean to UI in order to determine whether the shit was good or not.
        // If it was -> Vehicle sets it
        public bool Validator(string i_Answer, int io_QuestionIndex)
        {
            bool o_ValidationResult = false;
            if (m_VehicleToBuild is Car)
            {
                if ((m_VehicleToBuild as Car).ValidateAndSetProperty(i_Answer, io_QuestionIndex))
                {
                    o_ValidationResult = true;
                }
            }
            if (m_VehicleToBuild is Motorcycle)
            {
                if ((m_VehicleToBuild as Motorcycle).ValidateAndSetProperty(i_Answer, io_QuestionIndex))
                {
                    o_ValidationResult = true;
                }
            }
            if (m_VehicleToBuild is Truck)
            {
                if ((m_VehicleToBuild as Truck).ValidateAndSetProperty(i_Answer, io_QuestionIndex))
                {
                    o_ValidationResult = true;
                }
            }
            return o_ValidationResult;

        }
        public void NotifyDone()
        {
            // Initialize engine
            init();
        }

        private void init()
        {
            if (m_VehicleToBuild is Car)
            {
                (m_VehicleToBuild as Car).init();
            }
            if (m_VehicleToBuild is Motorcycle)
            {
                (m_VehicleToBuild as Motorcycle).init();
            }
            if (m_VehicleToBuild is Truck)
            {
                (m_VehicleToBuild as Truck).init();
            }
            m_Garage.Insert(m_VehicleToBuild);
            nullify(m_VehicleToBuild);
        }

        private void nullify(Vehicle m_VehicleToBuild)
        {
            m_VehicleToBuild = null;
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