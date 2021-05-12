using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Car
    {
        public enum eColors
        {
            Red,
            Silver,
            White,
            Black,
        }

        public enum eDoorsNumber
        {
            Two,
            Three,
            Four,
            Five,
        }

        public Car(eDoorsNumber i_DoorNumber, eColors i_CarColor)
        {
            r_Doors = i_DoorNumber;
            r_CarColor = i_CarColor;
        }

        public static List<VehicleCreator.RequiredData> RequiredData()
        {
            List<VehicleCreator.RequiredData> result = new List<VehicleCreator.RequiredData>
                                                           {
                                                               new VehicleCreator.RequiredData(
                                                                   "How many doors your car have?",
                                                                   typeof(eDoorsNumber)),
                                                               new VehicleCreator.RequiredData(
                                                                   "What is your car color?",
                                                                   typeof(eColors))
                                                           };
            return result;
        }

        private readonly eDoorsNumber r_Doors;
        private readonly eColors r_CarColor;
    }
}