using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        public float MinValue { get; set; }

        public float MaxValue { get; set; }

        public ValueOutOfRangeException(string i_Message, float i_MinValue, float i_MaxValue) : base($"Error : {i_Message}")
        {
            MinValue = i_MinValue;
            MaxValue = i_MaxValue;
        }
    }
}