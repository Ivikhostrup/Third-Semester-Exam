using System;

namespace EksamensopgaveOOPefteraarIvik
{
    public abstract class Transaction : ITransaction
    {
        public int Id { get; set; }

        public string User { get; set; }

        public DateTime Date { get; set; }

        public decimal Amount { get; set; }

        protected Transaction(string user, decimal amount)
        {
            User = user;
            Amount = amount;
            
            Date = DateTime.Now;
        }

        public abstract override string ToString();

        public virtual decimal Execute(decimal amount, string user)
        {
            throw new NotImplementedException();
        }
    }
}