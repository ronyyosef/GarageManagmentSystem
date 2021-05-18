using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class Truck
    {
        public const int k_NumberOfWheels = 16;
        public const float k_MaxAirPressure = 26;

        public static Dictionary<string, VehicleCreator.RequiredData> RequiredData()
        {
            Dictionary<string, VehicleCreator.RequiredData> result = new Dictionary<string, VehicleCreator.RequiredData>();
            result.Add("carryingHazardousMaterials", new VehicleCreator.RequiredData("Please enter if the truck carrying hazardous materials:", typeof(bool)));
            result.Add("maximumCarryingWeight", new VehicleCreator.RequiredData("Please enter the truck maximum carrying weight:", typeof(float)));
            return result;
        }

        public void Init(Dictionary<string, object> i_DataDictionary)
        {
            m_CarryingHazardousMaterials = (bool)i_DataDictionary["carryingHazardousMaterials"];
            m_MaximumCarryingWeight = (float)i_DataDictionary["maximumCarryingWeight"];
        }

        public bool CarryingHazardousMaterials
        {
            get
            {
                return m_CarryingHazardousMaterials;
            }
        }

        public float MaximumCarryingWeight
        {
            get
            {
                return m_MaximumCarryingWeight;
            }
        }

        public void GetData(Dictionary<string, string> i_Dictionary)
        {
            i_Dictionary.Add("carryingHazardousMaterials", CarryingHazardousMaterials == true ? "Yes" : "No");
            i_Dictionary.Add("maximumCarryingWeight", MaximumCarryingWeight.ToString());
        }

        private bool m_CarryingHazardousMaterials;
        private float m_MaximumCarryingWeight;
    }
}