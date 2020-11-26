using System;
using System.Collections.Generic;
using EksamensopgaveOOPefteraarIvik.Products;
using EksamensopgaveOOPefteraarIvik.Stregsystem;
using EksamensopgaveOOPefteraarIvik.Users;

namespace EksamensopgaveOOPefteraarIvik.SystemUserInterface
{
    public class StregsystemCli : IStregsystemUI
    {
        private IStregsystem Stregsystem { get; set; }
        private bool running;
        
        public StregsystemCli(IStregsystem stregsystem)
        {
            Stregsystem = stregsystem;
            running = true;
        }
        
        // TODO Figure out a quickbuy menu - Should receive username and if username is valid display all active products
        // TODO Figureout of to get product list from stregsystem
        public void Start()
        {
            while (running)
            {
                    

                DisplayProducts(Stregsystem.ActiveProducts);
                Close();
                Console.ReadLine();
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
                Console.WriteLine(item.Name);
            }
        }
        public void DisplayProducts(IProductBase product)
        {
            throw new System.NotImplementedException();
        }
        public void DisplayUserInfo(IUser user)
        {
            throw new System.NotImplementedException();
        }
        
        public void DisplayUserBuysProduct(int count, ITransaction transaction)
        {
            throw new System.NotImplementedException();
        }
        
        public void DisplayUserBuysProduct(ITransaction transaction)
        {
            throw new System.NotImplementedException();
        }
        
        public void DisplayInsufficientCash(IUser user, IProductBase product)
        {
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }

        
    }
}