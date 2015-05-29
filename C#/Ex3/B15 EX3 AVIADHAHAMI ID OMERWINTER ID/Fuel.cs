using System;
using System.Collections.Generic;
using System.Text;

namespace B15_EX3_AVIADHAHAMI_302188347_OMERWINTER_305526907
{
    class Fuel : Energy
    {
        private FuelType m_fuelType;


        public Fuel(float i_MaxFuelInTank, float i_CurrenFuelInTank, FuelType i_fuelType)
            : base(i_MaxFuelInTank, i_CurrenFuelInTank)
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
