using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EksamensopgaveOOPefteraarIvik
{
    public class LoadProductData
    {

        public static List<ProductParser> LoadDataOfProducts(char separator, string filePath)
        {
            return File
                .ReadAllLines(filePath)
                .Skip(1)
                .Select(x => new ProductParser(separator, x))
                .ToList();
        }
        
    }
}