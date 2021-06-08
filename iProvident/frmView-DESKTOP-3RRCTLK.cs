using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace iProvident
{
    public partial class frmView : DevExpress.XtraEditors.XtraForm
    {
        public String qq, LN;
        int[] sRow;


        public frmView()
        {
            InitializeComponent();
        }

        private void gvTbl_RowCountChanged(object sender, EventArgs e)
        {
            lblCtr.Text = gvTbl.RowCount.ToString() + " Record(s) Found";
        }

        private void frmView_Shown(object sender, EventArgs e)
        {
            btnRoadTo.Caption = $"Road to {clsF.dtDefV.Rows[0][2]}%";
        }

        private void frmView_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            switch (this.Text) {
                case "Active Loans":
                    clsF.is_fActive = false;
                    break;

                case "For Approval":
                    clsF.is_fApproval = false;
                    break;

                case "Cancelled":
                    clsF.is_fCancelled = false;
                    break;

                case "Unpaid":
                    clsF.is_fUnpaid = false;
                    break;

                case "Employee":
                    clsF.is_fEmployee = false;
                    break;
            }
        }

        private void gvTbl_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.C)
            {
                if (gvTbl.GetRowCellValue(gvTbl.FocusedRowHandle, gvTbl.FocusedColumn) != null && gvTbl.GetRowCellValue(gvTbl.FocusedRowHandle, gvTbl.FocusedColumn).ToString() != String.Empty)
                    Clipboard.SetText(gvTbl.GetRowCellValue(gvTbl.FocusedRowHandle, gvTbl.FocusedColumn).ToString());
                else
                    MessageBox.Show("The value on the selected cell is null or empty!");
                e.Handled = true;
            }
        }

        private void gvTbl_DoubleClick(object sender, EventArgs e)
        {
            switch (this.Text)
            {
                case "For Approval":
                    frmNewLoan frm = new frmNewLoan();
                    frm.MdiParent = clsF.fMain;
                    frm.txtLoanNo.Text = LN;
                    frm.Text = "LN " + LN;
                    frm.txtBID.ReadOnly = true;
                    frm.Show();
                    break;

                case "Active Loans":
                    frmLoan frmL = new frmLoan();
                    
                    frmL.LN = LN;
                    frmL.ShowDialog();
                    break;

                case "Employee":
                    frmEmpDtl frmE = new frmEmpDtl();
                    frmE.EmpID = gvTbl.GetRowCellValue(sRow[0], gvTbl.Columns["EmpID"]).ToString();
                    frmE.MdiParent = clsF.fMain;
                    frmE.Show();
                    break;
            }
        }

        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gvTbl_DoubleClick(sender, e);
        }

        private void btnApprove_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmAmrt frm = new frmAmrt();
            //if (cls.toDbl(gvTbl.GetRowCellValue(sRow[0], gvTbl.Columns["NetProceeds"]).ToString()) > cls.FBal)
            //{
            //    MessageBox.Show("Insufficient Fund");
            //}
            //else
            //{
            frm.txtLoanNo.Text = LN;
            frm.ShowDialog();

            //refresh for changes
            if (clsF.refApproval)
            {
                //filldata();
                gvTbl.DeleteRow(sRow[0]);
                clsF.refApproval = false;
            }
            //}
        }

        private void btnRoadTo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int minMos = int.Parse(clsF.dtDefV.Rows[0][2].ToString());
            string Prog = gvTbl.GetRowCellValue(sRow[0], gvTbl.Columns["Progress"]).ToString().Replace("%", "");
            if (int.Parse(Prog) < minMos)
            {
                string LNApp = gvTbl.GetRowCellValue(sRow[0], gvTbl.Columns["LoanApplied"]).ToString();
                string Payment = gvTbl.GetRowCellValue(sRow[0], gvTbl.Columns["Payment"]).ToString();
                string Prd = Payment.Substring(0, Payment.IndexOf(" "));
                string RMonth = clsF.qDtbl($"SELECT TOP 1 Period FROM tblLedger " +
                    $"WHERE LoanNo='{LN}' AND Balance <= ({LNApp} * {(100 - minMos) * .01}) ORDER BY Balance DESC;").Rows[0][0].ToString();
                int needMos = int.Parse(RMonth) - int.Parse(Prd);
                MessageBox.Show($"We need {needMos} Month(s) more to pay ({DateTime.Now.AddMonths(needMos+1).ToString("MMM yyyy")})", $"Road to {minMos}%");
            }
            else
            {
                MessageBox.Show("We already get there buddy!", $"Road to {minMos}%");
            }
        }

        private void btnPLedger_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //print Ledger
            string lbl = $"{gvTbl.GetRowCellValue(sRow[0], gvTbl.Columns[3])} " +
                $"{gvTbl.GetRowCellValue(sRow[0], gvTbl.Columns[2]).ToString().Substring(0, 1)}.";
            string LN = gvTbl.GetRowCellValue(sRow[0], gvTbl.Columns[0]).ToString();

            rptAmrt2 rpt2 = new rptAmrt2();

            // fetching data
            DataTable dt1 = new DataTable();
            dt1 = clsF.qDtbl("SELECT CONCAT(b.LastName, ', ', b.FirstName, ' ', MI, '.') AS BName, c.Position, b.DivCode, b.StationNo, a.LoanApplied, a.TInterest, (a.LoanApplied + a.TInterest) AS TCash, a.Note" +
               $" FROM tblLoan AS a INNER JOIN tblEmployee AS b ON a.BorrowersID = b.EmpID LEFT JOIN tblPosition c ON b.PositionID = c.PositionID WHERE a.LoanNo='{LN}';");
            string EmpN = clsF.qDtbl($"SELECT BorrowersID FROM tblLoan WHERE LoanNo = '{LN}';").Rows[0][0].ToString();
            rpt2.DataSource = clsF.qDtbl("SELECT CASE WHEN Remarks = 'Unpaid' THEN NULL ELSE FORMAT([Date], 'MMM yyyy') END AS [Month] , CASE WHEN Remarks = 'Unpaid' THEN NULL ELSE Remarks END AS Remarks, Period AS InstallmentPeriod," +
                                $" FORMAT(Principal, '#,#0.00') AS Principal, FORMAT(Interest, '#,#0.00') AS Interest, FORMAT(CashFlow, '#,#0.00') AS TotalCashFlow, FORMAT(Balance, '#,#0.00') AS PrincipalBalance  FROM tblLedger WHERE LoanNo = '{LN}' ORDER BY Period;");
            rpt2.lblName.Text = dt1.Rows[0]["BName"].ToString();
            rpt2.lblEmpID.Text = EmpN;
            rpt2.lblLNo.Text = LN;
            rpt2.lblDivSta.Text = $"{dt1.Rows[0]["DivCode"]}/{dt1.Rows[0]["StationNo"]}";
            rpt2.lblTCashFlow.Text = clsF.toDbl(dt1.Rows[0]["TCash"].ToString()).ToString("#,#0.00");
            rpt2.lblTInterest.Text = clsF.toDbl(dt1.Rows[0]["TInterest"].ToString()).ToString("#,#0.00");
            rpt2.lblTPrincipal.Text = clsF.toDbl(dt1.Rows[0]["LoanApplied"].ToString()).ToString("#,#0.00");
            rpt2.lblNote.Text = dt1.Rows[0]["Note"].ToString();
            rpt2.lblDesig.Text = dt1.Rows[0]["Position"].ToString();
            try
            {
                rpt2.lblCoM.Text = clsF.qDtbl($"SELECT CONCAT(b.LastName, ', ',  b.FirstName, ' ', b.MI, '.') AS CoM" +
                $" FROM tblLoan AS a INNER JOIN tblEmployee AS b ON a.CoMakersID = b.EmpID WHERE a.LoanNo='{LN}';").Rows[0][0].ToString();
            }catch (Exception)
            {
                rpt2.lblCoM.Text = "";
            }
            
            rpt2.lblAsig1.Text = clsF.dtUser.Rows[0]["Fullname"].ToString();
            rpt2.lblAsig1Pos.Text = clsF.dtUser.Rows[0]["Position"].ToString();

            clsF.showDcV(rpt2, "Caption");
        }

        private void picRef_MouseClick(object sender, MouseEventArgs e)
        {
            refGV();
        }

        private void refGV()
        {
            clsF.fMain.ssm1.ShowWaitForm();
            
            if (this.Text == "Active Loans")
            {
                gcTbl.DataSource = clsF.getActiveLoan();
            } else
            {
                gcTbl.DataSource = clsF.qDtbl(qq);
            }
            
            clsF.fMain.ssm1.CloseWaitForm();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (clsF.rQry($"UPDATE tblLoan SET [Status]= 'Waiting' WHERE LoanNo='{LN}';"))
            {
                MessageBox.Show("Successfully moved");
                gvTbl.DeleteRow(sRow[0]);
            }
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Are you sure to cancel application?", "iProvident", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (clsF.rQry($"UPDATE tblLoan SET [Status]= 'Cancelled' WHERE LoanNo='{LN}';"))
                {
                    gvTbl.DeleteRow(sRow[0]);
                }
            }
        }

        private void btnVDV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable dt1 = new DataTable();
            dt1 = clsF.qDtbl("SELECT a.FirstName, a.MI, a.LastName, a.[Address], b.Term, b.LType, b.LoanApplied, b.PrevBal, b.NetProceeds, b.MonthlyAmrt, b.DVNo, FORMAT(b.DVDate, 'MM.dd.yyyy') AS DVDate, b.TInterest" +
                $" FROM tblEmployee a INNER JOIN tblLoan b ON a.EmpID = b.BorrowersID WHERE b.LoanNo = '{LN}';");

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
            rDV.lblInterest.Text = clsF.toDbl(dt1.Rows[0]["TInterest"].ToString()).ToString("#0,0.00");
            rDV.lblTAmtInt.Text = (clsF.toDbl(rDV.lblAmtLoan.Text) + clsF.toDbl(rDV.lblInterest.Text)).ToString("#0,0.00");
            rDV.lblNetProc2.Text = rDV.lblNetProc.Text;
            rDV.lblDVDate.Text = dt1.Rows[0]["DVDate"].ToString();
            rDV.lblDVNo.Text = dt1.Rows[0]["DVNo"].ToString();
            rDV.lblAsig1.Text = clsF.dtDefV.Rows[14][2].ToString();
            rDV.lblAsig1Pos.Text = clsF.dtDefV.Rows[15][2].ToString();
            rDV.lblAsig2.Text = clsF.dtDefV.Rows[8][2].ToString();
            clsF.showDcV(rDV, $"DV {rDV.lblDVNo.Text}_{rDV.lblPayee.Text}");
        }

        private void btnUndoApp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {            
            if (MessageBox.Show("Are you sure to undo application of Ms/Mr " + gvTbl.GetRowCellValue(sRow[0], gvTbl.Columns["LastName"]).ToString() + "?", "Undo Approval", MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                if (clsF.rNTQ($"EXEC undoApp @LN='{LN}';"))
                {
                    gvTbl.DeleteRow(sRow[0]);
                }
            }            
        }

        private void gvTbl_MouseUp(object sender, MouseEventArgs e)
        {
            GridHitInfo hitInfo = gvTbl.CalcHitInfo(e.Location);
            if (hitInfo.InColumnPanel) return;
            try
            {
                sRow = gvTbl.GetSelectedRows();
                LN = gvTbl.GetRowCellValue(sRow[0], gvTbl.Columns[0]).ToString();
                btnUndoApp.Enabled = false;

                if (e.Button == MouseButtons.Right)
                {
                    var rowH = gvTbl.FocusedRowHandle;
                    var focusRowViewer = (DataRowView)gvTbl.GetFocusedRow();

                    if (focusRowViewer == null || focusRowViewer.IsNew) return;

                    switch (this.Text)
                    {
                        case "For Approval":
                            if (rowH >= 0)
                                pmApproval.ShowPopup(barManager1, new Point(MousePosition.X, MousePosition.Y));
                            else
                                pmApproval.HidePopup();
                            break;

                        case "Active Loans":
                            if (rowH >= 0)
                            {
                                pmActive.ShowPopup(barManager1, new Point(MousePosition.X, MousePosition.Y));
                                if (gvTbl.GetRowCellDisplayText(rowH, gvTbl.Columns["Progress"]) == "0%")
                                { btnUndoApp.Enabled = true; btnOrderPmt.Enabled = false; }
                                else
                                { btnUndoApp.Enabled = false; btnOrderPmt.Enabled = true; }
                            }
                            else
                            {
                                pmActive.HidePopup();
                            }
                            break;

                        case "Cancelled":
                            if (rowH >= 0)
                                pmCancelled.ShowPopup(barManager1, new Point(MousePosition.X, MousePosition.Y));
                            else
                                pmCancelled.HidePopup();
                            break;

                        case "Order Pmt":
                            if (rowH >= 0)
                            {
                                pmOP.ShowPopup(barManager1, new Point(MousePosition.X, MousePosition.Y));
                                if (gvTbl.GetRowCellDisplayText(rowH, gvTbl.Columns["ORNo"]) == "")
                                { btnOPDelete.Enabled = true; }
                                else
                                { btnOPDelete.Enabled = false; }
                            }
                            else
                                pmOP.HidePopup();
                            break;
                    }
                }
            } catch (Exception) { }
        }

        private void btnOrderPmt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmOrderPmt fOP = new frmOrderPmt();

            fOP.LN = gvTbl.GetRowCellValue(sRow[0], gvTbl.Columns[0]).ToString();
            fOP.Text = "OP " + fOP.LN;
            fOP.MdiParent = clsF.fMain;
            fOP.Show();
        }

        private void btnOPClean_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("This will delete unpaid Order Payment which is older than 30 days. Are you sure you want to proceed?","Clean", MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                //Maintainance
                if (clsF.rQry("DELETE FROM tblOrderPmt WHERE [Date] < GETDATE() - 30 AND ORNo IS NULL;"))
                {
                    MessageBox.Show("Successfully Cleaned.");
                    refGV();
                }
            }
        }

        private void btnOPEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmOrderPmt fOP = new frmOrderPmt();
            fOP.txtSerial.Text = gvTbl.GetRowCellValue(sRow[0], gvTbl.Columns["SerialNo"]).ToString();
            fOP.txtORN.ReadOnly = false;
            fOP.frmMode = "dg";
            fOP.ShowDialog();
            if (clsF.OPChanged)
            {
                refGV();
                clsF.OPChanged = false;
            }
        }

        private void btnVwAmrt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Amortization printing
            rptAmrt rpt = new rptAmrt();
            rpt.DataSource = clsF.qDtbl($"SELECT FORMAT([Date], 'MMM yyy') AS [Month], Period AS InstallmentPeriod, FORMAT(Principal, '#,#0.00') AS [Principal], Interest," +
                $" FORMAT(CashFlow, '#,#0.00') AS TotalCashFlow, FORMAT(Balance, '#,#0.00') AS PrincipalBalance FROM tblLedger WHERE LoanNo= '{LN}';");
            DataTable dt = new DataTable();
            dt = clsF.qDtbl("SELECT CONCAT(e.FirstName, ' ', e.MI, '. ', e.LastName) AS Name, o.Office, l.LoanApplied, FORMAT(l.TermStart, 'MMM yyyy') AS [Start]," +
                $" FORMAT((SELECT MAX([Date]) FROM tblLedger WHERE LoanNo='{LN}'), 'MMM yyyy') AS TEnd, l.MonthlyAmrt, l.Term, (l.NIRpAnnum * l.Term)/ 12 AS NIRMos, l.NIRpAnnum," +
                " (l.CIRpAnnum / 12) AS CIRMos, l.CIRpAnnum, l.TInterest, (l.LoanApplied + l.TInterest) AS TCashF" +
                " FROM tblLoan l LEFT JOIN tblEmployee e ON l.BorrowersID = e.EmpID LEFT JOIN tblOffice o ON e.OfficeID = o.OfficeID" +
                $" WHERE l.LoanNo = '{LN}';");

            clsF.mTest("SELECT CONCAT(e.FirstName, ' ', e.MI, '. ', e.LastName) AS Name, o.Office, l.LoanApplied, FORMAT(l.TermStart, 'MMM yyyy') AS [Start]," +
                $" FORMAT((SELECT MAX([Date]) FROM tblLedger WHERE LoanNo='{LN}'), 'MMM yyyy') AS TEnd, l.MonthlyAmrt, l.Term, (l.NIRpAnnum * l.Term)/ 12 AS NIRMos, l.NIRpAnnum," +
                " (l.CIRpAnnum / 12) AS CIRMos, l.CIRpAnnum, l.TInterest, (l.LoanApplied + l.TInterest) AS TCashF" +
                " FROM tblLoan l LEFT JOIN tblEmployee e ON l.BorrowersID = e.EmpID LEFT JOIN tblOffice o ON e.OfficeID = o.OfficeID" +
                $" WHERE l.LoanNo = '{LN}';");

            rpt.lblName.Text = dt.Rows[0]["Name"].ToString();
            rpt.lblOffice.Text = dt.Rows[0]["Office"].ToString();
            rpt.lblLNo.Text = LN;
            rpt.lblTPrincipal.Text = clsF.toDbl(dt.Rows[0]["LoanApplied"].ToString()).ToString("#,#0.00");
            rpt.lblPAmt.Text = "₱ " + rpt.lblTPrincipal.Text;
            rpt.lblPStart.Text = dt.Rows[0]["Start"].ToString();
            rpt.lblPEnd.Text = dt.Rows[0]["TEnd"].ToString();
            rpt.lblInstl.Text = "₱ " + clsF.toDbl(dt.Rows[0]["MonthlyAmrt"].ToString()).ToString("#,#0.00");
            rpt.lblTerm.Text = dt.Rows[0]["Term"].ToString() + " mos";
            rpt.lblForYr.Text = $"for {clsF.toDbl(dt.Rows[0]["Term"].ToString()) / 12} year(s):";
            rpt.lblNIRyr.Text = dt.Rows[0]["NIRMos"].ToString() + "%";
            rpt.lblNIRpAnn.Text = dt.Rows[0]["NIRpAnnum"].ToString() + "%";
            rpt.lblCIRAnn.Text = clsF.toDbl(dt.Rows[0]["CIRpAnnum"].ToString()).ToString("0.000") + "%";
            rpt.lblCIRMos.Text = clsF.toDbl(dt.Rows[0]["CIRMos"].ToString()).ToString("0.000") + "%";            
            rpt.lblTInterest.Text = clsF.toDbl(dt.Rows[0]["TInterest"].ToString()).ToString("#,#0.00");
            rpt.lblTCashFlow.Text = clsF.toDbl(dt.Rows[0]["TCashF"].ToString()).ToString("#,#0.00");
            rpt.lblAsig1.Text = clsF.dtUser.Rows[0]["FullName"].ToString();
            rpt.lblAsig1Pos.Text = clsF.dtUser.Rows[0]["Position"].ToString();
            rpt.lblAsig2.Text = clsF.dtDefV.Rows[14][2].ToString();
            rpt.lblAsig2Pos.Text = clsF.dtDefV.Rows[15][2].ToString();
            clsF.showDcV(rpt, $"AmrtSched_{rpt.lblName.Text}");
        }
    }
}