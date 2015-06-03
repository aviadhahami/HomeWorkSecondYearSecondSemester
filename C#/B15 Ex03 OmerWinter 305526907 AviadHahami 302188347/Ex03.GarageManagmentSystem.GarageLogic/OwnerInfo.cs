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

        public String OwnerName
        {
            get { return m_OwnerName; }
        }
        public String OwnerPhoneNumber
        {
            get { return m_OwnerPhoneNumber; }
        }
        public override string ToString()
        {
            return "Owner name: " + m_OwnerName + "\n" + "Phone number: " + m_OwnerPhoneNumber;
        }
    }
}
