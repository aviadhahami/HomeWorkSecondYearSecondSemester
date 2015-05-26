using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B15_EX3_AVIADHAHAMI_ID_OMERWINTER_ID
{
    abstract class Energy
    {
        protected float m_maxCapcityInTank;
        protected float m_currenCapacityInTank;

        public Energy(float i_maxFuelInTank, float i_currenFuelInTank)
        {
            m_currenCapacityInTank = i_currenFuelInTank;
            m_maxCapcityInTank = i_maxFuelInTank;
        }

        protected float getCurrenCapacityInTank()
        {
            return m_currenCapacityInTank;
        }
        protected float getMaxCapcityInTank() 
        {
            return m_maxCapcityInTank;
        }

        public float getRemainingEnergy
        {
            get { return 1 - (m_currenCapacityInTank / m_maxCapcityInTank); }
        }

        protected void fillEnergy(float value)
        {
            {
                if (this.getCurrenCapacityInTank() + value <= this.getMaxCapcityInTank())
                {
                    this.m_currenCapacityInTank = this.getCurrenCapacityInTank() + value;
                }
                else
                {
                    // TODO: throw exepsion in the future
                    Console.WriteLine("the fuel type is incorect or to much gas");
                }
            }
        }
    }
}
