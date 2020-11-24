using System;
using System.Text.RegularExpressions;
using EksamensopgaveOOPefteraarIvik.Products;

namespace EksamensopgaveOOPefteraarIvik
{
    public class ProductParser
    {
        public uint MyId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool IsActive { get; set; }

        // TODO Dont know if this works
        public ProductParser(char separator, string csvLine)
        {
            string[] field = csvLine.Split(separator);

            MyId = uint.Parse(field[0]);
            Name = field[1];
            Name = Regex.Replace(Name, "<.*?>", string.Empty);
            Price = decimal.Parse(field[2]);
            IsActive = field[3] != "0";
        }
        
        
        
        public static implicit operator ProductBase(ProductParser productParser)
        {
            return new Product(productParser.MyId, productParser.Name, productParser.Price, productParser.IsActive, true);
        }
    }
}