using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Truck
    {
        public Truck(bool i_carringHazardousMaterials, float i_MaximumCarryingWeight)
        {
            r_carringHazardousMaterials = i_carringHazardousMaterials;
            r_MaximumCarryingWeight = i_MaximumCarryingWeight;
        }

        public bool CarringHazardousMaterials
        {
            get
            {
                return r_carringHazardousMaterials;
            }
        }

        public float MaximumCarryingWeight
        {
            get
            {
                return r_MaximumCarryingWeight;
            }
        }

        private bool r_carringHazardousMaterials;
        private float r_MaximumCarryingWeight;
    }
}