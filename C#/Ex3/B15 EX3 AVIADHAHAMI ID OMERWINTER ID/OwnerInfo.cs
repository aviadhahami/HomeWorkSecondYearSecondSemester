using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagmentSystem.GarageLogic
{
    class OwnerInfo
    {
        String m_OnerName;
        String m_OnerPhoneNumber;

        public OwnerInfo(String i_OnerName, String i_OnerPhoneNumber)
        {
            m_OnerName = i_OnerName;
            m_OnerPhoneNumber = i_OnerPhoneNumber;
        }
        
        public String OnerName 
        {
            get { return m_OnerName; }
        }
        public String OnerPhoneNumber 
        { 
            get { return m_OnerPhoneNumber; }
        }
    }
}
