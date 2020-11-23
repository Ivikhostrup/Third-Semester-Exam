using System.Threading;

namespace EksamensopgaveOOPefteraarIvik.Products
{
    public class Product : ProductBase
    {
        private static int idCount = 0;
        public int MyId { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public bool IsActive { get; private set; }
        public bool CanBeBoughtOnCredit { get; private set; }

        // Interlocked.Increment safeguards against multiple concurrent updates to MyID
        public Product(string name, decimal price, bool isActive, bool canBeBoughtOnCredit) : base(name, price, isActive, canBeBoughtOnCredit)
        {
            MyId = Interlocked.Increment(ref idCount);
            Name = name;
            Price = price;
            IsActive = isActive;
            CanBeBoughtOnCredit = canBeBoughtOnCredit;
        }
        
        public override string ToString()
        {
            return MyId + ' ' + Name + ' '  + Price;
        }
    }
}