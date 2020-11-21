namespace EksamensopgaveOOPefteraarIvik
{
    public abstract class ProductBase
    {
        private int Id { get; set; }
        private string Name { get; set; }
        private decimal Price { get; set; }

        public ProductBase(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public abstract override string ToString();
    }
}