using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;

namespace Ex03.ConsoleUI
{
    internal class UI
    {
        /*
         *
         */

        private enum eUserChoice
        {
            AddNewVehicleToTheGarage = 1,
            DisplayAllVehiclesInTheGarage,
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
                        case eUserChoice.AddNewVehicleToTheGarage:
                            addNewVehicleToTheGarage();
                            break;

                        case eUserChoice.DisplayAllVehiclesInTheGarage:
                            DisplayAllVehiclesLicenseNumber();
                            break;

                        case eUserChoice.ChangeVehicleStatus:
                            changeVehicleStatus();
                            break;

                        case eUserChoice.InflateAllTires:
                            inflateTires();
                            break;

                        case eUserChoice.RefuelVehicle:
                            refuelVehicle();
                            break;

                        case eUserChoice.ChargeVehicle:
                            rechargeVehicle();
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
                catch (ValueOutOfRangeException e)
                {
                    Console.WriteLine($"The maxim value is:{e.MaxValue}");
                    Console.WriteLine($"The minim value is:{e.MinValue}");
                }
                catch (Exception e)
                {
                    //TODO how to show the massage
                    Console.WriteLine(e.Message);
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
            string vehicleLicense = getVehicleLicense();
            StringBuilder toPrint = new StringBuilder();
            Dictionary<string, string> dataDictionary = r_GarageManager.GetVehicleData(vehicleLicense);
            foreach (var item in dataDictionary)
            {
                toPrint.Append($"{ToSentenceCaseStartUpperCase(item.Key)}: {item.Value}");
                toPrint.Append(Environment.NewLine);
            }
            Console.Clear();
            Console.WriteLine(toPrint);
            PressAnyKeyToContinue();
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
            Console.WriteLine("Please write your phone number:");
            string phoneNumber = Console.ReadLine();

            return new Owner(name, phoneNumber);
        }

        private Dictionary<string, object> GetVehicleDataFromUser(Dictionary<string, VehicleCreator.RequiredData> i_VehicleRequiresList)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            foreach (KeyValuePair<string, VehicleCreator.RequiredData> fieldData in i_VehicleRequiresList)
            {
                Console.WriteLine(fieldData.Value.Question);
                if (fieldData.Value.InputType.IsEnum)
                {
                    Console.WriteLine("Options: " + string.Join(", ", Enum.GetNames(fieldData.Value.InputType)));
                }

                if (fieldData.Value.InputType == typeof(bool))
                {
                    Console.WriteLine("Options: true, false");
                }
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

        private void getUserChoice()
        {
            GetEnumChoice(out m_UserChoice);
        }

        private void DisplayMenu()
        {
            Console.Clear();
            ShowEnumOptions<eUserChoice>();
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

        private string getVehicleLicense()
        {
            Console.WriteLine("Please enter the vehicle license number");
            string vehicleLicense = Console.ReadLine();
            return vehicleLicense;
        }

        private void changeVehicleStatus()
        {
            string vehicleLicense = getVehicleLicense();
            GarageManager.eVehicleStatus vehicleStatus = r_GarageManager.GetVehicleStatus(vehicleLicense);
            Console.WriteLine($"The current status is: {ToSentenceCaseStartLowerCase(vehicleStatus.ToString())}");
            ShowEnumOptions<GarageManager.eVehicleStatus>();
            GetEnumChoice(out GarageManager.eVehicleStatus newStatus);
            r_GarageManager.ChangeVehicleStatus(vehicleLicense, newStatus);
        }

        private void inflateTires()
        {
            string vehicleLicense = getVehicleLicense();
            Console.WriteLine("How much to inflate?");
            string userInput = Console.ReadLine();
            if (float.TryParse(userInput, out float toInflate))
            {
                r_GarageManager.InflateTires(vehicleLicense, toInflate);
            }
            else
            {
                throw new FormatException();
            }
        }

        private void refuelVehicle()
        {
            string vehicleLicense = getVehicleLicense();
            Console.WriteLine("How much to refuel?");
            string userInput = Console.ReadLine();
            if (float.TryParse(userInput, out float toRefuel))
            {
                r_GarageManager.RefuelVehicle(vehicleLicense, toRefuel);
            }
            else
            {
                throw new FormatException();
            }
        }

        private void rechargeVehicle()
        {
            string vehicleLicense = getVehicleLicense();
            Console.WriteLine("How much to charge?");
            string userInput = Console.ReadLine();
            if (float.TryParse(userInput, out float toCharge))
            {
                r_GarageManager.RechargeVehicle(vehicleLicense, toCharge);
            }
            else
            {
                throw new FormatException();
            }
        }

        public static void ShowEnumOptions<TEnum>()
        {
            StringBuilder toPrint = new StringBuilder();
            toPrint.Append("Please Choose a number from the list below:");
            foreach (string options in Enum.GetNames(typeof(TEnum)))
            {
                toPrint.Append(Environment.NewLine);
                string optionsSentenceCase = ToSentenceCaseStartUpperCase(options);
                toPrint.Append($"{Enum.Parse(typeof(TEnum), options):D}. {optionsSentenceCase}");
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

        public static string ToSentenceCaseStartUpperCase(string i_Str)
        {
            return Regex.Replace(i_Str, "[a-z][A-Z]", m => $"{m.Value[0]} {char.ToLower(m.Value[1])}");
        }

        public static string ToSentenceCaseStartLowerCase(string i_Str)
        {
            return Regex.Replace(i_Str, "[a-z][A-Z]", m => $"{char.ToLower(m.Value[0])} {char.ToLower(m.Value[1])}");
        }
    }
}