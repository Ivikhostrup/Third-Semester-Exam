using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        

        public List<User> Users { get; set; }
        public List<Product> Products { get; set; }
        
        private List<ITransaction> Transactions = new List<ITransaction>();

        public event UserBalanceNotification UserBalanceWarning;

        public IEnumerable<IProductBase> ActiveProducts => Products.Where(product => product.IsActive);


        public Stregsystem()
        {
            LoadData();
            

        }
        
        
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
            Transactions.Add(transaction);
            transaction.Execute();
        }

        public IProductBase GetProductById(int id)
        {
            IProductBase product = Products.Find(x => x.MyId == id);

            return product ?? throw new NotImplementedException();
        }

        public IEnumerable<IUser> GetUsers(Func<IUser, bool> predicate)
        {
            return Users.Where(x => predicate(x));
        }

       // TODO Change the mapping from x.User
        public IEnumerable<ITransaction> GetTransactions(IUser user, int count)
        {
            return Transactions.OrderByDescending((x => x.User)).Take(count);
        }


        public IUser GetUserByUsername(string username)
        {
            IUser user = Users.Find(x => x.UserName == username);

            return user ?? throw new NotImplementedException();
        }

        // TODO figure out how to subscribe to event in user class


        private void LoadData()
        {
            Users = LoadUserData.LoadDataOfUsers(separatorForUsers, UsersFilePath);
            Products = LoadProductData.LoadDataOfProducts(separatorForProducts, productsFilePath);
            
        }
        
        
        
        
        
    }
}