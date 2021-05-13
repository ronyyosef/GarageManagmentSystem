using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Ex03.ConsoleUI
{
    internal class UI
    {
        /*
         *TODO change all enums show and input to numbers format
         *TODO Showing class names in prettier way
         */

        private enum eUserChoice
        {
            AddNewVehicle = 1,
            DisplayAllVehicles,
            ChangeVehicleStatus,
            InflateAllTires,
            RefuelVehicle,
            ChargeVehicle,
            DisplayVehicleData,
            Quit,
        }

        private eUserChoice m_UserChoice;
        private bool m_ToQuit;
        private readonly GarageManager r_GarageManager;

        public UI()
        {
            r_GarageManager = new GarageManager();
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
                    Console.Clear();
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
                    PressAnyKeyToContinue();
                }
            }
        }

        public static void PressAnyKeyToContinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void displayVehicleData()
        {
            throw new NotImplementedException();
        }

        private void addNewVehicleToTheGarage()
        {
            ShowEnumOptions<VehicleCreator.eVehicleTypes>();
            GetEnumChoice<VehicleCreator.eVehicleTypes>(out VehicleCreator.eVehicleTypes userInput);
            Dictionary<string, VehicleCreator.RequiredData> vehicleRequiresDictionary = VehicleCreator.CreateRequiredDataList(userInput);
            Dictionary<string, object> vehicleDataList = GetVehicleDataFromUser(vehicleRequiresDictionary);
            Vehicle newVehicle = VehicleCreator.Create(userInput, vehicleDataList);
            Owner newOwner = GetOwnerData();
            r_GarageManager.AddVehicle(newVehicle, newOwner);
        }

        private Owner GetOwnerData()
        {
            Console.WriteLine("Please write your Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Please write your Name:");
            string phoneNumber = Console.ReadLine();

            return new Owner(name, phoneNumber);
        }

        private Dictionary<string, object> GetVehicleDataFromUser(Dictionary<string, VehicleCreator.RequiredData> i_VehicleRequiresList)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            foreach (KeyValuePair<string, VehicleCreator.RequiredData> fieldData in i_VehicleRequiresList)
            {
                Type a = fieldData.Value.InputType;
                Object b = a as object;
                if (fieldData.Value.InputType.IsEnum)
                {
                }
                else
                {
                }

                Console.WriteLine(fieldData.Value.Question);
                string userInput = Console.ReadLine();
                TypeConverter converter = TypeDescriptor.GetConverter(fieldData.Value.InputType);
                object afterConvert = null;
                if (converter != null && converter.IsValid(userInput ?? string.Empty))
                {
                    afterConvert = converter.ConvertFromString(userInput);
                }
                else
                {
                    throw new FormatException();
                }

                result.Add(fieldData.Key, afterConvert);
            }

            return result;
        }

        /*
        private void addNewVehicleToTheGarageGetUserInput(out string i_UserInput)
        {
            i_UserInput = "";
            bool validInput = false;
            while (validInput == false)
            {
                i_UserInput = Console.ReadLine();
                if (VehicleCreator.sr_AvailableVehicles.Contains(i_UserInput))
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("This is not a valid vehicle name");
                }
            }
        }
        */

        /*
        private void showAvailableVehicles()
        {
            StringBuilder toPrint = new StringBuilder();
            toPrint.Append("Which of the following Vehicle do you want to create?");
            foreach (string vehicleName in VehicleCreator.sr_AvailableVehicles)
            {
                toPrint.Append(Environment.NewLine);
                toPrint.Append(vehicleName);
            }
            toPrint.Append(Environment.NewLine);
            Console.WriteLine(toPrint);
        }
        */

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
            Console.Clear();
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
                    r_GarageManager.AllVehiclesLicenseNumberList(allVehiclesLicenseNumber);
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
            Console.Clear();
            Console.WriteLine(toPrint);
            Console.ReadKey();
        }

        private void displayAllVehiclesLicenseNumberFiltered(List<string> i_AllVehiclesLicenseNumber)
        {
            int optionsCounter = 0;
            StringBuilder filterPrint = new StringBuilder();
            string[] possibleStatus = Enum.GetNames(typeof(GarageManager.eVehicleStatus));
            filterPrint.Append("Which of the following status do you want to filter by? ");

            foreach (string strStatus in possibleStatus)
            {
                filterPrint.Append(Environment.NewLine);
                filterPrint.Append(strStatus);
            }
            Console.Clear();
            Console.WriteLine(filterPrint);

            ShowEnumOptions<GarageManager.eVehicleStatus>();
            GetEnumChoice<GarageManager.eVehicleStatus>(out GarageManager.eVehicleStatus userChoice);
            r_GarageManager.AllVehiclesLicenseNumberListFiltered(i_AllVehiclesLicenseNumber, userChoice);
        }

        private void DisplayAllVehiclesLicenseNumberFilter()
        {
            Console.WriteLine("Do you want to filter the vehicles by status?(yes/no)");
            string answer = Console.ReadLine();
            if (answer == "no")
            {
            }
            Console.WriteLine("Which of the following status do you want to filter by?");
        }

        private void ChangeVehicleStatus()
        {
            Console.WriteLine("Please enter the vehicle license number");
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

        public static void ShowEnumOptions<TEnum>()
        {
            StringBuilder toPrint = new StringBuilder();
            toPrint.Append("Please Choose a number from the list below:");
            foreach (string options in Enum.GetNames(typeof(TEnum)))
            {
                toPrint.Append(Environment.NewLine);
                toPrint.Append($"{Enum.Parse(typeof(TEnum), options):D}. {options}");
            }
            Console.WriteLine(toPrint);
        }

        public void GetEnumChoice<TEnum>(out TEnum i_UserChoice) where TEnum : struct // will provide insurance that TEnum isn't nullable
        {
            int amountOfOptions = Enum.GetNames(typeof(TEnum)).Length;
            string userInput = Console.ReadLine();
            if (Enum.TryParse<TEnum>(userInput, out i_UserChoice) == false)
            {
                throw new FormatException();
            }
        }
    }
}