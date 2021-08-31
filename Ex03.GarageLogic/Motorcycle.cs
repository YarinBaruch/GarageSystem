namespace Ex03.GarageLogic
{
    using System.Collections.Generic;

    public class Motorcycle : Vehicle
    {
        private const int k_NumOfWheels = 2;
        private const float k_MaxAirPressure = 28f;
        private const float k_MaxBatteryTime = 1.6f;
        private const float k_MaxFuelCapacity = 5.5f;
        private const PetrolEngine.eFuelType k_FuelType = PetrolEngine.eFuelType.Octan98;
        private readonly int r_EngineCapacity;
        private readonly eLicenseType r_LicenseType;

        public Motorcycle(
            string i_ModelName,
            string i_LicenseNumber,
            Engine.eEngineType i_EngineType,
            string i_WheelManufacturerName,
            int i_EngineCapacity,
            eLicenseType i_LicenseType)
            : base(i_ModelName, i_LicenseNumber, i_EngineType)
        {
            r_LicenseType = i_LicenseType;
            r_EngineCapacity = i_EngineCapacity;
            if (i_EngineType == Engine.eEngineType.Electric)
            {
                EngineType = new ElectricEngine(k_MaxBatteryTime);
            }
            else
            {
                EngineType = new PetrolEngine(k_MaxFuelCapacity, k_FuelType);
            }

            m_Wheels = new List<Wheel>();
            for (int i = 0; i < k_NumOfWheels; i++)
            {
                m_Wheels.Add(new Wheel(i_WheelManufacturerName, k_MaxAirPressure));
            }
        }

        public enum eLicenseType
        {
            A,
            A1,
            A2,
            B
        }

        public int EngineCapacity => r_EngineCapacity;

        public eLicenseType LicenseType => r_LicenseType;

        public override string ToString()
        {
            return base.ToString() + $@"

                Vehicle Type: Motorcycle
                License Type: {LicenseType}
                Engine Capacity: {EngineCapacity}";
        }
    }
}