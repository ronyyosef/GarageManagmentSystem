using System;

namespace Ex03.GarageLogic
{
    public class ValueNotInFormatException : Exception
    {
        public ValueNotInFormatException()
        {
        }

        public ValueNotInFormatException(string i_Message) : base($"Error : {i_Message}")
        {
        }

        public ValueNotInFormatException(string i_Message, Exception i_Inner) : base(i_Message, i_Inner)
        {
        }
    }
}