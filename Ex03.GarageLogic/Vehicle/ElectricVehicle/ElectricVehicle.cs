using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class ElectricVehicle : Vehicle
    {
        private const float k_MinBattery = 0;

        protected ElectricVehicle(float i_MaxBatteryTime, float i_BatteryTimeRemain, List<Wheel> i_Wheels, string i_ModelName, string i_LicenseNumber)
            : base(i_Wheels, i_ModelName, i_LicenseNumber)
        {
            maxBatteryCheck(i_MaxBatteryTime);
            r_MaxBatteryTime = i_MaxBatteryTime;
            BatteryTimeRemain = i_BatteryTimeRemain;

            EnergyPercent = (m_BatteryTimeRemain / r_MaxBatteryTime);
        }

        protected float BatteryTimeRemain
        {
            get
            {
                return m_BatteryTimeRemain;
            }
            set
            {
                if (value > r_MaxBatteryTime || value < k_MinBattery)
                {
                    throw new ValueOutOfRangeException("Battery amount", k_MinBattery, r_MaxBatteryTime);
                }
                m_BatteryTimeRemain = value;
                EnergyPercent = (m_BatteryTimeRemain / r_MaxBatteryTime) * 100;
            }
        }

        private void maxBatteryCheck(float i_MaxBatteryAmount)
        {
            if (i_MaxBatteryAmount < k_MinBattery)
            {
                throw new ValueOutOfRangeException("Maximum battery time cannot be negative", k_MinBattery, r_MaxBatteryTime);
            }
        }

        protected float MaxBatteryTime
        {
            get
            {
                return r_MaxBatteryTime;
            }
        }

        protected void Recharge(float i_ToAdd)
        {
            BatteryTimeRemain += i_ToAdd;
        }

        private float m_BatteryTimeRemain;
        private readonly float r_MaxBatteryTime;
    }
}