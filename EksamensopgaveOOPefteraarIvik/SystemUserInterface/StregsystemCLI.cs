using System;
using System.Collections.Generic;
using EksamensopgaveOOPefteraarIvik.Products;
using EksamensopgaveOOPefteraarIvik.Stregsystem;
using EksamensopgaveOOPefteraarIvik.Users;

namespace EksamensopgaveOOPefteraarIvik.SystemUserInterface
{
    public delegate void UserCommandWatcher(string command);
    
    public class StregsystemCli : IStregsystemUI
    {
        private IStregsystem Stregsystem { get; set; }
        public event UserCommandWatcher CommandEntered;
        
        private bool running;
        
        public StregsystemCli(IStregsystem stregsystem)
        {
            Stregsystem = stregsystem;
            running = true;
        }
        
        public void Start()
        {
            while (running)
            {
                Stregsystem.UserBalanceWarning += DisplayBalanceWarning;
                DisplayProducts(Stregsystem.ActiveProducts);
                var command = Console.ReadLine();
                CommandEntered?.Invoke(command);


                Console.ReadKey();
                Console.Clear();
            }
        }
        
        public void Close()
        {
            running = false;
        }
        
        public void DisplayProducts(IEnumerable<IProductBase> product)
        {
            foreach (var item in product)
            {
                Console.WriteLine($"You can buy ID {item.MyId}      {item.Name}");
            }
        }
        
        public void DisplayUserInfo(IUser user)
        {
            
            Console.WriteLine(user);
        }
        
        public void DisplayUserBuysProduct(IUser user, IProductBase product, int count)
        {
            Console.WriteLine($"{user.UserName}: You have purchased {count} of {product.Name}");
        }
        
        public void DisplayUserBuysProduct(IUser user, IProductBase product)
        {
            Console.WriteLine($"{user.UserName}: You have purchased {product.Name}");
        }

        public void DisplayBalanceWarning(IUser user, decimal balance)
        {
            Console.WriteLine($"Your balance for {user.UserName} is below 50 kr. Your current balance is {balance}");
        }
        public void DisplayInsufficientCash(IUser user, IProductBase product)
        {
            Console.WriteLine($"You've tried to purchase {product.Name}. You do not have the funds");
        }
        
        public void DisplayUserNotFound(string username)
        {
            Console.WriteLine($"User {username} not found");
        }

        public void DisplayProductNotfound(string product)
        {
            Console.WriteLine($"Product {product} not found");
        }

        public void DisplayTooManyArguementsError(string command)
        {
            Console.WriteLine($"{command} exceeds the number of commands allowed");
        }

        public void DisplayAdminCommandNotFoundMessage(string adminCommand)
        {
            Console.WriteLine($"The command {adminCommand} does not exist");
        }

        public void DisplayGeneralError(string errorString)
        {
            Console.WriteLine("Something went wrong");
        }
    }
}