using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagmentSystem.GarageLogic
{
    public class VehicleInfo
    {
        private VehicleType m_VehicleType;
        private StatusType m_StatusType;
        private Vehicle m_Vehicle;
        private string m_Model;
        private string m_LicenseNumber;
        private float m_RemainingEnergy;
        private string m_TierManufacturer;
        private int m_NumberOfDoors;
        private Colors m_Color;
        private int m_EngineSize;
        private License m_LicenseType;
        private bool m_DangerousChemical;
        private float m_Weight;
        private List<float> m_Tiers;
        private string m_OwnerPhoneNumber;
        private string m_OwnerName;

        internal StatusType StatusType
        {
            get { return m_StatusType; }
            set { m_StatusType = value; }
        }

        public VehicleType VihecleType
        {
            get { return m_VehicleType; }
            set { m_VehicleType = value; }
        }

        public string Model
        {
            get { return m_Model; }
            set { m_Model = value; }
        }

        public string UserPhoneNumber
        {
            get { return m_OwnerPhoneNumber; }
            set { m_OwnerPhoneNumber = value; }
        }

        public string UserName
        {
            get { return m_OwnerName; }
            set { m_OwnerName = value; }
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
            get { return m_Weight; }
            set { m_Weight = value; }
        }


        public int NumberOfDors
        {
            get { return m_NumberOfDoors; }
            set { m_NumberOfDoors = value; }
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

        public string GetOwnerName()
        {
            return m_OwnerName;
        }

        public string GetOwnerPhone()
        {
            return m_OwnerPhoneNumber;
        }
        internal Vehicle Vehicle
        {
            get { return m_Vehicle; }
            set { m_Vehicle = value; }
        }
    }
}
