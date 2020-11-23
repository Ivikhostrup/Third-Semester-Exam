using System;
using System.Collections.Generic;
using EksamensopgaveOOPefteraarIvik.Products;
using EksamensopgaveOOPefteraarIvik.Users;

namespace EksamensopgaveOOPefteraarIvik.Stregsystem
{
    public interface IStregsystem
    {
        IEnumerable<IProductBase> ActiveProducts { get; }

        InsertCashTransaction AddCreditsToAccount(IUser user, decimal amount);

        BuyTransaction BuyProduct(IUser user, IProductBase product, decimal amount);
        
        IProductBase GetProductById(int id);

        IEnumerable<ITransaction> GetTransactions(User user, int count);

        IUser GetUsers(Func<User, bool> predicate);

        IUser GetUserByUsername(string username);

        event User.UserBalanceNotificationEventHandler UserBalanceWarning;
    }
}