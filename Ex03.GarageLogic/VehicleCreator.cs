using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public static class VehicleCreator
    {
        public struct RequiredData
        {
            public RequiredData(string i_Question, Type i_inputType)
            {
                Question = i_Question;
                InputType = i_inputType;
            }

            public string Question { get; set; }

            public Type InputType { get; set; }
        }

        public static readonly List<string> sr_AvailableVehicles = new List<string>
            {
                nameof(ElectricCar),
                nameof(ElectricMotorcycle),
                nameof(GasCar),
                nameof(GasMotorcycle),
                nameof(GasTruck)
            };

        public static GasCar CreateNewGasCar(
            GasVehicle.eFuelType i_FuelType,
            float i_CurrentFuelAmountLiter,
            float i_MaxFuelAmountLiter,
            List<Wheel> i_Wheels,
            string i_ModelName,
            string i_LicenseNumber,
            Car.eDoorsNumber i_DoorNumber,
            Car.eColors i_CarColor)
        {
            return new GasCar(
                i_FuelType,
                i_CurrentFuelAmountLiter,
                i_MaxFuelAmountLiter,
                i_Wheels,
                i_ModelName,
                i_LicenseNumber,
                i_DoorNumber,
                i_CarColor);
        }

        public static ElectricCar CreateNewElectricCar(
            float i_MaxBatteryTime,
            float i_BatteryTimeRemain,
            List<Wheel> i_Wheels,
            string i_ModelName,
            string i_LicenseNumber,
            Car.eDoorsNumber i_DoorNumber,
            Car.eColors i_CarColor)
        {
            return new ElectricCar(
                i_MaxBatteryTime,
                i_BatteryTimeRemain,
                i_Wheels,
                i_ModelName,
                i_LicenseNumber,
                i_DoorNumber,
                i_CarColor);
        }

        public static void VehicleToCreate(List<string> i_VehicleList)
        {
        }

        public static List<RequiredData> CreateRequiredDataList(string i_UserInput)
        {
            List<RequiredData> requiredData;
            switch (i_UserInput)
            {
                case nameof(ElectricCar):
                    requiredData = ElectricCar.RequiredData();
                    break;

                case nameof(ElectricMotorcycle):
                    requiredData = ElectricMotorcycle.RequiredData();
                    break;

                case nameof(GasCar):
                    requiredData = GasCar.RequiredData();
                    break;

                case nameof(GasMotorcycle):
                    requiredData = GasMotorcycle.RequiredData();
                    break;

                case nameof(GasTruck):
                    requiredData = GasTruck.RequiredData();
                    break;

                default:
                    throw new Exception("No such a vehicle");
                    break;
            }

            return requiredData;
        }

        public static Vehicle Create(string i_UserInput, List<object> i_VehicleDataList)
        {
            Vehicle newVehicle = null;
            switch (i_UserInput)
            {
                case nameof(ElectricCar):
                    newVehicle = new ElectricCar(i_VehicleDataList);
                    break;

                case nameof(ElectricMotorcycle):
                    //newVehicle = ElectricMotorcycle(i_VehicleDataList);
                    break;

                case nameof(GasCar):
                    //newVehicle = GasCar(i_VehicleDataList);
                    break;

                case nameof(GasMotorcycle):
                    //newVehicle = GasMotorcycle(i_VehicleDataList);
                    break;

                case nameof(GasTruck):
                    //newVehicle = GasTruck(i_VehicleDataList);
                    break;

                default:
                    //throw new Exception("No such a vehicle");
                    break;
            }

            return newVehicle;
        }
    }
}