using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class GasTruck : GasVehicle
    {
        private readonly Truck r_Truck;

        public GasTruck(Dictionary<string, object> i_DataDictionary) : base(i_DataDictionary, GasVehicle.eFuelType.Soler)
        {
            r_Truck = new Truck(i_DataDictionary);
        }

        public new static Dictionary<string, VehicleCreator.RequiredData> RequiredData()
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

        public override void GetData(Dictionary<string, string> i_Dictionary)
        {
            i_Dictionary.Add("vehicleType", "Gas truck");
            base.GetData(i_Dictionary);
            r_Truck.GetData(i_Dictionary);
        }
    }
}