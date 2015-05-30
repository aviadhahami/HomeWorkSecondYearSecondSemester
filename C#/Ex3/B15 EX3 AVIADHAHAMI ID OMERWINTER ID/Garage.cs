using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagmentSystem.GarageLogic
{
    public class Garage
    {
        internal static void UpdateStatus(string p, StatusType statusType)
        {
            throw new NotImplementedException();
        }

        internal static bool Exist(string p)
        {
            return false;
            //throw new NotImplementedException();
        }

        internal static void Insert(string p, string p_2, StatusType statusType, Vehicle i_Vehicle)
        {
            throw new NotImplementedException();
        }

        public bool CheckIfVehicleExists(string io_licnsePlate)
        {
            return Exist(io_licnsePlate);
        }

        public object GetVehicle(string io_licnsePlate)
        {
            //TODO 
            throw new NotImplementedException();
        }
    }
}
