using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : ElectricVehicle
    {
        private readonly Motorcycle r_Motorcycle;

        //TODO delete
        public ElectricMotorcycle(float i_MaxBatteryTime, float i_BatteryTimeRemain, List<Wheel> i_Wheels, string i_ModelName, string i_LicenseNumber, Motorcycle.eLicenseType i_LicenseType, int i_EngineCapacityCc)
            : base(i_MaxBatteryTime, i_BatteryTimeRemain, i_Wheels, i_ModelName, i_LicenseNumber)
        {
            r_Motorcycle = new Motorcycle(i_LicenseType, i_EngineCapacityCc);
        }


        public ElectricMotorcycle(Dictionary<string, object> i_DataDictionary) : base(i_DataDictionary)
        {
            r_Motorcycle = new Motorcycle(i_DataDictionary);
        }

        public static Dictionary<string, VehicleCreator.RequiredData> RequiredData()
        {
            Dictionary<string, VehicleCreator.RequiredData> result = new Dictionary<string, VehicleCreator.RequiredData>();
            foreach (var Require in ElectricVehicle.RequiredData())
            {
                result.Add(Require.Key, Require.Value);
            }
            foreach (var Require in Motorcycle.RequiredData())
            {
                result.Add(Require.Key, Require.Value);
            }
            return result;
        }
    }
}