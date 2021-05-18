using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class VehicleInTheGarage
    {
        private readonly Owner r_Owner;

        public VehicleInTheGarage(Owner i_Owner, Vehicle i_Vehicle)
        {
            r_Owner = i_Owner;
            Vehicle = i_Vehicle;
            Status = GarageManager.eVehicleStatus.InProgress;
        }

        public GarageManager.eVehicleStatus Status { get; set; }

        public Vehicle Vehicle { get; }

        public string GetLicenseNumber()
        {
            return Vehicle.LicenseNumber;
        }

        public void GetData(Dictionary<string, string> i_Dictionary)
        {
            r_Owner.GetData(i_Dictionary);
            Vehicle.GetData(i_Dictionary);
            i_Dictionary.Add("status", Status.ToString());
        }
    }
}