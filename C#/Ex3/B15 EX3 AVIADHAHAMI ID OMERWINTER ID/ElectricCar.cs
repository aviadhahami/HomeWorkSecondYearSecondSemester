using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B15_EX3_AVIADHAHAMI_ID_OMERWINTER_ID
{
    class ElectricCar : Car, ElectricVehicle
    {
        private readonly float MAXIMUMBUTTRYTIME = 2.2f;
        private readonly float MAXTIERPRESSUR = 31;


        public override float getEnergyLeftInCharger()
        {
            return MAXIMUMBUTTRYTIME * this.m_RemainingEnergy;
        }

        public override float getMaxEnergyInCharger()
        {
            return MAXIMUMBUTTRYTIME;
        }

        public override void charge(float i_timeToCharge)
        {
            if (getEnergyLeftInCharger() + i_timeToCharge > MAXIMUMBUTTRYTIME)
            {
                Console.WriteLine("Didnt add fuel, exceeded max volume or try to fuel with the wrong type of fuel");
            }
            else
            {
                this.getRemainingEnergy = (getEnergyLeftInCharger() + i_timeToCharge) / MAXIMUMBUTTRYTIME;
            }
        }

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
    }
}
