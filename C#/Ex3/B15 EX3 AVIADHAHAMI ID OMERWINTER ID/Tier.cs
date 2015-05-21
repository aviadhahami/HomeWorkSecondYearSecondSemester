using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B15_EX3_AVIADHAHAMI_ID_OMERWINTER_ID
{
    class Tier
    {
        string m_Manufacturer;
        float m_CurrentAirPressure;
        float m_MaximalAirPressure;
        public void Wheel(string i_Manufacturer, float i_CurrentAirPressure, float i_MaximalAirPressure)
        {
            m_CurrentAirPressure = i_CurrentAirPressure;
            m_Manufacturer = i_Manufacturer;
            m_MaximalAirPressure = i_MaximalAirPressure;
        }

        public float PumpAir
        {
            set
            {
                if (value > 0 && value + m_CurrentAirPressure <= m_MaximalAirPressure)
                {
                    m_CurrentAirPressure += value;
                }
                else
                {
                    // Should delete this else when done
                    Console.WriteLine("Didnt add air, exceeded max volume");
                }
            }
        }
    }
}
