using System;
using EksamensopgaveOOPefteraarIvik.Users;

namespace EksamensopgaveOOPefteraarIvik
{
    public abstract class Transaction : ITransaction
    {
        public int Id { get; set; }

        public User User { get; set; }

        public DateTime Date { get; set; }

        public decimal Amount { get; set; }

        protected Transaction(User user, decimal amount)
        {
            User = user;
            Amount = amount;
            
            Date = DateTime.Now;
        }

        public abstract override string ToString();

        public virtual decimal Execute(decimal amount, User user)
        {
            throw new NotImplementedException();
        }
    }
}