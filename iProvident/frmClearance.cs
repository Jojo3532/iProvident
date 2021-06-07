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
    public partial class frmClearance : DevExpress.XtraEditors.XtraForm
    {
        public string OrderPmtNo = "";
        public frmClearance()
        {
            InitializeComponent();
        }

        private void frmClearance_Shown(object sender, EventArgs e)
        {
            dtDate.DateTime = DateTime.Now;
            dtEff.DateTime = dtDate.DateTime;
            dtPaid.Text = dtEff.Text;
        }

        private void txtEmpID_DoubleClick(object sender, EventArgs e)
        {
            frmEmpLookUp fELookUp = new frmEmpLookUp();
            fELookUp.mode = "clID";
            fELookUp.ShowDialog();
            txtEmpID.Text = "";
            txtEmpID.Text = fELookUp.SelEmpID;
        }

        private void txtEmpID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = clsF.qDtbl("SELECT CONCAT(FirstName,' ', MI, '. ', LastName) AS Name, Position, Office, bl.Balance, l.[Status]" +
                    " FROM tblEmployee e LEFT JOIN tblPosition p ON e.PositionID = p.PositionID" +
                    " LEFT JOIN tblOffice o ON e.OfficeID = o.OfficeID" +
                    " LEFT JOIN tblLoan l ON e.EmpID = l.BorrowersID" +
                    " LEFT JOIN (SELECT LoanNo, MIN(Balance) AS Balance FROM tblLedger WHERE Remarks NOT IN('Processed','Unpaid') GROUP BY LoanNo) bl ON l.LoanNo = bl.LoanNo" +
                    $" WHERE EmpID = '{txtEmpID.Text}';");

                txtName.Text = dt.Rows[0]["Name"].ToString();
                txtPosition.Text = dt.Rows[0]["Position"].ToString();
                txtStation.Text = dt.Rows[0]["Office"].ToString();
                double bal = clsF.toDbl(dt.Rows[0]["Balance"].ToString());
                string status = dt.Rows[0]["Status"].ToString();

                if (bal == 0 || status == "Close")
                {
                    txtPurpose.Text = "Certificate of Last Payment";
                    txtRemarks.Text = "No Existing Provident Loan";
                    txtBalance.Text = "N/A";
                    dtPaid.Text = "N/A";
                    txtORN.Text = "N/A";
                    OrderPmtNo = "";
                }
                else
                {

                    //orderpmt not exist
                    txtBalance.Text = bal.ToString("#,#0.00");
                    txtPurpose.Text = "Certificate of Last Payment";
                    txtRemarks.Text = "Fully Paid Provident Loan";
                    string dtPref = DateTime.Now.ToString("yyyy-MM-");
                    OrderPmtNo = "PL " + dtPref + (clsF.toint(clsF.qDtbl("SELECT MAX(SerialNo) AS NewSerial FROM tblOrderPmt").Rows[0][0].ToString().Replace("PL " + dtPref, "")) + 1).ToString("000");
                    DataTable iMonth = clsF.qDtbl($"SELECT MIN([Date]) AS MinDate, MAX(Date) AS MaxDate FROM tblLedger WHERE Remarks = 'Unpaid' AND LoanNo = (SELECT LoanNo FROM tblLoan WHERE BorrowersID = '{txtEmpID.Text}' AND Status = 'Open')");
                    rptOrderPmt rptO = new rptOrderPmt();
                    rptO.txtSerial.Text = OrderPmtNo;
                    rptO.txtDate.Text = dtPaid.Text;
                    rptO.txtPayor.Text = txtName.Text;
                    rptO.txtOffice.Text = txtStation.Text;
                    rptO.txtPmtW.Text = clsF.CurToWords(clsF.toDbl(txtBalance.Text));
                    rptO.txtPurpose.Text = $"Full payment of Provident Fund ftm of {DateTime.Parse(iMonth.Rows[0][0].ToString()).ToString("MMMM yyyy")} - {DateTime.Parse(iMonth.Rows[0][1].ToString()).ToString("MMMM yyyy")}";
                    rptO.txtPerBill.Text = $"per Bill No. <b>{OrderPmtNo}</b> dated <b>{dtPaid.Text}</b>.";

                    rptO.txtAmount1.Text = "₱ " + txtBalance.Text;
                    rptO.txtTotal.Text = "₱ " + txtBalance.Text;
                    rptO.txtTotal2.Text = txtBalance.Text;
                    rptO.txtPrincipal.Text = txtBalance.Text;
                    rptO.txtInterest.Text = "0.00";
                    clsF.showDcV(rptO, "Order Payment");
                }
            }
            catch
            {
                txtName.Text = "";
                txtPosition.Text = "";
                txtStation.Text = "";
                txtPurpose.Text = "";
                txtRemarks.Text = "";
                txtBalance.Text = "";
                txtORN.Text = "";
            }



                ////look for existing Unpaid Orderpmt
                //DataTable dtEmp = new DataTable();

                //dtEmp = clsF.qDtbl($"SELECT c.*, CONCAT(e.FirstName, ' ', e.MI,'. ', e.LastName) AS fName, p.Position, o.Office" +
                //    " FROM tblClearance c LEFT JOIN tblEmployee e ON c.EmpID = e.EmpID" +
                //    " LEFT JOIN tblPosition p ON e.PositionID = p.PositionID" +
                //    " LEFT JOIN tblOffice o ON e.OfficeID = o.OfficeID" +
                //    $" WHERE c.EmpID = '{txtEmpID.Text}';");

                //if (dtEmp.Rows.Count > 0)
                //{
                //    dtDate.DateTime = DateTime.Now;
                //    txtRefN.Text = dtEmp.Rows[0]["RefNo"].ToString();
                //    txtPurpose.Text = dtEmp.Rows[0]["Purpose"].ToString();
                //    dtEff.EditValue = dtEmp.Rows[0]["EffDate"].ToString();
                //    txtRemarks.Text = dtEmp.Rows[0]["Remarks"].ToString();
                //    txtBalance.Text = dtEmp.Rows[0]["Balance"].ToString();
                //    dtPaid.Text = dtEmp.Rows[0]["DatePaid"].ToString();
                //    txtORN.Text = dtEmp.Rows[0]["ORNo"].ToString();
                //    txtName.Text = dtEmp.Rows[0]["fName"].ToString();
                //    txtPosition.Text = dtEmp.Rows[0]["Position"].ToString();
                //    txtStation.Text = dtEmp.Rows[0]["Office"].ToString();
                //}
                //else
                //{

                //    txtRefN.Text = "";

                //}
            }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtRefN.Text == "")
            {
                if (clsF.rQry("INSERT INTO tblClearance" +
                    $" VALUES ('{dtDate.Text}', '{txtEmpID.Text}', '{txtPurpose.Text}', '{dtEff.Text}', '{txtRemarks.Text}', '{txtBalance.Text}', '{dtPaid.Text}', '{txtORN.Text}');"))
                {
                    txtRefN.Text = clsF.qDtbl("SELECT MAX(RefNo) FROM tblClearance;").Rows[0][0].ToString();
                    MessageBox.Show("Successfully Saved.");
                    printClearance();
                    btnSave.Text = "Update";
                }
            } else
            {
                if (clsF.rQry($"UPDATE tblClearance SET[Date] = '{dtDate.Text}', Purpose = '{txtPurpose.Text}', EffDate = '{dtEff.Text}', Remarks = '{txtRemarks.Text}', Balance = '{txtBalance.Text}', DatePaid = '{dtPaid.Text}', ORNo = '{txtORN.Text}'" +
                    $" WHERE RefNo = '{txtRefN.Text}';"))
                {
                    MessageBox.Show("Successfully Updated.");
                    printClearance();
                    btnSave.Text = "Update";
                }
            }
        }

        private void printClearance()
        {
            rptClearance rC = new rptClearance();
            rC.lbRefNo.Text = txtRefN.Text;
            rC.lbDate.Text = dtDate.Text;
            rC.lbName.Text = txtName.Text;
            rC.lbEmpID.Text = txtEmpID.Text;
            rC.lbPosition.Text = txtPosition.Text;
            rC.lbStation.Text = txtStation.Text;
            rC.lbPurpose.Text = txtPurpose.Text;
            rC.lbEffDate.Text = dtEff.Text;
            rC.lbRemarks.Text = txtRemarks.Text;
            rC.lbBal.Text = txtBalance.Text;
            rC.lbDPaid.Text = dtPaid.Text;
            rC.lbOR.Text = txtORN.Text;
            rC.lbAss1.Text = clsF.dtUser.Rows[0]["FullName"].ToString(); ;
            rC.lbPos1.Text = clsF.dtUser.Rows[0]["Position"].ToString(); ;
            rC.lbAss2.Text = clsF.dtDefV.Rows[14][2].ToString();
            rC.lbPos2.Text = clsF.dtDefV.Rows[15][2].ToString();
            clsF.showDcV(rC, "Clearance");
        }

        private void txtORN_EditValueChanged(object sender, EventArgs e)
        {
            if(txtORN.Text == "")
            {
                btnSave.Enabled = false;
            } else
            {
                btnSave.Enabled = true;
            }
        }
    }
}