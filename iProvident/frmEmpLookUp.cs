using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iProvident
{
    public partial class frmEmpLookUp : DevExpress.XtraEditors.XtraForm
    {
        
        public string SelEmpID = "", mode, LoanStat;
        int Prog;
        int canReloan = clsF.toint(clsF.dtDefV.Rows[0][2].ToString());

        public frmEmpLookUp()
        {
            InitializeComponent();
        }

        private void gvTbl_DoubleClick(object sender, EventArgs e)
        {
            switch (mode)
            {
                case "BID":
                    LoanStat = gvTbl.GetRowCellValue(gvTbl.FocusedRowHandle, gvTbl.Columns["Loan"]).ToString();

                    if (LoanStat != "")
                    {
                        if (LoanStat == "Waiting" || LoanStat == "Cancelled")
                        {
                            MessageBox.Show("Employee has Pending Status.", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            Prog = int.Parse(LoanStat.Replace("Open (", "").Replace("%)", ""));
                            if (Prog < canReloan)
                            {
                                MessageBox.Show($"Employee must have paid at least {canReloan}%.", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                    break;

                case "CID":
                    if (clsF.toint(gvTbl.GetRowCellValue(gvTbl.FocusedRowHandle, gvTbl.Columns["Com#"]).ToString()) >= clsF.toint(clsF.dtDefV.Rows[17][2].ToString()))
                    {
                        MessageBox.Show("Maximum numbered of being Co-Maker exceeds.", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;
            }

            SelEmpID = gvTbl.GetRowCellValue(gvTbl.FocusedRowHandle, gvTbl.Columns["EmpID"]).ToString();
            this.Close();

        }

        private void frmEmpLookUp_Shown(object sender, EventArgs e)
        {

            gcTbl.DataSource = clsF.qDtbl("EXEC getEmpLookUp;");
            gvTbl.Columns["MI"].MaxWidth = 25;
            gvTbl.Columns["Com#"].MaxWidth = 40;
            gvTbl.Columns["EmpID"].MaxWidth = 70;
            gvTbl.Columns["Loan"].MaxWidth = 80;
            gcTbl.Focus();
            gvTbl.ShowFindPanel();
        }
    }
}