using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagmentSystem.GarageLogic
{

    class Motorcycle : Vehicle
    {
        private readonly float ro_MAX_TIER_PRESSURE_ELECTRIC = 31;
        private readonly float ro_MAX_TIER_PRESSURE_FUEL = 34;
        private readonly float ro_MAXIMUM_BATTERY_TIME = 1.2f;
        private readonly int NUMBEROFTAIERS = 2;
        private readonly float ro_MAX_FUEL_LEVEL = 8;
        private readonly FuelType ro_FUELTYPE = FuelType.Octan98;


        private EngineType m_EngineType;
        private int m_EngineSize;
        private License m_LicenseType;

        public Motorcycle()
            : base()
        {
        }

        public void init()
        {
            if (m_EngineType == EngineType.ElectricEngine)
            {
                SetTierData(m_CurrentPressurInTier, ro_MAX_TIER_PRESSURE_ELECTRIC, m_TierManufacturer);
                InitElectricityEngine(ro_MAXIMUM_BATTERY_TIME);
            }
            else
            {
                SetTierData(m_CurrentPressurInTier, ro_MAX_TIER_PRESSURE_FUEL, m_TierManufacturer);
                InitFuelEngine(ro_MAX_FUEL_LEVEL, ro_FUELTYPE);
            }
        }

        internal EngineType EngineType
        {
            get { return m_EngineType; }
            set { m_EngineType = value; }
        }

        public License LicenseType
        {
            get { return m_LicenseType; }
            set { m_LicenseType = value; }
        }

        public int EngineSize
        {
            get { return m_EngineSize; }
            set { m_EngineSize = value; }
        }
        
        internal bool ValidateAndSetProperty(string i_Answer, int i_QuestionIndex)
        {
            return false;
        }
    }
}
