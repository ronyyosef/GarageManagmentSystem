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

        public static List<VehicleCreator.RequiredData> RequiredData()
        {
            List<VehicleCreator.RequiredData> result = new List<VehicleCreator.RequiredData>
                                                           {
                                                               new VehicleCreator.RequiredData(
                                                                   "Please enter the motorcycle license type:",
                                                                   typeof(eLicenseType)),
                                                               new VehicleCreator.RequiredData(
                                                                   "Please enter the motorcycle engine capacity CC:",
                                                                   typeof(int))
                                                           };
            return result;
        }

        public eLicenseType LicenseType { get; }

        public int EngineCapacityCc { get; }
    }
}