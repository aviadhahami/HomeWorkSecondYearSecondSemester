using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B15_EX3_AVIADHAHAMI_ID_OMERWINTER_ID
{
    abstract class fuelVehicle
    {

        public abstract fuelType getFuelType();

        public abstract float getCurrentFuelInTank(); 

        public abstract float getMaxFuelInTank();

        public abstract void fuel(fuelType i_fuelType, int i_litersOfFuel);


    }
}
