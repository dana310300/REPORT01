using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using REPORT01.Model;

namespace REPORT01.Services.DAO
{
   internal class ProductRetHlp
    {
       public DataSet Action(SqlConnection dctx, Product product)
       {
          
           string sError = "";
           if (product == null)
               sError += ", Product";
           if (sError.Length > 0)
               throw new Exception("ProductRetHlp: Los siguientes campos no pueden ser vacíos " + sError.Substring(2));
           if (dctx == null)
               throw new Exception("SqlConection no puede ser nulo");
           SqlCommand sqlCmd = null;
           try
           {
               dctx.Open();
               sqlCmd = dctx.CreateCommand();
           }
           catch (Exception ex)
           {
               throw new Exception("ProductRetHlp");
           }
           SqlParameter sqlParam;
           StringBuilder sCmd = new StringBuilder();
           sCmd.Append("SELECT ProductID, ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued ");
           sCmd.Append(" FROM  Products");
           StringBuilder s_VarWHERE = new StringBuilder();

           if (product!=null && product.CategoryID != null)
           {
               s_VarWHERE.Append("AND CategoryID = @Product_CategoryID ");
               sqlParam = sqlCmd.CreateParameter();
               sqlParam.ParameterName = "Product_CategoryID";
               sqlParam.Value = product.CategoryID;
               sqlParam.DbType = DbType.Int32;
               sqlCmd.Parameters.Add(sqlParam);
           }

           string s_VarWHEREres = s_VarWHERE.ToString().Trim();
           if (s_VarWHEREres.Length > 0)
           {
               if (s_VarWHEREres.StartsWith("AND "))
                   s_VarWHEREres = s_VarWHEREres.Substring(4);
               else if (s_VarWHEREres.StartsWith("OR "))
                   s_VarWHEREres = s_VarWHEREres.Substring(3);
               else if (s_VarWHEREres.StartsWith(","))
                   s_VarWHEREres = s_VarWHEREres.Substring(1);
               sCmd.Append(" WHERE " + s_VarWHEREres);
           }
           //sCmd.Append(" ORDER BY ProductID ASC ");
           DataSet ds = new DataSet();
           DbDataAdapter sqlAdapter = new SqlDataAdapter(sqlCmd);
           sqlAdapter.SelectCommand = sqlCmd;
           try
           {
               sqlCmd.CommandText = sCmd.ToString();

               sqlAdapter.Fill(ds, "Product");
           }
           catch (Exception ex)
           {
               string exmsg = ex.Message;
               try { dctx.Close(); }
               catch (Exception) { }
               throw new Exception("ProductRetHlp: Hubo un error al consultar los registros. " + exmsg);
           }
           finally
           {
               try { dctx.Close(); }
               catch (Exception) { }
           }
           return ds;
       }
    }
}
