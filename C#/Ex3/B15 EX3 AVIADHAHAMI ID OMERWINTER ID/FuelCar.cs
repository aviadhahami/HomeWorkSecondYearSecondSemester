using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B15_EX3_AVIADHAHAMI_ID_OMERWINTER_ID
{
    class FuelCar : Car
    {

        private readonly int m_fullTank = 35;
        private readonly int m_tierPressur = 31;
        private readonly fuelType m_fullType = fuelType.Octan96;
        private readonly int m_numberOfTier = 4;

        private int m_currentFuelInTank;
    }
}
