using System;
using System.Threading;
using EksamensopgaveOOPefteraarIvik.Products;
using EksamensopgaveOOPefteraarIvik.Users;

namespace EksamensopgaveOOPefteraarIvik
{
    public class BuyTransaction : Transaction
    {
        private static int idCount = 0;
        public int MyId { get; set; }
        public IProductBase Product { get; set; }
        public User User { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        

        //Have to figure out how to deal with which product was selected - Property? Made with constructor? List of products??

        public BuyTransaction(User user, decimal amount, IProductBase product) : base(user, amount)
        {
            MyId = Interlocked.Increment(ref idCount);
            Product = product;
            User = user;
            Amount = amount;
            
            Date = DateTime.Now;
        }

        public override string ToString()
        {
            return $"You are about to pay {Amount} with the transaction ID {Id} - The transaction date is {Date}";
        }

        public override decimal Execute(decimal amount, User user)
        {
            if (user.Balance < Product.Price && Product.CanBeBoughtOnCredit == true)
            {
                return user.Balance - amount;
            }
            else if(user.Balance < Product.Price && Product.CanBeBoughtOnCredit == false)
            {
                return 0;
            }
            else
            {
                return user.Balance - amount;
            }
        }
    }
}