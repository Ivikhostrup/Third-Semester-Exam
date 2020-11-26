using System.Text.RegularExpressions;
using System.Threading;

namespace EksamensopgaveOOPefteraarIvik.Products
{
    public class Product : ProductBase
    {
       public Product(char separator, string csvLine) : base(separator, csvLine)
        {
            
        }
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