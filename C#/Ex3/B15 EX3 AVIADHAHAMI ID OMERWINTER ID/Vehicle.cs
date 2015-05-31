﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagmentSystem.GarageLogic
{
    class Vehicle
    {
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
            //getQuestions();
            //m_Model = i_Model;
            //m_LicenseNumber = i_LicenseNumber;
            //m_TierManufacturer = i_TierManufacturer;

            m_ListOfQuestions = new List<string>();

            // Should set questions
            m_ListOfQuestions.Add("Please insert model");
            m_ListOfQuestions.Add("Please insert license plate number");
            m_ListOfQuestions.Add("Please insert tier manufacturer");

        }

        protected void SetTierData(float i_PressurInTiers, float i_MaxTierPressur, string i_tierManufacturer)
        {
            foreach (Tier tier in m_Tiers)
            {
                tier.manufacturer = this.m_TierManufacturer;
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
        protected bool verifyTiers(string i_GivenPressure, float i_MaxTierPressure)
        {
            float parsedFloat;
            bool parsingFlag = float.TryParse(i_GivenPressure, out parsedFloat);
            if (parsingFlag == false)
            {
                throw new FormatException("Bad input for doors amount");
            }
            if (parsedFloat >= 0 && parsedFloat <= i_MaxTierPressure)
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
    }

}
