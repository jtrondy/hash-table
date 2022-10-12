namespace hash_table
{
    public class Jersey_Cow : Cow
    {
        public Jersey_Cow(int Id, double AmtMilk)
            : base(Id, AmtMilk)
        {
            // uses base Cow constructor
        }

        override public double CalculateProfitPerDay()
        {
            return (AmtMilk * Prices.cowMilkPrice) - (Prices.jerseyVaccineCost / 365);
        }
    }
}
