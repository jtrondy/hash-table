namespace hash_table
{
    public class Goat : Animal
    {
        public double AmtMilk { get; }

        public Goat(int Id, double AmtMilk)
            : base(Id)
        {
            this.AmtMilk = AmtMilk;
        }

        override public double CalculateProfitPerDay()
        {
            return (AmtMilk * Prices.goatMilkPrice) - (Prices.goatVaccineCost / 365);
        }
    }
}
