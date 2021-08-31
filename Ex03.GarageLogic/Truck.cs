namespace Ex03.GarageLogic
{
    using System.Collections.Generic;

    public class Truck : Vehicle
    {
        private const int k_NumOfWheels = 16;
        private const float k_MaxAirPressure = 26f;
        private const float k_MaxFuelCapacity = 110f;
        private const PetrolEngine.eFuelType k_FuelType = PetrolEngine.eFuelType.Soler;
        private readonly float r_CargoVolume;
        private readonly bool r_IsDangerousMaterials;
        
        public Truck(
            string i_ModelName,
            string i_LicenseNumber,
            string i_WheelManufacturerName,
            float i_CargoVolume,
            bool i_IsDangerousMaterials)
            : base(i_ModelName, i_LicenseNumber, Engine.eEngineType.Petrol)
        {
            r_CargoVolume = i_CargoVolume;
            r_IsDangerousMaterials = i_IsDangerousMaterials;
            EngineType = new PetrolEngine(k_MaxFuelCapacity, k_FuelType);

            m_Wheels = new List<Wheel>();
            for (int i = 0; i < k_NumOfWheels; i++)
            {
                m_Wheels.Add(new Wheel(i_WheelManufacturerName, k_MaxAirPressure));
            }
        }

        public float CargoVolume => r_CargoVolume;

        public bool IsDangerousMaterials => r_IsDangerousMaterials;

        public override string ToString()
        {
            return base.ToString() + $@"

                Vehicle Type: Truck
                Cargo Volume: {CargoVolume}
                Is Dangerous Materials: {IsDangerousMaterials}";
        }
    }
}
