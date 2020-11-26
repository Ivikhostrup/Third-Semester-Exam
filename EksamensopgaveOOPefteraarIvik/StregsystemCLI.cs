using System;
using EksamensopgaveOOPefteraarIvik.Products;
using EksamensopgaveOOPefteraarIvik.Stregsystem;
using EksamensopgaveOOPefteraarIvik.Users;

namespace EksamensopgaveOOPefteraarIvik
{
    public class StregsystemCli : IStregsystemUI
    {
        private readonly IStregsystem stregsystem;
        private bool running;
        
        public StregsystemCli(IStregsystem stregsystem)
        {
            this.stregsystem = stregsystem;
            running = true;
        }
        
        public void Start()
        {
            while (running)
            {
                throw new NotImplementedException();
            }
        }
        
        public void Close()
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