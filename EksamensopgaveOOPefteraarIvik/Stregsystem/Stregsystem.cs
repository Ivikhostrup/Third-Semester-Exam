using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EksamensopgaveOOPefteraarIvik.DataLoading;
using EksamensopgaveOOPefteraarIvik.Exceptions;
using EksamensopgaveOOPefteraarIvik.Products;
using EksamensopgaveOOPefteraarIvik.Users;

namespace EksamensopgaveOOPefteraarIvik.Stregsystem 
{
    public class Stregsystem : IStregsystem
    {
        
        private static string directoryInfo = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        private string productsFilePath = Path.Combine(directoryInfo, "Data", "products.csv");
        private char separatorForProducts = ';';
        
        private string UsersFilePath = Path.Combine(directoryInfo, "Data", "users.csv");
        private char separatorForUsers = ',';
        

        private List<IUser> Users { get; set; } = new List<IUser>();
        private List<IProductBase> Products { get; set; } = new List<IProductBase>();
        
        private List<ITransaction> Transactions = new List<ITransaction>();

        public event UserBalanceNotification UserBalanceWarning;

        public IEnumerable<IProductBase> ActiveProducts => Products.Where(product => product.IsActive);


        public Stregsystem()
        {
            LoadData();
            UserBalanceLowHandler();
            
        }
        
        public void UserBalanceLowHandler()
        {
            foreach (IUser user in Users)
            {
                user.BalanceLow += WarnUserOfLowBalance;
            }
        }
        
        // ?. Null conditional operater - If UserBalanceWarning is null it will not throw exception
        public void WarnUserOfLowBalance(decimal amount)
        {
            foreach (IUser user in Users)
            {
                UserBalanceWarning?.Invoke(user, amount);
            }
        }
        
        public BuyTransaction BuyProduct(IUser user, IProductBase product, decimal amount)
        {
            BuyTransaction buyTransaction = new BuyTransaction(user, DateTime.Now, product);
            
            
            ExecuteTransaction(buyTransaction);
            
            return buyTransaction;
        }
               
        public InsertCashTransaction AddCreditsToAccount(IUser user, decimal amount)
        {
            InsertCashTransaction insertCash = new InsertCashTransaction(user, DateTime.Now, amount);
            
            
            ExecuteTransaction(insertCash);
            
            return insertCash;
        }
        
        public void ExecuteTransaction(ITransaction transaction)
        {
            Transactions.Add(transaction);
            transaction.Execute();
        }

        public IProductBase GetProductById(int id)
        {
            IProductBase product = Products.Find(x => x.MyId == id);

            return product ?? throw new ProductDoesNotExistException("The product does not exist");
        }
        
        // Could be used to find a specific person given name, ID or otherwise
        public IEnumerable<IUser> GetUsers(Func<IUser, bool> predicate)
        {
            return Users.Where(x => predicate(x));
        }
        
        public IEnumerable<ITransaction> GetTransactions(IUser user, int count)
        {
            return Transactions.OrderByDescending((x => x.User)).Take(count);
        }


        public IUser GetUserByUsername(string username)
        {
            IUser user = Users.Find(x => x.UserName == username);

            return user ?? throw new UserInformationNullExceptions("Cannot find specified user");
        }
        
        // Could make loadDataOfProducts and users non static by instantiating the class first
       private void LoadData()
        {
            Users = LoadUserData.LoadDataOfUsers(separatorForUsers, UsersFilePath).ToList();
            Products = LoadProductData.LoadDataOfProducts(separatorForProducts, productsFilePath).ToList();
        }
    }
}