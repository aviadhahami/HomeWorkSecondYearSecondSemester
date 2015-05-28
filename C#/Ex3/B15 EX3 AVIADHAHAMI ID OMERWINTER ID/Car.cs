using System;
using System.Collections.Generic;
using System.Text;

namespace B15_EX3_AVIADHAHAMI_ID_OMERWINTER_ID
{
    class Car : Vehicle
    {
        private readonly float MAXIMUMBUTTRYTIME = 2.2f;
        private readonly float MAXTIERPRESSUR = 31;
        private readonly float FULLTANK = 35;
        private readonly int NUMBEROFTAIERS = 4;
        private readonly FuelType FUELTYPE = FuelType.Octan96;

        Energy m_myEnergy;
        int m_numberOfDors;
        Colors m_color;
        public Car(int i_NumberOfDors, Colors i_Color, List<float> i_PressurInTiers, VihecleType i_ElectricVehicle, string i_Model, string i_LicenseNumber, float i_RemainingEnergy, string i_TierManufacturer)
            : base(i_Model, i_LicenseNumber, i_RemainingEnergy,i_TierManufacturer)
        {
            m_color = i_Color;
            m_numberOfDors = i_NumberOfDors;
            this.m_Tiers = new List<Tier>(NUMBEROFTAIERS);
            setTierData(i_PressurInTiers, MAXTIERPRESSUR, this.m_TierManufacturer);
            if (i_ElectricVehicle == VihecleType.ElectricCar)
            {
                m_myEnergy = new Electricity(MAXIMUMBUTTRYTIME, MAXIMUMBUTTRYTIME * m_RemainingEnergy);
            }
            else
            {
                m_myEnergy = new Fuel(FULLTANK, FULLTANK * m_RemainingEnergy, FUELTYPE);
            }
        }

        public Colors Color
        {
            get { return m_color; }
            set { m_color = value; }
        }
        public int NumberOfDors
        {
            get { return m_numberOfDors; }
            set { m_numberOfDors = value; }
        }
    }
}
