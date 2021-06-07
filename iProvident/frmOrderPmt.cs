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
    public partial class frmOrderPmt : DevExpress.XtraEditors.XtraForm
    {
        public string LN, Serial, BankNo, BankName, mqSuff, frmMode, Amt;
        public int cUnpaid, nMos;
        public DateTime baseMonth;
        public double Amrt, Principal, Interest;

        public frmOrderPmt()
        {
            InitializeComponent();
        }

        private void frmOrderPmt_Shown(object sender, EventArgs e)
        {
            if (txtSerial.Text != "")
            {
                LN = clsF.qDtbl($"SELECT LoanNo FROM tblOrderPmt WHERE SerialNo='{txtSerial.Text}';").Rows[0][0].ToString();
                mqSuff = $" SerialNo='{txtSerial.Text}';";
            }
            else
            {
                mqSuff = " ORNo IS NULL;";
            }

            txtLN.EditValue = LN;
            BankNo = clsF.dtDefV.Rows[21][2].ToString();
            BankName = clsF.dtDefV.Rows[22][2].ToString();
            txtMos.Focus();
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            string qq;
            if (btnProceed.Text == "Proceed") {
                string dtPref = "PL " + DateTime.Now.ToString("yyyy-MM-");
                Serial = dtPref + (clsF.toint(clsF.qDtbl("SELECT" +
                    " CASE WHEN (RIGHT(MAX(SerialNo), 3) + 1) IS NULL THEN '1'" +
                    " ELSE RIGHT(MAX(SerialNo), 3) + 1" +
                    " END NewSerial" +
                    " FROM tblOrderPmt" +
                    $" WHERE SerialNo LIKE '{dtPref}%';").Rows[0][0].ToString()).ToString("000"));
                qq = "INSERT INTO tblOrderPmt (SerialNo, [Date], LoanNo, NoOfMos, Particular, Amount, Principal, Interest, BankAcct, BankName)" +
                     $" VALUES('{Serial}', '{dtDate.Text}', '{LN}', '{txtMos.Text}', '{txtParticular.Text}', '{txtAmount.EditValue}', '{Principal}', '{Interest}', '{BankNo}', '{BankName}');";
            }
            else
            {
                string ORN = txtORN.Text == "" ? "NULL" : $"'{txtORN.Text}'";
                qq = $"UPDATE tblOrderPmt SET [Date] = '{dtDate.Text}', NoOfMos = '{txtMos.Text}', Particular='{txtParticular.Text}'," +
                    $" Amount = '{txtAmount.EditValue}', Principal = '{Principal}', Interest = '{Interest}', BankAcct='{BankNo}', BankName = '{BankName}', ORNo = {ORN}" +
                     $" WHERE SerialNo = '{Serial}';";
            }

            

            if(Amt != txtAmount.Text || txtORN.Text == "")
            {
                if (clsF.rQry(qq))
                {
                    rptOrderPmt rptO = new rptOrderPmt();
                    rptO.txtSerial.Text = Serial;
                    rptO.txtDate.Text = dtDate.Text;
                    rptO.txtPayor.Text = txtName.Text;
                    rptO.txtOffice.Text = lkStation.Text;
                    rptO.txtPmtW.Text = clsF.CurToWords(clsF.toDbl(txtAmount.Text));
                    rptO.txtPurpose.Text = txtParticular.Text;
                    rptO.txtPerBill.Text = $"per Bill No. <b>{Serial}</b> dated <b>{dtDate.Text}</b>.";

                    rptO.txtAmount1.Text = "₱ " + txtAmount.Text;
                    rptO.txtTotal.Text = "₱ " + txtAmount.Text;
                    rptO.txtTotal2.Text = txtAmount.Text;
                    rptO.txtPrincipal.Text = Principal.ToString("#,#0.00");
                    rptO.txtInterest.Text = Interest.ToString("#,#0.00");
                    rptO.txtNo1.Text = BankNo;
                    rptO.txtBank1.Text = BankName;

                    clsF.showDcV(rptO, "Order Payment");
                    this.Text = LN;

                    txtSerial.Text = Serial;
                    clsF.OPChanged = true;
                    btnProceed.Text = "Update";
                }

                Amt = txtAmount.Text;
                txtORN.Focus();
            }

            //printClearance if full payment ♥
            if (ckFull.Checked && txtORN.Text.Trim() != "")
            {
                MessageBox.Show("Hey it is full payment, I will print Clearance");
            }            

            if (frmMode == "dg")
            {
                this.Dispose();
            }
        }

        private void ckFull_CheckedChanged(object sender, EventArgs e)
        {
            if (ckFull.Checked) {
                txtMos.EditValue = cUnpaid;
                txtMos.ReadOnly = true;
            }
            else
            {
                txtMos.EditValue = 1;
                txtMos.ReadOnly = false;
            }
        }

        private void txtLN_EditValueChanged(object sender, EventArgs e)
        {
            if (txtLN.Text != "")
            {
                retriveData();
            }
            
        }

        private void retriveData()
        {
            lkStation.Properties.DataSource = clsF.qDtbl("SELECT Office FROM tblOffice;");
            lkStation.Properties.DisplayMember = "Office";
            txtBal.Text = clsF.qDtbl($"SELECT MIN(Balance) FROM tblLedger WHERE Remarks != 'Unpaid' AND LoanNo = '{LN}';").Rows[0][0].ToString();
            DataTable dtInfo = new DataTable();
            dtInfo = clsF.qDtbl("SELECT CONCAT(e.FirstName, ' ', e.MI, '. ', e.LastName) AS Name, o.Office, l.MonthlyAmrt" +
                $" FROM (SELECT * FROM tblLoan WHERE LoanNo = '{LN}') l LEFT JOIN tblEmployee e ON l.BorrowersID = e.EmpID LEFT JOIN tblOffice o ON e.OfficeID = o.OfficeID;");
            txtName.Text = dtInfo.Rows[0]["Name"].ToString();
            lkStation.EditValue = lkStation.Properties.GetKeyValueByDisplayText(dtInfo.Rows[0]["Office"].ToString());
            Amrt = clsF.toDbl(dtInfo.Rows[0]["MonthlyAmrt"].ToString());
            cUnpaid = clsF.toint(clsF.qDtbl($"SELECT COUNT(Remarks) AS Unpaid FROM tblLedger WHERE LoanNo = '{LN}' AND Remarks='Unpaid';").Rows[0][0].ToString());
            baseMonth = DateTime.Parse(clsF.qDtbl($"SELECT Top 1 FORMAT([Date], 'MM/dd/yyyy') AS Unpaid FROM tblLedger WHERE LoanNo = '{LN}' AND Remarks='Unpaid' ORDER BY Period ASC;").Rows[0][0].ToString());           
            dtDate.DateTime = DateTime.Now;

            DataTable dtPOP = new DataTable();
            dtPOP = clsF.qDtbl($"SELECT SerialNo, NoOfMos, ORNo FROM tblOrderPmt WHERE LoanNo = '{LN}' AND {mqSuff}");
            if (dtPOP.Rows.Count > 0)
            {
                btnProceed.Text = "Update";
                Serial = dtPOP.Rows[0]["SerialNo"].ToString();
                txtMos.Text = dtPOP.Rows[0]["NoOfMos"].ToString();
                txtORN.Text = dtPOP.Rows[0]["ORNo"].ToString();
                txtSerial.Text = Serial;
                txtORN.ReadOnly = false;
            }
            else
            {
                txtMos.Text = "1";
            }            
            
        }

        private void txtMos_EditValueChanged(object sender, EventArgs e)
        {
            nMos = clsF.toint(txtMos.Text);
            if (nMos > cUnpaid) nMos = 0;

            if (nMos == 0)
            {
                txtParticular.Text = "Invalid";
                txtAmount.Text = "";
                btnProceed.Enabled = false;
                ckFull.Checked = false;
            }
            else if(nMos == cUnpaid)
            {
                txtParticular.Text = "Full payment of Provident Fund ftm of " + baseMonth.ToString("MMMM yyyy") + " to " + baseMonth.AddMonths(cUnpaid-1).ToString("MMMM yyyy");
                txtAmount.EditValue = txtBal.EditValue;
                Principal = clsF.toDbl(txtAmount.Text);
                Interest = 0;
                ckFull.Checked = true;
                btnProceed.Enabled = true;
            }
            else
            {
                string suffix;

                if (nMos == 1)
                {
                    suffix = " month";
                }
                else
                {
                    suffix = " months";
                }
                txtParticular.Text = "Partial payment of Provident Fund equivalent for " + nMos + suffix;
                txtAmount.Text = (Amrt * nMos).ToString();

                DataTable PrinI = new DataTable();
                PrinI = clsF.qDtbl("SELECT SUM(Principal) AS tPrincipal, SUM(Interest) AS tInterest" +
                    $" FROM (SELECT Top {nMos} * FROM tblLedger WHERE LoanNo='{LN}' AND Remarks = 'Unpaid') tb;");
                Principal = clsF.toDbl(PrinI.Rows[0]["tPrincipal"].ToString());
                Interest = clsF.toDbl(PrinI.Rows[0]["tInterest"].ToString());

                btnProceed.Enabled = true;
                ckFull.Checked = false;
            }
        }
    }
}