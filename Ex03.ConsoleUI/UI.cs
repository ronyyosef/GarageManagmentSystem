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
            List<string> AllVehiclesLicenseNumber;
            Console.WriteLine("Do you want to filter the vehicles by status?(yes/no)");
            string answer = Console.ReadLine();
            if (answer == "no")
            {
                AllVehiclesLicenseNumber = r_garage.AllVehiclesLicenseNumberList();
            }
            else if(answer == "yes")
            {
                StringBuilder filterPrint = new StringBuilder();
                Console.WriteLine("Which of the following status do you want to fillter by? ");
                string[] possibleStatus = Enum.GetNames(typeof(Garage.eVehicleStatus));
                foreach (string status in possibleStatus)
                {
                    filterPrint.Append(status);
                    filterPrint.Append(" ");
                }
                Console.WriteLine(filterPrint);
                string filterBy = Console.ReadLine();
                if (Array.Find(possibleStatus,curr=> curr == filterBy) != null)
                {
                    if (Enum.TryParse(filterBy, out Garage.eVehicleStatus status)==false)
                    {
                        throw new Exception();
                    }
                    AllVehiclesLicenseNumber = r_garage.AllVehiclesLicenseNumberListFiltered(status);
                }
                else
                {
                    throw new Exception();
                }
            }
            else
            {
                throw new Exception();
            }
            
            StringBuilder toPrint = new StringBuilder();
            foreach(string licenseNumber in AllVehiclesLicenseNumber)
            {
                toPrint.Append(licenseNumber);
            }
            Console.WriteLine(toPrint);
        }
        private enum eFilterBy
        {
            None,

        }
        private void DisplayAllVehiclesLicenseNumberFilter()
        {
            Console.WriteLine("Do you want to filter the vehicles by status?(yes/no)");
            string answer = Console.ReadLine();
            if (answer == "no")
            {

            }
            Console.WriteLine("Which of the following status do you want to fillter by?");
        }

        private void ChangeVehicleStatus()
        {
            Console.WriteLine("pleace enter" );
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
