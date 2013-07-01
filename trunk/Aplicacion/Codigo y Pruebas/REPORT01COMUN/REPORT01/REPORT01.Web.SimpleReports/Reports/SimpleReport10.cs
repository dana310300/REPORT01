using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace REPORT01.Web.SimpleReports.Reports
{
    public partial class SimpleReport10 : DevExpress.XtraReports.UI.XtraReport
    {
        public SimpleReport10()
        {
            InitializeComponent();
        }

        private void xrChart1_CustomDrawSeriesPoint(object sender, DevExpress.XtraCharts.CustomDrawSeriesPointEventArgs e)
        {
            e.LegendText = e.SeriesPoint.Argument == "0" ? "Vigente" : "Descontinuado";
        }
    }
}
