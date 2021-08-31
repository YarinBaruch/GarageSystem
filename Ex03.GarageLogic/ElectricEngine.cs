namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        private readonly float r_MaxBatteryTime;
        private float m_RemainingBatteryTime;

        public ElectricEngine(float i_MaxBatteryTime)
        {
            m_RemainingBatteryTime = 0;
            r_MaxBatteryTime = i_MaxBatteryTime;
        }

        public float RemainingBatteryTime
        {
            get => m_RemainingBatteryTime;
            set => m_RemainingBatteryTime = value;
        }

        public float MaxBatteryTime => r_MaxBatteryTime;

        public void BatteryCharge(float i_NumOfHoursToAdd)
        {
            if (i_NumOfHoursToAdd + m_RemainingBatteryTime <= r_MaxBatteryTime)
            {
                RemainingBatteryTime += i_NumOfHoursToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(60 * (MaxBatteryTime - RemainingBatteryTime), 0);
            }
        }

        public override string ToString()
        {
            return base.ToString() +
                $@"Electric Engine
                Remaining Battery Time: {RemainingBatteryTime} (hours)
                Max Battery Time: {MaxBatteryTime} (hours)";
        }
    }
}
