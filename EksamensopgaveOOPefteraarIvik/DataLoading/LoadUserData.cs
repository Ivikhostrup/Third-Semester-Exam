using System.Collections.Generic;
using System.IO;
using System.Linq;
using EksamensopgaveOOPefteraarIvik.Users;

namespace EksamensopgaveOOPefteraarIvik.DataLoading
{
    public class LoadUserData
    {
        public static IEnumerable<IUser> LoadDataOfUsers(char separator, string filePath)
        {
            return File
                .ReadAllLines(filePath)
                .Skip(1)
                .Select(x => new User(separator, x))
                .ToList();
        }
    }
}