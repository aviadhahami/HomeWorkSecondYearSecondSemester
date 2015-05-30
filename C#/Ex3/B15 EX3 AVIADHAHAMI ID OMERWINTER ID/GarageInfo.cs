using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagmentSystem.GarageLogic
{
    public class GarageInfo
    {
        private VehicleInfo m_VehicleInfo;
        private OwnerInfo m_OwnerInfo;
        private Vehicle m_Vehicle;

        internal GarageInfo(VehicleInfo o_VehicleInfo, OwnerInfo o_OwnerInfo, Vehicle o_Vehicle)
        {
            m_OwnerInfo = o_OwnerInfo;
            m_Vehicle = o_Vehicle;
            m_VehicleInfo = o_VehicleInfo;
        }

        public VehicleInfo VehicleInfo
        {
            get { return m_VehicleInfo; }
        }

        internal Vehicle Vehicle
        {
            get { return m_Vehicle; }
        }

        internal OwnerInfo OwnerInfo
        {
            get { return m_OwnerInfo; }
        }
    }
}
