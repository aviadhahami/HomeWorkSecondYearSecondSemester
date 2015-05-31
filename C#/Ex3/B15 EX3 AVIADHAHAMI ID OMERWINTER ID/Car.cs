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
        private readonly int ro_MIN_AMOUNT_OF_DOORS = 1;
        private readonly int ro_MAX_AMOUNT_OF_DOORS = 5;

        private EngineType m_EngineType;
        private Colors m_Color;
        private int m_NumberOfDoors;


        public Car()
            : base()
        {
            m_Tiers = new List<Tier>(ro_NUMBER_OF_TIERS);
            m_ListOfQuestions.Add("What is the color of your car?");
            m_ListOfQuestions.Add("How many doors you have in the car?");
            m_ListOfQuestions.Add("Specify tiers' pressure?");
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
            bool o_ValidationIndicator = false;
            // Check for three first questions
            if (i_QuestionIndex == 1 || i_QuestionIndex == 3)
            {
                // First three question are unimportant strings
                return true;
            }
            else if (i_QuestionIndex == 2)
            {
                // Verify license
                o_ValidationIndicator = verifyLicense(i_Answer);
            }
            else if (i_QuestionIndex == 4)
            {
                // Verify color
                o_ValidationIndicator = verifyGivenColor(i_Answer);
            }
            else if (i_QuestionIndex == 5)
            {
                // Verify doors
                o_ValidationIndicator = verifyDoorsAmount(i_Answer);
            }
            else if (i_QuestionIndex > 5 && i_QuestionIndex <= 5 + ro_NUMBER_OF_TIERS)
            {
                // Verify tiers
                o_ValidationIndicator = verifyTiers(i_Answer);
            }
            return o_ValidationIndicator;
        }

        private bool verifyTiers(string i_GivenPressure)
        {
            float parsedFloat;
            bool parsingFlag = float.TryParse(i_GivenPressure, out parsedFloat);
            if (parsingFlag == false)
            {
                throw new FormatException("Bad input for doors amount");
            }
            if (parsedFloat >= 0 && parsedFloat <= ro_MAX_TIER_PRESSURE)
            {
                foreach (var tier in m_Tiers)
                {
                    tier.currentAirPressure = parsedFloat;
                }
                return true;
            }
            else
            {
                return false;
            }

        }

        // Verification zone
        private bool verifyDoorsAmount(string i_GivenDoorsNumber)
        {
            int parsedInt;
            bool parsingFlag = int.TryParse(i_GivenDoorsNumber, out parsedInt);
            if (parsingFlag == false)
            {
                throw new FormatException("Bad input for doors amount");
            }

            // Check amount is in range
            if (parsedInt > ro_MIN_AMOUNT_OF_DOORS && parsedInt <= ro_MAX_AMOUNT_OF_DOORS)
            {
                m_NumberOfDoors = parsedInt;
                return true;
            }
            return false;
        }

        private bool verifyGivenColor(string i_GivenColor)
        {
            Console.WriteLine("VERIFY GIVEN COLOR DEBUGGING -> USER CHOSE " + i_GivenColor);
            string givenColorUpperCase = i_GivenColor.ToUpper();
            foreach (Colors currentColor in Enum.GetValues(typeof(Colors)))
            {
                if (currentColor.ToString() == givenColorUpperCase)
                {
                    // Set the color and return true
                    m_Color = currentColor;
                    return true;
                }
            }
            return false;
        }
    }
}