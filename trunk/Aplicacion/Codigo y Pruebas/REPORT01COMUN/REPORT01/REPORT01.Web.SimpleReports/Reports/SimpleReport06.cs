using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace REPORT01.Web.SimpleReports.Reports
{
    public partial class SimpleReport06 : DevExpress.XtraReports.UI.XtraReport
    {
        public SimpleReport06()
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
            xrTableCell6.DataBindings.Add("Text", DataSource, "Country");
            xrCountry.DataBindings.Add("Text", DataSource, "Country");
            xrCity.DataBindings.Add("Text", DataSource, "City");

            //Crear agrupación por código
            GroupHeaderBand groupheader1 = this.Bands["GroupHeader1"] as GroupHeaderBand;
            if (groupheader1 != null)
            {
                GroupField groupField1 = new GroupField("Country");
                GroupField groupField2 = new GroupField("City");
                groupheader1.GroupFields.Add(groupField1);
                groupheader1.GroupFields.Add(groupField2);
            }
      

        }

    }
}
