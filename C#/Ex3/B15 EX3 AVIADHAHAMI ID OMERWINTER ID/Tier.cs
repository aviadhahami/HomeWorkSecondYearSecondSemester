using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagmentSystem.GarageLogic
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

        public string manufacturer
        {
            get { return m_Manufacturer; }
            set { m_Manufacturer = value; }
        }

        public float currentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set { m_CurrentAirPressure = value; }
        }

        public float MaximalAirPressure
        {
            get { return m_MaximalAirPressure; }
            set { m_MaximalAirPressure = value; }
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
