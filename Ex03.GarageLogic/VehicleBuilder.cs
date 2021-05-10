using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public static class VehicleBuilder
    {
        public static GasCar CreateNewGasCar()
        {
            return new GasCar();
        }

        public static ElectricCar CreateNewElectricCar()
        {
            return new ElectricCar();
        }

        public static GasMotorcycle CreateNewGasMotorcycle()
        {
            return new GasMotorcycle();
        }

        public static ElectricMotorcycle CreateNewElectricMotorcycle()
        {
            return new ElectricMotorcycle();
        }

        public static GasTruck CreateNewGasTruck()
        {
            return new GasTruck();
        }
        
        public static List<string> VehiclesTypeList()
        {
            List<string> resultList = new List<string>();


            /*
            var values = AppDomain.CurrentDomain.GetAssemblies()
                       .SelectMany(assembly => assembly.GetTypes())
                       .Where(type => type.IsSubclassOf(typeof(Vehicle)));
            foreach(var value in values)
            {
                if (value.IsAbstract)
                {
                    continue;
                }
                Console.WriteLine(value.Name);
            }
            */
            return resultList;
        }
    }
}
