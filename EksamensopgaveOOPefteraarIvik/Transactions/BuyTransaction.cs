using System;
using System.Threading;
using EksamensopgaveOOPefteraarIvik.Products;
using EksamensopgaveOOPefteraarIvik.Users;

namespace EksamensopgaveOOPefteraarIvik
{
    public class BuyTransaction : Transaction
    {
        
        public IProductBase Product { get; set; }
        
        //Have to figure out how to deal with which product was selected - Property? Made with constructor? List of products??

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
                return User.Balance - Amount;
            }
            else if(User.Balance < Product.Price && Product.CanBeBoughtOnCredit == false)
            {
                // TODO make exception for this - Whole function can probably be simplified
                return 0;
            }
            else
            {
                return User.Balance - Amount;
            }
        }
        
    }
}