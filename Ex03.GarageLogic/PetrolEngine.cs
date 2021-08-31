namespace Ex03.GarageLogic
{
    public class PetrolEngine : Engine
    {
        private readonly float r_MaxFuelCapacity;
        private readonly eFuelType r_FuelType;
        private float m_CurrentFuelAmount;

        public PetrolEngine(float m_MaxFuelCapacity, eFuelType i_FuelType)
        {
            r_MaxFuelCapacity = m_MaxFuelCapacity;
            m_CurrentFuelAmount = 0;
            r_FuelType = i_FuelType;
        }

        public enum eFuelType
        {
            Octan98,
            Octan96,
            Octan95,
            Soler
        }

        public float CurrentFuelAmount
        {
            get => m_CurrentFuelAmount;

            set => m_CurrentFuelAmount = value;
        }

        public eFuelType FuelType => r_FuelType;

        public float MaxFuelCapacity => r_MaxFuelCapacity;

        public void Refuel(float i_FuelAmountToAdd)
        {
            if (i_FuelAmountToAdd + CurrentFuelAmount <= MaxFuelCapacity)
            {
                CurrentFuelAmount += i_FuelAmountToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(MaxFuelCapacity - CurrentFuelAmount, 0);
            }
        }

        public override string ToString()
        {
            return base.ToString() +
                $@"Petrol Engine
                Current Fuel Amount: {CurrentFuelAmount}
                Max Fuel Capacity: {MaxFuelCapacity}";
        }
    }
}
