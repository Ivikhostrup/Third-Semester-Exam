namespace EksamensopgaveOOPefteraarIvik
{
    public abstract class ProductBase : IProductBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        
        public bool IsActive { get; set; }
        
        public bool CanBeBoughtOnCredit { get; set; }

        public ProductBase(int id, string name, decimal price, bool isActive, bool canBeBoughtOnCredit)
        {
            Id = id;
            Name = name;
            Price = price;
            IsActive = isActive;
            CanBeBoughtOnCredit = canBeBoughtOnCredit;
        }

        public abstract override string ToString();
    }
}