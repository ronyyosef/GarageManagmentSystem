using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Wheel
    {
        private float m_CurrentAirPressure;
        private readonly float r_MaxAirPressure;

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
        }

        public string ManufacturerName { get; set; }

        public Wheel(float r_MaxAirPressure)
        {
            this.r_MaxAirPressure = r_MaxAirPressure;
        }

    }
}
