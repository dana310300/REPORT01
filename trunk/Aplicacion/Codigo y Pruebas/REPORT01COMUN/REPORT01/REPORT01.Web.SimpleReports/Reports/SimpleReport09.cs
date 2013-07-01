using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraCharts;
using DevExpress.XtraReports.UI;

namespace REPORT01.Web.SimpleReports.Reports
{
    public partial class SimpleReport09 : DevExpress.XtraReports.UI.XtraReport
    {
        public SimpleReport09()
        {
            InitializeComponent();
            InitControls();
        }

        private void InitControls()
        {
            var point = new Series("UnitsInStockPoint",ViewType.Point);
            point.ArgumentDataMember = "ProductName";
            point.ValueDataMembers.AddRange("UnitsInStock");
            point.LegendText = "unidades en Stock (punto)";
            (point.View as XYDiagramSeriesViewBase).Pane = (xrChartProduct.Diagram as XYDiagram2D).Panes[0];

            xrChartProduct.Series.Add(point);
        }
    }
}
