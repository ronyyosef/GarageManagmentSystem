using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private const float k_MaxPercent = 100;
        private const float k_MinPercent = 0;

        //TODO delete
        protected Vehicle(List<Wheel> i_Wheels, string i_ModelName, string i_LicenseNumber)
        {
            r_Wheels = i_Wheels;
            r_ModelName = i_ModelName;
            LicenseNumber = i_LicenseNumber;
        }

        protected Vehicle(Dictionary<string, object> i_DataDictionary)
        {
            r_Wheels = new List<Wheel>();
            for (int i = 0; i < (int)i_DataDictionary["numOfWheels"]; i++)
            {
                r_Wheels.Add(new Wheel((float)i_DataDictionary["currentAirPressure"], (float)i_DataDictionary["maxAirPressure"], (string)i_DataDictionary["manufacturerName"]));
            }
            r_ModelName = (string)i_DataDictionary["modelName"];
            LicenseNumber = (string)i_DataDictionary["licenseNumber"];
        }

        public static Dictionary<string, VehicleCreator.RequiredData> RequiredData()
        {
            Dictionary<string, VehicleCreator.RequiredData> result = new Dictionary<string, VehicleCreator.RequiredData>();
            result.Add("numOfWheels", new VehicleCreator.RequiredData("please enter how many wheels your vehicle have", typeof(int)));
            foreach (KeyValuePair<string, VehicleCreator.RequiredData> Require in Wheel.RequiredData())
            {
                result.Add(Require.Key, Require.Value);
            }
            result.Add("modelName", new VehicleCreator.RequiredData("please enter how many your vehicle model name", typeof(string)));
            result.Add("licenseNumber", new VehicleCreator.RequiredData("please enter how many your vehicle license number", typeof(string)));
            return result;
        }

        private readonly List<Wheel> r_Wheels;

        private readonly string r_ModelName;

        private string m_LicenseNumber;

        private float m_EnergyPercent;

        public float EnergyPercent
        {
            get
            {
                return m_EnergyPercent;
            }
            set
            {
                if (m_EnergyPercent < k_MinPercent || m_EnergyPercent > k_MaxPercent)
                {
                    throw new ValueOutOfRangeException(
                        "Percent out of need to be between 0-100",
                        k_MinPercent,
                        k_MaxPercent);
                }

                m_EnergyPercent = value;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }
            set
            {
                if (int.TryParse(value, out int _) == false)
                {
                    throw new ValueNotInFormatException("License Number have to be a number");
                }

                m_LicenseNumber = value;
            }
        }
    }
}