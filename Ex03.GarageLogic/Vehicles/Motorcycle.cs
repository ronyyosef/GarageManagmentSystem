using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Motorcycle
    {
        public enum eLicenseType
        {
            A,
            B1,
            AA,
            BB,
        }

        public const int k_NumberOfWheels = 2;
        public const float k_MaxAirPressure = 30;

        public static Dictionary<string, VehicleCreator.RequiredData> RequiredData()
        {
            Dictionary<string, VehicleCreator.RequiredData> result = new Dictionary<string, VehicleCreator.RequiredData>();
            result.Add("licenseType", new VehicleCreator.RequiredData("Please enter your motorcycle license type:", typeof(eLicenseType)));
            result.Add("engineCapacityCc", new VehicleCreator.RequiredData("Please enter your motorcycle engine capacity CC:", typeof(int)));
            return result;
        }

        public void Init(Dictionary<string, object> i_DataDictionary)
        {
            LicenseType = (eLicenseType)i_DataDictionary["licenseType"];
            EngineCapacityCc = (int)i_DataDictionary["engineCapacityCc"];
        }

        public eLicenseType LicenseType { get; set; }

        public int EngineCapacityCc { get; set; }

        public void GetData(Dictionary<string, string> i_Dictionary)
        {
            i_Dictionary.Add("licenseType", LicenseType.ToString());
            i_Dictionary.Add("engineCapacityCc", EngineCapacityCc.ToString());
        }
    }
}