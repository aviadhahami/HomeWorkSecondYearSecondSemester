using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagmentSystem.GarageLogic
{
    public class GarageInfo
    {
        private const string k_newLineToken = "\n";
        
        private StatusType m_StatusType;
        private OwnerInfo m_OwnerInfo;
        private Vehicle m_Vehicle;


        internal GarageInfo(StatusType o_StatusType, OwnerInfo o_OwnerInfo, Vehicle o_Vehicle)
        {
            m_OwnerInfo = o_OwnerInfo;
            m_Vehicle = o_Vehicle;
            m_StatusType = o_StatusType;
        }

        public StatusType StatusType
        {
            get { return m_StatusType; }
            set { StatusType = value; }
        }

        internal Vehicle Vehicle
        {
            get { return m_Vehicle; }
        }

        internal OwnerInfo OwnerInfo
        {
            get { return m_OwnerInfo; }
        }
        public override string ToString()
        {
            string o_OutputString = "";
            o_OutputString += "Owner name: " + m_OwnerInfo.OwnerName + k_newLineToken;
            o_OutputString += "Owner Phone: " + m_OwnerInfo.OwnerPhoneNumber + k_newLineToken;
            return o_OutputString;
        }
    }
}
