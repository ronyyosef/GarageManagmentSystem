using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;
namespace Ex03.ConsoleUI
{
    class UI
    {
        enum eUserChoies
        {
            GetUserChoice,
        }
        private readonly Garage r_garage;
        public void Run()
        {
            while (true)
            {
                
                DisplayMenu();
                eUserChoies userChoice = GetUserChoice();
                //switch on userChoice
                //1
                addNewVehicleToTheGarage();

            }
        }

        private void addNewVehicleToTheGarage()
        {

            //Vehicle newVehicle = Vehicle.CreateNewGasCar()
            //r_garage.AddNewVehicleToTheGarage(newVehicle)
            throw new NotImplementedException();
        }

        private eUserChoies GetUserChoice()
        {
            throw new NotImplementedException();
        }

        private void DisplayMenu()
        {

        }

        private void DisplayAllVehiclesLicenseNumber()
        {

        }

        private void ChangeVehicleStatus()
        {

        }

        private void InflateTiresToMax()
        {

        }

        private void RefuelVehicle()
        {

        }

        private void ChargeVehicle()
        {

        }

        private void ShowSpecificVehicleData()
        {

        }
        private void CreateNewGasCar()
        {
            
        }

        private void CreateNewElectricCar()
        {

        }

        private void CreateNewGasMotorcycle()
        {

        }
        private void CreateNewElectricMotorcycle()
        {

        }

        private void CreateNewGasTruck()
        {

        }
    }
}
