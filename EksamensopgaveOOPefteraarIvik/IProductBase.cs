﻿namespace EksamensopgaveOOPefteraarIvik
{
    public interface IProductBase
    {
        int Id { get; set; }
        string Name { get; set; }
        decimal Price { get; set; }
        bool IsActive { get; set; }
        bool CanBeBoughtOnCredit { get; set; }
        
    }
}