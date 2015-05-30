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

        public VehicleInfo(int i_NumberOfDors, Colors i_Color, List<float> i_PressurInTiers, VehicleType i_VehicleType, string i_Model, string i_LicenseNumber, float i_RemainingEnergy, string i_TierManufacturer)
        {
            m_NumberOfDors = i_NumberOfDors;
            m_Color = i_Color;
            m_Tiers = i_PressurInTiers;
            m_VihecleType = i_VehicleType;
            m_Model = i_Model;
            m_LicenseNumber = i_LicenseNumber;
            m_RemainingEnergy = i_RemainingEnergy;
            m_TierManufacturer = i_TierManufacturer;
        }

        public VehicleInfo(string i_Model, List<float> i_PressurInTiers, string i_LicenseNumber, float i_RemainingEnergy, string i_TierManufacturer, VehicleType i_VehicleType, int i_EngineSize, License i_LicenseType)
        {
            m_EngineSize = i_EngineSize;
            m_LicenseType = i_LicenseType;
            m_Tiers = i_PressurInTiers;
            m_VihecleType = i_VehicleType;
            m_Model = i_Model;
            m_LicenseNumber = i_LicenseNumber;
            m_RemainingEnergy = i_RemainingEnergy;
            m_TierManufacturer = i_TierManufacturer;
        }

        public VehicleInfo(string i_Model, string i_LicenseNumber, List<float> i_PressurInTiers, float i_RemainingEnergy, string i_TierManufacturer, bool i_DangerousChemical, float i_Wight, VehicleType i_VehicleType)
        {
            m_DangerousChemical = i_DangerousChemical;
            m_Wight = i_Wight;
            m_Tiers = i_PressurInTiers;
            m_VihecleType = i_VehicleType;
            m_Model = i_Model;
            m_LicenseNumber = i_LicenseNumber;
            m_RemainingEnergy = i_RemainingEnergy;
            m_TierManufacturer = i_TierManufacturer;
        }

        public StatusType StatusType
        {
            get { return m_StatusType; }
            set { m_StatusType = value; }
        }

        public VehicleType VihecleType
        {
            get { return m_VihecleType; }
        }

        public string Model
        {
            get { return m_Model; }
        }

        public string UserPhoneNumber
        {
            get { return m_UserPhoneNumber; }
        }

        public string UserName
        {
            get { return m_UserName; }
        }

        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
        }

        public string TierManufacturer
        {
            get { return m_TierManufacturer; }
        }

        public float RemainingEnergy
        {
            get { return m_RemainingEnergy; }
        }

        public float Wight
        {
            get { return m_Wight; }
        }


        public int NumberOfDors
        {
            get { return m_NumberOfDors; }
        }

        public Colors Color
        {
            get { return m_Color; }
        }

        public int EngineSize
        {
            get { return m_EngineSize; }
        }

        public License LicenseType
        {
            get { return m_LicenseType; }
        }

        public bool DangerousChemical
        {
            get { return m_DangerousChemical; }
        }

        public List<float> Tiers
        {
            get { return m_Tiers; }
        }

    }
}
