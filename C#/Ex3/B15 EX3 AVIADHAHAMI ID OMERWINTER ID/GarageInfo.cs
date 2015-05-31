using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagmentSystem.GarageLogic
{
    public class GarageInfo
    {
        private StatusType m_StatusType;
        private OwnerInfo m_OwnerInfo;
        private Vehicle m_Vehicle;

        internal GarageInfo(StatusType o_StatusType, OwnerInfo o_OwnerInfo, Vehicle o_Vehicle)
        {
            m_OwnerInfo = o_OwnerInfo;
            m_Vehicle = o_Vehicle;
            m_StatusType = o_StatusType;
        }

        public StatusType VehicleInfo
        {
            get { return m_StatusType; }
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
