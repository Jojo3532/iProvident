using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace iProvident
{
    public partial class rptAppForm : DevExpress.XtraReports.UI.XtraReport
    {
        public rptAppForm()
        {
            InitializeComponent();
        }

        private void rptAppForm_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            rSecName.Text = clsF.dtUser.Rows[0]["FullName"].ToString();
            rSecName2.Text = rSecName.Text;
            rAssig1Name.Text = clsF.dtDefV.Rows[10]["Value"].ToString();
            rAssig1Pos.Text = clsF.dtDefV.Rows[11]["Value"].ToString();
            rAssig2Name.Text = clsF.dtDefV.Rows[12]["Value"].ToString();
            rAssig2Pos.Text = clsF.dtDefV.Rows[13]["Value"].ToString();
            rSDS.Text = clsF.dtDefV.Rows[8]["Value"].ToString();
        }
    }
}
