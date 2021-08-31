namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string r_ManufacturerName;
        private readonly float r_MaxAirPressure;
        private float m_CurrentAirPressure;
        
        public Wheel(string i_ManufacturerName, float i_MaxAirPressure)
        {
            this.r_ManufacturerName = i_ManufacturerName;
            this.m_CurrentAirPressure = 0;
            this.r_MaxAirPressure = i_MaxAirPressure;
        }

        public string ManufacturerName
        {
            get { return r_ManufacturerName; }
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }

            set { m_CurrentAirPressure = value; }
        }

        public float MaxAirPressure
        {
            get { return r_MaxAirPressure; }
        }

        public void InflateAir(float i_CountOfAirToAdd)
        {
            if(i_CountOfAirToAdd + CurrentAirPressure <= MaxAirPressure)
            {
                CurrentAirPressure += i_CountOfAirToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(MaxAirPressure - CurrentAirPressure, 0);
            }
        }

        public override string ToString() => $@"
                Wheel Manufacturer Name: {ManufacturerName}
                Current Air Pressure: {CurrentAirPressure}
                Max Air Pressure : {MaxAirPressure}";
    }
}
