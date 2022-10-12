namespace hash_table
{
    public class Cow : Animal
    {
        public double AmtMilk { get; }

        public Cow(int Id, double AmtMilk)
            : base(Id)
        {
            this.AmtMilk = AmtMilk;
        }

        override public double CalculateProfitPerDay()
        {
            return (AmtMilk * Prices.cowMilkPrice) - (Prices.cowVaccineCost / 365);
        }
    }
}
