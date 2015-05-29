﻿using System;
using System.Collections.Generic;
using System.Text;

namespace B15_EX3_AVIADHAHAMI_ID_OMERWINTER_ID
{
    class Vehicle
    {
        protected string m_Model;
        protected string m_LicenseNumber;
        protected float m_RemainingEnergy;
        protected List<Tier> m_Tiers;
        protected string m_TierManufacturer;
        protected bool m_ElectricVehicle;

        protected Vehicle(string i_Model, string i_LicenseNumber, float i_RemainingEnergy, string i_TierManufacturer)
        {
            m_Model = i_Model;
            m_LicenseNumber = i_LicenseNumber;
            m_RemainingEnergy = i_RemainingEnergy;
            m_TierManufacturer = i_TierManufacturer;
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

        public void PumpAir(List<Tier> i_tiersToPump)
        {
            foreach (Tier tier in i_tiersToPump)
            {
                tier.PumpAir = tier.MaximalAirPressure - tier.currentAirPressure;
            }
        }
    }

}
