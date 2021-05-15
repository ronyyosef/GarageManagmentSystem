using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class GasMotorcycle : GasVehicle
    {
        private readonly Motorcycle r_Motorcycle;

        public GasMotorcycle(Dictionary<string, object> i_DataDictionary) : base(i_DataDictionary, GasVehicle.eFuelType.Octan98)
        {
            r_Motorcycle = new Motorcycle(i_DataDictionary);
        }

        public new static Dictionary<string, VehicleCreator.RequiredData> RequiredData()
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

        public override void GetData(Dictionary<string, string> i_Dictionary)
        {
            i_Dictionary.Add("vehicleType", "Gas motorcycle");
            base.GetData(i_Dictionary);
            r_Motorcycle.GetData(i_Dictionary);
        }
    }
}