using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace Ex03.ConsoleUI
{
    internal class UI
    {
        private enum eUserChoice
        {
            AddNewVehicle = 1,
            DisplayAllVehicles = 2,
            ChangeVehicleStatus = 3,
            InflateAllTires = 4,
            RefuelVehicle = 5,
            ChargeVehicle = 6,
            DisplayVehicleData = 7,
            Quit = 8,
        }

        private eUserChoice m_UserChoice;
        private bool m_ToQuit;
        private readonly Garage r_Garage;

        public UI()
        {
            r_Garage = new Garage();
            m_ToQuit = false;
        }

        public void Run()
        {
            while (m_ToQuit == false)
            {
                try
                {
                    DisplayMenu();
                    getUserChoice();
                    switch (m_UserChoice)
                    {
                        case eUserChoice.AddNewVehicle:
                            addNewVehicleToTheGarage();
                            break;

                        case eUserChoice.DisplayAllVehicles:
                            DisplayAllVehiclesLicenseNumber();
                            break;

                        case eUserChoice.ChangeVehicleStatus:
                            ChangeVehicleStatus();
                            break;

                        case eUserChoice.InflateAllTires:
                            InflateTiresToMax();
                            break;

                        case eUserChoice.RefuelVehicle:
                            refuelVehicle();
                            break;

                        case eUserChoice.ChargeVehicle:
                            chargeVehicle();
                            break;

                        case eUserChoice.DisplayVehicleData:
                            displayVehicleData();
                            break;

                        case eUserChoice.Quit:
                            m_ToQuit = true;
                            break;

                        default:
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        private void displayVehicleData()
        {
            throw new NotImplementedException();
        }

        private void addNewVehicleToTheGarage()
        {
            throw new NotImplementedException();
        }

        private void getUserChoice()
        {
            bool inputValid = false;
            while (inputValid == false)
            {
                string userInputString = Console.ReadLine();
                bool successfulParsed = int.TryParse(userInputString, out int userInput);
                if (successfulParsed == true)
                {
                    if (Enum.IsDefined(typeof(eUserChoice), userInput) == true)
                    {
                        m_UserChoice = (eUserChoice)userInput;
                        inputValid = true;
                    }
                    else
                    {
                        Console.WriteLine("This is not a valid input");
                    }
                }
                else
                {
                    DisplayMenu();
                    Console.WriteLine("This is not a number");
                }
            }
        }

        private void DisplayMenu()
        {
            Ex02.ConsoleUtils.Screen.Clear();
            Console.WriteLine(
    @"1. Add new vehicle to the garage
2. Display all vehicles in the garage
3. Change vehicle status
4. Inflate all tires
5. Refuel vehicle
6. Charge vehicle
7. Show vehicle data
8. Quit
Enter a number:");
        }

        public void DisplayAllVehiclesLicenseNumber()
        {
            List<string> allVehiclesLicenseNumber = new List<string>();
            bool validAnswer = false;
            Console.WriteLine("Do you want to filter the vehicles by status?(yes/no)");
            while (validAnswer == false)
            {
                string answer = Console.ReadLine();
                if (answer == "no")
                {
                    r_Garage.AllVehiclesLicenseNumberList(allVehiclesLicenseNumber);
                    validAnswer = true;
                }
                else if (answer == "yes")
                {
                    displayAllVehiclesLicenseNumberFiltered(allVehiclesLicenseNumber);
                    validAnswer = true;
                }
                else
                {
                    Console.WriteLine("This is not a valid input. Answer yes or no only");
                }
            }

            StringBuilder toPrint = new StringBuilder();
            int Index = 1;
            foreach (string licenseNumber in allVehiclesLicenseNumber)
            {
                toPrint.Append($"{Index}. ");
                toPrint.Append(licenseNumber);
                toPrint.Append(Environment.NewLine);
                Index++;
            }

            toPrint.Append("Press any key to continue ...");
            Ex02.ConsoleUtils.Screen.Clear();
            Console.WriteLine(toPrint);
            Console.ReadKey();
        }

        private void displayAllVehiclesLicenseNumberFiltered(List<string> i_AllVehiclesLicenseNumber)
        {
            StringBuilder filterPrint = new StringBuilder();
            string[] possibleStatus = Enum.GetNames(typeof(Garage.eVehicleStatus));
            filterPrint.Append("Which of the following status do you want to filter by? ");

            foreach (string strStatus in possibleStatus)
            {
                filterPrint.Append(Environment.NewLine);
                filterPrint.Append(strStatus);
            }
            Ex02.ConsoleUtils.Screen.Clear();
            Console.WriteLine(filterPrint);

            bool validAnswer = false;
            Garage.eVehicleStatus statusToFilter = Garage.eVehicleStatus.InProgress;
            while (validAnswer == false)
            {
                string filterBy = Console.ReadLine();
                if (Enum.TryParse(filterBy, out statusToFilter) == false)
                {
                    Console.WriteLine("This is not one of the possible filter");
                }
                else
                {
                    validAnswer = true;
                }
            }

            r_Garage.AllVehiclesLicenseNumberListFiltered(i_AllVehiclesLicenseNumber, statusToFilter);
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
            Console.WriteLine("pleace enter");
        }

        private void InflateTiresToMax()
        {
        }

        private void refuelVehicle()
        {
        }

        private void chargeVehicle()
        {
        }
    }
}