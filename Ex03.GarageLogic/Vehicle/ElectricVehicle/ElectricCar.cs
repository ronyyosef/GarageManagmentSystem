using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class ElectricCar : ElectricVehicle
    {
        private readonly Car r_car;

        public ElectricCar(float i_MaxBatteryTime, float i_BatteryTimeRemain, List<Wheel> i_Wheels, string i_ModelName, string i_LicenseNumber, Car.eDoorsNumber i_DoorNumber, Car.eColors i_CarColor)
            : base(i_MaxBatteryTime, i_BatteryTimeRemain, i_Wheels, i_ModelName, i_LicenseNumber)
        {
            r_car = new Car(i_DoorNumber, i_CarColor);
        }

        public static List<VehicleCreator.RequiredData> RequiredData()
        {
            List<VehicleCreator.RequiredData> result = new List<VehicleCreator.RequiredData>();
            result.AddRange(ElectricVehicle.RequiredData());
            result.AddRange(Car.RequiredData());
            return result;
        }
    }
}