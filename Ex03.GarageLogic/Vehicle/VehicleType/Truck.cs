using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class Truck
    {
        //TODO delete
        public Truck(bool i_CarryingHazardousMaterials, float i_MaximumCarryingWeight)
        {
            r_CarryingHazardousMaterials = i_CarryingHazardousMaterials;
            r_MaximumCarryingWeight = i_MaximumCarryingWeight;
        }

        public Truck(Dictionary<string, object> i_DataDictionary)
        {
            r_CarryingHazardousMaterials = (bool)i_DataDictionary["carryingHazardousMaterials"];
            r_MaximumCarryingWeight = (float)i_DataDictionary["maximumCarryingWeight"];
        }


        public static Dictionary<string, VehicleCreator.RequiredData> RequiredData()
        {
            Dictionary<string, VehicleCreator.RequiredData> result = new Dictionary<string, VehicleCreator.RequiredData>();
            result.Add("carryingHazardousMaterials", new VehicleCreator.RequiredData("Please enter if the truck carrying hazardous materials:", typeof(bool)));
            result.Add("maximumCarryingWeight", new VehicleCreator.RequiredData("Please enter the truck maximum carrying weight:", typeof(float)));
            return result;
        }

        public bool CarryingHazardousMaterials
        {
            get
            {
                return r_CarryingHazardousMaterials;
            }
        }

        public float MaximumCarryingWeight
        {
            get
            {
                return r_MaximumCarryingWeight;
            }
        }

        private readonly bool r_CarryingHazardousMaterials;
        private readonly float r_MaximumCarryingWeight;
    }
}