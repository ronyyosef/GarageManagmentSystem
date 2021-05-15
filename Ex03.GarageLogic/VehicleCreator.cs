using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public static class VehicleCreator
    {
        public enum eVehicleTypes
        {
            ElectricCar = 1,
            ElectricMotorcycle,
            GasCar,
            GasMotorcycle,
            GasTruck,
        }

        public struct RequiredData
        {
            public RequiredData(string i_Question, Type i_InputType)
            {
                Question = i_Question;
                InputType = i_InputType;
            }

            public string Question { get; set; }

            public Type InputType { get; set; }
        }

        public static Dictionary<string, RequiredData> CreateRequiredDataList(eVehicleTypes i_UserChoice)
        {
            Dictionary<string, RequiredData> requiredData;
            switch (i_UserChoice)
            {
                case eVehicleTypes.ElectricCar:
                    requiredData = ElectricCar.RequiredData();
                    break;

                case eVehicleTypes.ElectricMotorcycle:
                    requiredData = ElectricMotorcycle.RequiredData();
                    break;

                case eVehicleTypes.GasCar:
                    requiredData = GasCar.RequiredData();
                    break;

                case eVehicleTypes.GasMotorcycle:
                    requiredData = GasMotorcycle.RequiredData();
                    break;

                case eVehicleTypes.GasTruck:
                    requiredData = GasTruck.RequiredData();
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(i_UserChoice), i_UserChoice, null);
            }
            return requiredData;
        }

        public static Vehicle Create(eVehicleTypes i_UserChoice, Dictionary<string, object> i_VehicleDataList)
        {
            Vehicle newVehicle = null;
            switch (i_UserChoice)
            {
                case eVehicleTypes.ElectricCar:
                    newVehicle = new ElectricCar(i_VehicleDataList);
                    break;

                case eVehicleTypes.ElectricMotorcycle:
                    newVehicle = new ElectricMotorcycle(i_VehicleDataList);
                    break;

                case eVehicleTypes.GasCar:
                    newVehicle = new GasCar(i_VehicleDataList);
                    break;

                case eVehicleTypes.GasMotorcycle:
                    newVehicle = new GasMotorcycle(i_VehicleDataList);
                    break;

                case eVehicleTypes.GasTruck:
                    newVehicle = new GasTruck(i_VehicleDataList);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(i_UserChoice), i_UserChoice, null);
            }

            return newVehicle;
        }
    }
}