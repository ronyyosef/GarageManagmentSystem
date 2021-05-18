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
                    displayMenu();
                    GetEnumChoice(out m_UserChoice);
                    Console.Clear();
                    switch (m_UserChoice)
                    {
                        case eUserChoice.AddNewVehicleToTheGarage:
                            addNewVehicleToTheGarage();
                            break;

                        case eUserChoice.DisplayAllVehiclesInTheGarage:
                            displayAllVehiclesLicenseNumber();
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
                    Console.WriteLine(e.Message);
                    Console.WriteLine($"The maximum value is: {e.MaxValue}");
                    Console.WriteLine($"The minimum value is: {e.MinValue}");
                    PressAnyKeyToContinue();
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"The input is not in the correct format: {e.Message}");
                    PressAnyKeyToContinue();
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"This is not a valid operation: {e.Message}");
                    PressAnyKeyToContinue();
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
            string vehicleLicense = getVehicleLicense();
            StringBuilder toPrint = new StringBuilder();
            Dictionary<string, string> dataDictionary = r_GarageManager.GetVehicleData(vehicleLicense);
            foreach (var item in dataDictionary)
            {
                toPrint.Append($"{CamelcaseToSentenceCase(item.Key)}: {item.Value}");
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
            Dictionary<string, object> vehicleDataList = getVehicleDataFromUser(vehicleRequiresDictionary);
            Vehicle newVehicle = VehicleCreator.Create(userInput, vehicleDataList);
            Owner newOwner = getOwnerData();
            r_GarageManager.AddVehicle(newVehicle, newOwner);
        }

        private static Owner getOwnerData()
        {
            Console.WriteLine("Please enter your Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Please enter your phone number:");
            string phoneNumber = Console.ReadLine();
            return new Owner(name, phoneNumber);
        }

        private static Dictionary<string, object> getVehicleDataFromUser(Dictionary<string, VehicleCreator.RequiredData> i_VehicleRequiresList)
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
                if (converter.IsValid(userInput))
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

        private static void displayMenu()
        {
            Console.Clear();
            ShowEnumOptions<eUserChoice>();
        }

        private void displayAllVehiclesLicenseNumber()
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
            int index = 1;
            if (allVehiclesLicenseNumber.Count == 0)
            {
                toPrint.Append("There are no vehicles in that status");
            }
            foreach (string licenseNumber in allVehiclesLicenseNumber)
            {
                toPrint.Append($"{index}. ");
                toPrint.Append(licenseNumber);
                toPrint.Append(Environment.NewLine);
                index++;
            }
            Console.Clear();
            Console.WriteLine(toPrint);
            PressAnyKeyToContinue();
        }

        private void displayAllVehiclesLicenseNumberFiltered(List<string> i_AllVehiclesLicenseNumber)
        {
            StringBuilder filterPrint = new StringBuilder();
            Console.WriteLine("Which of the following status do you want to filter by? ");
            ShowEnumOptions<GarageManager.eVehicleStatus>();
            GetEnumChoice<GarageManager.eVehicleStatus>(out GarageManager.eVehicleStatus userChoice);
            r_GarageManager.AllVehiclesLicenseNumberListFiltered(i_AllVehiclesLicenseNumber, userChoice);
        }

        private static string getVehicleLicense()
        {
            Console.WriteLine("Please enter the vehicle license number:");
            string vehicleLicense = Console.ReadLine();
            return vehicleLicense;
        }

        private void changeVehicleStatus()
        {
            string vehicleLicense = getVehicleLicense();
            GarageManager.eVehicleStatus vehicleStatus = r_GarageManager.GetVehicleStatus(vehicleLicense);
            Console.WriteLine($"The current status is: {CamelcaseToSentenceCase(vehicleStatus.ToString())}");
            ShowEnumOptions<GarageManager.eVehicleStatus>();
            GetEnumChoice(out GarageManager.eVehicleStatus newStatus);
            r_GarageManager.ChangeVehicleStatus(vehicleLicense, newStatus);
            Console.WriteLine("Vehicle status changed successfully");
            PressAnyKeyToContinue();
        }

        private void inflateTires()
        {
            string vehicleLicense = getVehicleLicense();
            Console.WriteLine("How much to inflate?");
            string userInput = Console.ReadLine();
            if (float.TryParse(userInput, out float toInflate))
            {
                r_GarageManager.InflateTires(vehicleLicense, toInflate);
                Console.WriteLine($"All tires has been inflated by {toInflate}");
                PressAnyKeyToContinue();
            }
            else
            {
                throw new FormatException();
            }
        }

        private void refuelVehicle()
        {
            string vehicleLicense = getVehicleLicense();
            Console.WriteLine("What is the fuel type?");
            ShowEnumOptions<GasVehicle.eFuelType>();
            GetEnumChoice(out GasVehicle.eFuelType fuelType);
            Console.WriteLine("How much to refuel?");
            string userInput = Console.ReadLine();
            if (float.TryParse(userInput, out float toRefuel))
            {
                r_GarageManager.RefuelVehicle(vehicleLicense, fuelType, toRefuel);
                Console.WriteLine($"Vehicle has been refueled by {toRefuel}");
                PressAnyKeyToContinue();
            }
            else
            {
                throw new FormatException();
            }
        }

        private void rechargeVehicle()
        {
            string vehicleLicense = getVehicleLicense();
            Console.WriteLine("How many minutes to recharge?");
            string userInput = Console.ReadLine();
            if (float.TryParse(userInput, out float toCharge))
            {
                r_GarageManager.RechargeVehicle(vehicleLicense, toCharge / 60f);
                Console.WriteLine($"Vehicle has been recharged by {toCharge}");
                PressAnyKeyToContinue();
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
                toPrint.Append($"{Enum.Parse(typeof(TEnum), options):D}. {CamelcaseToSentenceCase(options)}");
            }
            Console.WriteLine(toPrint);
        }

        public void GetEnumChoice<TEnum>(out TEnum i_UserChoice) where TEnum : struct // will provide insurance that TEnum isn't nullable
        {
            int amountOfOptions = Enum.GetNames(typeof(TEnum)).Length;
            string userInput = Console.ReadLine();
            if (Enum.TryParse<TEnum>(userInput, out i_UserChoice) && Enum.IsDefined(typeof(TEnum), i_UserChoice) == false)
            {
                throw new FormatException();
            }
        }

        public static string CamelcaseToSentenceCase(string i_Str)
        {
            if (char.IsLower(i_Str[0]))
            {
                i_Str = $"{char.ToUpper(i_Str[0]) + i_Str.Substring(1)}";
            }
            string output = Regex.Replace(i_Str, @"\p{Lu}", m => " " + m.Value.ToLowerInvariant());
            return $"{char.ToUpper(output[1]) + output.Substring(2)}";
        }
    }
}