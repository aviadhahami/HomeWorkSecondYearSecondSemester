using System;
using System.Collections.Generic;
using System.Text;

namespace B15_EX3_AVIADHAHAMI_302188347_OMERWINTER_305526907
{
    class Electricity : Energy
    {
        public Electricity(float i_maxFuelInTank, float i_currenFuelInTank)
            : base(i_maxFuelInTank, i_currenFuelInTank) { }
        
        public void fillElectricity(float value)
        {
            fillEnergy(value);
        }
    }
}
