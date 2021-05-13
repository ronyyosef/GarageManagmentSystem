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

        public ElectricCar(Dictionary<string, object> i_DataList) : base((float)i_DataList["maxBattery"], (float)i_DataList["batteryTimeRemain"], new List<Wheel> { new Wheel(10, 20, "rony") }/*need to be replace with wheels*/, (string)i_DataList["modelName"], (string)i_DataList["licenseNumber"])
        {
            r_car = new Car((Car.eDoorsNumber)i_DataList["doorNumber"], (Car.eColors)i_DataList["carColor"]);
        }

        public static Dictionary<string, VehicleCreator.RequiredData> RequiredData()
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            foreach (var req in ElectricVehicle.RequiredData())
            {
            }
            result.AddRange(ElectricVehicle.RequiredData());
            result.AddRange(Car.RequiredData());
            return result;
        }
    }
}