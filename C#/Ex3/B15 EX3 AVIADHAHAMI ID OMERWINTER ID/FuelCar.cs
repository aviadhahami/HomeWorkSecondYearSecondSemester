using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B15_EX3_AVIADHAHAMI_ID_OMERWINTER_ID
{
    class FuelCar : Car, fuelVehicle
    {

        private readonly float m_fullTank = 35;
        private readonly float m_tierPressur = 31;
        private readonly fuelType m_fuelType = fuelType.Octan96;
        private readonly int m_numberOfTier = 4;

        public override fuelType getFuelType()
        {
            return m_fuelType;
        }

        public override float getMaxFuelInTank()
        {
            return m_fullTank;
        }

        public override void fuel(fuelType i_fuelType, int i_litersOfFuel)
        {

        }

        public override float getCurrentFuelInTank()
        {
            return m_fullTank * this.getRemainingEnergy;
        }
    }
}
