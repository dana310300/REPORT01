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
  public  class CustomerCtrl
    {

      public  CustomerCtrl()
      {
      }


      public  DataSet Retrieve(SqlConnection sqlConnection,Customer cu)
      {
          DataSet ds = (new CustomerRetHlp().Action(sqlConnection, cu));

          return ds;
      }

      public  IEnumerable<Customer> RetrieveLista(SqlConnection sqlConnection,Customer cu) 
      {
          List<Customer> ls= new List<Customer>();

          DataSet ds = (new CustomerRetHlp().Action(sqlConnection, cu));
          if (ds.Tables[0].Rows.Count > 0)
          {
              foreach (DataRow customer in ds.Tables[0].Rows)
              {
                  ls.Add(DataRowToCustomer(customer));
              }
          }
          return ls;
      }
 
      public Customer DataRowToCustomer(DataRow row)
      {
          Customer customer = new Customer();

          if (row != null)
          {
              if (row["CustomerID"] != null)
              {
                  customer.CustomerID = row["CustomerID"].ToString();
              }

              if (row["CompanyName"] != null)
              {
                  customer.ComanyName = row["CompanyName"].ToString();
              }
              if (row["ContactName"] != null)
              {
                  customer.ContactName = row["ContactName"].ToString();
              }
              if (row["ContactTitle"] != null)
              {
                  customer.ContactTitle = row["ContactTitle"].ToString();
              }
              if (row["Address"] != null)
              {
                  customer.Address = row["Address"].ToString();
              }
              if (row["City"] != null)
              {
                  customer.City = row["City"].ToString();
              }
              if (row["Region"] != null)
              {
                  customer.Region = row["Region"].ToString();
              }
              if (row["PostalCode"] != null)
              {
                  customer.PostalCode = row["PostalCode"].ToString();
              }
              if (row["Country"] != null)
              {
                  customer.Country = row["Country"].ToString();
              }
              if (row["Phone"] != null)
              {
                  customer.Phone = row["Phone"].ToString();
              }
              if (row["Fax"] != null)
              {
                  customer.Fax = row["Fax"].ToString();
              }
          }

          return customer;
      }
    }
}
