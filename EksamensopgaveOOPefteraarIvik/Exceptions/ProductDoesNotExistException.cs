using System;

namespace EksamensopgaveOOPefteraarIvik.Exceptions
{
    public class ProductDoesNotExistException : Exception
    {
        public ProductDoesNotExistException(string message) : base(message)
        {
            
        }
        
        
    }
}