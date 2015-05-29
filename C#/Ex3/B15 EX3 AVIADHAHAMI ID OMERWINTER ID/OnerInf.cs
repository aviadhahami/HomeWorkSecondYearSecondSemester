using System;
using System.Collections.Generic;
using System.Text;

namespace B15_EX3_AVIADHAHAMI_ID_OMERWINTER_ID
{
    class OnerInf
    {
        Vehicle m_Vehicle;
        String m_OnerName;
        String m_OnerPhoneNumber;

        public OnerInf(Vehicle i_Vehicle, String i_OnerName, String i_OnerPhoneNumber)
        {
            m_OnerName = i_OnerName;
            m_OnerPhoneNumber = i_OnerPhoneNumber;
            m_Vehicle = i_Vehicle;
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
