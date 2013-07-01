using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REPORT01.Model
{
   public class Product
    {
       public int? ProductID { get; set; }
       public string ProductName { get; set; }
       public int? SupplierID { get; set; }
       public int? CategoryID { get; set; }
       //public Category Category { get; set; }
       public string QuantityPerUnit { get; set; }
       public int? UnitsInStock { get; set; }
       public int? UnitsInOrder { get; set; }
       public int? UnitsOnOrder { get; set; }
       public int? ReorderLevel { get; set; }
       public decimal? UnitPrice { get; set; }
       public bool? Discontinued { get; set; }
       
    }
}
