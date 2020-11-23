using System;
using System.Threading;
using EksamensopgaveOOPefteraarIvik.Users;

namespace EksamensopgaveOOPefteraarIvik
{
    public sealed class InsertCashTransaction : Transaction
    {
        
        public InsertCashTransaction(IUser user, DateTime date, decimal amount) : base(user, date, amount)
        {
            
        }

        public override string ToString()
        {
            return $"You are about to insert {Amount} into {User}'s account - The transaction date is {Date}";
        }

        public override decimal Execute()
        {
            return User.Balance += Amount;
        }
    }
}