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
    }
}