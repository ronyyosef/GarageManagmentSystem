using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class ElectricCar : ElectricVehicle
    {
        private readonly Car r_car;

        //TODO delete
        public ElectricCar(float i_MaxBatteryTime, float i_BatteryTimeRemain, List<Wheel> i_Wheels, string i_ModelName, string i_LicenseNumber, Car.eDoorsNumber i_DoorNumber, Car.eColors i_CarColor)
            : base(i_MaxBatteryTime, i_BatteryTimeRemain, i_Wheels, i_ModelName, i_LicenseNumber)
        {
            r_car = new Car(i_DoorNumber, i_CarColor);
        }

        public ElectricCar(Dictionary<string, object> i_DataDictionary) : base(i_DataDictionary)
        {
            r_car = new Car(i_DataDictionary);
        }

        public static Dictionary<string, VehicleCreator.RequiredData> RequiredData()
        {
            Dictionary<string, VehicleCreator.RequiredData> result = new Dictionary<string, VehicleCreator.RequiredData>();
            foreach (var Require in ElectricVehicle.RequiredData())
            {
                result.Add(Require.Key, Require.Value);
            }
            foreach (var Require in Car.RequiredData())
            {
                result.Add(Require.Key, Require.Value);
            }
            return result;
        }

        public override void GetData(Dictionary<string, string> i_Dictionary)
        {
            base.GetData(i_Dictionary);
            r_car.GetData(i_Dictionary);
        }
    }
}