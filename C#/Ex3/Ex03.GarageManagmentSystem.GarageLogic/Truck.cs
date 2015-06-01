using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagmentSystem.GarageLogic
{
    class Truck : Vehicle
    {

        private readonly float r_MAX_TIER_PRESSURE = 25;
        private readonly float r_MAX_FUEL_LEVEL = 170;
        private readonly int r_NUMBER_OF_TIERS = 16;
        private readonly FuelType r_FUELTYPE = FuelType.Soler;

        private const string K_INSERT_TRUCK_WEIGHT = "What is the truck weight load?";
        private const string K_INSERT_TIER_PRESSURE = "Specify tiers' pressure?";
        private const string K_TRUCK_DANGER_OR_NOT = "Are there dangerous chemicals? (Y/N)";
        private const string K_WORNG_TRUCK_LOAD = "Truck load got wrong data";
        private const string K_WORNG_LENGHT_BIGGER_THEN_ONE = "Length bigger than one for chemicals";
        private const string K_YES = "Y";
        private const string K_NO = "N";
        private const string k_NewLineToken = "\n";

        private bool m_DangerousChemical;
        private float m_Weight;

        public Truck()
            : base()
        {
            m_Tiers = new List<Tier>(r_NUMBER_OF_TIERS);
            for (int i = 0; i < r_NUMBER_OF_TIERS; i++)
            {
                m_Tiers.Add(new Tier());
            }
            m_ListOfQuestions.Add(K_TRUCK_DANGER_OR_NOT);
            m_ListOfQuestions.Add(K_INSERT_TRUCK_WEIGHT);
            m_ListOfQuestions.Add(K_INSERT_TIER_PRESSURE);
        }

        public void init()
        {
            SetTierData(m_CurrentPressurInTier, r_MAX_TIER_PRESSURE, m_TierManufacturer);
            InitFuelEngine(r_MAX_FUEL_LEVEL, r_FUELTYPE);
        }
        public float LicenseType
        {
            get { return m_Weight; }
            set { m_Weight = value; }
        }

        public bool DangerousChemical
        {
            get { return m_DangerousChemical; }
            set { m_DangerousChemical = value; }
        }

        internal bool ValidateAndSetProperty(string i_Answer, int i_QuestionIndex)
        {
            bool o_ValidationIndicator = false;
            // Check for three first questions
            if (i_QuestionIndex == 1)
            {
                m_Model = i_Answer;
                // First three question are unimportant strings
                return true;
            }
            else if (i_QuestionIndex == 2)
            {
                // Verify license
                o_ValidationIndicator = verifyLicense(i_Answer);
            }
            else if (i_QuestionIndex == 3)
            {
                m_TierManufacturer = i_Answer;
                o_ValidationIndicator = true;
            }
            else if (i_QuestionIndex == 4)
            {
                // Verify chemicals
                o_ValidationIndicator = verifyChemicals(i_Answer);
            }
            else if (i_QuestionIndex == 5)
            {
                // Verify load
                o_ValidationIndicator = verifyLoad(i_Answer);
            }
            else if (i_QuestionIndex > 5 && i_QuestionIndex <= 5 + r_NUMBER_OF_TIERS)
            {
                // Verify tiers
                o_ValidationIndicator = verifyTiersPressure(i_Answer, r_MAX_TIER_PRESSURE);
            }
            return o_ValidationIndicator;
        }

        private bool verifyLoad(string i_GivenTruckLoad)
        {
            float parsedValue;
            bool o_VerificationIndicator = false;
            bool parsingIndicator = float.TryParse(i_GivenTruckLoad, out parsedValue);
            if (!parsingIndicator)
            {
                throw new FormatException(K_WORNG_TRUCK_LOAD);
            }
            if (parsedValue > 0)
            {
                o_VerificationIndicator = true;
                m_Weight = parsedValue;

            }
            return o_VerificationIndicator;
        }

        private bool verifyChemicals(string i_ChemicalsIndication)
        {
            bool o_Result = false;
            if (i_ChemicalsIndication.Length > 1)
            {
                throw new FormatException(K_WORNG_LENGHT_BIGGER_THEN_ONE);
            }
            else
            {
                if (i_ChemicalsIndication == K_YES)
                {
                    m_DangerousChemical = true;
                    o_Result = true;
                }
                else if (i_ChemicalsIndication == K_NO)
                {
                    m_DangerousChemical = false;
                    o_Result = true;
                }
            }
            return o_Result;
        }

        public List<string> Questions
        {
            get { return m_ListOfQuestions; }
        }

        public override string ToString()
        {
            string o_OutputString = "";
            o_OutputString += "Dangerous: " + (m_DangerousChemical ? "Yes" : "False");
            o_OutputString += k_NewLineToken;
            o_OutputString += "Weight: " + m_Weight;
            o_OutputString += k_NewLineToken;

            return o_OutputString + base.ToString();
        }
    }
}
