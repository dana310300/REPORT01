using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REPORT01.Model.ReportDataContract
{
  public  class RptProductContract
    {
      public int? ProductId { get; set; }
      public String ProductName { get; set; }
      public Double UnitPrice { get; set; }
      public int? CategoryId { get; set; }
      public String CategoryName { get; set; }
     
    }
}
