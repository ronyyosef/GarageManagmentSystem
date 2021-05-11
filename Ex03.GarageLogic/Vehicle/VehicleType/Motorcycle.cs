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

        public eLicenseType LicenseType { get; }

        public int EngineCapacityCc { get; }
    }
}