using System.Collections.Generic;

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

        private readonly List<VehicleInTheGarage> r_VehicleInTheGarageList;

        public GarageManager()
        {
            r_VehicleInTheGarageList = new List<VehicleInTheGarage>();
            /*
            Vehicle newCreatedVehicle = VehicleCreator.CreateNewElectricCar(
                        30,
                        10,
                        new List<Wheel> { (new Wheel(10, 20, "willi")), },
                        "skoda",
                        "1234123",
                        Car.eDoorsNumber.Four,
                        Car.eColors.Black);
            Owner ronyOwner = new Owner("rony", "0532840340");
            r_VehicleInTheGarageList.Add(new VehicleInTheGarage(ronyOwner, newCreatedVehicle));
            */
        }

        public void AllVehiclesLicenseNumberListFiltered(List<string> i_VehiclesLicenseNumber, GarageManager.eVehicleStatus i_FilterBy)
        {
            foreach (VehicleInTheGarage vehicleInGarage in r_VehicleInTheGarageList)
            {
                if (vehicleInGarage.Status == i_FilterBy)
                {
                    i_VehiclesLicenseNumber.Add(vehicleInGarage.GetLicenseNumber());
                }
            }
        }

        public void AllVehiclesLicenseNumberList(List<string> i_VehiclesLicenseNumber)
        {
            foreach (VehicleInTheGarage vehicleInGarage in r_VehicleInTheGarageList)
            {
                i_VehiclesLicenseNumber.Add(vehicleInGarage.GetLicenseNumber());
            }
        }
    }
}