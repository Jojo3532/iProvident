using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace iProvident
{
    public partial class rptAmrt2 : DevExpress.XtraReports.UI.XtraReport
    {
        public rptAmrt2()
        {
            InitializeComponent();
        }

        private void rptAmrt2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            txtAssig2.Text = clsF.dtDefV.Rows[14][2].ToString();
            txtAssig2Pos.Text = clsF.dtDefV.Rows[15][2].ToString();
        }
    }
}
