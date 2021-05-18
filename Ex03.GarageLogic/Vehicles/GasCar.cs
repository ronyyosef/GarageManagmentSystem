using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class GasCar : GasVehicle
    {
        private const eFuelType k_FuelType = eFuelType.Octan95;
        private const float k_MaxFuel = 45;
        private readonly Car r_Car = new Car();

        public GasCar() : base(k_FuelType, k_MaxFuel, Car.k_NumberOfWheels, Car.k_MaxAirPressure)
        {
        }

        public static new Dictionary<string, VehicleCreator.RequiredData> RequiredData()
        {
            Dictionary<string, VehicleCreator.RequiredData> result = new Dictionary<string, VehicleCreator.RequiredData>();
            foreach (var Require in GasVehicle.RequiredData())
            {
                result.Add(Require.Key, Require.Value);
            }

            foreach (var Require in Car.RequiredData())
            {
                result.Add(Require.Key, Require.Value);
            }

            return result;
        }

        public override void Init(Dictionary<string, object> i_DataDictionary)
        {
            r_Car.Init(i_DataDictionary);
            base.Init(i_DataDictionary);
        }

        public override void GetData(Dictionary<string, string> i_Dictionary)
        {
            i_Dictionary.Add("vehicleType", "Gas car");
            base.GetData(i_Dictionary);
            r_Car.GetData(i_Dictionary);
        }
    }
}