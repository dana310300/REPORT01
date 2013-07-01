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
   internal class CustomerRetHlp
    {
       public DataSet Action(SqlConnection dctx, Customer customer)
       {
          
           string sError = "";
           if (customer == null)
               sError += ", Customer";
           if (sError.Length > 0)
               throw new Exception("CustomerRetHlp: Los siguientes campos no pueden ser vacíos " + sError.Substring(2));
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
               throw new Exception("CustomerRetHlp");
           }
           DbParameter sqlParam;
           StringBuilder sCmd = new StringBuilder();
           sCmd.Append(" SELECT  Customers.CustomerID, Customers.CompanyName, Customers.ContactName, Customers.ContactTitle, Customers.Address, Customers.City, Customers.Region, ");
           sCmd.Append("Customers.PostalCode, Customers.Country, Customers.Phone, Customers.Fax ");
           sCmd.Append(" FROM Customers ");
           StringBuilder s_VarWHERE = new StringBuilder();

           //if (customer.CustomerID != null)
           //{
           //    s_VarWHERE.Append(" CustomerID = Customer_CustomerID ");
           //    sqlParam = sqlCmd.CreateParameter();
           //    sqlParam.ParameterName = "Customer_CustomerID";
           //    sqlParam.Value = customer.CustomerID;
           //    sqlParam.DbType = DbType.String;
           //    sqlCmd.Parameters.Add(sqlParam);
           //}
         
           //string s_VarWHEREres = s_VarWHERE.ToString().Trim();
           //if (s_VarWHEREres.Length > 0)
           //{
           //    if (s_VarWHEREres.StartsWith("AND "))
           //        s_VarWHEREres = s_VarWHEREres.Substring(4);
           //    else if (s_VarWHEREres.StartsWith("OR "))
           //        s_VarWHEREres = s_VarWHEREres.Substring(3);
           //    else if (s_VarWHEREres.StartsWith(","))
           //        s_VarWHEREres = s_VarWHEREres.Substring(1);
           //    sCmd.Append(" WHERE " + s_VarWHEREres);
           //}
           //sCmd.Append(" ORDER BY CustomerID ASC ");
           DataSet ds = new DataSet();
           DbDataAdapter sqlAdapter = new SqlDataAdapter(sqlCmd);
           sqlAdapter.SelectCommand = sqlCmd;
           try
           {
               sqlCmd.CommandText = sCmd.ToString();

               sqlAdapter.Fill(ds, "Customer");
           }
           catch (Exception ex)
           {
               string exmsg = ex.Message;
               try { dctx.Close(); }
               catch (Exception) { }
               throw new Exception("CustomerRetHlp: Hubo un error al consultar los registros. " + exmsg);
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
