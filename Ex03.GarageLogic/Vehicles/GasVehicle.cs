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

        protected GasVehicle(eFuelType i_FuelType, float i_MaxFuel, int i_NumberOfWheels, float i_MaxAirPressure) : base(i_NumberOfWheels, i_MaxAirPressure)
        {
            r_FuelType = i_FuelType;
            r_MaxFuelAmountLiter = i_MaxFuel;
        }

        public static new Dictionary<string, VehicleCreator.RequiredData> RequiredData()
        {
            Dictionary<string, VehicleCreator.RequiredData> result = new Dictionary<string, VehicleCreator.RequiredData>();
            result.Add("currentFuelAmountLiter", new VehicleCreator.RequiredData("Please enter the current fuel amount in liters:", typeof(float)));
            foreach (var require in Vehicle.RequiredData())
            {
                result.Add(require.Key, require.Value);
            }

            return result;
        }

        public override void Init(Dictionary<string, object> i_DataDictionary)
        {
            CurrentFuelAmountLiter = (float)i_DataDictionary["currentFuelAmountLiter"];
            EnergyPercent = (CurrentFuelAmountLiter / r_MaxFuelAmountLiter) * 100;
            base.Init(i_DataDictionary);
        }

        public void Refuel(eFuelType i_FuelType, float i_ToAdd)
        {
            if (i_FuelType != r_FuelType)
            {
                throw new ArgumentException($"This vehicle runs on {r_FuelType.ToString()} only!");
            }

            CurrentFuelAmountLiter += i_ToAdd;
        }

        private eFuelType r_FuelType;

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
                    throw new ValueOutOfRangeException($"You cant put {value} fuel in that vehicle.", k_MinFuel, r_MaxFuelAmountLiter);
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