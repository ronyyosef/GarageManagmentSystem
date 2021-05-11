using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class GasVehicle : Vehicle
    {
        private const float k_MinFuel = 0;

        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98,
        }

        protected GasVehicle(eFuelType i_FuelType, float i_CurrentFuelAmountLiter, float i_MaxFuelAmountLiter, List<Wheel> i_Wheels, string i_ModelName, string i_LicenseNumber) : base(i_Wheels, i_ModelName, i_LicenseNumber)
        {
            r_FuelType = i_FuelType;
            CurrentFuelAmountLiter = i_CurrentFuelAmountLiter;
            maxFuelCheck(i_MaxFuelAmountLiter);
            r_MaxFuelAmountLiter = i_MaxFuelAmountLiter;
            EnergyPercent = (i_CurrentFuelAmountLiter / i_MaxFuelAmountLiter) * 100;
        }

        private static void maxFuelCheck(float i_MaxFuelAmountLiter)
        {
            if (i_MaxFuelAmountLiter < k_MinFuel)
            {
                throw new ValueOutOfRangeException("Max fuel isn't checked ,Fuel Amount", k_MinFuel, float.MaxValue);
            }
        }

        public void Refuel(float i_ToAdd)
        {
            CurrentFuelAmountLiter += i_ToAdd;
        }

        private readonly eFuelType r_FuelType;

        private float m_CurrentFuelAmountLiter;

        public float CurrentFuelAmountLiter
        {
            get
            {
                return m_CurrentFuelAmountLiter;
            }
            set
            {
                if (value > r_MaxFuelAmountLiter || value < k_MinFuel)
                {
                    throw new ValueOutOfRangeException("Fuel Amount", k_MinFuel, r_MaxFuelAmountLiter);
                }

                EnergyPercent = (value / r_MaxFuelAmountLiter) * 100;
                m_CurrentFuelAmountLiter = value;
            }
        }

        private readonly float r_MaxFuelAmountLiter;
    }
}