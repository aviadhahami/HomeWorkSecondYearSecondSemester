using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B15_EX3_AVIADHAHAMI_ID_OMERWINTER_ID
{
    class Truck : Vehicle
    {
        public Truck(string i_Model, string i_LicenseNumber, float i_RemainingEnergy, List<Tier> i_tiers, string i_tierManufacturer, bool i_electricCar)
            : base(i_Model, i_LicenseNumber, i_RemainingEnergy, i_tiers, i_tierManufacturer, i_electricCar)
        {

        }
    }
}
