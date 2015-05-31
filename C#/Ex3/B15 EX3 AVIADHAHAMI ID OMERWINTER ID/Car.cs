using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagmentSystem.GarageLogic
{
    class Car : Vehicle
    {
        // Constants for cars
        private readonly float ro_MAX_TIER_PRESSURE = 31;
        private readonly int ro_NUMBER_OF_TIERS = 4;
        private readonly FuelType ro_FUELTYPE = FuelType.Octan96;
        private readonly float ro_MAX_FUEL_LEVEL = 35;
        private readonly float ro_MAXIMUM_BATTERY_TIME = 2.2f;


        private EngineType m_EngineType;
        private Colors m_Color;
        private int m_NumberOfDoors;

        public Car()
            : base()
        {
            m_Tiers = new List<Tier>(ro_NUMBER_OF_TIERS);
            m_ListOfQuestions.Add("What is the color of your car?");
            m_ListOfQuestions.Add("How many doors you have in the car?");
            for (int i = 0; i < ro_NUMBER_OF_TIERS; i++)
            {
                m_ListOfQuestions.Add("Specify tiers' pressure?");
            }

        }

        public void init()
        {
            SetTierData(m_CurrentPressurInTier, ro_MAX_TIER_PRESSURE, m_TierManufacturer);
            if (m_EngineType == EngineType.ElectricEngine)
            {
                InitElectricityEngine(ro_MAXIMUM_BATTERY_TIME);
            }
            else
            {
                InitFuelEngine(ro_MAX_FUEL_LEVEL, ro_FUELTYPE);
            }
        }

        internal EngineType EngineType
        {
            get { return m_EngineType; }
            set { m_EngineType = value; }
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
        internal bool ValidateAndSetProperty(string i_Answer, int i_QuestionIndex)
        {
            // Check for three first questions
            if (i_QuestionIndex > 0 && i_QuestionIndex <= 3)
            {
                // First three question are unimportant strings
                return true;
            }
            else if (i_QuestionIndex == 4)
            {
                // Verify color
            }
            else if (i_QuestionIndex == 5)
            {
                // Verify doors
            }
            else if (i_QuestionIndex > 5 && i_QuestionIndex <= 5 + ro_NUMBER_OF_TIERS)
            {
                // Verify tiers
            }
            return false;
        }
    }
}