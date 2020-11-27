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
        
        // TODO Currently not parsing in inactive products - needs fix
        
        private IStregsystem stregsystem;
        private IStregsystemUI ui;
        public Dictionary<string, Action<string[]>> adminCommands = new Dictionary<string, Action<string[]>>();
        
        public StregsystemController(IStregsystem stregsystem, IStregsystemUI ui)
        {
            this.stregsystem = stregsystem;
            this.ui = ui;
            AddAdminCommands();

            ui.CommandEntered += CheckIfAdmin;
        }

        public void CheckIfAdmin(string args)
        {
            string[] command = args.Split(":").ToArray();
            Console.WriteLine(command[1]);

        }
        public void AddAdminCommands()
        {
            adminCommands.Add(":quit", (command) => ui.Close());
            adminCommands.Add(":q", (command) => ui.Close());
            adminCommands.Add(":activate", (command) => ChangeProductStatus(command, true));
            adminCommands.Add(":deactivate", (command) => ChangeProductStatus(command, false));
            adminCommands.Add(":crediton", (command) => ChangeProductCreditStatus(command, true));
            adminCommands.Add(":creditoff", (command) => ChangeProductCreditStatus(command, false));
            adminCommands.Add(":addcredits", (command) => ChangeProductCreditStatus(command, false));
        }

        public void ChangeProductStatus(string[] args, bool status)
        {
            string[] command = args[0].Split(' ').Skip(1).ToArray();
            
            if (command[1] != null)
            {
                IProductBase product = stregsystem.GetProductById(int.Parse(command[3]));

                product.IsActive = status;
            }
        }

        public void ChangeProductCreditStatus(string[] args, bool status)
        {
            string[] command = args[0].Split(' ').Skip(1).ToArray();
            
            if (command[1] != null)
            {
                IProductBase product = stregsystem.GetProductById(int.Parse(command[3]));

                product.CanBeBoughtOnCredit = status;
            }
        }

        public void AddCreditToUser(string[] args, decimal amount)
        {
            string[] command = args[0].Split(' ').Skip(1).ToArray();
            if (command[1] != null)
            {
                IUser user = stregsystem.GetUserByUsername(command[3]);

                user.Balance += amount;
            }
        }

        public void UserCommands(string[] args)
        {
            string[] command = args[0].Split(' ');

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

            var user = stregsystem.GetUserByUsername(username);
            var product = stregsystem.GetProductById(int.Parse(productId));
            var cost = product.Price;
            
            ui.DisplayUserBuysProduct(user, product);
            stregsystem.BuyProduct(user, product, cost);
        }

        public void DisplayUserInformation(string username)
        {
            var user = stregsystem.GetUserByUsername(username);
            ui.DisplayUserInfo(user);
        }
    }
}