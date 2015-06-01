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

        private string K_INSERT_CAR_COLOR = String.Format(@"What is the color of your car? ({0}/{1}/{2}/{3})", Colors.BLACK, Colors.GREEN, Colors.RED, Colors.WHITE);
        private const string K_INSERT_NUMBER_OF_DOORS = "How many doors you have in the car? (2-5)";
        private const string K_INSERT_TIER_PRESSURE = "Specify tiers' pressure?";
        private const string K_WRONG_AMOUNT_OF_DOORS = "Bad input for doors amount";
        private const string K_VERIFY_GIVEN_COLOR = "VERIFY GIVEN COLOR DEBUGGING -> USER CHOSE ";
        private const string k_NewLineToken = "\n";

        private EngineType m_EngineType;
        private Colors m_Color;
        private int m_NumberOfDoors;

        public Car()
            : base()
        {
            m_Tiers = new List<Tier>(ro_NUMBER_OF_TIERS);
            m_ListOfQuestions.Add(K_INSERT_CAR_COLOR);
            m_ListOfQuestions.Add(K_INSERT_NUMBER_OF_DOORS);
            m_ListOfQuestions.Add(K_INSERT_TIER_PRESSURE);
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
                o_ValidationIndicator = true;
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
                o_ValidationIndicator = verifyTiers(i_Answer, ro_MAX_TIER_PRESSURE);
            }
            return o_ValidationIndicator;
        }
        // Verification zone
        private bool verifyDoorsAmount(string i_GivenDoorsNumber)
        {
            int parsedInt;
            bool parsingFlag = int.TryParse(i_GivenDoorsNumber, out parsedInt);
            if (parsingFlag == false)
            {
                throw new FormatException(K_WRONG_AMOUNT_OF_DOORS);
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
            bool o_ValidationIndicator = false;
            Console.WriteLine(K_VERIFY_GIVEN_COLOR + i_GivenColor);
            string givenColorUpperCase = i_GivenColor.ToUpper();
            foreach (Colors currentColor in Enum.GetValues(typeof(Colors)))
            {
                if (currentColor.ToString() == givenColorUpperCase)
                {
                    // Set the color and return true
                    m_Color = currentColor;
                    o_ValidationIndicator = true;
                }
            }
            return o_ValidationIndicator;
        }
        public override string ToString()
        {
            string o_OutputString = "";
            o_OutputString += "Engine type: " + m_EngineType.ToString();
            o_OutputString += k_NewLineToken;
            o_OutputString += "Number of doors: " + m_NumberOfDoors;
            o_OutputString += k_NewLineToken;

            return o_OutputString + base.ToString();
        }
    }
}

