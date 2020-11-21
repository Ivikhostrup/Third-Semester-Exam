namespace EksamensopgaveOOPefteraarIvik
{
    public class Product : ProductBase
    {
        
        // Could probably make interface


        public Product(int id, string name, decimal price) : base(id, name, price)
        {
        }

        public override string ToString()
        {
            return Id + Name + Price;
        }
    }
}