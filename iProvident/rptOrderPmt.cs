using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace iProvident
{
    public partial class rptOrderPmt : DevExpress.XtraReports.UI.XtraReport
    {
        public rptOrderPmt()
        {
            InitializeComponent();
        }

        private void frmOrderPmt_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            txtEntity.Text = clsF.dtDefV.Rows[18][2].ToString();
            txtAssig1.Text = clsF.dtDefV.Rows[19][2].ToString();
            txtPos1.Text = clsF.dtDefV.Rows[20][2].ToString();
            txtAssig2.Text = clsF.dtDefV.Rows[14][2].ToString();
            txtAssig2Pos.Text = clsF.dtDefV.Rows[15][2].ToString();
        }
    }
}
