using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        public float MaxAirPressure
        {
            get
            {
                return r_MaxAirPressure;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
            set
            {
                if (value > r_MaxAirPressure)
                {
                    throw new ValueOutOfRangeException("Error : Air pressure exceeded maximum capacity");
                }
                if (value < 0)
                {
                    throw new ValueOutOfRangeException("Error : Air pressure cannot be negative");
                }

                m_CurrentAirPressure = value;
            }
        }

        public Wheel(float r_MaxAirPressure)
        {
            this.r_MaxAirPressure = r_MaxAirPressure;
        }

        public Wheel(float i_currentAirPressure, float i_MaxAirPressure, string i_manufacturerName)
        {
            r_MaxAirPressure = i_MaxAirPressure;
            CurrentAirPressure = i_currentAirPressure;
            ManufacturerName = i_manufacturerName;
        }

        public void Inflate(float i_HowMuchToInflate)
        {
            CurrentAirPressure = CurrentAirPressure + i_HowMuchToInflate;
        }

        public string ManufacturerName { get; set; }

        private float m_CurrentAirPressure;
        private readonly float r_MaxAirPressure;
    }
}