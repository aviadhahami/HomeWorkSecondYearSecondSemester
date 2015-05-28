using System;
using System.Collections.Generic;
using System.Text;

namespace B15_EX3_AVIADHAHAMI_ID_OMERWINTER_ID
{
    class Motorcycle : Vehicle
    {
        private readonly float MAXTIERPRESSUROFELECTRIC = 31;
        private readonly float MAXTIERPRESSUROFFUEL = 34;
        private readonly float MAXTBUTERI = 1.2f;
        private readonly int NUMBEROFTAIERS = 2;
        private readonly float MAXTANK = 8;
        private readonly FuelType FUELTYPE = FuelType.Octan98;

        Energy m_myEnergy;
        int m_EngineSize;
        License m_LicenseType;


        public Motorcycle(string i_Model, List<float> i_PressurInTiers, string i_LicenseNumber, float i_RemainingEnergy, string i_TierManufacturer, bool i_ElectricVehicle, int i_EngineSize, License i_LicenseType)
            : base(i_Model, i_LicenseNumber, i_RemainingEnergy, i_TierManufacturer, i_ElectricVehicle)
        {

            m_EngineSize = i_EngineSize;
            m_LicenseType = i_LicenseType;
            this.m_tiers = new List<Tier>(NUMBEROFTAIERS);
            if (i_ElectricVehicle)
            {
                setTierData(i_PressurInTiers, MAXTIERPRESSUROFELECTRIC, this.m_tierManufacturer);
                m_myEnergy = new Electricity(MAXTBUTERI, MAXTBUTERI * m_RemainingEnergy);
            }
            else
            {
                setTierData(i_PressurInTiers, MAXTIERPRESSUROFFUEL, this.m_tierManufacturer);
                m_myEnergy = new Fuel(MAXTANK, MAXTANK * m_RemainingEnergy, FUELTYPE);
            }
        }

        public License LicenseType
        {
            get { return m_LicenseType; }
            set { m_LicenseType = value; }
        }

        public int LicenseType
        {
            get { return m_EngineSize; }
            set { m_EngineSize = value; }
        }
    }
}
