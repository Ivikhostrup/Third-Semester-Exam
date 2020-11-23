using System;
using System.Threading;
using EksamensopgaveOOPefteraarIvik.Users;

namespace EksamensopgaveOOPefteraarIvik
{
    public abstract class Transaction : ITransaction
    {
        private static int idCount = 0;
        public int MyId { get; set; }

        public IUser User { get; set; }

        public DateTime Date { get; set; }

        public decimal Amount { get; set; }

        protected Transaction(IUser user, DateTime date, decimal amount)
        {
            MyId = Interlocked.Increment(ref idCount);
            User = user;
            Amount = amount;
            Date = date;
        }

        public abstract override string ToString();

        public abstract decimal Execute();

    }
}