using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class ElectricCar : ElectricVehicle
    {
        private readonly Car r_Car = new Car();
        private const float k_MaxBatteryTimeHours = 3.2f;

        public ElectricCar() : base(k_MaxBatteryTimeHours, Car.k_NumberOfWheels, Car.k_MaxAirPressure)
        {
        }

        public override void Init(Dictionary<string, object> i_DataDictionary)
        {
            r_Car.Init(i_DataDictionary);
            base.Init(i_DataDictionary);
        }

        public new static Dictionary<string, VehicleCreator.RequiredData> RequiredData()
        {
            Dictionary<string, VehicleCreator.RequiredData> result = new Dictionary<string, VehicleCreator.RequiredData>();
            foreach (var require in ElectricVehicle.RequiredData())
            {
                result.Add(require.Key, require.Value);
            }
            foreach (var require in Car.RequiredData())
            {
                result.Add(require.Key, require.Value);
            }
            return result;
        }

        public override void GetData(Dictionary<string, string> i_Dictionary)
        {
            i_Dictionary.Add("vehicleType", "Electric car");
            base.GetData(i_Dictionary);
            r_Car.GetData(i_Dictionary);
        }
    }
}