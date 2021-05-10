using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Motorcycle
    {
        public enum eLicenseType
        {
            A,
            B1,
            AA,
            BB,
        }

        public Motorcycle(eLicenseType i_LicenseType, int i_EngineCapacityCC)
        {
            r_LicenseType = i_LicenseType;
            r_EngineCapacityCC = i_EngineCapacityCC;
        }

        public eLicenseType LicenseType
        {
            get
            {
                return r_LicenseType;
            }
        }

        public int EngineCapacityCC
        {
            get
            {
                return r_EngineCapacityCC;
            }
        }

        private eLicenseType r_LicenseType;
        private int r_EngineCapacityCC;
    }
}