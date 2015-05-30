using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagmentSystem.GarageLogic
{
    class GarageInfo
    {
        private VehicleInfo m_VehicleInfo;
        private OwnerInfo m_OwnerInfo;
        private Vehicle m_Vehicle;

        public GarageInfo(VehicleInfo o_VehicleInfo, OwnerInfo o_OwnerInfo, Vehicle o_Vehicle)
        {
            m_OwnerInfo = o_OwnerInfo;
            m_Vehicle = o_Vehicle;
            m_VehicleInfo = o_VehicleInfo;
        }

        public VehicleInfo VihecleInfo
        {
            get { return m_VehicleInfo; }
        }

        public Vehicle Vihecle
        {
            get { return m_Vehicle; }
        }

        public OwnerInfo OwnerInfo
        {
            get { return m_OwnerInfo; }
        }
    }
}
