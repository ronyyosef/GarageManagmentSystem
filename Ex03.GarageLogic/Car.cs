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

        private eDoorsNumber r_doors;
        private eColors r_CarColor;
    }
}