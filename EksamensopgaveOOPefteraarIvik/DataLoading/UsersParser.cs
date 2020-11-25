using System;
using System.Linq.Expressions;
using EksamensopgaveOOPefteraarIvik.Users;

namespace EksamensopgaveOOPefteraarIvik
{
    public class UsersParser
    {
        public uint MyId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public decimal Balance { get; set; }

        public string Email { get; set; }

        public UsersParser(char separator, string csvLine)
        {
            string[] fields = csvLine.Split(separator);

            MyId = uint.Parse(fields[0]);
            FirstName = fields[1];
            LastName = fields[2];
            Username = fields[3];
            Balance = decimal.Parse(fields[4]);
            Email = fields[5];
        }
        
        public static implicit operator User(UsersParser usersParser)
        {
            return new User(usersParser.MyId, usersParser.FirstName, usersParser.LastName, usersParser.Username,
                                usersParser.Email);
        }
        
    }
}