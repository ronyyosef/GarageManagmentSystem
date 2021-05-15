using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class GasCar : GasVehicle
    {
        private readonly Car r_Car;

        public GasCar(Dictionary<string, object> i_DataDictionary) : base(i_DataDictionary, GasVehicle.eFuelType.Octan95)
        {
            r_Car = new Car(i_DataDictionary);
        }

        public new static Dictionary<string, VehicleCreator.RequiredData> RequiredData()
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

        public override void GetData(Dictionary<string, string> i_Dictionary)
        {
            i_Dictionary.Add("vehicleType", "Gas car");
            base.GetData(i_Dictionary);
            r_Car.GetData(i_Dictionary);
        }
    }
}