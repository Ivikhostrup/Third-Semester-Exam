using System;
using System.Threading;
using EksamensopgaveOOPefteraarIvik.Users;

namespace EksamensopgaveOOPefteraarIvik
{
    public sealed class InsertCashTransaction : Transaction
    {
        private static int idCount = 0;
        public int MyId { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }

        public InsertCashTransaction(User user, decimal amount) : base(user, amount)
        {
            MyId = Interlocked.Increment(ref idCount);
            User = user;
            Amount = amount;
            
            Date = DateTime.Now;
        }

        public override string ToString()
        {
            return $"You are about to insert {Amount} into {User}'s account - The transaction date is {Date}";
        }

        public override decimal Execute(decimal amount, User user)
        {
            return user.Balance + amount;
        }
    }
}