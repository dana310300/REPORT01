using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using REPORT01.Model;
using REPORT01.Services.DAO;

namespace REPORT01.Services.Service
{
   public class ProductCtrl
    {


        public DataSet Retrieve(SqlConnection sqlConnection,Product cu)
        {
            DataSet ds = (new ProductRetHlp().Action(sqlConnection,cu));

            return ds;
        }

        public IEnumerable<Product> RetrieveLista(SqlConnection sqlConnection, Product cu)
        {
            List<Product> ls = new List<Product>();
            CategoryCtrl categoryCtrl = new CategoryCtrl();
            DataSet dsc = null;
            DataSet ds = (new ProductRetHlp().Action(sqlConnection, cu));
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow product in ds.Tables[0].Rows)
                {
                    Product p = DataRowToProduct(product);
                    //if (p.CategoryID != null)
                    //{
                    //    dsc=categoryCtrl.Retrieve(sqlConnection, new Category {CategoryID = p.CategoryID});
                    //    int index = dsc.Tables[0].Rows.Count;
                    //    if(index>0) {
                    //        p.Category = categoryCtrl.DataRowTocategory(dsc.Tables[0].Rows[index - 1]);
                    //    }
                      
                    //}
                    ls.Add(p);
                }
            }
            return ls;
        }

        public Product DataRowToProduct(DataRow row)
        {
           
            Product product = new Product();

            if (row != null)
            {
                if (row["ProductID"] != null)
                {
                    product.ProductID = int.Parse(row["ProductID"].ToString());
                }

                if (row["ProductName"] != null)
                {
                    product.ProductName = row["ProductName"].ToString();
                }
                if (row["SupplierID"] != null)
                {
                    product.SupplierID = int.Parse(row["SupplierID"].ToString());
                }
                if (row["CategoryID"] != null)
                {
                    product.CategoryID =int.Parse(row["CategoryID"].ToString());
                }
                if (row["QuantityPerUnit"] != null)
                {
                    product.QuantityPerUnit = row["QuantityPerUnit"].ToString();
                }
             
                if (row["UnitPrice"] != null)
                {
                    product.UnitPrice = decimal.Parse(row["UnitPrice"].ToString());
                }
                if (row["UnitsInStock"] != null)
                {
                    product.UnitsInStock =int.Parse(row["UnitsInStock"].ToString());
                }
                if (row["UnitsOnOrder"] != null)
                {
                    product.UnitsOnOrder = int.Parse(row["UnitsOnOrder"].ToString());
                }
                if (row["ReorderLevel"] != null)
                {
                    product.ReorderLevel = int.Parse(row["ReorderLevel"].ToString());
                }
                if (row["Discontinued"] != null)
                {
                    product.Discontinued =bool.Parse(row["Discontinued"].ToString());
                }
              
            }

            return product;
        }
    }
}
