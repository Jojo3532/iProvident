using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace iProvident
{
    public partial class frmBreakDown : DevExpress.XtraEditors.XtraForm
    {
        public frmBreakDown()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                string selDate = dtDate.DateTime.ToString("MM/01/yyyy");
                frmView fView = new frmView();
                fView.qq = "SELECT l.[AsDate] AS 'AsOf', FORMAT(l.LoanNo, '000000') AS LoanNo, e.EmpID, e.LastName, e.FirstName, e.MI, l.Period, l.Principal, l.Interest, l.CashFlow, l.Balance, l.CollectionID, l.Remarks" +
                    $" FROM (SELECT LoanNo, Period, Principal, Interest, Cashflow, FORMAT([Date], 'yyyy-MM') AS [AsDate], Balance, CollectionID, Remarks FROM tblLedger WHERE [Date] = '{selDate}' AND Remarks IS NOT NULL) l" +
                     " LEFT JOIN tblLoan ln ON l.LoanNo = ln.LoanNo LEFT JOIN tblEmployee e ON ln.BorrowersID = e.EmpID;";
                fView.gcTbl.DataSource = clsF.qDtbl(fView.qq);
                fView.gvTbl.OptionsSelection.MultiSelect = true;
                fView.Text = dtDate.DateTime.ToString("yyyy-MM") + " (Breakdown)";
                fView.TopLevel = false;
                fView.FormBorderStyle = FormBorderStyle.None;
                fView.WindowState = FormWindowState.Maximized;
                panelSelect.Hide();
                mainPanel.Controls.Add(fView);
                fView.Show();
                this.Text = fView.Text;
            } catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
            
        }

        private void frmBreakDown_Shown(object sender, EventArgs e)
        {
            dtDate.DateTime = DateTime.Now.AddMonths(-1);
        }
    }
}