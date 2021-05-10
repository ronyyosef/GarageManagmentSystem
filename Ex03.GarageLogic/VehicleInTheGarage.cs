using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleInTheGarage
    {

        private readonly Owner r_owner;
        private readonly Vehicle r_vehicle;
        public Garage.eVehicleStatus Status { get; set; }
        public string GetLicenseNumber()
        {
            return r_vehicle.LicenseNumber;
        }
    }
}
