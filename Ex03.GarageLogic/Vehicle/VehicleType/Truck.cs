using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class Truck
    {
        public Truck(bool i_CarryingHazardousMaterials, float i_MaximumCarryingWeight)
        {
            r_CarryingHazardousMaterials = i_CarryingHazardousMaterials;
            r_MaximumCarryingWeight = i_MaximumCarryingWeight;
        }

        public static List<VehicleCreator.RequiredData> RequiredData()
        {
            List<VehicleCreator.RequiredData> result = new List<VehicleCreator.RequiredData>
                                                           {
                                                               new VehicleCreator.RequiredData(
                                                                   "Please enter if the truck carrying hazardous materials:",
                                                                   typeof(bool)),
                                                               new VehicleCreator.RequiredData(
                                                                   "Please enter the truck maximum carrying weight:",
                                                                   typeof(float))
                                                           };
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