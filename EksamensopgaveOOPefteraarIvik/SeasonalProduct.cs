using System;

namespace EksamensopgaveOOPefteraarIvik
{
    public class SeasonalProduct : ProductBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
        
        public bool IsActive { get; set; }
        
        public bool CanBeBoughtOnCredit { get; set; }

        public DateTime SeasonStartDate { get; set; }

        public DateTime SeasonEndDate { get; set; }
        

        public SeasonalProduct(int id, string name, decimal price, DateTime seasonStartDate, DateTime seasonEndDate,
                                bool isActive, bool canBeBoughtOnCredit) 
            : base(id, name, price, isActive, canBeBoughtOnCredit)
        {
            Id += id;
            Name = name;
            Price = price;
            IsActive = isActive;
            CanBeBoughtOnCredit = canBeBoughtOnCredit;
            
            SeasonStartDate = seasonStartDate;
            SeasonEndDate = seasonEndDate;
        }
        
        public override string ToString()
        {
            return Id + Name + Price;
        }
    }
}