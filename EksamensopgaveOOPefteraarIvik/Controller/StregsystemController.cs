using System;
using System.Collections.Generic;
using System.Linq;
using EksamensopgaveOOPefteraarIvik.Products;
using EksamensopgaveOOPefteraarIvik.Stregsystem;
using EksamensopgaveOOPefteraarIvik.SystemUserInterface;
using EksamensopgaveOOPefteraarIvik.Users;

namespace EksamensopgaveOOPefteraarIvik.Controller
{
    public class StregsystemController
    {
        private IStregsystem stregsystem;
        private IStregsystemUI ui;
        
        // Action<string[] - Method with parameter of string[]
        public Dictionary<string, Action<string[]>> adminCommands;
        
        public StregsystemController(IStregsystem stregsystem, IStregsystemUI ui)
        {
            this.stregsystem = stregsystem;
            this.ui = ui;
            AddAdminCommands();

            ui.CommandEntered += CheckIfAdmin;
        }
        
        public void CheckIfAdmin(string args)
        {
            
            if (args.Contains(":"))
            {
                string[] command = args.Split(' ');
                
                adminCommands[command[0]](command);
            }
            else if (!args.Contains(":"))
            {
                UserCommands(args);
            }

        }
        public void AddAdminCommands()
        {
            adminCommands = new Dictionary<string, Action<string[]>>()
            {
                {":quit", (command) => ui.Close() },
                {":q", (command) => ui.Close() },
                {":activate", (command) => ChangeProductStatus(command, true) },
                {":deactivate", (command) => ChangeProductStatus(command, false)},
                {":crediton", (command) => ChangeProductCreditStatus(command, true)},
                {":creditoff", (command) => ChangeProductCreditStatus(command, false)},
                {":addcredits", (command) => AddCreditToUser(command)}
            };
        }

        public void ChangeProductStatus(string[] args, bool status)
        {
            
            if (args[0] != null)
            {
                IProductBase product = stregsystem.GetProductById(int.Parse(args[1]));

                product.IsActive = status;
            }
        }

        public void ChangeProductCreditStatus(string[] args, bool status)
        {
            if (args[0] != null)
            {
                IProductBase product = stregsystem.GetProductById(int.Parse(args[1]));

                product.CanBeBoughtOnCredit = status;
                Console.WriteLine($"{product.MyId} buy on credit status is now {status}");
            }
        }

        public void AddCreditToUser(string[] args)
        {
            if (args[0] != null)
            {
                IUser user = stregsystem.GetUserByUsername(args[1]);
                decimal amount = decimal.Parse(args[2]);
                user.Balance += amount;
                Console.WriteLine($"User {user.UserName} now has {user.Balance} credits");
            }
        }

        public void UserCommands(string args)
        {
            string[] command = args.Split(' ');

            if (command.Length == 1)
            {
                DisplayUserInformation(command[0]);
            }
            else if (command.Length == 2)
            {
                UserBuysProduct(command[0], command[1]);
            }
            else
            {
                ui.DisplayTooManyArguementsError(command.Length.ToString());
            }
        }

        public void UserBuysProduct(string username, string productId)
        {
            IUser user = stregsystem.GetUserByUsername(username);
            IProductBase product = stregsystem.GetProductById(int.Parse(productId));
            decimal cost = product.Price;
            
            ui.DisplayUserBuysProduct(user, product);
            stregsystem.BuyProduct(user, product, cost);
        }

        public void DisplayUserInformation(string username)
        {
            IUser user = stregsystem.GetUserByUsername(username);
            ui.DisplayUserInfo(user);
        }
    }
}