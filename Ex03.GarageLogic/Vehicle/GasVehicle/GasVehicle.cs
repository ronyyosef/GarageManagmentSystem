using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class GasVehicle : Vehicle
    {
        private const float k_MinFuel = 0;

        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98,
        }

        protected GasVehicle(eFuelType i_FuelType, float i_CurrentFuelAmountLiter, float i_MaxFuelAmountLiter, List<Wheel> i_Wheels, string i_ModelName, string i_LicenseNumber) : base(i_Wheels, i_ModelName, i_LicenseNumber)
        {
            r_FuelType = i_FuelType;
            CurrentFuelAmountLiter = i_CurrentFuelAmountLiter;
            maxFuelCheck(i_MaxFuelAmountLiter);
            r_MaxFuelAmountLiter = i_MaxFuelAmountLiter;
            EnergyPercent = (i_CurrentFuelAmountLiter / i_MaxFuelAmountLiter) * 100;
        }

        protected GasVehicle(Dictionary<string, object> i_DataDictionary) : base(i_DataDictionary)
        {
            r_FuelType = (eFuelType)i_DataDictionary["fuelType"];
            CurrentFuelAmountLiter = (float)i_DataDictionary["currentFuelAmountLiter"];
            float maxFuelAmountLiter = (float)i_DataDictionary["maxFuelAmountLiter"];
            maxFuelCheck(maxFuelAmountLiter);
            r_MaxFuelAmountLiter = maxFuelAmountLiter;
            EnergyPercent = (CurrentFuelAmountLiter / r_MaxFuelAmountLiter) * 100;
        }

        public static Dictionary<string, VehicleCreator.RequiredData> RequiredData()
        {
            Dictionary<string, VehicleCreator.RequiredData> result = new Dictionary<string, VehicleCreator.RequiredData>();
            result.Add("fuleType", new VehicleCreator.RequiredData("Please enter the fuel type:", typeof(eFuelType)));
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
                throw new ValueOutOfRangeException("Max fuel isn't checked ,Fuel Amount", k_MinFuel, float.MaxValue);
            }
        }

        public void Refuel(float i_ToAdd)
        {
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
                    throw new ValueOutOfRangeException("Fuel Amount", k_MinFuel, r_MaxFuelAmountLiter);
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
            i_Dictionary.Add("energyPercent", EnergyPercent.ToString());
        }

        private readonly float r_MaxFuelAmountLiter;
    }
}