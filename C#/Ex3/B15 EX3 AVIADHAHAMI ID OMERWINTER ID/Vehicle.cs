using System;
using System.Collections.Generic;
using System.Text;

namespace B15_EX3_AVIADHAHAMI_ID_OMERWINTER_ID
{
    class Vehicle
    {
        protected string m_Model;
        protected string m_LicenseNumber;
        protected float m_RemainingEnergy;
        protected List<Tier> m_tiers;

        public void Vehicle(string i_Model, string i_LicenseNumber, float i_RemainingEnergy, List<Tier> i_tiers)
        {
            m_Model = i_Model;
            m_LicenseNumber = i_LicenseNumber;
            m_RemainingEnergy = i_RemainingEnergy;
            m_tiers = i_tiers;
        }

        public float getRemainingEnergy
        {
            get { return m_RemainingEnergy; }
            set { m_RemainingEnergy = value; }
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

    }

}
