using System;
using System.Collections.Generic;
using System.Text;

namespace B15_EX3_AVIADHAHAMI_302188347_OMERWINTER_305526907
{
    class OwnerInfo
    {
        Vehicle m_Vehicle;
        String m_OnerName;
        String m_OnerPhoneNumber;
        StatusType m_StatusType;

        public OwnerInfo(Vehicle i_Vehicle, String i_OnerName, String i_OnerPhoneNumber, StatusType i_StatusType)
        {
            m_OnerName = i_OnerName;
            m_OnerPhoneNumber = i_OnerPhoneNumber;
            m_Vehicle = i_Vehicle;
            m_StatusType = i_StatusType;
        }

        public StatusType StatusType
        {
            get { return m_StatusType; }
            set { m_StatusType = value; }
        }

        public Vehicle Vehicle
        {
            get { return m_Vehicle; }
            set { m_Vehicle = value; } 
        }
        public String OnerName 
        {
            get { return m_OnerName; }
            set { m_OnerName = value; } 
        }
        public String OnerPhoneNumber 
        { 
            get { return m_OnerPhoneNumber; }
            set { m_OnerPhoneNumber = value; }  
            
        }
    }
}
