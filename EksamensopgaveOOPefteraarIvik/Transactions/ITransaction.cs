using System;
using EksamensopgaveOOPefteraarIvik.Users;

namespace EksamensopgaveOOPefteraarIvik
{
    public interface ITransaction
    {
        int MyId { get; set; }
        IUser User { get; set; }
        DateTime Date { get; set; }
        decimal Amount { get; set; }
        decimal Execute();
    }
}