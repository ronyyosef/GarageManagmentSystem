using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class GasMotorcycle : GasVehicle
    {
        private const eFuelType k_FuelType = eFuelType.Octan98;
        private const float k_MaxFuel = 6;
        private readonly Motorcycle r_Motorcycle = new Motorcycle();

        public GasMotorcycle() : base(k_FuelType, k_MaxFuel, Motorcycle.k_NumberOfWheels, Motorcycle.k_MaxAirPressure)
        {
        }

        public static new Dictionary<string, VehicleCreator.RequiredData> RequiredData()
        {
            Dictionary<string, VehicleCreator.RequiredData> result = new Dictionary<string, VehicleCreator.RequiredData>();
            foreach (var Require in GasVehicle.RequiredData())
            {
                result.Add(Require.Key, Require.Value);
            }

            foreach (var Require in Motorcycle.RequiredData())
            {
                result.Add(Require.Key, Require.Value);
            }

            return result;
        }

        public override void Init(Dictionary<string, object> i_DataDictionary)
        {
            r_Motorcycle.Init(i_DataDictionary);
            base.Init(i_DataDictionary);
        }

        public override void GetData(Dictionary<string, string> i_Dictionary)
        {
            i_Dictionary.Add("vehicleType", "Gas motorcycle");
            base.GetData(i_Dictionary);
            r_Motorcycle.GetData(i_Dictionary);
        }
    }
}