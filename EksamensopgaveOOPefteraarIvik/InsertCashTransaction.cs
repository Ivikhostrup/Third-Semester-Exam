using System;

namespace EksamensopgaveOOPefteraarIvik
{
    public sealed class InsertCashTransaction : Transaction
    {
        private int Id { get; set; }
        private string User { get; set; }
        private DateTime Date { get; set; }
        private decimal Amount { get; set; }

        public InsertCashTransaction(string user, decimal amount) : base(user, amount)
        {
            Id += 1;
            User = user;
            Amount = amount;
            
            Date = DateTime.Now;
        }

        public override string ToString()
        {
            return $"You are about to insert {Amount} into {User}'s account - The transaction date is {Date}";
        }

        public override decimal Execute(decimal amount, string user)
        {
            throw new NotImplementedException();
        }
    }
}