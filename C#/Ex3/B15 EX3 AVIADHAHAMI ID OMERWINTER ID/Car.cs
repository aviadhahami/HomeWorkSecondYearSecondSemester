﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagmentSystem.GarageLogic
{
    class Car : Vehicle
    {
        private readonly float MAXIMUMBUTTRYTIME = 2.2f;
        private readonly float MAXTIERPRESSUR = 31;
        private readonly float FULLTANK = 35;
        private readonly int NUMBEROFTAIERS = 4;
        private readonly FuelType FUELTYPE = FuelType.Octan96;

        int m_numberOfDors;
        Colors m_color;
        public Car(int i_NumberOfDors, Colors i_Color, List<float> i_PressurInTiers, VehicleType i_ElectricVehicle, string i_Model, string i_LicenseNumber, float i_RemainingEnergy, string i_TierManufacturer)
            : base(i_Model, i_LicenseNumber, i_RemainingEnergy,i_TierManufacturer)
        {
            m_color = i_Color;
            m_numberOfDors = i_NumberOfDors;
            this.m_Tiers = new List<Tier>(NUMBEROFTAIERS);
            setTierData(i_PressurInTiers, MAXTIERPRESSUR, this.m_TierManufacturer);
            if (i_ElectricVehicle == VehicleType.ElectricCar)
            {
                m_MyEnergy = new Electricity(MAXIMUMBUTTRYTIME, MAXIMUMBUTTRYTIME * m_RemainingEnergy);
            }
            else
            {
                m_MyEnergy = new Fuel(FULLTANK, FULLTANK * m_RemainingEnergy, FUELTYPE);
            }
        }

        public Colors Color
        {
            get { return m_color; }
            set { m_color = value; }
        }
        public int NumberOfDors
        {
            get { return m_numberOfDors; }
            set { m_numberOfDors = value; }
        }
    }
}
