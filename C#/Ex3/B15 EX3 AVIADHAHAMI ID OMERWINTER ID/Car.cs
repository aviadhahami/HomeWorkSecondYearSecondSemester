using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B15_EX3_AVIADHAHAMI_ID_OMERWINTER_ID
{
    class Car : Vehicle
    {
        private readonly float MAXIMUMBUTTRYTIME = 2.2f;
        private readonly float MAXTIERPRESSUR = 31;
        private readonly float FULLTANK = 35;
        private readonly FuelType FUELTYPE = FuelType.Octan96;

        int m_numberOfDors;
        Colors m_color;
        public Car(int i_numberOfDors, Colors i_color, List<float> i_PressurInTiers, bool i_electricCar, string i_Model, string i_LicenseNumber, float i_RemainingEnergy, List<Tier> i_tiers, string i_tierManufacturer)
            : base(i_Model, i_LicenseNumber, i_RemainingEnergy, i_tiers, i_tierManufacturer, i_electricCar)
        {
            m_color = i_color;
            m_numberOfDors = i_numberOfDors;
            this.m_tiers = new List<Tier>(4);
            m_electricCar = i_electricCar;
            setTierData(i_PressurInTiers, MAXTIERPRESSUR, this.m_tierManufacturer);
        }

        public Colors getColor
        {
            get { return m_color; }
            set { m_color = value; }
        }
        public int getNumberOfDors
        {
            get { return m_numberOfDors; }
            set { m_numberOfDors = value; }
        }
    }
    enum Colors
    {
        GREEN,
        RED,
        BLACK,
        WIGHT
    };
}
