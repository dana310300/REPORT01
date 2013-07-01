using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REPORT01.Model
{
   public class Category
    {
       public int? CategoryID { get; set; }
       public string CategoryName { get; set; }
       public string Description { get; set; }
       public byte[] Picture { get; set; }

       public List<Product> CategoryProducts { get; set; }
    }
}
