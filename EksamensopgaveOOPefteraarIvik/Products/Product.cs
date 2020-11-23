using System.Threading;

namespace EksamensopgaveOOPefteraarIvik.Products
{
    public class Product : ProductBase
    {
        

        // Interlocked.Increment safeguards against multiple concurrent updates to MyID
        public Product(string name, decimal price, bool isActive, bool canBeBoughtOnCredit) : base(name, price, isActive, canBeBoughtOnCredit)
        {
            
        }
        
        public override string ToString()
        {
            return MyId + ' ' + Name + ' '  + Price;
        }
    }
}