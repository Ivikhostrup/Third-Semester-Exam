using System;
using System.Collections.Generic;
using EksamensopgaveOOPefteraarIvik.Products;
using EksamensopgaveOOPefteraarIvik.Users;

namespace EksamensopgaveOOPefteraarIvik.Stregsystem
{
    public delegate void UserBalanceNotification(IUser user, decimal balance);
    
    public interface IStregsystem
    {
        IEnumerable<IProductBase> ActiveProducts { get; }

        InsertCashTransaction AddCreditsToAccount(IUser user, decimal amount);

        BuyTransaction BuyProduct(IUser user, IProductBase product, decimal amount);
        
        IProductBase GetProductById(int id);

        IEnumerable<ITransaction> GetTransactions(IUser user, int count);

        IEnumerable<IUser> GetUsers(Func<IUser, bool> predicate);

        IUser GetUserByUsername(string username);

        event UserBalanceNotification UserBalanceWarning;
        

    }
}