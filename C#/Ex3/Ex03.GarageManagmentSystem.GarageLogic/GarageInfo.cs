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


        public GarageInfo(StatusType o_StatusType, OwnerInfo o_OwnerInfo, Vehicle o_Vehicle)
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

            // Add owner
            o_OutputString += m_OwnerInfo.ToString();
            o_OutputString += k_newLineToken;
            o_OutputString += "Status type: " + StatusType.ToString();
            o_OutputString += k_newLineToken;
            o_OutputString += m_Vehicle.ToString();
            return o_OutputString;
        }
    }
}
