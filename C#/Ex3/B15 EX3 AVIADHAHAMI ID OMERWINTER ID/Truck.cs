using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagmentSystem.GarageLogic
{
    class Truck : Vehicle
    {

        private readonly float ro_MAX_TIER_PRESSURE = 25;
        private readonly float ro_MAX_FUEL_LEVEL = 170;
        private readonly int ro_NUMBER_OF_TIERS = 16;
        private readonly FuelType ro_FUELTYPE = FuelType.Soler;

        private EngineType m_EngineType;
        private bool m_DangerousChemical;
        private float m_Wight;

        public Truck()
            : base()
        {
            m_Tiers = new List<Tier>(ro_NUMBER_OF_TIERS);
            m_ListOfQuestions.Add("there are dangerous chemicals?");
            m_ListOfQuestions.Add("what is the the truck weight?");
            m_ListOfQuestions.Add("what is your tier pressur?");
        }

        public void init()
        {
            SetTierData(m_CurrentPressurInTier, ro_MAX_TIER_PRESSURE, m_TierManufacturer);
            InitFuelEngine(ro_MAX_FUEL_LEVEL, ro_FUELTYPE);
        }
        public float LicenseType
        {
            get { return m_Wight; }
            set { m_Wight = value; }
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
            }
            return o_ValidationIndicator;
        }
    }
}
