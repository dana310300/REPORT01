using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using REPORT01.Model;
using REPORT01.Services.DAO;
using REPORT01.Services.DAO.Reports;
using REPORT01.Model.ReportDataContract;

namespace REPORT01.Services
{
   public class RptProductContractCtrl
    {

        public DataSet Retrieve(SqlConnection sqlConnection, RptProductContract cu)
        {
            DataSet ds = (new RptProductsRetHlp().Action(sqlConnection, cu));

            return ds;
        }

        public IEnumerable<RptProductContract> RetrieveLista(SqlConnection sqlConnection, RptProductContract cu)
        {
            List<RptProductContract> ls = new List<RptProductContract>();
           
            DataSet dsc = null;
            DataSet ds = (new RptProductsRetHlp().Action(sqlConnection, cu));
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow product in ds.Tables[0].Rows)
                {
                    RptProductContract p = DataRowToRptProductContract(product);
               
                    ls.Add(p);
                }
            }
            return ls;
        }

        public RptProductContract DataRowToRptProductContract(DataRow row)
        {

            RptProductContract product = new RptProductContract();

            if (row != null)
            {
                if (row["ProductID"] != null)
                {
                    product.ProductId = int.Parse(row["ProductID"].ToString());
                }

                if (row["ProductName"] != null)
                {
                    product.ProductName = row["ProductName"].ToString();
                }
                //if (row["SupplierID"] != null)
                //{
                //    product.SupplierID = int.Parse(row["SupplierID"].ToString());
                //}
                if (row["CategoryID"] != null)
                {
                    product.CategoryId = int.Parse(row["CategoryID"].ToString());
                }
                if (row["CategoryName"] != null)
                {
                    product.CategoryName = row["CategoryName"].ToString();
                }
                //if (row["QuantityPerUnit"] != null)
                //{
                //    product.QuantityPerUnit = row["QuantityPerUnit"].ToString();
                //}

                if (row["UnitPrice"] != null)
                {
                    product.UnitPrice =double.Parse(row["UnitPrice"].ToString());
                }
                //if (row["UnitsInStock"] != null)
                //{
                //    product.UnitsInStock = int.Parse(row["UnitsInStock"].ToString());
                //}
                //if (row["UnitsOnOrder"] != null)
                //{
                //    product.UnitsOnOrder = int.Parse(row["UnitsOnOrder"].ToString());
                //}
                //if (row["ReorderLevel"] != null)
                //{
                //    product.ReorderLevel = int.Parse(row["ReorderLevel"].ToString());
                //}
                //if (row["Discontinued"] != null)
                //{
                //    product.Discontinued = bool.Parse(row["Discontinued"].ToString());
                //}

            }

            return product;
        }
    }
}
