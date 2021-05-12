using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private const float k_MinAirPressure = 0;

        public float MaxAirPressure { get; }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
            set
            {
                if ((value) > MaxAirPressure)
                {
                    throw new ValueOutOfRangeException("Air pressure", k_MinAirPressure, MaxAirPressure);
                }
                if (value < k_MinAirPressure)
                {
                    throw new ValueOutOfRangeException("Air pressure", k_MinAirPressure, MaxAirPressure);
                }

                m_CurrentAirPressure = value;
            }
        }

        public Wheel(float i_MaxAirPressure)
        {
            this.MaxAirPressure = i_MaxAirPressure;
        }

        public Wheel(float i_CurrentAirPressure, float i_MaxAirPressure, string i_ManufacturerName)
        {
            MaxAirPressure = i_MaxAirPressure;
            CurrentAirPressure = i_CurrentAirPressure;
            ManufacturerName = i_ManufacturerName;
        }

        public void Inflate(float i_HowMuchToInflate)
        {
            CurrentAirPressure += i_HowMuchToInflate;
        }

        public string ManufacturerName { get; set; }

        private float m_CurrentAirPressure;

        public static List<VehicleCreator.RequiredData> RequiredData()
        {
            return new List<VehicleCreator.RequiredData>
                       {
                           new VehicleCreator.RequiredData("What is the current air pressure?", typeof(float)),
                           new VehicleCreator.RequiredData("What is the maximum air pressure?", typeof(float)),
                           new VehicleCreator.RequiredData("What is the manufacturer name?", typeof(string)),
                       };
        }
    }
}