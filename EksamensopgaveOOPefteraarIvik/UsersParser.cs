using System;
using System.Linq.Expressions;

namespace EksamensopgaveOOPefteraarIvik
{
    public class UsersParser
    {
        public uint Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public decimal Balance { get; set; }

        public string Email { get; set; }

        public UsersParser(char separator, string csvLine)
        {
            string[] fields = csvLine.Split(separator);

            Id = uint.Parse(fields[0]);
            FirstName = fields[1];
            LastName = fields[2];
            Username = fields[3];
            Balance = decimal.Parse(fields[4]);
            Email = fields[5];
        }
        
    }
}