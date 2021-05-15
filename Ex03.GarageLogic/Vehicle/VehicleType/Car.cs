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

        public Car(Dictionary<string, object> i_DataDictionary)
        {
            r_Doors = (eDoorsNumber)i_DataDictionary["doorNumber"];
            r_CarColor = (eColors)i_DataDictionary["carColor"];
        }

        public static Dictionary<string, VehicleCreator.RequiredData> RequiredData()
        {
            Dictionary<string, VehicleCreator.RequiredData> result = new Dictionary<string, VehicleCreator.RequiredData>();
            result.Add("doorNumber", new VehicleCreator.RequiredData("How many doors your car have?", typeof(eDoorsNumber)));
            result.Add("carColor", new VehicleCreator.RequiredData("What is your car color?", typeof(eColors)));
            return result;
        }

        private readonly eDoorsNumber r_Doors;
        private readonly eColors r_CarColor;

        public void GetData(Dictionary<string, string> i_Dictionary)
        {
            i_Dictionary.Add("doorNumber", r_Doors.ToString());
            i_Dictionary.Add("carColor", r_CarColor.ToString());
        }
    }
}