using System;
using System.Threading;

namespace EksamensopgaveOOPefteraarIvik.Products
{
    public class SeasonalProduct : ProductBase
    {
        public DateTime SeasonStartDate { get; private set; }

        public DateTime SeasonEndDate { get; private set; }
        
        // Interlocked.Increment safeguards against multiple concurrent updates to MyID
        public SeasonalProduct(string name, decimal price, DateTime seasonStartDate, DateTime seasonEndDate,
                                bool isActive, bool canBeBoughtOnCredit) 
            : base(name, price, isActive, canBeBoughtOnCredit)
        {
            SeasonStartDate = seasonStartDate;
            SeasonEndDate = seasonEndDate;
        }
        
        public override string ToString()
        {
            return MyId + Name + Price;
        }
    }
}