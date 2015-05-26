using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B15_EX3_AVIADHAHAMI_ID_OMERWINTER_ID
{
    class Fuel : Energy
    {
        private FuelType m_fuelType;

        public Fuel(float i_maxFuelInTank, float i_currenFuelInTank, FuelType i_fuelType)
            : base(i_maxFuelInTank, i_currenFuelInTank)
        {
            m_fuelType = i_fuelType;
        }
        
        public FuelType fuelType
        {
            set { m_fuelType = value; }
        }
        public void fillFuel(float value, FuelType i_fuelType)
        {
            if (m_fuelType == i_fuelType)
            {
                fillEnergy(value);
            }
            else
            {
                // TODO: throw exepsion in the futher
                Console.WriteLine("the fuel type is incorect or to much gas");
            }
        }
    
    }

}
