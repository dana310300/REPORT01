using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using REPORT01.Model;
using REPORT01.Model.ReportDataContract;
using REPORT01.Services;
using REPORT01.Services;
using DevExpress.XtraReports.UI;
using REPORT01.Services.Service;
using REPORT01.Web.SimpleReports.Reports;

namespace REPORT01.Web.SimpleReports.ReportView
{
    public partial class Viwer01 : System.Web.UI.Page
    {
        public XtraReport LastReport
        {

            get { return Session["SS_rptReport"] != null ? (XtraReport) Session["SS_rptReport"] : null; }

            set { Session["SS_rptReport"] = value; }
        }

        public string LastReportID
        {

            get { return Session["SS_ReportID"] != null ? (string) Session["SS_ReportID"] : Request.QueryString["id"]; }
            set { Session["SS_ReportID"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string rptID = Request.QueryString["id"];
            LastReportID = rptID;
            switch (LastReportID)
            {
                case "2":
                    LoadReport02();
                    break;
                case  "3":
                    LoadReport03();
                    break;
                case "4":
                    LoadReport04();
                    break;
                case "5":
                    LoadReport05();
                    break;
                case "6":
                    LoadReport06();
                    break;
                case "7":
                    LoadReport07();
                    break;
                case "8":
                    LoadReport08();
                    break;
                case "9":
                    LoadReport09();
                    break;

                case "10":
                    LoadReport10();
                    break;
            }
           
        }


        public void LoadReport02()
        {
         string conectionStr = ConfigurationManager.ConnectionStrings["REPORT01"].ConnectionString;
         SqlConnection conn = new SqlConnection(conectionStr);
         CustomerCtrl customerCtrl = new CustomerCtrl();
         DataSet ds= customerCtrl.Retrieve(conn, new Customer());
         SimpleReport02 report = new SimpleReport02 {DataSource = ds,DataMember = "Customers"};
         LastReport = report;
         ReportViewer1.Report = LastReport;
        }

        public void LoadReport03()
        {
            string conectionStr = ConfigurationManager.ConnectionStrings["REPORT01"].ConnectionString;
            SqlConnection conn = new SqlConnection(conectionStr);
            CustomerCtrl customerCtrl = new CustomerCtrl();
            IEnumerable<Customer>  ls = customerCtrl.RetrieveLista(conn, new Customer());
            SimpleReport03 report = new SimpleReport03 { DataSource = ls };
            LastReport = report;
            ReportViewer1.Report = LastReport;
        }

        public void LoadReport04()
        {
            string conectionStr = ConfigurationManager.ConnectionStrings["REPORT01"].ConnectionString;
            SqlConnection conn = new SqlConnection(conectionStr);
            CustomerCtrl customerCtrl = new CustomerCtrl();
            IEnumerable<Customer> ls = customerCtrl.RetrieveLista(conn, new Customer());
            SimpleReport04 report = new SimpleReport04 { DataSource = ls };
            LastReport = report;
            ReportViewer1.Report = LastReport;
            
        }

        public void LoadReport05()
        {
            string conectionStr = ConfigurationManager.ConnectionStrings["REPORT01"].ConnectionString;
            SqlConnection conn = new SqlConnection(conectionStr);
            CategoryCtrl categoryCtrl = new CategoryCtrl();
            IEnumerable<Categories> ls = categoryCtrl.RetrieveCategoriesComplete(conn, new Category());
            SimpleReport05 report = new SimpleReport05 { DataSource = ls };
            LastReport = report;
            ReportViewer1.Report = LastReport;

        }

        public void LoadReport06()
        {
            string conectionStr = ConfigurationManager.ConnectionStrings["REPORT01"].ConnectionString;
            SqlConnection conn = new SqlConnection(conectionStr);
            CustomerCtrl customerCtrl = new CustomerCtrl();
            IEnumerable<Customer> ls = customerCtrl.RetrieveLista(conn, new Customer());
            SimpleReport06 report = new SimpleReport06 { DataSource = ls };
            LastReport = report;
            ReportViewer1.Report = LastReport;
        }

        public void LoadReport07()
        {
            string conectionStr = ConfigurationManager.ConnectionStrings["REPORT01"].ConnectionString;
            SqlConnection conn = new SqlConnection(conectionStr);
            CategoryCtrl categoryCtrl = new CategoryCtrl();
            IEnumerable<Category> ls = categoryCtrl.RetrieveListaComplete(conn, new Category());
            SimpleReport07 report = new SimpleReport07 { DataSource = ls };
            report.nameReport.Value = "Reporte 07:Parámetros y Maestro detalles";
            LastReport = report;
            ReportViewer1.Report = LastReport;

        }

        public void LoadReport08()
        {
            string conectionStr = ConfigurationManager.ConnectionStrings["REPORT01"].ConnectionString;
            SqlConnection conn = new SqlConnection(conectionStr);
            ProductCtrl productCtrl = new ProductCtrl();
            IEnumerable<Product> ls = productCtrl.RetrieveLista(conn, new Product());
            SimpleReport08 report = new SimpleReport08 { DataSource = ls };
            LastReport = report;
            ReportViewer1.Report = LastReport;

        }

        public void LoadReport09()
        {
            string conectionStr = ConfigurationManager.ConnectionStrings["REPORT01"].ConnectionString;
            SqlConnection conn = new SqlConnection(conectionStr);
            RptProductContractCtrl rptproductCtrl = new RptProductContractCtrl();
            IEnumerable<RptProductContract> ls = rptproductCtrl.RetrieveLista(conn, new RptProductContract());
            
            ProductCtrl productCtrl = new ProductCtrl();
            IEnumerable<Product> lsp = productCtrl.RetrieveLista(conn, new Product { CategoryID =4});

            SimpleReport09 report = new SimpleReport09();

            report.xrChart1.DataSource = ls;
            report.xrChartProduct.DataSource = lsp;
            LastReport = report;
            ReportViewer1.Report = LastReport;

        }

        public void LoadReport10()
        {

            string conectionStr = ConfigurationManager.ConnectionStrings["REPORT01"].ConnectionString;
            SqlConnection conn = new SqlConnection(conectionStr);
            CategoryCtrl categoryCtrl = new CategoryCtrl();
            IEnumerable<Category> ls = categoryCtrl.RetrieveListaComplete(conn, new Category());
            SimpleReport10 report = new SimpleReport10 { DataSource = ls };
            LastReport = report;
            ReportViewer1.Report = LastReport;
        }



        protected void ReportViewer1_Unload(object sender, EventArgs e)
        {
            ReportViewer1.Report = null;
        }

        protected override void OnInit(EventArgs e)
        {

              base.OnInit(e);

              if (LastReport == null)
              {
                  switch (LastReportID)
                  {
                      case "2":
                          LoadReport02();
                          break;
                      case "3":
                          LoadReport03();
                          break;
                      case "4":
                          LoadReport04();
                          break;
                      case "5":
                          LoadReport05();
                          break;
                      case "6":
                          LoadReport06();
                          break;
                      case "7":
                          LoadReport07();
                          break;
                      case "8":
                          LoadReport08();
                          break;
                      case "9":
                          LoadReport09();
                          break;

                      case "10":
                          LoadReport10();
                          break;
                  }
                 
                  ReportViewer1.Report = LastReport;
              }
        }
    }
}