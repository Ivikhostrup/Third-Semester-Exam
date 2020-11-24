using System.Collections.Generic;
using System.IO;
using EksamensopgaveOOPefteraarIvik.Users;

namespace EksamensopgaveOOPefteraarIvik
{
    public class LoadUserData
    {
        private List<UsersParser> usersList;

        public List<IUser> LoadData()
        {
            StreamReader reader = new StreamReader("path");
            UsersParser parsedUser = new UsersParser(';', );
            
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                
            }
        }
    }
}