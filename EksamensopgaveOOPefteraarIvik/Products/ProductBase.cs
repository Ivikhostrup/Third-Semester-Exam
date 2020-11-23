namespace EksamensopgaveOOPefteraarIvik.Products
{
    public abstract class ProductBase : IProductBase
    {
        // Look into making abstract/virtual properties
        public int MyId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        
        public bool IsActive { get; set; }
        
        public bool CanBeBoughtOnCredit { get; set; }

        public ProductBase(string name, decimal price, bool isActive, bool canBeBoughtOnCredit)
        {
            Name = name;
            Price = price;
            IsActive = isActive;
            CanBeBoughtOnCredit = canBeBoughtOnCredit;
        }

        public abstract override string ToString();
    }
}