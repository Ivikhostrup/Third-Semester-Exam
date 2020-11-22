using System;

namespace EksamensopgaveOOPefteraarIvik
{
    public sealed class InsertCashTransaction : Transaction
    {
        public int Id { get; set; }
        public string User { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }

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