using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class GasMotorcycle : GasVehicle
    {
        private readonly Motorcycle r_Motorcycle;

        //TODO delete
        public GasMotorcycle(eFuelType i_FuelType, float i_CurrentFuelAmountLiter, float i_MaxFuelAmountLiter, List<Wheel> i_Wheels, string i_ModelName, string i_LicenseNumber, Motorcycle.eLicenseType i_LicenseType, int i_EngineCapacityCc)
            : base(i_FuelType, i_CurrentFuelAmountLiter, i_MaxFuelAmountLiter, i_Wheels, i_ModelName, i_LicenseNumber)
        {
            r_Motorcycle = new Motorcycle(i_LicenseType, i_EngineCapacityCc);
        }

        public GasMotorcycle(Dictionary<string, object> i_DataDictionary) : base(i_DataDictionary)
        {
            r_Motorcycle = new Motorcycle(i_DataDictionary);
        }

        public static Dictionary<string, VehicleCreator.RequiredData> RequiredData()
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
    }
}