﻿using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class ElectricVehicle : Vehicle
    {
        private const float k_MinBattery = 0;

        protected ElectricVehicle(Dictionary<string, object> i_DataDictionary)
            : base(i_DataDictionary)
        {
            maxBatteryCheck((float)i_DataDictionary["maxBatteryTime"]);
            r_MaxBatteryTime = (float)i_DataDictionary["maxBatteryTime"];
            BatteryTimeRemain = (float)i_DataDictionary["batteryTimeRemain"];
            EnergyPercent = (m_BatteryTimeRemain / r_MaxBatteryTime);
        }

        public new static Dictionary<string, VehicleCreator.RequiredData> RequiredData()
        {
            Dictionary<string, VehicleCreator.RequiredData> result = new Dictionary<string, VehicleCreator.RequiredData>();
            result.Add("maxBatteryTime", new VehicleCreator.RequiredData("Please enter the maximum battery time:", typeof(float)));
            result.Add("batteryTimeRemain", new VehicleCreator.RequiredData("Please enter the current battery time remain:", typeof(float)));
            foreach (var Require in Vehicle.RequiredData())
            {
                result.Add(Require.Key, Require.Value);
            }
            return result;
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
                    throw new ValueOutOfRangeException($"The current battery amount is {BatteryTimeRemain}.", k_MinBattery, r_MaxBatteryTime);
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

        public void Recharge(float i_ToAdd)
        {
            BatteryTimeRemain += i_ToAdd;
        }

        private float m_BatteryTimeRemain;
        private readonly float r_MaxBatteryTime;

        public override void GetData(Dictionary<string, string> i_Dictionary)
        {
            base.GetData(i_Dictionary);
            i_Dictionary.Add("batteryTimeRemain", BatteryTimeRemain.ToString());
            i_Dictionary.Add("maxBatteryTime", MaxBatteryTime.ToString());
        }
    }
}