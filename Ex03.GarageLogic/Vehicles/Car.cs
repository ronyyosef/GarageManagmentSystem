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

        public const int k_NumberOfWheels = 4;
        public const float k_MaxAirPressure = 32;

        public static Dictionary<string, VehicleCreator.RequiredData> RequiredData()
        {
            Dictionary<string, VehicleCreator.RequiredData> result = new Dictionary<string, VehicleCreator.RequiredData>();
            result.Add("doorNumber", new VehicleCreator.RequiredData("Please enter the how many doors your car has:", typeof(eDoorsNumber)));
            result.Add("carColor", new VehicleCreator.RequiredData("Please enter your car color:", typeof(eColors)));
            return result;
        }

        public void Init(Dictionary<string, object> i_DataDictionary)
        {
            m_Doors = (eDoorsNumber)i_DataDictionary["doorNumber"];
            m_CarColor = (eColors)i_DataDictionary["carColor"];
        }

        private eDoorsNumber m_Doors;
        private eColors m_CarColor;

        public void GetData(Dictionary<string, string> i_Dictionary)
        {
            i_Dictionary.Add("doorNumber", m_Doors.ToString());
            i_Dictionary.Add("carColor", m_CarColor.ToString());
        }
    }
}