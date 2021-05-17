using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class GasVehicle : Vehicle
    {
        private const float k_MinFuel = 0;

        public enum eFuelType
        {
            Soler = 1,
            Octan95,
            Octan96,
            Octan98,
        }

        protected GasVehicle(Dictionary<string, object> i_DataDictionary, eFuelType i_FuelType) : base(i_DataDictionary)
        {
            r_FuelType = i_FuelType;
            r_MaxFuelAmountLiter = (float)i_DataDictionary["maxFuelAmountLiter"];
            maxFuelCheck(r_MaxFuelAmountLiter);
            CurrentFuelAmountLiter = (float)i_DataDictionary["currentFuelAmountLiter"];
            EnergyPercent = (CurrentFuelAmountLiter / r_MaxFuelAmountLiter) * 100;
        }

        public new static Dictionary<string, VehicleCreator.RequiredData> RequiredData()
        {
            Dictionary<string, VehicleCreator.RequiredData> result = new Dictionary<string, VehicleCreator.RequiredData>();
            result.Add("currentFuelAmountLiter", new VehicleCreator.RequiredData("Please enter the current fuel amount in liters:", typeof(float)));
            result.Add("maxFuelAmountLiter", new VehicleCreator.RequiredData("Please enter the max fuel amount in liters:", typeof(float)));
            foreach (var Require in Vehicle.RequiredData())
            {
                result.Add(Require.Key, Require.Value);
            }
            return result;
        }

        private static void maxFuelCheck(float i_MaxFuelAmountLiter)
        {
            if (i_MaxFuelAmountLiter < k_MinFuel)
            {
                throw new ValueOutOfRangeException($"Maximum fuel amount cannot be negative", k_MinFuel, float.MaxValue);
            }
        }

        public void Refuel(eFuelType i_FuelType, float i_ToAdd)
        {
            if (i_FuelType != r_FuelType)
            {
                throw new ArgumentException($"This vehicle runs on {r_FuelType.ToString()} only!");
            }
            CurrentFuelAmountLiter += i_ToAdd;
        }

        private readonly eFuelType r_FuelType;

        private float m_CurrentFuelAmountLiter;

        public float CurrentFuelAmountLiter
        {
            get
            {
                return m_CurrentFuelAmountLiter;
            }
            set
            {
                if (value > r_MaxFuelAmountLiter || value < k_MinFuel)
                {
                    throw new ValueOutOfRangeException($"The current fuel Amount is {CurrentFuelAmountLiter}.", k_MinFuel, r_MaxFuelAmountLiter);
                }

                EnergyPercent = (value / r_MaxFuelAmountLiter) * 100;
                m_CurrentFuelAmountLiter = value;
            }
        }

        public override void GetData(Dictionary<string, string> i_Dictionary)
        {
            base.GetData(i_Dictionary);
            i_Dictionary.Add("fuelType", r_FuelType.ToString());
            i_Dictionary.Add("currentFuelAmountLiter", CurrentFuelAmountLiter.ToString());
            i_Dictionary.Add("maxFuelAmountLiter", r_MaxFuelAmountLiter.ToString());
        }

        private readonly float r_MaxFuelAmountLiter;
    }
}