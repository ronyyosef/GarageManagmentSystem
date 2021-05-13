using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        public enum eVehicleStatus
        {
            InProgress,
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
    }
}