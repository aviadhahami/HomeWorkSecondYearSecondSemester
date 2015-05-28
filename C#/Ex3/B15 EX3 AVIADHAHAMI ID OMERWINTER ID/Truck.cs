using System;
using System.Collections.Generic;
using System.Text;

namespace B15_EX3_AVIADHAHAMI_ID_OMERWINTER_ID
{
    class Truck : Vehicle
    {

        private readonly float MAXTIERPRESSUR = 25;
        private readonly float FULLTANK = 170;
        private readonly int NUMBEROFTAIERS = 16;
        private readonly FuelType FUELTYPE = FuelType.Soler;

        private bool m_DangerousChemical;
        private float m_Wight;
        Energy m_myEnergy;

        public Truck(string i_Model, string i_LicenseNumber, List<float> i_PressurInTiers, float i_RemainingEnergy, string i_tierManufacturer, bool i_electricCar)
            : base(i_Model, i_LicenseNumber, i_RemainingEnergy, i_tierManufacturer, i_electricCar)
        {
            this.m_tiers = new List<Tier>(NUMBEROFTAIERS);
            setTierData(i_PressurInTiers, MAXTIERPRESSUR, this.m_tierManufacturer);
            m_myEnergy = new Fuel(FULLTANK, FULLTANK * m_RemainingEnergy, FUELTYPE);
        }

        public float LicenseType
        {
            get { return m_Wight; }
            set { m_Wight = value; }
        }

        public bool LicenseType
        {
            get { return m_DangerousChemical; }
            set { m_DangerousChemical = value; }
        }
    }
}
