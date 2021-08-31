namespace Ex03.GarageLogic
{
    using System;

    public class ValueOutOfRangeException : Exception
    {
        private readonly float r_MaxValue;
        private readonly float r_MinValue;

        public ValueOutOfRangeException(Exception i_Inner, float i_MaxValue, float i_MinValue)
            : base($"Invalid input range... type value between: {i_MinValue} - {i_MaxValue}", i_Inner)
        {
            this.r_MaxValue = i_MaxValue;
            this.r_MinValue = i_MinValue;
        }

        public ValueOutOfRangeException(float i_MaxValue, float i_MinValue)
            : base($"Invalid input range... type value between: {i_MinValue} - {i_MaxValue}")
        {
            this.r_MaxValue = i_MaxValue;
            this.r_MinValue = i_MinValue;
        }

        public float MaxValue => r_MaxValue;

        public float MinValue => r_MinValue;
    }
}
