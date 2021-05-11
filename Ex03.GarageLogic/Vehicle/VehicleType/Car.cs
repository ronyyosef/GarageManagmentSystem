using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private readonly eDoorsNumber r_Doors;
        private readonly eColors r_CarColor;
    }
}