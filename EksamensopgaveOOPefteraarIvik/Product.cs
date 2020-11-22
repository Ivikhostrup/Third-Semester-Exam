namespace EksamensopgaveOOPefteraarIvik
{
    public class Product : ProductBase
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public bool IsActive { get; private set; }
        public bool CanBeBoughtOnCredit { get; private set; }

        public Product(int id, string name, decimal price, bool isActive, bool canBeBoughtOnCredit) : base(id, name, price, isActive, canBeBoughtOnCredit)
        {
            Id = id;
            Name = name;
            Price = price;
            IsActive = isActive;
            CanBeBoughtOnCredit = canBeBoughtOnCredit;
        }
        
        public override string ToString()
        {
            return Id + ' ' + Name + ' '  + Price;
        }
    }
}