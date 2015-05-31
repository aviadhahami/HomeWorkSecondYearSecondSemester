using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagmentSystem.GarageLogic
{
    class Car : Vehicle
    {

        private readonly float ro_MAXIMUM_BATTERY_TIME = 2.2f;
        private readonly float ro_MAX_TIER_PRESSURE = 31;
        private readonly int ro_NUMBER_OF_TIERS = 4;


        List<Tier> m_Wheels;
        EngineType m_Engine;
        Colors m_Color;
        int m_NumberOfDoors;

        public Car(string i_Model, string i_LicenseNumber, string i_TierManufacturer)
            : base(i_Model, i_LicenseNumber, i_TierManufacturer)
        {

        }
        public List<Tier> Tiers
        {
            get { return m_Wheels; }
            set { m_Wheels = value; }
        }
        public EngineType Engine
        {
            get { return m_Engine; }
            set { m_Engine = value; }
        }
        public Colors Colors
        {
            get { return m_Color; }
            set { m_Color = value; }
        }

        public int Doors
        {
            get { return m_NumberOfDoors; }
            set { m_NumberOfDoors = value; }
        }
        public float RemainingEnergy
        {
            get { return m_RemainingEnergy; }
            set { m_RemainingEnergy = value; }
        }
    }
}