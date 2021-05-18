using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        public enum eVehicleStatus
        {
            InProgress = 1,
            Repaired,
            Paid,
        }

        private readonly Dictionary<string, VehicleInTheGarage> r_VehicleInTheGarageDictionary;

        public GarageManager()
        {
            r_VehicleInTheGarageDictionary = new Dictionary<string, VehicleInTheGarage>();
        }

        public void AllVehiclesLicenseNumberListFiltered(List<string> i_VehiclesLicenseNumber, GarageManager.eVehicleStatus i_FilterBy)
        {
            foreach (var vehicleInGarage in r_VehicleInTheGarageDictionary)
            {
                if (vehicleInGarage.Value.Status == i_FilterBy)
                {
                    i_VehiclesLicenseNumber.Add(vehicleInGarage.Value.GetLicenseNumber());
                }
            }
        }

        public void AllVehiclesLicenseNumberList(List<string> i_VehiclesLicenseNumber)
        {
            foreach (var vehicleInGarage in r_VehicleInTheGarageDictionary)
            {
                i_VehiclesLicenseNumber.Add(vehicleInGarage.Value.GetLicenseNumber());
            }
        }

        public void AddVehicle(Vehicle i_NewVehicle, Owner i_NewOwner)
        {
            if (r_VehicleInTheGarageDictionary.ContainsKey(i_NewVehicle.LicenseNumber))
            {
                throw new ArgumentException("This vehicle number already in the garage!!!");
            }

            r_VehicleInTheGarageDictionary.Add(i_NewVehicle.LicenseNumber, new VehicleInTheGarage(i_NewOwner, i_NewVehicle));
        }

        public eVehicleStatus GetVehicleStatus(string i_VehicleLicense)
        {
            getVehicleInTheGarage(i_VehicleLicense, out VehicleInTheGarage vehicleInTheGarage);
            return vehicleInTheGarage.Status;
        }

        private void getVehicle(string i_VehicleLicense, out Vehicle i_Vehicle)
        {
            if (r_VehicleInTheGarageDictionary.TryGetValue(i_VehicleLicense, out VehicleInTheGarage vehicleInTheGarage) == false)
            {
                throw new ArgumentException("Vehicle not found");
            }

            i_Vehicle = vehicleInTheGarage.Vehicle;
        }

        public void InflateTires(string i_VehicleLicense, float i_ToInflate)
        {
            getVehicle(i_VehicleLicense, out Vehicle vehicle);
            vehicle.Inflate(i_ToInflate);
        }

        public void ChangeVehicleStatus(string i_VehicleLicense, eVehicleStatus i_UserChoice)
        {
            getVehicleInTheGarage(i_VehicleLicense, out VehicleInTheGarage vehicleInTheGarage);
            vehicleInTheGarage.Status = i_UserChoice;
        }

        private void getVehicleInTheGarage(string i_VehicleLicense, out VehicleInTheGarage i_VehicleInTheGarage)
        {
            if (r_VehicleInTheGarageDictionary.TryGetValue(i_VehicleLicense, out i_VehicleInTheGarage) == false)
            {
                throw new ArgumentException("Vehicle not found");
            }
        }

        public void RefuelVehicle(string i_VehicleLicense, GasVehicle.eFuelType i_FuelType, float i_ToRefuel)
        {
            getVehicle(i_VehicleLicense, out Vehicle vehicle);
            if (vehicle is GasVehicle gasVehicle)
            {
                gasVehicle.Refuel(i_FuelType, i_ToRefuel);
            }
            else
            {
                throw new ArgumentException("This is not a gas based vehicle");
            }
        }

        public void RechargeVehicle(string i_VehicleLicense, float i_ToRecharge)
        {
            getVehicle(i_VehicleLicense, out Vehicle vehicle);
            if (vehicle is ElectricVehicle electricVehicle)
            {
                electricVehicle.Recharge(i_ToRecharge);
            }
            else
            {
                throw new ArgumentException("This is not an electric based vehicle");
            }
        }

        public Dictionary<string, string> GetVehicleData(string i_VehicleLicense)
        {
            getVehicleInTheGarage(i_VehicleLicense, out VehicleInTheGarage vehicleInTheGarage);
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            vehicleInTheGarage.GetData(dictionary);
            return dictionary;
        }
    }
}