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

        public string GetLicenseNumber()
        {
            return r_Vehicle.LicenseNumber;
        }
    }
}