using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using EksamensopgaveOOPefteraarIvik.Products;
using EksamensopgaveOOPefteraarIvik.Stregsystem;
using EksamensopgaveOOPefteraarIvik.Users;

namespace EksamensopgaveOOPefteraarIvik
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO How to get path for user and product files
            // var directoryInfo = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            //
            // var productFilePath = Path.Combine(directoryInfo, "Data", "products.csv");


            // IUser jane = new User(1, "jane", "Jameson", "Jane123", "Jane@gmail.com");
            // IProductBase product1 = new Product(1, "pepsi", 20, true, true);
            // jane.Balance = 500;
            //
            // IStregsystem launch = new Stregsystem.Stregsystem();
            //
            // launch.BuyProduct(jane, product1, 20);
            //
            // var res = launch.GetTransactions(jane, 1).ToList();
            //
            // Console.WriteLine(jane.Balance);
            //
            // foreach (var item in res)
            // {
            //     Console.WriteLine(item.Amount);
            //     Console.WriteLine(item.Date);
            //     Console.WriteLine(item.User);
            //     Console.WriteLine(item.MyId);
            // }
            //
            // Console.ReadLine();
        }
    }
}