namespace EksamensopgaveOOPefteraarIvik.Products
{
    public interface IProductBase
    {
        int MyId { get; set; }
        string Name { get; set; }
        decimal Price { get; set; }
        bool IsActive { get; set; }
        bool CanBeBoughtOnCredit { get; set; }
        
    }
}