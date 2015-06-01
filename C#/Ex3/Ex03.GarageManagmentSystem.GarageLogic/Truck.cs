﻿using System;
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

        private const string K_INSERT_TRUCK_WEIGHT = "What is the truck weight load?";
        private const string K_INSERT_TIER_PRESSURE = "Specify tiers' pressure?";
        private const string K_TRUCK_DANGER_OR_NOT = "Are there dangerous chemicals? (Y/N)";

        private bool m_DangerousChemical;
        private float m_Wight;

        public Truck()
            : base()
        {
            m_Tiers = new List<Tier>(ro_NUMBER_OF_TIERS);
            m_ListOfQuestions.Add(K_TRUCK_DANGER_OR_NOT);
            m_ListOfQuestions.Add(K_INSERT_TRUCK_WEIGHT);
            m_ListOfQuestions.Add(K_INSERT_TIER_PRESSURE);
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
                // Verify chemicals
                o_ValidationIndicator = verifyChemicals(i_Answer);
            }
            else if (i_QuestionIndex == 5)
            {
                // Verify load
                o_ValidationIndicator = verifyLoad(i_Answer);
            }
            else if (i_QuestionIndex > 5 && i_QuestionIndex <= 5 + ro_NUMBER_OF_TIERS)
            {
                // Verify tiers
                o_ValidationIndicator = verifyTiers(i_Answer, ro_MAX_TIER_PRESSURE);
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
                throw new FormatException("Truck load got wrong data");
            }
            if (parsedValue > 0)
            {
                o_VerificationIndicator = true;
                m_Wight = parsedValue;

            }
            return o_VerificationIndicator;
        }

        private bool verifyChemicals(string i_ChemicalsIndication)
        {
            bool o_Result = false;
            if (i_ChemicalsIndication.Length > 1)
            {
                throw new FormatException("Length bigger than one for chemicals");
            }
            else
            {
                if (i_ChemicalsIndication == "Y")
                {
                    m_DangerousChemical = true;
                    o_Result = true;
                }
                else if (i_ChemicalsIndication == "N")
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
    }
}
