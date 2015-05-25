using System;
using System.Collections.Generic;
using System.Text;

namespace B15_EX3_AVIADHAHAMI_ID_OMERWINTER_ID
{
    class Vehicle
    {
        string m_Model;
        string m_LicenseNumber;
        float m_RemainingEnergy;
        int m_tierPressur;

        public void Vehicle(string i_Model, string i_LicenseNumber, float i_RemainingEnergy)
        {
            m_Model = i_Model;
            m_LicenseNumber = i_LicenseNumber;
            m_RemainingEnergy = i_RemainingEnergy;
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
