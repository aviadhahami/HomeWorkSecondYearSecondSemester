using System;
using System.Collections.Generic;
using System.Text;

namespace B15_EX3_AVIADHAHAMI_ID_OMERWINTER_ID
{
    abstract class Vehicle
    {
        protected string m_Model;
        protected string m_LicenseNumber;
        protected float m_RemainingEnergy;
        protected List<Tier> m_tiers;
        protected string m_tierManufacturer;
        protected bool m_electricCar;

        public Vehicle(string i_Model, string i_LicenseNumber, float i_RemainingEnergy, string i_tierManufacturer, bool i_electricCar)
        {
            m_Model = i_Model;
            m_LicenseNumber = i_LicenseNumber;
            m_RemainingEnergy = i_RemainingEnergy;
            m_tierManufacturer = i_tierManufacturer;
            m_electricCar = i_electricCar;
        }

        public override sealed bool Equals(object obj)
        {
            bool equals = false;
            
            Vehicle toCompareTo = obj as Vehicle;
            if (toCompareTo != null)
            {
                equals = this.m_LicenseNumber == toCompareTo.m_LicenseNumber;
            }
            return equals;
        }

        protected void setTierData(List<float> i_PressurInTiers, float i_MaxTierPressur, string i_tierManufacturer)
        {
            int currentAirPressurPerTier = 0;
            foreach (Tier tier in m_tiers)
            {
                tier.manufacturer = this.m_tierManufacturer;
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
