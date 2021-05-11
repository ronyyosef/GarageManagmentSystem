using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class GasTruck : GasVehicle
    {
        private readonly Truck r_Truck;

        public GasTruck(eFuelType i_FuelType, float i_CurrentFuelAmountLiter, float i_MaxFuelAmountLiter, List<Wheel> i_Wheels, string i_ModelName, string i_LicenseNumber, bool i_CarryingHazardousMaterials, float i_MaximumCarryingWeight)
            : base(i_FuelType, i_CurrentFuelAmountLiter, i_MaxFuelAmountLiter, i_Wheels, i_ModelName, i_LicenseNumber)
        {
            r_Truck = new Truck(i_CarryingHazardousMaterials, i_MaximumCarryingWeight);
        }
    }
}