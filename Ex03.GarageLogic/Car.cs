namespace Ex03.GarageLogic
{
    using System.Collections.Generic;

    public class Car : Vehicle
    {
        private const int k_NumOfWheels = 4;
        private const float k_MaxAirPressure = 30f;
        private const float k_MaxBatteryTime = 2.8f;
        private const float k_MaxFuelCapacity = 50f;
        private const PetrolEngine.eFuelType k_FuelType = PetrolEngine.eFuelType.Octan95;
        private eColors m_Colors;
        private eDoorsNumber m_DoorsNumber;

        public Car(
            string i_ModelName,
            string i_LicenseNumber,
            Engine.eEngineType i_EngineType,
            string i_WheelManufacturerName,
            eDoorsNumber i_NumOfDoors,
            eColors i_CarColor)
            : base(i_ModelName, i_LicenseNumber, i_EngineType)
        {
            m_DoorsNumber = i_NumOfDoors;
            m_Colors = i_CarColor;

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

        public enum eColors
        {
            Yellow,
            White,
            Black,
            Blue
        }

        public enum eDoorsNumber
        {
            Two = 2,
            Three,
            Four,
            Five
        }

        public eColors Colors
        {
            get => m_Colors;
            set => m_Colors = value;
        }

        public eDoorsNumber DoorsNumber
        {
            get => m_DoorsNumber;
            set => m_DoorsNumber = value;
        }

        public override string ToString()
        {
            return base.ToString() + $@"

                Vehicle Type: Car
                Color: {Colors}
                Number Of Doors: {DoorsNumber}";
        }
    }
}
