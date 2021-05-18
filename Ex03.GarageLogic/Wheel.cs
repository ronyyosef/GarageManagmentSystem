using System;
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
                    throw new ValueOutOfRangeException($"The current air pressure is {CurrentAirPressure}.", k_MinAirPressure, MaxAirPressure);
                }
                if (value < k_MinAirPressure)
                {
                    throw new ValueOutOfRangeException($"The current air pressure is {CurrentAirPressure}.", k_MinAirPressure, MaxAirPressure);
                }

                m_CurrentAirPressure = value;
            }
        }

        public Wheel(float i_MaxAirPressure)
        {
            MaxAirPressure = i_MaxAirPressure;
        }

        /*
        public Wheel(float i_CurrentAirPressure, float i_MaxAirPressure, string i_ManufacturerName)
        {
            MaxAirPressure = i_MaxAirPressure;
            CurrentAirPressure = i_CurrentAirPressure;
            ManufacturerName = i_ManufacturerName;
        }
        */

        public void Inflate(float i_HowMuchToInflate)
        {
            CurrentAirPressure += i_HowMuchToInflate;
        }

        public string ManufacturerName { get; set; }

        private float m_CurrentAirPressure;

        public static Dictionary<string, VehicleCreator.RequiredData> RequiredData()
        {
            Dictionary<string, VehicleCreator.RequiredData> result = new Dictionary<string, VehicleCreator.RequiredData>();
            result.Add("currentAirPressure", new VehicleCreator.RequiredData("What is the current air pressure?", typeof(float)));
            result.Add("manufacturerName", new VehicleCreator.RequiredData("What is the manufacturer name?", typeof(string)));
            return result;
        }

        public override string ToString()
        {
            return
                $"manufacturer name: {ManufacturerName}, max air pressure: {MaxAirPressure}, current air pressure: {CurrentAirPressure}";
        }

        public void Init(Dictionary<string, object> i_DataDictionary)
        {
            CurrentAirPressure = (float)i_DataDictionary["currentAirPressure"];
            ManufacturerName = (string)i_DataDictionary["manufacturerName"];
        }
    }
}