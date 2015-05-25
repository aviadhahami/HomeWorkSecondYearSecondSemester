using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B15_EX3_AVIADHAHAMI_ID_OMERWINTER_ID
{
    abstract class ElectricVehicle
    {
        public abstract float getEnergyLeftInCharger();

        public abstract float getMaxEnergyInCharger();

        public abstract void charge(float i_powerToCharge);

    }
}
