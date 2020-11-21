using System;

namespace EksamensopgaveOOPefteraarIvik
{
    public class SeasonalProduct : ProductBase
    {
        private int Id { get; set; }

        private string Name { get; set; }

        private decimal Price { get; set; }
     
        private DateTime SeasonStartDate { get; set; }

        private DateTime SeasonEndDate { get; set; }
        

        public SeasonalProduct(int id, string name, decimal price, DateTime seasonStartDate, DateTime seasonEndDate) : base(id, name, price)
        {
            Id += id;
            Name = name;
            Price = price;
            
            SeasonStartDate = seasonStartDate;
            SeasonEndDate = seasonEndDate;
        }
        
        public override string ToString()
        {
            return Id + Name + Price;
        }
    }
}