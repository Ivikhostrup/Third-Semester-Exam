using System.Collections.Generic;
using System.IO;
using System.Linq;
using EksamensopgaveOOPefteraarIvik.Products;
using EksamensopgaveOOPefteraarIvik.Users;

namespace EksamensopgaveOOPefteraarIvik
{
    public class LoadUserData
    {
        public static List<User> LoadDataOfUsers(char separator, string filePath)
        {
            return File
                .ReadAllLines(filePath)
                .Skip(1)
                .Select(x => new User(separator, x))
                .ToList();
        }
    }
}