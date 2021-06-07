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
using System.Data.SqlClient;
using DevExpress.XtraGrid;

namespace iProvident
{
    public partial class frmLoan : DevExpress.XtraEditors.XtraForm
    {
        public string qq, LN, EmpID;
        public bool saved = false;
        DataTable dtbl;
        SqlDataAdapter sqlDa;
        SqlCommandBuilder sqlcb;
        public frmLoan()
        {
            InitializeComponent();
        }

        private void frmLoan_Shown(object sender, EventArgs e)
        {
            this.Text = LN;
            DataTable dt = new DataTable();
            dt = clsF.qDtbl("SELECT l.BorrowersID, l.Note, CONCAT(b.FirstName, ' ', b.MI, '. ', b.LastName) AS Borrower, b.ContactNo AS bContact, CONCAT(c.FirstName, ' ', c.MI, '. ', c.LastName) AS CoMaker, c.ContactNo AS cContact, FORMAT(l.MonthlyAmrt, '#,#0.00') AS Amrt, l.[Status]" +
                $" FROM (SELECT * FROM tblLoan WHERE LoanNo='{LN}') l LEFT JOIN tblEmployee b ON l.BorrowersID = b.EmpID LEFT JOIN tblEmployee c ON l.CoMakersID = c.EmpID;");

            EmpID = dt.Rows[0]["BorrowersID"].ToString();
            txtBorrower.Text = dt.Rows[0]["Borrower"].ToString();
            txtBContact.Text = dt.Rows[0]["bContact"].ToString();
            txtCoMaker.Text = dt.Rows[0]["CoMaker"].ToString();
            txtCContact.Text = dt.Rows[0]["cContact"].ToString();
            txtAmrt.Text = dt.Rows[0]["Amrt"].ToString();
            txtNote.Text = dt.Rows[0]["Note"].ToString();
            cbStatus.EditValue = dt.Rows[0]["Status"].ToString();
            qq = $"SELECT PmtID, LoanNo, CollectionID, [Date], Period, Principal, Interest, CashFlow, Balance, Remarks FROM tblLedger WHERE LoanNo = '{LN}' ORDER BY Period;";
            sqlDa = new SqlDataAdapter(qq, clsF.Conn);
            dtbl = new DataTable();
            sqlDa.Fill(dtbl);

            gcTbl.DataSource = dtbl;
            lblCtr.Text = gvTbl.RowCount.ToString() + " Record(s) Found";
            gvTbl.Columns["PmtID"].Visible = false;
            gvTbl.Columns["LoanNo"].Visible = false;
            gvTbl.BestFitColumns();
            clsF.fMain.ssm1.CloseWaitForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                sqlcb = new SqlCommandBuilder(sqlDa);
                sqlDa.Update(dtbl);
                string stDate = gvTbl.GetRowCellValue(1, "Date").ToString();
                string EmpLoanStat, qq;

                switch (cbStatus.Text)
                {
                    case "Close":
                        EmpLoanStat = "NULL";
                        break;

                    default:
                        EmpLoanStat = "'Open'";
                        break;

                }

                qq = $"UPDATE tblEmployee SET Loan = {EmpLoanStat} WHERE EmpID = '{EmpID}';";

                switch (cbStatus.Text)
                {
                    case "Open":
                        qq += $" UPDATE tblLedger SET Remarks = 'Unpaid' WHERE Remarks = NULL AND LoanNo = '{this.Text}';";
                        break;

                    default:
                        qq += $" UPDATE tblLedger SET Remarks = NULL WHERE Remarks = 'Unpaid' AND LoanNo = '{this.Text}';";
                        break;
                }

                qq += $" UPDATE tblLoan SET TermStart='{stDate}', Note = '{txtNote.Text}', [Status] = '{cbStatus.Text}' WHERE LoanNo = '{this.Text}';";


                if (clsF.rQry(qq))
                {
                    MessageBox.Show($"Successfully {btnSave.Text}d!");
                    saved = true;
                    this.Dispose();
                }                
            }
            catch (Exception)
            {
                MessageBox.Show("Error occur, please double check your data first.");
            }
            
        }

        private void frmLoan_Load(object sender, EventArgs e)
        {
            clsF.fMain.ssm1.ShowWaitForm();
        }

        private void gcTbl_EditorKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control)
            {
                int i = gvTbl.GetSelectedRows()[0];

                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        double CIRpMo = clsF.toDbl(clsF.dtDefV.Rows[1][2].ToString());
                        double Interest, PrevBal, Principal, Amrt = clsF.toDbl(txtAmrt.Text), NewBal, cBal;
                        gvTbl.SetRowCellValue(i, "Principal", clsF.toDbl(gvTbl.GetRowCellDisplayText(i, "CashFlow")) - clsF.toDbl(gvTbl.GetRowCellDisplayText(i, "Interest")));
                        cBal = clsF.toDbl(gvTbl.GetRowCellDisplayText(i - 1, "Balance")) - clsF.toDbl(gvTbl.GetRowCellDisplayText(i, "Principal"));
                        gvTbl.SetRowCellValue(i, "Balance", cBal);

                        while (i < (gvTbl.RowCount - 1))
                        {
                            PrevBal = clsF.toDbl(gvTbl.GetRowCellDisplayText(i, "Balance"));
                            Interest = Math.Ceiling(PrevBal * CIRpMo * 100) / 100;
                            Principal = Amrt - Interest;
                            NewBal = PrevBal - Principal;
                            i++;
                            gvTbl.SetRowCellValue(i, "Principal", Principal.ToString("#.00"));
                            gvTbl.SetRowCellValue(i, "Interest", Interest.ToString("#.00"));
                            gvTbl.SetRowCellValue(i, "CashFlow", Amrt.ToString("#.00"));
                            gvTbl.SetRowCellValue(i, "Balance", NewBal.ToString("#.00"));
                        }

                        if (clsF.toDbl(gvTbl.GetRowCellDisplayText(i, "Balance")) < 0) gvTbl.SetRowCellValue(i, "Balance", "0.00");
                        break;

                    case Keys.Delete:
                        if (MessageBox.Show("Are you sure to delete the current row?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            gvTbl.DeleteSelectedRows();
                        }
                        break;

                    case Keys.D:
                        DateTime cDT = new DateTime(), nDT = new DateTime();
                        while (i < (gvTbl.RowCount - 1))
                        {
                            cDT = DateTime.Parse(gvTbl.GetRowCellDisplayText(i, "Date"));
                            nDT = cDT.AddMonths(1);
                            i++;
                            gvTbl.SetRowCellValue(i, "Date", nDT);
                        }
                        break;

                    case Keys.R:
                        gvTbl.AddNewRow();
                        gvTbl.SetRowCellValue(GridControl.NewItemRowHandle, gvTbl.Columns["LoanNo"], this.Text);
                break;
                }
            }
        }
    }
}