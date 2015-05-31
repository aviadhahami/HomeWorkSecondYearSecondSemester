using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagmentSystem.GarageLogic
{

    class Motorcycle : Vehicle
    {
        private readonly float ro_MAX_TIER_PRESSURE_ELECTRIC = 31;
        private readonly float ro_MAX_TIER_PRESSURE_FUEL = 34;
        private readonly float ro_MAXIMUM_BATTERY_TIME = 1.2f;
        private readonly int ro_NUMBER_OF_TIERS = 2;
        private readonly float ro_MAX_FUEL_LEVEL = 8;
        private readonly FuelType ro_FUELTYPE = FuelType.Octan98;


        private EngineType m_EngineType;
        private int m_EngineSize;
        private License m_LicenseType;

        public Motorcycle()
            : base()
        {
            m_Tiers = new List<Tier>(ro_NUMBER_OF_TIERS);
            string licensTypeToString = String.Format(@"what is your licens type? ({0}/{1}/{2}/{3})", License.A, License.A2, License.AB, License.B1);
            m_ListOfQuestions.Add(licensTypeToString);
            m_ListOfQuestions.Add("what is your engine size?");
            m_ListOfQuestions.Add("what is your tier pressur?");
        }

        public void init()
        {
            if (m_EngineType == EngineType.ElectricEngine)
            {
                SetTierData(m_CurrentPressurInTier, ro_MAX_TIER_PRESSURE_ELECTRIC, m_TierManufacturer);
                InitElectricityEngine(ro_MAXIMUM_BATTERY_TIME);
            }
            else
            {
                SetTierData(m_CurrentPressurInTier, ro_MAX_TIER_PRESSURE_FUEL, m_TierManufacturer);
                InitFuelEngine(ro_MAX_FUEL_LEVEL, ro_FUELTYPE);
            }
        }

        internal EngineType EngineType
        {
            get { return m_EngineType; }
            set { m_EngineType = value; }
        }

        public License LicenseType
        {
            get { return m_LicenseType; }
            set { m_LicenseType = value; }
        }

        public int EngineSize
        {
            get { return m_EngineSize; }
            set { m_EngineSize = value; }
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
