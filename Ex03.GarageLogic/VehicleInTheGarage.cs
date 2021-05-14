using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class VehicleInTheGarage
    {
        private readonly Owner r_Owner;
        private readonly Vehicle r_Vehicle;

        public VehicleInTheGarage(Owner i_Owner, Vehicle i_Vehicle)
        {
            r_Owner = i_Owner;
            r_Vehicle = i_Vehicle;
        }

        public GarageManager.eVehicleStatus Status { get; set; }

        public Vehicle Vehicle
        {
            get
            {
                return r_Vehicle;
            }
        }

        public string GetLicenseNumber()
        {
            return r_Vehicle.LicenseNumber;
        }

        public void GetData(Dictionary<string, string> i_Dictionary)
        {
            r_Owner.GetData(i_Dictionary);
            r_Vehicle.GetData(i_Dictionary);
            i_Dictionary.Add("Status", Status.ToString());
        }
    }
}