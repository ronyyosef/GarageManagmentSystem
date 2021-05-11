using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public static class VehicleCreator
    {
        public static GasCar CreateNewGasCar(GasVehicle.eFuelType i_FuelType, float i_CurrentFuelAmountLiter, float i_MaxFuelAmountLiter, List<Wheel> i_Wheels, string i_ModelName, string i_LicenseNumber, Car.eDoorsNumber i_DoorNumber, Car.eColors i_CarColor)
        {
            return new GasCar(i_FuelType, i_CurrentFuelAmountLiter, i_MaxFuelAmountLiter, i_Wheels, i_ModelName, i_LicenseNumber, i_DoorNumber, i_CarColor);
        }

        public static ElectricCar CreateNewElectricCar(float i_MaxBatteryTime, float i_BatteryTimeRemain, List<Wheel> i_Wheels, string i_ModelName, string i_LicenseNumber, Car.eDoorsNumber i_DoorNumber, Car.eColors i_CarColor)
        {
            return new ElectricCar(i_MaxBatteryTime, i_BatteryTimeRemain, i_Wheels, i_ModelName, i_LicenseNumber, i_DoorNumber, i_CarColor);
        }

        /*
        public static GasMotorcycle CreateNewGasMotorcycle()
        {
        }

        public static ElectricMotorcycle CreateNewElectricMotorcycle()
        {
        }

        public static GasTruck CreateNewGasTruck()
        {
        }

        public static List<string> VehiclesTypeList()
        {
            List<string> resultList = new List<string>();
            return resultList;
        }
        */
    }
}