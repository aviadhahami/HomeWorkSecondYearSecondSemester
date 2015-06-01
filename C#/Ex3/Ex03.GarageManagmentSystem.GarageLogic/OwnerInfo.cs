using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagmentSystem.GarageLogic
{
    public class OwnerInfo
    {
        String m_OwnerName;
        String m_OwnerPhoneNumber;

        public OwnerInfo(String i_OnerName, String i_OnerPhoneNumber)
        {
            m_OwnerName = i_OnerName;
            m_OwnerPhoneNumber = i_OnerPhoneNumber;
        }

        public String OnerName
        {
            get { return m_OwnerName; }
        }
        public String OnerPhoneNumber
        {
            get { return m_OwnerPhoneNumber; }
        }
    }
}
