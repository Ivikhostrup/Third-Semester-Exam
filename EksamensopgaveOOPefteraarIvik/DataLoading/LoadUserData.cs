using System.Collections.Generic;
using System.IO;
using System.Linq;
using EksamensopgaveOOPefteraarIvik.Users;

namespace EksamensopgaveOOPefteraarIvik
{
    public class LoadUserData
    {
        public static List<UsersParser> LoadDataOfUsers(char separator, string filePath)
        {
            return File
                .ReadAllLines(filePath)
                .Skip(1)
                .Select(x => new UsersParser(separator, x))
                .ToList();
        }
        
    }
}