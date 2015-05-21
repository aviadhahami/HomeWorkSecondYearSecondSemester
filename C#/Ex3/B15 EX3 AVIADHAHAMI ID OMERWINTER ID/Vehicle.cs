using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;

namespace B15_EX3_AVIADHAHAMI_ID_OMERWINTER_ID
{
    class Vehicle
    {
        string m_Model;
        string m_LicenseNumber;
        float m_RemainingEnergy;
        List<Tier> m_Wheels;

        public void Vehicle(string i_Model, string i_LicenseNumber, float i_RemainingEnergy, List<Tier> i_Wheels)
        {
            m_Model = i_Model;
            m_LicenseNumber = i_LicenseNumber;
            m_RemainingEnergy = i_RemainingEnergy;
            m_Wheels = i_Wheels;
        }

    }

}
