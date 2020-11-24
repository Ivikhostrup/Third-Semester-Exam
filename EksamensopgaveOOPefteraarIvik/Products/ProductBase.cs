using System.Threading;

namespace EksamensopgaveOOPefteraarIvik.Products
{
    public abstract class ProductBase : IProductBase
    {
        public uint MyId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        
        public bool IsActive { get; set; }
        
        public bool CanBeBoughtOnCredit { get; set; }

        public ProductBase(uint myId, string name, decimal price, bool isActive, bool canBeBoughtOnCredit)
        {
            MyId = myId;
            Name = name;
            Price = price;
            IsActive = isActive;
            CanBeBoughtOnCredit = canBeBoughtOnCredit;
        }

        public abstract override string ToString();
    }
}