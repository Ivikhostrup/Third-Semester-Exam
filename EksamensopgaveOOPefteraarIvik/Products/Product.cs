using System.Threading;

namespace EksamensopgaveOOPefteraarIvik.Products
{
    public class Product : ProductBase
    {
        public Product(uint myId, string name, decimal price, bool isActive, bool canBeBoughtOnCredit) 
            : base(myId, name, price, isActive, canBeBoughtOnCredit)
        {
            
        }
        
        public override string ToString()
        {
            return MyId + ' ' + Name + ' '  + Price;
        }
    }
}