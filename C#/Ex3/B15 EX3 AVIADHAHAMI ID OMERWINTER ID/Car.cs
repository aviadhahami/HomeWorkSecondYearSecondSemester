using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagmentSystem.GarageLogic
{
    class Car : Vehicle
    {
        private readonly float ro_MAX_TIER_PRESSURE = 31;
        private readonly int ro_NUMBER_OF_TIERS = 4;

        // Stub for later engine creation
        private readonly FuelType FUELTYPE = FuelType.Octan96;
        private readonly float ro_MAX_FUEL_LEVEL = 35;
        private readonly float ro_MAXIMUM_BATTERY_TIME = 2.2f;


        EngineType m_EngineType;
        Energy m_Engine;
        Colors m_Color;
        int m_NumberOfDoors;

        public Car(string i_Model, string i_LicenseNumber, string i_TierManufacturer)
            : base(i_Model, i_LicenseNumber, i_TierManufacturer)
        {
            // Add questions to the list
            m_ListOfQuestions.Add("Enter engine type:");

        }
        internal List<Tier> GetTiers
        {
            get { return m_Wheels; }
        }
        internal EngineType EngineType
        {
            get { return m_EngineType; }
            set
            {
                m_EngineType = value;
                if (value == EngineType.ElectricEngine)
                {
                    m_Engine = new Electricity(ro_MAXIMUM_BATTERY_TIME, ro_MAXIMUM_BATTERY_TIME * m_RemainingEnergy);
                }
                else
                {
                    m_Engine = new Fuel(ro_MAX_FUEL_LEVEL, ro_MAX_FUEL_LEVEL * m_RemainingEnergy, FUELTYPE);
                }
            }
        }
        internal Colors Colors
        {
            get { return m_Color; }
            set { m_Color = value; }
        }
        public List<string> Questions
        {
            get { return m_ListOfQuestions; }
        }
        internal int Doors
        {
            get { return m_NumberOfDoors; }
            set { m_NumberOfDoors = value; }
        }
        internal float RemainingEnergy
        {
            get { return m_RemainingEnergy; }
            set { m_RemainingEnergy = value; }
        }
        public bool ValidateAndSetProperty(string i_Answer, int i_QuestionIndex)
        {
            return false;
        }
    }
}