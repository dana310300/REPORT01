using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace REPORT01.Web.SimpleReports.Reports
{
    public partial class SimpleReport02 : DevExpress.XtraReports.UI.XtraReport
    {
        public SimpleReport02()
        {
            InitializeComponent();
            BoundControls();
        }

        public void BoundControls()
        {
            xrTableCell1.DataBindings.Add("Text", DataSource, "CustomerID");
            xrTableCell2.DataBindings.Add("Text", DataSource, "CompanyName");
            xrTableCell3.DataBindings.Add("Text", DataSource, "ContactName");
            xrTableCell4.DataBindings.Add("Text", DataSource, "ContactTitle");
            xrTableCell5.DataBindings.Add("Text", DataSource, "City");

        }
    }
}
