namespace hash_table
{
    // declare as abstract to forbid instantiation of class but allow for inheritance.
    abstract public class Animal
    {
        public int Id { get; }

        public Animal(int Id)
        {
            this.Id = Id;
        }

        // virtual modifer lets subclasses override method.
        virtual public double CalculateProfitPerDay()
        {
            return 0;
        }
    }
}

