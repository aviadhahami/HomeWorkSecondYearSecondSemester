using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagmentSystem.GarageLogic
{
    class Vehicle
    {
        private const string K_INSERT_MODEL = "Please insert model:";
        private const string K_INSERT_LICENSE_NUMBER = "Please insert license plate number:";
        private const string K_INSERT_TIER_MANUFACTURER = "Please insert tier manufacturer:";
        private const string K_WRONG_TIER_DATA = "Bad input for tier data";
        private const string k_NewLineToken = "\n";

        protected string m_Model;
        protected string m_LicenseNumber;
        protected float m_RemainingEnergy;
        protected float m_CurrentPressurInTier;
        protected List<Tier> m_Tiers;
        protected string m_TierManufacturer;
        protected Energy m_Engine;
        protected List<string> m_ListOfQuestions;

        protected Vehicle()
        {
            m_ListOfQuestions = new List<string>();
            m_ListOfQuestions.Add(K_INSERT_MODEL);
            m_ListOfQuestions.Add(K_INSERT_LICENSE_NUMBER);
            m_ListOfQuestions.Add(K_INSERT_TIER_MANUFACTURER);

        }
        protected void SetTierData(float i_PressurInTiers, float i_MaxTierPressur, string i_tierManufacturer)
        {
            foreach (Tier tier in m_Tiers)
            {
                tier.manufacturer = m_TierManufacturer;
                tier.MaximalAirPressure = i_MaxTierPressur;
                tier.currentAirPressure = i_PressurInTiers;
            }
        }
        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
        }
        public Energy Engine
        {
            get { return m_Engine; }
        }
        public List<Tier> Tiers
        {
            get { return m_Tiers; }
        }
        public void PumpAir()
        {
            foreach (Tier tier in m_Tiers)
            {
                tier.PumpAir = tier.MaximalAirPressure - tier.currentAirPressure;
            }
            m_CurrentPressurInTier = m_Tiers[1].currentAirPressure;
        }
        // Init engines
        protected void InitElectricityEngine(float io_MaxBatteryTime)
        {
            m_Engine = new Electricity(io_MaxBatteryTime, io_MaxBatteryTime * m_RemainingEnergy);

        }
        protected void InitFuelEngine(float io_MaxFuelLevel, FuelType io_FuelType)
        {
            m_Engine = new Fuel(io_MaxFuelLevel, io_MaxFuelLevel * m_RemainingEnergy, io_FuelType);
        }
        // Verifications
        protected bool verifyLicense(string i_GivenLicense)
        {
            foreach (char currentChar in i_GivenLicense)
            {
                if (!char.IsLetterOrDigit(currentChar))
                {
                    return false;
                }
            }
            // If true set the license
            m_LicenseNumber = i_GivenLicense;
            return true;
        }
        protected bool verifyTiersPressure(string i_GivenPressure, float i_MaxTierPressure)
        {
            float parsedFloat;
            bool parsingFlag = float.TryParse(i_GivenPressure, out parsedFloat);
            if (parsingFlag == false)
            {
                throw new FormatException(K_WRONG_TIER_DATA);
            }
            if (parsedFloat >= 0 && parsedFloat <= i_MaxTierPressure)
            {
                foreach (var tier in m_Tiers)
                {
                    tier.currentAirPressure = parsedFloat;
                }
                m_CurrentPressurInTier = parsedFloat;
                return true;
            }
            else
            {
                return false;
            }

        }


        public override string ToString()
        {
            string o_StringedData = "";
            o_StringedData += "Vehicle type: " + this.GetType().Name;
            o_StringedData += k_NewLineToken;
            o_StringedData += "License plate: " + m_LicenseNumber;
            o_StringedData += k_NewLineToken;
            o_StringedData += "Model: " + m_Model;
            o_StringedData += k_NewLineToken;
            o_StringedData += "Current energy: " + m_Engine.getRemainingEnergy;
            o_StringedData += k_NewLineToken;
            o_StringedData += "Current pressure in tiers: " + m_CurrentPressurInTier;
            o_StringedData += k_NewLineToken;
            o_StringedData += "Amount of tiers: " + m_Tiers.Count;
            o_StringedData += k_NewLineToken;
            o_StringedData += "Tier manu.: " + m_TierManufacturer;
            return o_StringedData;
        }
    }

}
