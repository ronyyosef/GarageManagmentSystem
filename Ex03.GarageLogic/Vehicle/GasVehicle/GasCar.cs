using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class GasCar : GasVehicle
    {
        private readonly Car r_Car;

        public GasCar(eFuelType i_FuelType, float i_CurrentFuelAmountLiter, float i_MaxFuelAmountLiter, List<Wheel> i_Wheels, string i_ModelName, string i_LicenseNumber, Car.eDoorsNumber i_DoorNumber, Car.eColors i_CarColor)
            : base(i_FuelType, i_CurrentFuelAmountLiter, i_MaxFuelAmountLiter, i_Wheels, i_ModelName, i_LicenseNumber)
        {
            r_Car = new Car(i_DoorNumber, i_CarColor);
        }

        public GasCar(Dictionary<string, object> i_DataDictionary) : base(i_DataDictionary)
        {
            r_Car = new Car(i_DataDictionary);
        }

        public static Dictionary<string, VehicleCreator.RequiredData> RequiredData()
        {
            Dictionary<string, VehicleCreator.RequiredData> result = new Dictionary<string, VehicleCreator.RequiredData>();
            foreach (var Require in GasVehicle.RequiredData())
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
            r_Car.GetData(i_Dictionary);
        }
    }
}