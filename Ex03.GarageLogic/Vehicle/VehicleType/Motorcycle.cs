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

        public Motorcycle(eLicenseType i_LicenseType, int i_EngineCapacityCc)
        {
            LicenseType = i_LicenseType;
            EngineCapacityCc = i_EngineCapacityCc;
        }

        public Motorcycle(Dictionary<string, object> i_DataDictionary)
        {
            LicenseType = (eLicenseType)i_DataDictionary["licenseType"];
            EngineCapacityCc = (int)i_DataDictionary["engineCapacityCc"];
        }

        public static Dictionary<string, VehicleCreator.RequiredData> RequiredData()
        {
            Dictionary<string, VehicleCreator.RequiredData> result = new Dictionary<string, VehicleCreator.RequiredData>();
            result.Add("licenseType", new VehicleCreator.RequiredData("Please enter the motorcycle license type:", typeof(eLicenseType)));
            result.Add("engineCapacityCc", new VehicleCreator.RequiredData("Please enter the motorcycle engine capacity CC:", typeof(int)));
            return result;
        }

        public eLicenseType LicenseType { get; }

        public int EngineCapacityCc { get; }
    }
}