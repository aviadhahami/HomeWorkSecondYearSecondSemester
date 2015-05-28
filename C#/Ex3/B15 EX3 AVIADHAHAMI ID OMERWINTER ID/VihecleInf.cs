using System;
using System.Collections.Generic;
using System.Text;

namespace B15_EX3_AVIADHAHAMI_ID_OMERWINTER_ID
{
    public class VihecleInf
    {
        private VihecleType m_VihecleType;
        private string m_Model;
        private string m_LicenseNumber;
        private float m_RemainingEnergy;
        private string m_TierManufacturer;
        private int m_NumberOfDors;
        private Colors m_Color;
        private int m_EngineSize;
        private License m_LicenseType;
        private bool m_DangerousChemical;
        private float m_Wight;
        private List<float> m_Tiers;
        private string m_UserPhoneNumber;
        private string m_UserName;

        public VihecleType VihecleType
        {
            get { return m_VihecleType; }
            set { m_VihecleType = value; }
        }

        public string Model
        {
            get { return m_Model; }
            set { m_Model = value; }
        }

        public string UserPhoneNumber
        {
            get { return m_UserPhoneNumber; }
            set { m_UserPhoneNumber = value; }
        }

        public string UserName
        {
            get { return m_UserName; }
            set { m_UserName = value; }
        }

        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
            set { m_LicenseNumber = value; }
        }

        public string TierManufacturer
        {
            get { return m_TierManufacturer; }
            set { m_TierManufacturer = value; }
        }

        public float RemainingEnergy
        {
            get { return m_RemainingEnergy; }
            set { m_RemainingEnergy = value; }
        }

        public float Wight
        {
            get { return m_Wight; }
            set { m_Wight = value; }
        }

       
        public int NumberOfDors
        {
            get { return m_NumberOfDors; }
            set { m_NumberOfDors = value; }
        }

        public Colors Color
        {
            get { return m_Color; }
            set { m_Color = value; }
        }

        public int EngineSize
        {
            get { return m_EngineSize; }
            set { m_EngineSize = value; }
        }

        public License LicenseType
        {
            get { return m_LicenseType; }
            set { m_LicenseType = value; }
        }

        public bool DangerousChemical
        {
            get { return m_DangerousChemical; }
            set { m_DangerousChemical = value; }
        }

        public List<float> Tiers
        {
            get { return m_Tiers; }
            set { m_Tiers = value; }
        }
    }
}
