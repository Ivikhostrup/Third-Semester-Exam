using System.Threading;

namespace EksamensopgaveOOPefteraarIvik.Products
{
    public abstract class ProductBase : IProductBase
    {
        // Look into making abstract/virtual properties
        private static int idCount = 0;
        public int MyId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        
        public bool IsActive { get; set; }
        
        public bool CanBeBoughtOnCredit { get; set; }

        public ProductBase(string name, decimal price, bool isActive, bool canBeBoughtOnCredit)
        {
            MyId = Interlocked.Increment(ref idCount);
            Name = name;
            Price = price;
            IsActive = isActive;
            CanBeBoughtOnCredit = canBeBoughtOnCredit;
        }

        public abstract override string ToString();
    }
}