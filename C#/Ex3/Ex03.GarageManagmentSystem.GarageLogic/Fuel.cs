using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagmentSystem.GarageLogic
{
    class Fuel : Energy
    {

        private const string K_WRONG_FUEL_TYPE = "the fuel type is incorect";

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
                throw new ArgumentException(K_WRONG_FUEL_TYPE);
            }
        }
    
    }

}
