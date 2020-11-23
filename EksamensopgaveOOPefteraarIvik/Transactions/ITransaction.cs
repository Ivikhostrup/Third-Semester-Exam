using System;
using EksamensopgaveOOPefteraarIvik.Users;

namespace EksamensopgaveOOPefteraarIvik
{
    public interface ITransaction
    {
        int Id { get; set; }
        User User { get; set; }
        DateTime Date { get; set; }
        decimal Amount { get; set; }
        decimal Execute(decimal amount, User user);
    }
}