using System;
using System.Threading;
using EksamensopgaveOOPefteraarIvik.Exceptions;
using EksamensopgaveOOPefteraarIvik.Products;
using EksamensopgaveOOPefteraarIvik.Users;

namespace EksamensopgaveOOPefteraarIvik
{
    public class BuyTransaction : Transaction
    {
        
        public IProductBase Product { get; set; }
        
        public BuyTransaction(IUser user, DateTime date, IProductBase product) : base(user, date, product.Price)
        {
            Product = product;
        }

        public override string ToString()
        {
            return $"You are about to pay {Amount} with the transaction ID {MyId} - The transaction date is {Date}";
        }

        public override decimal Execute()
        {
            if (User.Balance < Product.Price && Product.CanBeBoughtOnCredit == true)
            {
                return User.Balance -= Amount;
            }
            else if(User.Balance < Product.Price && Product.CanBeBoughtOnCredit == false)
            {
                throw new NotEnoughFundsException("You dont have enough funds for this purchase");
            }
            else
            {
                return User.Balance -= Amount;
            }
        }
        
    }
}