using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Repository;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace iProvident
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //FORMS
        frmView fActive, fApproval, fCancelled, fEmployee, fOP;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            //Load Default Values ♥
            lblUser.Caption = clsF.dtUser.Rows[0]["FullName"].ToString();
            clsF.CIRpMonth = double.Parse(clsF.dtDefV.Rows[1][2].ToString());
            clsF.maxLoan = double.Parse(clsF.dtDefV.Rows[3][2].ToString());
            clsF.maxMonth = double.Parse(clsF.dtDefV.Rows[4][2].ToString());
            clsF.minNetP = double.Parse(clsF.dtDefV.Rows[5][2].ToString());
            brKeepM.Checked = Properties.Settings.Default.KeepMeSign;

            DataTable dtT = new DataTable();
            dtT = clsF.qDtbl("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES ORDER BY TABLE_NAME;");
            foreach(DataRow rw in dtT.Rows)
            {
                btnTbls.Strings.Add(rw["TABLE_NAME"].ToString());
            }
            clsF.getActiveLoan();
            ssm1.CloseWaitForm();
        }
        private void btnBackUp_ItemClick(object sender, ItemClickEventArgs e)
        {
            sfdBackUp.FileName = "iProvD_" + DateTime.Now.ToString("yyMMdd");
            sfdBackUp.ShowDialog();
        }

        private void sfdBackUp_FileOk(object sender, CancelEventArgs e)
        {
            ssm1.ShowWaitForm();
            if (clsF.rNTQ($"BACKUP DATABASE iProvD TO  DISK = '{sfdBackUp.FileName}'"))
            {
                ssm1.CloseWaitForm();
                MessageBox.Show("Back-up was successfully created!", "Back-Up:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ssm1.CloseWaitForm();
                e.Cancel = true;
            }
        }

        private void btnResDb_ItemClick(object sender, ItemClickEventArgs e)
        {
            ofdRestore.ShowDialog();
        }

        private void ofdRestore_FileOk(object sender, CancelEventArgs e)
        {
            ssm1.ShowWaitForm();
            clsF.Restore(ofdRestore.FileName);
            ssm1.CloseWaitForm();
        }


        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Properties.Settings.Default.Username = "";
            Properties.Settings.Default.Password = "";
            Properties.Settings.Default.Save();
            frmLogIn frm = new frmLogIn();
            this.Hide();
            frm.ShowDialog();
            this.Dispose();
        }

        private void btnAddL_ItemClick(object sender, ItemClickEventArgs e)
        {
            ssm1.ShowWaitForm();
            frmNewLoan fNewLoan = new frmNewLoan();
            fNewLoan.MdiParent = this;
            fNewLoan.Show();
            ssm1.CloseWaitForm();
        }
        private void btnActive_ItemClick(object sender, ItemClickEventArgs e)
        {
            //if (clsF.is_fActive)
            //{
            //    fActive.Focus();
            //}
            //else
            //{
                //TODO: simplify code
                ssm1.ShowWaitForm();
                fActive = new frmView();
                fActive.Text = "Active Loans";
                fActive.qq = "EXEC getLoans 'Open';"; //-- duplicated code
                fActive.gcTbl.DataSource = clsF.dtActiveL;
                fActive.gvTbl.Columns[fActive.gvTbl.Columns.Count() - 1].Visible = false;
                fActive.gvTbl.Columns["LoanApplied"].DisplayFormat.FormatType = FormatType.Numeric;
                fActive.gvTbl.Columns["LoanApplied"].DisplayFormat.FormatString = "#,#0.00";
                fActive.gvTbl.Columns["MonthlyAmrt"].DisplayFormat.FormatType = FormatType.Numeric;
                fActive.gvTbl.Columns["MonthlyAmrt"].DisplayFormat.FormatString = "#,#0.00";
                fActive.gvTbl.Columns["Balance"].DisplayFormat.FormatType = FormatType.Numeric;
                fActive.gvTbl.Columns["Balance"].DisplayFormat.FormatString = "#,#0.00";
                fActive.gvTbl.Columns["LoanNo"].MaxWidth = 65;
                fActive.gvTbl.BestFitColumns();

                //Adding ProgressBar
                RepositoryItemProgressBar rPy = new RepositoryItemProgressBar();
                rPy.Minimum = 0;
                rPy.Maximum = 100;
                rPy.ShowTitle = true;
                fActive.gcTbl.RepositoryItems.Add(rPy);
                fActive.gvTbl.Columns["Progress"].ColumnEdit = rPy;

                fActive.MdiParent = this;
                fActive.Show();
                clsF.is_fActive = true;
                ssm1.CloseWaitForm();
            //}

        }

        private void btnCancelled_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (clsF.is_fCancelled)
            {
                fCancelled.Focus();
            }
            else
            {
                //TODO: simplify code
                ssm1.ShowWaitForm();
                fCancelled = new frmView();
                fCancelled.Text = "Cancelled";
                fCancelled.qq = "EXEC getLoansMin 'Cancelled';";
                fCancelled.gcTbl.DataSource = clsF.qDtbl(fCancelled.qq);
                fCancelled.gvTbl.Columns["LoanApplied"].DisplayFormat.FormatType = FormatType.Numeric;
                fCancelled.gvTbl.Columns["LoanApplied"].DisplayFormat.FormatString = "#,#0.00";
                fCancelled.gvTbl.Columns["MonthlyAmrt"].DisplayFormat.FormatType = FormatType.Numeric;
                fCancelled.gvTbl.Columns["MonthlyAmrt"].DisplayFormat.FormatString = "#,#0.00";
                fCancelled.gvTbl.Columns["NetProceeds"].DisplayFormat.FormatType = FormatType.Numeric;
                fCancelled.gvTbl.Columns["NetProceeds"].DisplayFormat.FormatString = "#,#0.00";
                fCancelled.gvTbl.Columns["LoanNo"].MaxWidth = 65;
                fCancelled.gvTbl.BestFitColumns();

                fCancelled.MdiParent = this;
                fCancelled.Show();
                clsF.is_fCancelled = true;
                ssm1.CloseWaitForm();
            }
        }

        private void btnFApproval_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (clsF.is_fApproval)
            {
                fApproval.Focus();
            }
            else
            {
                //TODO: simplify code
                ssm1.ShowWaitForm();
                fApproval = new frmView();
                fApproval.Text = "For Approval";
                fApproval.qq = "EXEC getLoansMin 'Waiting';";
                fApproval.gcTbl.DataSource = clsF.qDtbl(fApproval.qq);
                fApproval.gvTbl.Columns["LoanApplied"].DisplayFormat.FormatType = FormatType.Numeric;
                fApproval.gvTbl.Columns["LoanApplied"].DisplayFormat.FormatString = "#,#0.00";
                fApproval.gvTbl.Columns["MonthlyAmrt"].DisplayFormat.FormatType = FormatType.Numeric;
                fApproval.gvTbl.Columns["MonthlyAmrt"].DisplayFormat.FormatString = "#,#0.00";
                fApproval.gvTbl.Columns["NetProceeds"].DisplayFormat.FormatType = FormatType.Numeric;
                fApproval.gvTbl.Columns["NetProceeds"].DisplayFormat.FormatString = "#,#0.00";
                fApproval.gvTbl.Columns["LoanNo"].MaxWidth = 65;
                fApproval.gvTbl.BestFitColumns();

                fApproval.MdiParent = this;
                fApproval.Show();
                clsF.is_fApproval = true;
                ssm1.CloseWaitForm();
            }
        }

        private void btnUnpaid_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnMaEmp_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (clsF.is_fEmployee)
            {
                fEmployee.Focus();
            }
            else
            {
                ssm1.ShowWaitForm();
                fEmployee = new frmView();
                fEmployee.Text = "Employee";
                fEmployee.qq = "SELECT EmpID, LastName, FirstName, MI, ContactNo, PositionID, FORMAT(StationNo, '000') AS StationNo, OfficeID, CollectionID, EmpStatus, CASE WHEN Times IS NULL THEN NULL WHEN Times = 0 THEN Loan ELSE CONCAT(Loan, ' (', Times, ')') END AS Loans" +
                    " FROM tblEmployee e LEFT JOIN (SELECT BorrowersID, COUNT(LoanNo)-1 AS Times FROM tblLoan WHERE [Status] != 'Close' GROUP BY BorrowersID) l ON e.EmpID = l.BorrowersID" +
                    " ORDER BY LastName, FirstName;";
                fEmployee.gcTbl.DataSource = clsF.qDtbl(fEmployee.qq);
                fEmployee.MdiParent = this;
                fEmployee.gvTbl.Columns["MI"].MaxWidth = 65;
                fEmployee.Show();
                clsF.is_fEmployee = true;
                ssm1.CloseWaitForm();
            }
        }

        private void btnNewE_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmEmpDtl frmN = new frmEmpDtl();
            frmN.MdiParent = this;
            frmN.Show();
        }

        private void btnClearance_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmClearance fC = new frmClearance();
            fC.MdiParent = this;
            fC.Show();
        }

        private void btnBreakD_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmBreakDown fBd = new frmBreakDown();
            fBd.MdiParent = this;
            fBd.Show();
        }

        private void btnTbls_ListItemClick(object sender, ListItemClickEventArgs e)
        {
            string selItem = btnTbls.Strings[e.Index];
            frmEditTable fEdit = new frmEditTable();
            fEdit.MdiParent = this;
            fEdit.qq = $"SELECT * FROM {selItem};";
            fEdit.gvTbl.OptionsView.ColumnAutoWidth = false;
            fEdit.Text = selItem;
            fEdit.Show();
        }

        private void brKeepM_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            Properties.Settings.Default.KeepMeSign = brKeepM.Checked;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ssm1.ShowWaitForm();
        }

        private void btnOrderP_ItemClick(object sender, ItemClickEventArgs e)
        {
            ssm1.ShowWaitForm();
            fOP = new frmView();
            fOP.Text = "Order Pmt";
            fOP.qq = "SELECT TOP 100 SerialNo, [Date], LastName, FirstName, MI, Particular, FORMAT(Principal, 'n2') Principal, FORMAT(Interest, 'n2') Interest, FORMAT(Amount, 'n2') Amount, ORNo" +
                " FROM tblOrderPmt o LEFT JOIN tblLoan l ON o.LoanNo = l.LoanNo LEFT JOIN tblEmployee e ON l.BorrowersID = e.EmpID ORDER BY SerialNo DESC;";
            fOP.gcTbl.DataSource = clsF.qDtbl(fOP.qq);
            fOP.MdiParent = this;
            fOP.Show();
            fOP.gvTbl.BestFitColumns();
            clsF.is_fEmployee = true;
            ssm1.CloseWaitForm();
        }

        private void btnForm_ItemClick(object sender, ItemClickEventArgs e)
        {
            rptAppForm rptFrm = new rptAppForm();
            docViewer dcV = new docViewer();
            dcV.dcViewer.DocumentSource = rptFrm;
            rptFrm.DisplayName = "Application Form";
            dcV.Text = "Application Form";
            dcV.MdiParent = this;
            dcV.Show();
        }

        private void brBiller_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmBiller fBiller = new frmBiller();

            fBiller.MdiParent= this;
            fBiller.Show();
        }

        private void btnDEDRECS_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ofdDEDRECS.ShowDialog() == DialogResult.OK)
            {
                ssm1.ShowWaitForm();
                frmDedrecs frm = new frmDedrecs();
                frm.MdiParent = this;
                frm.xlsFile = ofdDEDRECS.FileName;
                frm.Text = ofdDEDRECS.SafeFileName;
                frm.Show();
                ssm1.CloseWaitForm();
            }
        }

       
    }
}