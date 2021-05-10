using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        public enum eVehicleStatus
        {
            InProgress,
            repaired,
            paied,
        }
        private readonly List<VehicleInTheGarage> VehicleInTheGarageList;
        public List<string> AllVehiclesLicenseNumberListFiltered(Garage.eVehicleStatus filterBy)
        {
            List<string> licenseNumberList = new List<string>();
            foreach (VehicleInTheGarage vehicleInGarage in VehicleInTheGarageList)
            {
                if (vehicleInGarage.Status == filterBy)
                {
                    licenseNumberList.Add(vehicleInGarage.GetLicenseNumber());
                }
            }
            return licenseNumberList;
        }
        public List<string> AllVehiclesLicenseNumberList()
        {
            List<string> licenseNumberList = new List<string>();
            foreach (VehicleInTheGarage vehicleInGarage in VehicleInTheGarageList)
            {
                licenseNumberList.Add(vehicleInGarage.GetLicenseNumber());
            }
            return licenseNumberList;
        }
    }
}
