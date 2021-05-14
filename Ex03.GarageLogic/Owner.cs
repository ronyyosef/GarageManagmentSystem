using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Owner
    {
        public Owner(string i_Name, string i_PhoneNumber)
        {
            Name = i_Name;
            PhoneNumber = i_PhoneNumber;
        }

        public string Name { get; private set; }

        public string PhoneNumber { get; private set; }

        public void GetData(Dictionary<string, string> i_Dictionary)
        {
            i_Dictionary.Add("ownerName", Name);
            i_Dictionary.Add("ownerPhoneNumber", PhoneNumber);
        }
    }
}