using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagmentSystem.GarageLogic
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
