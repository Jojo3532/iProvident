using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace iProvident
{
    public partial class rptClearance : DevExpress.XtraReports.UI.XtraReport
    {
        public rptClearance()
        {
            InitializeComponent();
        }

        private void rptClearance_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }
    }
}
