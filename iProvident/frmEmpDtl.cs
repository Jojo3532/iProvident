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
using DevExpress.XtraEditors.Repository;
using DevExpress.Utils;

namespace iProvident
{
    public partial class frmEmpDtl : DevExpress.XtraEditors.XtraForm
    {
        public string EmpID = "";
        public frmEmpDtl()
        {
            InitializeComponent();
        }

        private void frmEmpDtl_Shown(object sender, EventArgs e)
        {
            //load values
            txtEmpStatus.Properties.DataSource = clsF.qDtbl("SELECT EmpStatus AS Status FROM tblEmpStatus;");
            txtEmpStatus.Properties.DisplayMember = "Status";
            txtPosition.Properties.DataSource = clsF.qDtbl("SELECT Position FROM tblPosition;");
            txtPosition.Properties.DisplayMember = "Position";
            txtStation.Properties.DataSource = clsF.qDtbl("SELECT Office AS Station FROM tblOffice;");
            txtStation.Properties.DisplayMember = "Station";
            txtStaNo.Properties.DataSource = clsF.qDtbl("SELECT FORMAT(StationNo, '000') AS [Station No] FROM tblStationNo;");
            txtStaNo.Properties.DisplayMember = "Station No";
            txtColl.Properties.DataSource = clsF.qDtbl("SELECT CollectionID AS Collection FROM tblCollection;");
            txtColl.Properties.DisplayMember = "Collection";
            txtDiv.Properties.DataSource = clsF.qDtbl("SELECT FORMAT(DivCode, '000') AS DivCode FROM tblDivision;");
            txtDiv.Properties.DisplayMember = "DivCode";
            txtPlantilla.Properties.DataSource = clsF.qDtbl("SELECT Plantilla FROM tblPlantilla;");
            txtPlantilla.Properties.DisplayMember = "Plantilla";

            if (EmpID != "")
            {
                txtEmpID.Text = EmpID;
                DataTable dt = new DataTable();
                dt = clsF.qDtbl("SELECT LastName, FirstName, MI, Gender, Birthdate, [Address], e.PositionID, MonthlySal, Office, pl.Plantilla, FirstDay, e.CollectionID, ContactNo, EmpStatus, FORMAT(StationNo, '000') AS StationNo, e.DivCode, d.RegCode " +
                    " FROM tblEmployee e LEFT JOIN tblPlantilla pl ON e.PlantillaID = pl.PlantillaID LEFT JOIN tblOffice o ON e.OfficeID = o.OfficeID LEFT JOIN tblDivision d ON e.DivCode = d.DivCode " +
                    $" WHERE EmpID='{EmpID}'; ");
                txtLName.Text = dt.Rows[0]["LastName"].ToString();
                txtFName.Text = dt.Rows[0]["FirstName"].ToString();
                txtMI.Text = dt.Rows[0]["MI"].ToString();
                txtGender.Text = dt.Rows[0]["Gender"].ToString();
                txtBDate.EditValue = dt.Rows[0]["Birthdate"].ToString();
                txtAddress.Text = dt.Rows[0]["Address"].ToString();
                txtPosition.Text = dt.Rows[0]["PositionID"].ToString();
                txtSalary.Text = dt.Rows[0]["MonthlySal"].ToString();
                txtStation.Text = dt.Rows[0]["Office"].ToString();
                txtPlantilla.Text = dt.Rows[0]["Plantilla"].ToString();
                txtFDay.EditValue = dt.Rows[0]["FirstDay"].ToString();
                txtColl.Text = dt.Rows[0]["CollectionID"].ToString();
                txtContact.Text = dt.Rows[0]["ContactNo"].ToString();
                txtEmpStatus.Text = dt.Rows[0]["EmpStatus"].ToString();
                txtStaNo.Text = dt.Rows[0]["StationNo"].ToString();
                txtDiv.Text = dt.Rows[0]["DivCode"].ToString();
                this.Text = txtLName.Text + " (Dtl)";

                refreshGrid();

                //Adding ProgressBar
                RepositoryItemProgressBar rPy = new RepositoryItemProgressBar();
                rPy.Minimum = 0;
                rPy.Maximum = 100;
                rPy.ShowTitle = true;
                gcTbl.RepositoryItems.Add(rPy);
                gvTbl.Columns["Progress"].ColumnEdit = rPy;

                gvTbl.Columns["LoanApplied"].DisplayFormat.FormatType = FormatType.Numeric;
                gvTbl.Columns["LoanApplied"].DisplayFormat.FormatString = "#,#0.00";
                gvTbl.Columns["MonthlyAmrt"].DisplayFormat.FormatType = FormatType.Numeric;
                gvTbl.Columns["MonthlyAmrt"].DisplayFormat.FormatString = "#,#0.00";
                gvTbl.Columns["PrevBal"].DisplayFormat.FormatType = FormatType.Numeric;
                gvTbl.Columns["PrevBal"].DisplayFormat.FormatString = "#,#0.00";
                gvTbl.Columns["Balance"].DisplayFormat.FormatType = FormatType.Numeric;
                gvTbl.Columns["Balance"].DisplayFormat.FormatString = "#,#0.00";

                gvTbl.BestFitColumns();
            } else
            {
                txtDiv.ItemIndex = 0;
            }
                      
        }

        public void refreshGrid()
        {
            gcTbl.DataSource = clsF.qDtbl($"EXEC getEmpLoans @EmpID='{EmpID}'");
        }
        private void gvTbl_DoubleClick(object sender, EventArgs e)
        {
            int[] sRow = gvTbl.GetSelectedRows();
            String LN = gvTbl.GetRowCellValue(sRow[0], gvTbl.Columns["LoanNo"]).ToString();
            String sStat = gvTbl.GetRowCellValue(sRow[0], gvTbl.Columns["Status"]).ToString();

            if (sStat != "Waiting")
            {
                string _LoanNo = gvTbl.GetRowCellValue(sRow[0], gvTbl.Columns[0]).ToString();
                frmLoan frmL = new frmLoan();
                frmL.LN = LN;
                frmL.ShowDialog();
                refreshGrid();
            }
            else {
                MessageBox.Show("Sorry cannot view when status is \"Waiting\"");
            }           
        }

        private void gvTbl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var rowH = gvTbl.FocusedRowHandle;
                var focusRowViewer = (DataRowView)gvTbl.GetFocusedRow();

                if (focusRowViewer == null || focusRowViewer.IsNew) return;

                if (rowH >= 0)
                    pmActive.ShowPopup(barManager1, new Point(MousePosition.X, MousePosition.Y));
                else
                    pmActive.HidePopup();
            }
        }

        private void btnPLedger_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //print Ledger
            int[] sRow = gvTbl.GetSelectedRows();
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
            rpt2.lblCoM.Text = clsF.qDtbl($"SELECT CONCAT(b.LastName, ', ',  b.FirstName, ' ', b.MI, '.') AS CoM" +
                $" FROM tblLoan AS a INNER JOIN tblEmployee AS b ON a.CoMakersID = b.EmpID WHERE a.LoanNo='{LN}';").Rows[0][0].ToString();
            rpt2.lblAsig1.Text = clsF.dtUser.Rows[0]["Fullname"].ToString();
            rpt2.lblAsig1Pos.Text = clsF.dtUser.Rows[0]["Position"].ToString();

            clsF.showDcV(rpt2, "Caption");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (EmpID != "")
            {
                if (clsF.rQry($"UPDATE tblEmployee SET EmpID='{txtEmpID.Text}', LastName = '{txtLName.Text}', FirstName = '{txtFName.Text}', MI = '{txtMI.Text}', Gender = '{txtGender.Text}', Birthdate = '{txtBDate.Text}', [Address] = '{txtAddress.Text}'," +
                                $" PositionID = '{txtPosition.Text}' , MonthlySal = '{clsF.toDbl(txtSalary.Text)}', OfficeID= (SELECT OfficeID FROM tblOffice WHERE Office='{txtStation.Text}')," +
                                $" PlantillaID = (SELECT PlantillaID FROM tblPlantilla WHERE Plantilla='{txtPlantilla.Text}'), FirstDay = '{txtFDay.Text}', CollectionID = '{txtColl.Text}'," +
                                $" ContactNo = '{txtContact.Text}', EmpStatus = '{txtEmpStatus.Text}', StationNo = '{txtStaNo.Text}', DivCode = '{txtDiv.Text}'" +
                                $" WHERE EmpID='{EmpID}';"))
                {
                    MessageBox.Show($"Successfully {btnSave.Text}d!");
                    btnSave.Text = "Update";
                }
            }
            else
            {
                if (clsF.rQry("INSERT INTO tblEmployee (EmpID, LastName, FirstName, MI, Gender, Birthdate, [Address], PositionID , MonthlySal, OfficeID, PlantillaID , FirstDay, CollectionID, ContactNo, EmpStatus, StationNo, DivCode)" +
                    $" VALUES('{txtEmpID.Text}', '{txtLName.Text}', '{txtFName.Text}', '{txtMI.Text}', '{txtGender.Text}', '{txtBDate.Text}', '{txtAddress.Text}', (SELECT Position FROM tblPosition WHERE PositionID='{txtPosition.Text}')," +
                    $" '{clsF.toDbl(txtSalary.Text)}', (SELECT OfficeID FROM tblOffice WHERE Office='{txtStation.Text}'), (SELECT PlantillaID FROM tblPlantilla WHERE Plantilla='{txtPlantilla.Text}'), '{txtFDay.Text}', '{txtColl.Text}', '{txtContact.Text}'," +
                    $" '{txtEmpStatus.Text}', '{txtStaNo.Text}', '{txtDiv.Text}')"))
                {
                    MessageBox.Show($"Successfully {btnSave.Text}d!");
                    btnSave.Text = "Update";
                    this.Text = txtLName.Text + " (Dtl)";
                    EmpID = txtEmpID.Text;
                }
            }
        }

        private void txtDiv_EditValueChanged(object sender, EventArgs e)
        {
            txtReg.Text = clsF.qDtbl($"SELECT RegCode FROM tblDivision WHERE DivCode='{txtDiv.Text}';").Rows[0][0].ToString();
        }

        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gvTbl_DoubleClick(sender, e);
        }
    }
}