using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : ElectricVehicle
    {
        private readonly Motorcycle r_Motorcycle;

        public ElectricMotorcycle(float i_MaxBatteryTime, float i_BatteryTimeRemain, List<Wheel> i_Wheels, string i_ModelName, string i_LicenseNumber, Motorcycle.eLicenseType i_LicenseType, int i_EngineCapacityCc)
            : base(i_MaxBatteryTime, i_BatteryTimeRemain, i_Wheels, i_ModelName, i_LicenseNumber)
        {
            r_Motorcycle = new Motorcycle(i_LicenseType, i_EngineCapacityCc);
        }
    }
}