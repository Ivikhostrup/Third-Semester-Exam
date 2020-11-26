using System.Collections.Generic;
using System.IO;
using System.Linq;
using EksamensopgaveOOPefteraarIvik.Products;

namespace EksamensopgaveOOPefteraarIvik
{
    public class LoadProductData
    {
        public static List<Product> LoadDataOfProducts(char separator, string filePath)
        {
            return File
                .ReadAllLines(filePath)
                .Skip(1)
                .Select(x => new Product(separator, x))
                .ToList();
        }
    }
}