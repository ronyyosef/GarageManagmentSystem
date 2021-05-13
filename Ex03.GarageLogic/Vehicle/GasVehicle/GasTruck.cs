using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class GasTruck : GasVehicle
    {
        private readonly Truck r_Truck;

        //TODO delete
        public GasTruck(eFuelType i_FuelType, float i_CurrentFuelAmountLiter, float i_MaxFuelAmountLiter, List<Wheel> i_Wheels, string i_ModelName, string i_LicenseNumber, bool i_CarryingHazardousMaterials, float i_MaximumCarryingWeight)
            : base(i_FuelType, i_CurrentFuelAmountLiter, i_MaxFuelAmountLiter, i_Wheels, i_ModelName, i_LicenseNumber)
        {
            r_Truck = new Truck(i_CarryingHazardousMaterials, i_MaximumCarryingWeight);
        }

        public GasTruck(Dictionary<string, object> i_DataDictionary) : base(i_DataDictionary)
        {
            r_Truck = new Truck(i_DataDictionary);
        }

        public static Dictionary<string, VehicleCreator.RequiredData> RequiredData()
        {
            Dictionary<string, VehicleCreator.RequiredData> result = new Dictionary<string, VehicleCreator.RequiredData>();
            foreach (var Require in GasVehicle.RequiredData())
            {
                result.Add(Require.Key, Require.Value);
            }
            foreach (var Require in Truck.RequiredData())
            {
                result.Add(Require.Key, Require.Value);
            }
            return result;
        }
    }
}