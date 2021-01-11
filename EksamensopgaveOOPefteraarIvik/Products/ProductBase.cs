using System.Text.RegularExpressions;
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

        public ProductBase(char separator, string csvLine)
        {
            string[] field = csvLine.Split(separator);

            MyId = uint.Parse(field[0]);
            Name = field[1];
            Name = Regex.Replace(Name, "<.*?>", string.Empty);
            Price = decimal.Parse(field[2]);
            IsActive = field[3] != "0";
        }

        public ProductBase(uint myId, string name, decimal price, bool isActive, bool canBeBoughtOnCredit)
        {
            MyId = myId;
            Name = name;
            Price = price;
            IsActive = isActive;
            CanBeBoughtOnCredit = canBeBoughtOnCredit;
        }
        
        // Forcing derived class to provide a new implementation
        public abstract override string ToString();
    }
}