using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private const float k_MaxPercent = 100;
        private const float k_MinPercent = 0;
        private readonly List<Wheel> r_Wheels = new List<Wheel>();
        private string m_ModelName;
        private float m_EnergyPercent;

        protected Vehicle(int i_NumberOfWheels, float i_MaxAirPressure)
        {
            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                r_Wheels.Add(new Wheel(i_MaxAirPressure));
            }
        }

        public static Dictionary<string, VehicleCreator.RequiredData> RequiredData()
        {
            Dictionary<string, VehicleCreator.RequiredData> result = new Dictionary<string, VehicleCreator.RequiredData>();
            foreach (KeyValuePair<string, VehicleCreator.RequiredData> require in Wheel.RequiredData())
            {
                result.Add(require.Key, require.Value);
            }

            result.Add("modelName", new VehicleCreator.RequiredData("Please enter your vehicle model name:", typeof(string)));
            result.Add("licenseNumber", new VehicleCreator.RequiredData("Please enter your vehicle license number:", typeof(string)));
            return result;
        }

        public virtual void Init(Dictionary<string, object> i_DataDictionary)
        {
            for (int i = 0; i < r_Wheels.Count; i++)
            {
                r_Wheels[i].Init(i_DataDictionary);
            }

            m_ModelName = (string)i_DataDictionary["modelName"];
            LicenseNumber = (string)i_DataDictionary["licenseNumber"];
        }

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
                    throw new ValueOutOfRangeException("Percent out of range,need to be between 0-100.", k_MinPercent, k_MaxPercent);
                }

                m_EnergyPercent = value;
            }
        }

        public string LicenseNumber { get; set; }

        public void Inflate(float i_QuaToInflate)
        {
            foreach (Wheel singleWheel in r_Wheels)
            {
                singleWheel.Inflate(i_QuaToInflate);
            }
        }

        public virtual void GetData(Dictionary<string, string> i_Dictionary)
        {
            StringBuilder wheelsData = new StringBuilder();
            wheelsData.Append($"There are {r_Wheels.Count} wheels:");
            for (int i = 0; i < r_Wheels.Count; i++)
            {
                wheelsData.Append(Environment.NewLine);
                wheelsData.Append($"{i + 1}. {r_Wheels[i].ToString()}");
            }

            i_Dictionary.Add("wheels", wheelsData.ToString());
            i_Dictionary.Add("modelName", m_ModelName);
            i_Dictionary.Add("energyPercent", $"{EnergyPercent:0.00}%");
            i_Dictionary.Add("licenseNumber", LicenseNumber.ToString());
        }
    }
}