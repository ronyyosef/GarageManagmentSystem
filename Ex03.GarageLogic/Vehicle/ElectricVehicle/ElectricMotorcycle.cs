using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class ElectricMotorcycle : ElectricVehicle
    {
        private readonly Motorcycle r_Motorcycle;

        public ElectricMotorcycle(Dictionary<string, object> i_DataDictionary) : base(i_DataDictionary)
        {
            r_Motorcycle = new Motorcycle(i_DataDictionary);
        }

        public new static Dictionary<string, VehicleCreator.RequiredData> RequiredData()
        {
            Dictionary<string, VehicleCreator.RequiredData> result = new Dictionary<string, VehicleCreator.RequiredData>();
            foreach (var require in ElectricVehicle.RequiredData())
            {
                result.Add(require.Key, require.Value);
            }
            foreach (var require in Motorcycle.RequiredData())
            {
                result.Add(require.Key, require.Value);
            }
            return result;
        }

        public override void GetData(Dictionary<string, string> i_Dictionary)
        {
            i_Dictionary.Add("vehicleType", "Electric motorcycle");

            base.GetData(i_Dictionary);
            r_Motorcycle.GetData(i_Dictionary);
        }
    }
}