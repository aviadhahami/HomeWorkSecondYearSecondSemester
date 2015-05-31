using System;
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



        protected void setTierData(float i_PressurInTiers, float i_MaxTierPressur, string i_tierManufacturer)
        {
            int currentAirPressurPerTier = 0;
            foreach (Tier tier in m_Tiers)
            {
                tier.manufacturer = this.m_TierManufacturer;
                tier.MaximalAirPressure = i_MaxTierPressur;
                tier.currentAirPressure = i_PressurInTiers;
                currentAirPressurPerTier++;
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
    }

}
