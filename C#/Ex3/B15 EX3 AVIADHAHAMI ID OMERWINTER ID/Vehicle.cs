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
        protected List<Tier> m_Tiers;
        protected string m_TierManufacturer;
        protected Energy m_MyEnergy;
        protected List<string> m_ListOfQuestions;

        protected Vehicle(string i_Model, string i_LicenseNumber, string i_TierManufacturer)
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



        protected void setTierData(List<float> i_PressurInTiers, float i_MaxTierPressur, string i_tierManufacturer)
        {
            int currentAirPressurPerTier = 0;
            foreach (Tier tier in m_Tiers)
            {
                tier.manufacturer = this.m_TierManufacturer;
                tier.MaximalAirPressure = i_MaxTierPressur;
                tier.currentAirPressure = i_PressurInTiers[currentAirPressurPerTier];
                currentAirPressurPerTier++;
            }
        }

        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
        }

        public Energy MyEnergy
        {
            get { return m_MyEnergy; }
        }

        public List<Tier> MyTiers
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
    }

}
