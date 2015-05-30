using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagmentSystem.GarageLogic
{
    class Truck : Vehicle
    {

        private readonly float MAXTIERPRESSUR = 25;
        private readonly float FULLTANK = 170;
        private readonly int NUMBEROFTAIERS = 16;
        private readonly FuelType FUELTYPE = FuelType.Soler;

        private bool m_DangerousChemical;
        private float m_Wight;

        public Truck(string i_Model, string i_LicenseNumber, List<float> i_PressurInTiers, float i_RemainingEnergy, string i_TierManufacturer, bool i_DangerousChemical, float i_Wight)
            : base(i_Model, i_LicenseNumber, i_RemainingEnergy, i_TierManufacturer)
        {
            m_DangerousChemical = i_DangerousChemical;
            m_Wight = i_Wight;
            this.m_Tiers = new List<Tier>(NUMBEROFTAIERS);
            setTierData(i_PressurInTiers, MAXTIERPRESSUR, this.m_TierManufacturer);
            m_MyEnergy = new Fuel(FULLTANK, FULLTANK * m_RemainingEnergy, FUELTYPE);
        }

        public float LicenseType
        {
            get { return m_Wight; }
            set { m_Wight = value; }
        }

        public bool DangerousChemical
        {
            get { return m_DangerousChemical; }
            set { m_DangerousChemical = value; }
        }
    }
}
