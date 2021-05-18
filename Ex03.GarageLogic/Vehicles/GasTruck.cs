using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class GasTruck : GasVehicle
    {
        private const eFuelType k_FuelType = eFuelType.Soler;
        private const float k_MaxFuel = 120;
        private readonly Truck r_Truck = new Truck();

        public GasTruck() : base(k_FuelType, k_MaxFuel, Truck.k_NumberOfWheels, Truck.k_MaxAirPressure)
        {
        }

        public static new Dictionary<string, VehicleCreator.RequiredData> RequiredData()
        {
            Dictionary<string, VehicleCreator.RequiredData> result = new Dictionary<string, VehicleCreator.RequiredData>();
            foreach (var require in GasVehicle.RequiredData())
            {
                result.Add(require.Key, require.Value);
            }

            foreach (var require in Truck.RequiredData())
            {
                result.Add(require.Key, require.Value);
            }

            return result;
        }

        public override void Init(Dictionary<string, object> i_DataDictionary)
        {
            r_Truck.Init(i_DataDictionary);
            base.Init(i_DataDictionary);
        }

        public override void GetData(Dictionary<string, string> i_Dictionary)
        {
            i_Dictionary.Add("vehicleType", "Gas truck");
            base.GetData(i_Dictionary);
            r_Truck.GetData(i_Dictionary);
        }
    }
}