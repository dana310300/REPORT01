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
    public class CategoryCtrl
    {

        public DataSet Retrieve(SqlConnection sqlConnection, Category cu)
        {
            DataSet ds = (new CategoryRetHlp().Action(sqlConnection, cu));

            return ds;
        }

        public IEnumerable<Category> RetrieveLista(SqlConnection sqlConnection, Category cu)
        {
            List<Category> ls = new List<Category>();

            DataSet ds = (new CategoryRetHlp().Action(sqlConnection, cu));
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow category in ds.Tables[0].Rows)
                {
                    ls.Add(DataRowTocategory(category));
                }
            }
            return ls;
        }

        public  IEnumerable<Category> RetrieveListaComplete(SqlConnection sqlConnection,Category cu)
        {
            List<Category> ls = new List<Category>();
            List<Category> lscat = (List<Category>)RetrieveLista(sqlConnection, cu);
            ProductCtrl productCtrl = new ProductCtrl();

            foreach (Category item in lscat)
            {
                Category ci = item;
                ci.CategoryProducts= new List<Product>();
                ci.CategoryProducts = (List<Product>)productCtrl.RetrieveLista(sqlConnection, new Product { CategoryID = item.CategoryID });
                //ci.Products = (List<Product>)productCtrl.RetrieveLista(sqlConnection, new Product { CategoryID = item.CategoryID });
                ls.Add(ci);
            }

            return ls;

        }

        public  IEnumerable<Categories> RetrieveCategoriesComplete(SqlConnection sqlConnection,Category cu)
        {
            List<Categories> ls = new List<Categories>();
            List<Category> lscat = (List<Category>)RetrieveLista(sqlConnection, cu);
            ProductCtrl productCtrl = new ProductCtrl();

            foreach (Category item in lscat)
            {
               Categories ci = new Categories {Category = item,Products = new List<Product>()};
               ci.Products= (List<Product>) productCtrl.RetrieveLista(sqlConnection, new Product { CategoryID = item.CategoryID });
               ls.Add(ci);
            }

            return ls;
        }

        public Category DataRowTocategory(DataRow row)
        {
            Category category = new Category();

            if (row != null)
            {
                //CategoryID, CategoryName, Description, Picture
                if (row["categoryID"] != null)
                {
                    category.CategoryID =int.Parse(row["CategoryID"].ToString());
                }

                if (row["CategoryName"] != null)
                {
                    category.CategoryName = row["CategoryName"].ToString();
                }
                if (row["Description"] != null)
                {
                    category.Description = row["Description"].ToString();
                }
                if (row["Picture"] != null)
                {
                    category.Picture = (byte[]) Convert.ChangeType(row["Picture"], typeof (byte[]));
                }
               
            }

            return category;
        }
    }
}
