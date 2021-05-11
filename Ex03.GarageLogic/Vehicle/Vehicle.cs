using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private const float k_MaxPercent = 100;
        private const float k_MinPercent = 0;

        protected Vehicle(List<Wheel> i_Wheels, string i_ModelName, string i_LicenseNumber)
        {
            r_Wheels = i_Wheels;
            r_ModelName = i_ModelName;
            LicenseNumber = i_LicenseNumber;
        }

        private readonly List<Wheel> r_Wheels;

        private readonly string r_ModelName;

        private string m_LicenseNumber;

        private float m_EnergyPercent;

        public float EnergyPercent
        {
            get
            {
                return m_EnergyPercent;
            }
            set
            {
                if (m_EnergyPercent < k_MinPercent || m_EnergyPercent > k_MaxPercent)
                {
                    throw new ValueOutOfRangeException(
                        "Percent out of need to be between 0-100",
                        k_MinPercent,
                        k_MaxPercent);
                }

                m_EnergyPercent = value;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }
            set
            {
                if (int.TryParse(value, out int _) == false)
                {
                    throw new ValueNotInFormat("License Number have to be a number");
                }

                m_LicenseNumber = value;
            }
        }
    }
}