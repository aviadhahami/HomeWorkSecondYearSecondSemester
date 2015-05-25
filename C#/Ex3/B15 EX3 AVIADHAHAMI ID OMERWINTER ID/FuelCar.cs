using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B15_EX3_AVIADHAHAMI_ID_OMERWINTER_ID
{
    class FuelCar : Car, fuelVehicle
    {

        private readonly float FULLTANK = 35;
        private readonly float MAXTIERPRESSUR = 31;
        private readonly fuelType FUELTYPE = fuelType.Octan96;


        public override void PumpAir()
        {
            foreach (Tier tier in this.m_tiers)
            {
                if (tier.currentAirPressure <= MAXTIERPRESSUR)
                {
                    tier.PumpAir = MAXTIERPRESSUR - tier.currentAirPressure;
                }
                else
                {
                    Console.WriteLine("the pressur is to heigh");
                }
            }
        }
        public override fuelType getFuelType()
        {
            return FUELTYPE;
        }

        public override float getMaxFuelInTank()
        {
            return FULLTANK;
        }

        public override void fuel(fuelType i_fuelType, float i_litersToFuel)
        {
            if (i_fuelType != FUELTYPE || getCurrentFuelInTank() + i_litersToFuel > FULLTANK)
            {
                Console.WriteLine("Didnt add fuel, exceeded max volume or try to fuel with the wrong type of fuel");
            }
            else
            {
                this.getRemainingEnergy = (getCurrentFuelInTank() + i_litersToFuel) / FULLTANK;
            }
        }

        public override float getCurrentFuelInTank()
        {
            return FULLTANK * this.getRemainingEnergy;
        }
    }
}
