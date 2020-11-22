using System;

namespace EksamensopgaveOOPefteraarIvik
{
    public interface ITransaction
    {
        int Id { get; set; }
        string User { get; set; }
        DateTime Date { get; set; }
        decimal Amount { get; set; }
        decimal Execute(decimal amount, string user);
    }
}