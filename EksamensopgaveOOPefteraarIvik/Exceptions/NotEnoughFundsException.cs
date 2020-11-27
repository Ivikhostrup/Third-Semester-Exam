using System;

namespace EksamensopgaveOOPefteraarIvik.Exceptions
{
    public class NotEnoughFundsException : Exception
    {
        public NotEnoughFundsException(string message) : base(message)
        {
            
        }
    }
}