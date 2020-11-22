using System;

namespace EksamensopgaveOOPefteraarIvik
{
    public class BuyTransaction : Transaction
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public string User { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }

        //Have to figure out how to deal with which product was selected - Property? Made with constructor? List of products??

        public BuyTransaction(string user, decimal amount, Product product) : base(user, amount)
        {
            Id += 1;
            User = user;
            Amount = amount;
            Product = product;
            
            Date = DateTime.Now;
        }

        public override string ToString()
        {
            return $"You are about to pay {Amount} with the transaction ID {Id} - The transaction date is {Date}";
        }

        public override decimal Execute(decimal amount, string user)
        {
            throw new NotImplementedException();
        }
    }
}