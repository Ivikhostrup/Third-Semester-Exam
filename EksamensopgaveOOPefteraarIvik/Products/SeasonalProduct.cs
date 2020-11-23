using System;
using System.Threading;

namespace EksamensopgaveOOPefteraarIvik.Products
{
    public class SeasonalProduct : ProductBase
    {
        private static int idCount = 0;
        public int MyId { get; private set; }

        public string Name { get; private set; }

        public decimal Price { get; private set; }
        
        public bool IsActive { get; private set; }
        
        public bool CanBeBoughtOnCredit { get; private set; }

        public DateTime SeasonStartDate { get; private set; }

        public DateTime SeasonEndDate { get; private set; }
        
        // Interlocked.Increment safeguards against multiple concurrent updates to MyID
        public SeasonalProduct(string name, decimal price, DateTime seasonStartDate, DateTime seasonEndDate,
                                bool isActive, bool canBeBoughtOnCredit) 
            : base(name, price, isActive, canBeBoughtOnCredit)
        {
            MyId = Interlocked.Increment(ref idCount);
            Name = name;
            Price = price;
            IsActive = isActive;
            CanBeBoughtOnCredit = canBeBoughtOnCredit;
            
            SeasonStartDate = seasonStartDate;
            SeasonEndDate = seasonEndDate;
        }
        
        public override string ToString()
        {
            return MyId + Name + Price;
        }
    }
}