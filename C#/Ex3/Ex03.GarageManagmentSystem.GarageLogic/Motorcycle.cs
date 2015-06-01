using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagmentSystem.GarageLogic
{

    class Motorcycle : Vehicle
    {
        private readonly float r_MAX_TIER_PRESSURE_ELECTRIC = 31;
        private readonly float r_MAX_TIER_PRESSURE_FUEL = 34;
        private readonly float r_MAXIMUM_BATTERY_TIME = 1.2f;
        private readonly int r_NUMBER_OF_TIERS = 2;
        private readonly float r_MAX_FUEL_LEVEL = 8;
        private readonly FuelType r_FUELTYPE = FuelType.Octan98;

        private const string K_INSERT_LICENS_TYPE = String.Format(@"what is your licens type? ({0}/{1}/{2}/{3})", License.A, License.A2, License.AB, License.B1);
        private const string k_ASK_ENGINE_SIZE = "What is your engine size?";
        private const string K_INSERT_TIER_PRESSURE = "Specify tiers' pressure?";
        private const string K_WRONG_WITH_TIERS = "Something is wrong with motorcycle tiers!";
        private const string K_WRONG_LICENS_TYPE = "Motorcycle license type got bad args";
        private const string K_WRONG_ENGINE_DATA = "Motorcycle engine got wrong data";
        
        private EngineType m_EngineType;
        private int m_EngineSize;
        private License m_LicenseType;


        public Motorcycle()
            : base()
        {
            m_Tiers = new List<Tier>(r_NUMBER_OF_TIERS);
            m_ListOfQuestions.Add(K_INSERT_LICENS_TYPE);
            m_ListOfQuestions.Add(k_ASK_ENGINE_SIZE);
            m_ListOfQuestions.Add(K_INSERT_TIER_PRESSURE);
        }

        public void init()
        {
            if (m_EngineType == EngineType.ElectricEngine)
            {
                SetTierData(m_CurrentPressurInTier, r_MAX_TIER_PRESSURE_ELECTRIC, m_TierManufacturer);
                InitElectricityEngine(r_MAXIMUM_BATTERY_TIME);
            }
            else
            {
                SetTierData(m_CurrentPressurInTier, r_MAX_TIER_PRESSURE_FUEL, m_TierManufacturer);
                InitFuelEngine(r_MAX_FUEL_LEVEL, r_FUELTYPE);
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
                // Verify license type
                o_ValidationIndicator = verifyLicenseType(i_Answer);
            }
            else if (i_QuestionIndex == 5)
            {
                // Verify engine size
                o_ValidationIndicator = verifyEngineSize(i_Answer);
            }
            else if (i_QuestionIndex > 5 && i_QuestionIndex <= 5 + r_NUMBER_OF_TIERS)
            {
                // Verify tiers
                if (m_EngineType == EngineType.ElectricEngine)
                {
                    o_ValidationIndicator = verifyTiers(i_Answer, r_MAX_TIER_PRESSURE_ELECTRIC);
                }
                else if (m_EngineType == EngineType.FuelEngine)
                {
                    o_ValidationIndicator = verifyTiers(i_Answer, r_MAX_TIER_PRESSURE_FUEL);
                }
                else
                {
                    throw new ArgumentException(K_WRONG_WITH_TIERS);
                }
            }
            return o_ValidationIndicator;
        }

        private bool verifyLicenseType(string i_GivenLicenseType)
        {
            bool o_ValidationIndicator = false;
            if (i_GivenLicenseType.Length > 2)
            {
                throw new FormatException(K_WRONG_LICENS_TYPE);
            }
            string i_givenLicenseTypeUpperCase = i_GivenLicenseType.ToUpper();
            foreach (License licenseType in Enum.GetValues(typeof(License)))
            {
                if (licenseType.ToString() == i_givenLicenseTypeUpperCase)
                {
                    // Set the color and return true
                    m_LicenseType = licenseType;
                    o_ValidationIndicator = true;
                }
            }
            return o_ValidationIndicator;
        }

        private bool verifyEngineSize(string i_GivenEngineSize)
        {
            int parsedValue;
            bool o_VerificationIndicator = false;
            bool parsingIndicator = int.TryParse(i_GivenEngineSize, out parsedValue);
            if (!parsingIndicator)
            {
                throw new FormatException(K_WRONG_ENGINE_DATA);
            }
            if (parsedValue > 0)
            {
                o_VerificationIndicator = true;
                m_EngineSize = parsedValue;
            }
            return o_VerificationIndicator;
        }

        public List<string> Questions
        {
            get { return m_ListOfQuestions; }
        }
    }
}
