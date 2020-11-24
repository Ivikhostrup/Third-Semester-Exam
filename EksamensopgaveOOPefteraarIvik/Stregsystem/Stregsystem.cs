using System;
using System.Collections.Generic;
using EksamensopgaveOOPefteraarIvik.Products;
using EksamensopgaveOOPefteraarIvik.Users;

namespace EksamensopgaveOOPefteraarIvik.Stregsystem 
{
    public class Stregsystem : IStregsystem
    {
        private List<IUser> Users = new List<IUser>();
        private List<IProductBase> Products = new List<IProductBase>();
        private List<ITransaction> Transactions = new List<ITransaction>();
        
        public IEnumerable<IProductBase> ActiveProducts { get; }
        
        // TODO Make log and possibly event
        public BuyTransaction BuyProduct(IUser user, IProductBase product, decimal amount)
        {
            BuyTransaction buyTransaction = new BuyTransaction(user, DateTime.Now, product);
            
            ExecuteTransaction(buyTransaction);
            
            return buyTransaction;
        }
        
        // TODO Make log and possibly event
        public InsertCashTransaction AddCreditsToAccount(IUser user, decimal amount)
        {
            InsertCashTransaction insertCash = new InsertCashTransaction(user, DateTime.Now, amount);
            
            ExecuteTransaction(insertCash);
            
            return insertCash;
        }
        
        // TODO add to list of logs
        public void ExecuteTransaction(ITransaction transaction)
        {
            transaction.Execute();
        }

        public IProductBase GetProductById(int id)
        {
            IProductBase product = Products.Find(x => x.MyId == id);

            return product ?? throw new NotImplementedException();
        }

        public IUser GetUsers(Func<User, bool> predicate)
        {
            throw new NotImplementedException();
        }

       
        public IEnumerable<ITransaction> GetTransactions(User user, int count)
        {
            throw new NotImplementedException();
        }


        public IUser GetUserByUsername(string username)
        {
            IUser user = Users.Find(x => x.UserName == username);

            return user ?? throw new NotImplementedException();
        }
        
        // TODO figure out how to subscribe to event in user class
        public event User.UserBalanceNotificationEventHandler UserBalanceWarning;

        
    }
}