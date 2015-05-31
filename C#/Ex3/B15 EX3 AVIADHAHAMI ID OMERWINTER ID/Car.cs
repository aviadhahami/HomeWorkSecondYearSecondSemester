using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagmentSystem.GarageLogic
{
    class Car : Vehicle
    {

        List<Tier> m_Wheels;
        EngineType m_Engine;
        Colors m_Color;
        int m_NumberOfDoors;
        float m_RemainingEnergy;

        public Car(string i_Model, string i_LicenseNumber, string i_TierManufacturer)
            : base(i_Model, i_LicenseNumber, i_TierManufacturer)
        {

        }
        public List<Tier> Tiers
        {
            get { return m_Wheels; }
            set { m_Wheels = value; }
        }
        public EngineType Engine
        {
            get { return m_Engine; }
            set { m_Engine = value; }
        }
        public Colors Colors
        {
            get { return m_Color; }
            set { m_Color = value; }
        }

    }
}
//    private readonly float MAXIMUMBUTTRYTIME = 2.2f;
//    private readonly float MAXTIERPRESSUR = 31;
//    private readonly float FULLTANK = 35;
//    private readonly int NUMBEROFTAIERS = 4;
//    private readonly FuelType FUELTYPE;// = FuelType.Octan96;

//    int m_numberOfDors;
//    Colors m_color;


//    public Car(int i_NumberOfDors, Colors i_Color, List<float> i_PressurInTiers, EngineType i_ElectricVehicle, string i_Model, string i_LicenseNumber, float i_RemainingEnergy, string i_TierManufacturer)
//        : base(i_Model, i_LicenseNumber, i_TierManufacturer)
//    {
//        m_color = i_Color;
//        m_numberOfDors = i_NumberOfDors;
//        this.m_Tiers = new List<Tier>(NUMBEROFTAIERS);
//        setTierData(i_PressurInTiers, MAXTIERPRESSUR, this.m_TierManufacturer);
//        if (i_ElectricVehicle == EngineType.ElectricEngine)
//        {
//            m_MyEnergy = new Electricity(MAXIMUMBUTTRYTIME, MAXIMUMBUTTRYTIME * m_RemainingEnergy);
//        }
//        else
//        {
//            m_MyEnergy = new Fuel(FULLTANK, FULLTANK * m_RemainingEnergy, FUELTYPE);
//        }
//    }

//    public float MaxButteryType
//    {
//        get { return MAXIMUMBUTTRYTIME; }
//    }

//    public float MaxTierPressur
//    {
//        get { return MAXTIERPRESSUR; }
//    }

//    public float MaxFuelInTank
//    {
//        get { return FULLTANK; }
//    }

//    public float RemainingEnergy
//    {
//        get { return FULLTANK * m_RemainingEnergy; }
//    }

//    public Colors Color
//    {
//        get { return m_color; }
//        set { m_color = value; }
//    }
//    public int NumberOfDors
//    {
//        get { return m_numberOfDors; }
//        set { m_numberOfDors = value; }
//    }
//}
//}
