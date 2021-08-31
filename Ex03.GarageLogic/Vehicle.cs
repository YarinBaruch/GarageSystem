namespace Ex03.GarageLogic
{
    using System.Collections.Generic;

    public abstract class Vehicle
    {
        protected readonly string r_ModelName;
        protected readonly string r_LicenseNumber;
        protected float m_RemainingEnergyPercentage;
        protected List<Wheel> m_Wheels;
        protected Engine m_EngineType;

        protected Vehicle(
            string i_ModelName,
            string i_LicenseNumber,
            Engine.eEngineType i_EngineType)
        {
            r_ModelName = i_ModelName;
            r_LicenseNumber = i_LicenseNumber;
            m_RemainingEnergyPercentage = 0;
        }

        public enum eVehicleType
        {
            Car,
            Motorcycle,
            Truck
        }

        public string ModelName => r_ModelName;

        public string LicenseNumber => r_LicenseNumber;

        public float RemainingEnergyPercentage
        {
            get => m_RemainingEnergyPercentage;
            set => m_RemainingEnergyPercentage = value;
        }

        public List<Wheel> Wheels
        {
            get => m_Wheels;
            set => m_Wheels = value;
        }

        public Engine EngineType
        {
            get => m_EngineType;
            set => m_EngineType = value;
        }

        public override string ToString()
        {
            return $@"
                License Number: {LicenseNumber}
                Model Name: {ModelName}
                Engine Type: {EngineType}
                Remaining Energy Percentage: {RemainingEnergyPercentage}

                Wheels: {Wheels[0]}";
        }
    }
}