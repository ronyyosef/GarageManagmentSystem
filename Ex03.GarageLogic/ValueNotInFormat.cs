using System;

namespace Ex03.GarageLogic
{
    public class ValueNotInFormat : Exception
    {
        public ValueNotInFormat()
        {
        }

        public ValueNotInFormat(string i_Message) : base($"Error : {i_Message}")
        {
        }

        public ValueNotInFormat(string i_Message, Exception i_Inner) : base(i_Message, i_Inner)
        {
        }
    }
}