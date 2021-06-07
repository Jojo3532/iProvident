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
using DevExpress.XtraGrid;
using DevExpress.Data;

namespace iProvident
{
    public partial class frmAmrt : DevExpress.XtraEditors.XtraForm
    {
        public double dTInterest = 0, dTPrincipal = 0, dTCashflow = 0;
        string EmpNo;
        public frmAmrt()
        {
            InitializeComponent();
        }

        private void frmAmrt_Shown(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = clsF.qDtbl("SELECT CONCAT(b.FirstName, ' ', b.MI, '. ', b.LastName) AS Name," +
                " c.Office, a.LoanApplied, a.LType, a.MonthlyAmrt, a.TermStart, a.Term, a.DVDate," +
                " a.DVNo, a.NetProceeds, a.Note, b.EmpID" +
              " FROM tblLoan a INNER JOIN tblEmployee b ON a.BorrowersID = b.EmpID INNER JOIN tblOffice c ON b.OfficeID = c.OfficeID" +
              $" WHERE a.LoanNo='{txtLoanNo.Text}';");

            txtBName.Text = dt.Rows[0]["Name"].ToString();
            txtOffice.Text = dt.Rows[0]["Office"].ToString();
            txtPrincipalAmt.Text = clsF.toDbl(dt.Rows[0]["LoanApplied"].ToString()).ToString("#,#0.00");
            txtMonthlyDed.Text = clsF.toDbl(dt.Rows[0]["MonthlyAmrt"].ToString()).ToString("#,#0.00");
            txtLType.Text = dt.Rows[0]["LType"].ToString();
            txtTMos.Text = dt.Rows[0]["Term"].ToString();
            txtDVNo.Text = dt.Rows[0]["DVNo"].ToString();
            txtNetProc.Text = clsF.toDbl(dt.Rows[0]["NetProceeds"].ToString()).ToString("#,#0.00");
            txtNote.Text = dt.Rows[0]["Note"].ToString();
            txtCIR.Text = (clsF.toDbl(clsF.dtDefV.Rows[1][2].ToString()) * 1200).ToString("0.000") ;
            EmpNo = dt.Rows[0]["EmpID"].ToString();
            try
            {
                txtPStart.DateTime = DateTime.Parse(dt.Rows[0]["TermStart"].ToString());
                txtDate.DateTime = DateTime.Parse(dt.Rows[0]["DVDate"].ToString());
            }
            catch (Exception)
            {
                txtPStart.DateTime = DateTime.Now.AddMonths(1);
                txtDate.DateTime = DateTime.Now;
            }

            if (txtDate.Text == "")
            {
              txtDate.DateTime = DateTime.Now;
              txtPStart.DateTime = DateTime.Now.AddMonths(1);
            }

            popGrid();
        }

        private void txtMonthlyDed_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Month");
                dt.Columns.Add("InstallmentPeriod");
                dt.Columns.Add("Principal");
                dt.Columns.Add("Interest");
                dt.Columns.Add("TotalCashflow");
                dt.Columns.Add("PrincipalBalance");

                dt.Rows.Add(txtDate.Text, "0", "0", "0", "0", txtPrincipalAmt.Text);

                int Tmos = int.Parse(txtTMos.Text);
                int ctr = 0;
                string LastMonth;
                string Amrt = txtMonthlyDed.Text;
                double Interest, Principal, NewBalance;
                dTInterest = 0;
                dTPrincipal = 0;
                dTCashflow = 0;

                Interest = clsF.toDbl(dt.Rows[ctr][5].ToString()) * clsF.toDbl(clsF.dtDefV.Rows[1][2].ToString());
                Interest = clsF.toDbl((Math.Floor(Interest * 1000) / 1000).ToString("#,#0.00"));
                Principal = clsF.toDbl(txtMonthlyDed.Text) - Interest;

                while (Tmos >= ctr + 1)
                {
                    if (ctr != 0)
                    {
                        LastMonth = DateTime.Parse(dt.Rows[ctr][0].ToString()).AddMonths(1).ToString("MMM yyyy");
                    }
                    else
                    {
                        LastMonth = txtPStart.DateTime.ToString("MMM yyyy");
                    }

                    NewBalance = clsF.toDbl(dt.Rows[ctr][5].ToString()) - Principal;

                    if (NewBalance < 0)
                    {
                        Principal = clsF.toDbl(dt.Rows[ctr][5].ToString());
                        Amrt = (Principal + Interest).ToString("#,#0.00");
                        NewBalance = 0;
                    }

                    dt.Rows.Add(LastMonth, (1 + ctr).ToString(), Principal.ToString("#,#0.00"), Interest.ToString("#,#0.00"), Amrt, NewBalance.ToString("#,#0.00"));
                    dTPrincipal += clsF.toDbl(Principal.ToString("#,#0.00"));
                    dTInterest += clsF.toDbl(Interest.ToString("#,#0.00"));
                    dTCashflow += clsF.toDbl(Amrt);
                    ctr++;
                }

                gcAmr.DataSource = null;
                gvAmr.Columns.Clear();
                gcAmr.DataSource = dt;
                dt.Dispose();
                GridColumnSummaryItem TPrincipal = new GridColumnSummaryItem();
                TPrincipal.SummaryType = SummaryItemType.Custom;
                TPrincipal.DisplayFormat = dTPrincipal.ToString("#,#0.00");
                gvAmr.Columns["Principal"].Summary.Clear();
                gvAmr.Columns["Principal"].Summary.Add(TPrincipal);

                GridColumnSummaryItem TInterest = new GridColumnSummaryItem();
                TInterest.SummaryType = SummaryItemType.Custom;
                TInterest.DisplayFormat = dTInterest.ToString("#,#0.00");
                gvAmr.Columns["Interest"].Summary.Clear();
                gvAmr.Columns["Interest"].Summary.Add(TInterest);

                GridColumnSummaryItem TCashflow = new GridColumnSummaryItem();
                TCashflow.SummaryType = SummaryItemType.Custom;
                TCashflow.DisplayFormat = dTCashflow.ToString("#,#0.00");
                gvAmr.Columns["TotalCashflow"].Summary.Clear();
                gvAmr.Columns["TotalCashflow"].Summary.Add(TCashflow);

                txtNIR.Text = (dTInterest / dTPrincipal / (clsF.toint(txtTMos.Text) / 12) * 100).ToString("#.000");

                gvAmr.Columns[0].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gvAmr.Columns[1].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gvAmr.Columns[2].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                gvAmr.Columns[3].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                gvAmr.Columns[4].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                gvAmr.Columns[5].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (txtDVNo.Text == "") txtDVNo.Text = genDVNo();
            string CollID = clsF.qDtbl($"SELECT CollectionID FROM tblEmployee WHERE EmpID = '{EmpNo}';").Rows[0][0].ToString();
            string QQ = "";
            //update tblLoan
            if (txtLType.Text == "Reloan")
            {
                string prevLoan = clsF.qDtbl($"SELECT LoanNo FROM tblLoan WHERE BorrowersID = '{EmpNo}' AND Status='Open';").Rows[0][0].ToString();
                QQ = $"UPDATE tblLoan SET [Status] = 'Reloaned' WHERE LoanNo = '{prevLoan}';" +
                    $" UPDATE tblLedger SET Remarks = NULL WHERE LoanNo = '{prevLoan}' AND Remarks='Unpaid';" +
                    $" UPDATE tblLedger SET Remarks = 'Reloan' WHERE LoanNo = '{prevLoan}' AND Period = (SELECT MIN(Period) AS prd FROM tblLedger WHERE LoanNo = '{prevLoan}' AND Remarks IS NULL);";
            }

            QQ += "UPDATE tblLoan " +
                $" SET TermStart='{txtPStart.Text}', NIRpAnnum ='{txtNIR.Text}', CIRpAnnum ='{txtCIR.Text}'," +
                    $" DVNo ='{txtDVNo.Text}', DVDate ='{txtDate.Text}', TInterest ='{dTInterest}', Status = 'Open', MonthlyAmrt = '{clsF.toDbl(txtMonthlyDed.Text)}' " +
                $" WHERE LoanNo='{txtLoanNo.Text}'; ";

            //INSERT tblPayments
            int gvRows = gvAmr.RowCount;

            for (int i = 0; i < gvRows; i++)
            {
                QQ += "INSERT INTO tblLedger (LoanNo, [Date], Period, Principal, Interest, CashFlow, Balance, CollectionID, Remarks)" +
                    $" VALUES ('{txtLoanNo.Text}', '{gvAmr.GetRowCellDisplayText(i, "Month")}', '{gvAmr.GetRowCellDisplayText(i, "InstallmentPeriod")}', " +
                    $" '{gvAmr.GetRowCellDisplayText(i, "Principal").Replace(",","")}', '{gvAmr.GetRowCellDisplayText(i, "Interest").Replace(",", "")}', '{gvAmr.GetRowCellDisplayText(i, "TotalCashflow").Replace(",", "")}', " +
                    $" '{gvAmr.GetRowCellDisplayText(i, "PrincipalBalance").Replace(",", "")}', '{CollID}', ";
                QQ += i == 0 ? "'Processed'); " : "'Unpaid'); ";
            };

            //update tblEmployee's Loan Status
            QQ += $"UPDATE tblEmployee SET Loan = 'Open' WHERE EmpID = '{EmpNo}';";
            if (clsF.rQry(QQ))
            {
                MessageBox.Show("Successfully Processed!");
                printing();
                clsF.refApproval = true;
                this.Dispose();
            }            
        }

        private string genDVNo()
        {
            string Lprefix = DateTime.Now.Year.ToString().Substring(2, 2) + DateTime.Now.Month.ToString("-00-");
            int Lsuffix = 0;
            try
            {
                DataTable dt = clsF.qDtbl($"SELECT SUBSTRING(MAX([DVNo]), 7, 4) FROM [tblLoan] WHERE [DVNo] LIKE '{Lprefix}%'");
                Lsuffix = clsF.toint(dt.Rows[0][0].ToString()) + 1;
            }
            catch (Exception)
            {
                Lsuffix = 1;
            }
            return Lprefix + Lsuffix.ToString("0000");
        }

        private void printing()
        {
            //Amortization printing
            rptAmrt rpt = new rptAmrt();
            rpt.DataSource = gvAmr.DataSource;
            rpt.lblName.Text = txtBName.Text;
            rpt.lblOffice.Text = txtOffice.Text;
            rpt.lblLNo.Text = txtLoanNo.Text;
            rpt.lblPAmt.Text = "₱ " + txtPrincipalAmt.Text;
            rpt.lblPStart.Text = txtPStart.Text;
            rpt.lblPEnd.Text = txtPEnd.Text;
            rpt.lblInstl.Text = "₱ " + txtMonthlyDed.Text;
            rpt.lblTerm.Text = $"{txtTMos.Text} mos";
            rpt.lblForYr.Text = $"for {clsF.toDbl(txtTMos.Text) / 12} year(s):";
            rpt.lblNIRyr.Text = (clsF.toDbl(txtNIR.Text) * (clsF.toDbl(txtTMos.Text)/12)).ToString("0.000") + "%";
            rpt.lblNIRpAnn.Text = txtNIR.Text + "%";
            rpt.lblCIRAnn.Text = txtCIR.Text + "%";
            rpt.lblCIRMos.Text = (clsF.toDbl(txtCIR.Text) / 12).ToString("0.000") + "%";
            rpt.lblTPrincipal.Text = dTPrincipal.ToString("#0,0.00");
            rpt.lblTInterest.Text = dTInterest.ToString("#0,0.00");
            rpt.lblTCashFlow.Text = dTCashflow.ToString("#0,0.00");
            rpt.lblAsig1.Text = clsF.dtUser.Rows[0]["FullName"].ToString();
            rpt.lblAsig1Pos.Text = clsF.dtUser.Rows[0]["Position"].ToString();
            rpt.lblAsig2.Text = clsF.dtDefV.Rows[14][2].ToString();
            rpt.lblAsig2Pos.Text = clsF.dtDefV.Rows[15][2].ToString();
            clsF.showDcV(rpt, $"AmrtSched_{rpt.lblName.Text}");

            //Printing DV
            DataTable dt1 = new DataTable();
            dt1 = clsF.qDtbl("SELECT a.FirstName, a.MI, a.LastName, a.[Address], b.Term, b.LType, b.LoanApplied, b.PrevBal, b.NetProceeds, b.MonthlyAmrt" +
                $" FROM tblEmployee a INNER JOIN tblLoan b ON a.EmpID = b.BorrowersID WHERE b.LoanNo = '{txtLoanNo.Text}';");

            rptDV rDV = new rptDV();
            rDV.lblPayee.Text = $"{dt1.Rows[0]["FirstName"]} {dt1.Rows[0]["MI"]}. {dt1.Rows[0]["LastName"]}";
            rDV.lblAddress.Text = dt1.Rows[0]["Address"].ToString();
            int Mos = clsF.toint(dt1.Rows[0]["Term"].ToString()) % 12;
            string strForYrs = Mos > 0 ? " and " + Mos.ToString() + " months." : ".";
            rDV.lblForYrs.Text = $"Payment for loan ({dt1.Rows[0]["LType"]}) for {clsF.toint(dt1.Rows[0]["Term"].ToString()) / 12} years{strForYrs}";
            rDV.lblAmtLoan.Text = clsF.toDbl(dt1.Rows[0]["LoanApplied"].ToString()).ToString("#0,0.00");
            rDV.lblOutBal.Text = clsF.toDbl(dt1.Rows[0]["PrevBal"].ToString()).ToString("#0,0.00");
            rDV.lblNetProc.Text = clsF.toDbl(dt1.Rows[0]["NetProceeds"].ToString()).ToString("#0,0.00");
            rDV.lblMosAmr.Text = clsF.toDbl(dt1.Rows[0]["MonthlyAmrt"].ToString()).ToString("#0,0.00");
            rDV.lblAmtLoan2.Text = rDV.lblAmtLoan.Text;
            rDV.lblInterest.Text = dTInterest.ToString("#0,0.00");
            rDV.lblTAmtInt.Text = (clsF.toDbl(rDV.lblAmtLoan.Text) + clsF.toDbl(rDV.lblInterest.Text)).ToString("#0,0.00");
            rDV.lblNetProc2.Text = rDV.lblNetProc.Text;
            rDV.lblDVDate.Text = txtDate.Text.Replace("/", ".");
            rDV.lblDVNo.Text = txtDVNo.Text;
            rDV.lblAsig1.Text = clsF.dtDefV.Rows[14][2].ToString();
            rDV.lblAsig1Pos.Text = clsF.dtDefV.Rows[15][2].ToString();
            rDV.lblAsig2.Text = clsF.dtDefV.Rows[8][2].ToString();
            clsF.showDcV(rDV, $"DV {txtDVNo.Text}_{txtBName.Text}");
        }

        private void txtPStart_Leave(object sender, EventArgs e)
        {
            
            popGrid();
        }

        private void popGrid()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Month");
            dt.Columns.Add("InstallmentPeriod");
            dt.Columns.Add("Principal");
            dt.Columns.Add("Interest");
            dt.Columns.Add("TotalCashflow");
            dt.Columns.Add("PrincipalBalance");

            dt.Rows.Add(txtDate.Text, "0", "0", "0", "0", txtPrincipalAmt.Text);

            int Tmos = int.Parse(txtTMos.Text);
            int ctr = 0;
            string LastMonth;
            string Amrt = txtMonthlyDed.Text;
            double Interest, Principal, NewBalance;
            dTInterest = 0;
            dTPrincipal = 0;
            dTCashflow = 0;

            while (Tmos >= ctr + 1)
            {
                if (ctr != 0)
                {
                    LastMonth = DateTime.Parse(dt.Rows[ctr][0].ToString()).AddMonths(1).ToString("MMM yyyy");
                }
                else
                {
                    LastMonth = txtPStart.DateTime.ToString("MMM yyyy");
                }

                Interest = clsF.toDbl(dt.Rows[ctr][5].ToString()) * clsF.toDbl(clsF.dtDefV.Rows[1][2].ToString());
                Interest = clsF.toDbl((Math.Floor(Interest * 1000) / 1000).ToString("#,#0.00"));
                Principal = clsF.toDbl(txtMonthlyDed.Text) - Interest;
                NewBalance = clsF.toDbl(dt.Rows[ctr][5].ToString()) - Principal;

                if (NewBalance < 0)
                {
                    Principal = clsF.toDbl(dt.Rows[ctr][5].ToString());
                    Amrt = (Principal + Interest).ToString("#,#0.00");
                    NewBalance = 0;
                }

                dt.Rows.Add(LastMonth, (1 + ctr).ToString(), Principal.ToString("#,#0.00"), Interest.ToString("#,#0.00"), Amrt, NewBalance.ToString("#,#0.00"));
                dTPrincipal += clsF.toDbl(Principal.ToString("#,#0.00"));
                dTInterest += clsF.toDbl(Interest.ToString("#,#0.00"));
                dTCashflow += clsF.toDbl(Amrt);
                ctr++;
            }

            gcAmr.DataSource = null;
            gvAmr.Columns.Clear();
            gcAmr.DataSource = dt;
            dt.Dispose();
            GridColumnSummaryItem TPrincipal = new GridColumnSummaryItem();
            TPrincipal.SummaryType = SummaryItemType.Custom;
            TPrincipal.DisplayFormat = dTPrincipal.ToString("#,#0.00");
            gvAmr.Columns["Principal"].Summary.Clear();
            gvAmr.Columns["Principal"].Summary.Add(TPrincipal);

            GridColumnSummaryItem TInterest = new GridColumnSummaryItem();
            TInterest.SummaryType = SummaryItemType.Custom;
            TInterest.DisplayFormat = dTInterest.ToString("#,#0.00");
            gvAmr.Columns["Interest"].Summary.Clear();
            gvAmr.Columns["Interest"].Summary.Add(TInterest);

            GridColumnSummaryItem TCashflow = new GridColumnSummaryItem();
            TCashflow.SummaryType = SummaryItemType.Custom;
            TCashflow.DisplayFormat = dTCashflow.ToString("#,#0.00");
            gvAmr.Columns["TotalCashflow"].Summary.Clear();
            gvAmr.Columns["TotalCashflow"].Summary.Add(TCashflow);

            txtPEnd.DateTime = txtPStart.DateTime.AddMonths(clsF.toint(txtTMos.Text) - 1);
            txtNIR.Text = (dTInterest / dTPrincipal / (clsF.toint(txtTMos.Text)/ 12) * 100).ToString("#.000"); 

            gvAmr.Columns[0].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gvAmr.Columns[1].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gvAmr.Columns[2].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            gvAmr.Columns[3].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            gvAmr.Columns[4].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            gvAmr.Columns[5].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
        }

    }
}