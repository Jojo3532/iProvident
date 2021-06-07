using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace iProvident
{
    public partial class frmBiller : DevExpress.XtraEditors.XtraForm
    {
        public string strTerm;
        string EmpNo, Type;
        public string sEmpID
        {
            set { txtEmpNo.Text = value; }
        }
        public frmBiller()
        {
            InitializeComponent();
        }        
        private string fillTxt(string ss, int targetSize)
        {
            int textSize = ss.Length;
            if (targetSize > textSize)
            {
                while (targetSize > textSize)
                {
                    ss += " ";
                    textSize++;
                }
            }
            return ss;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MemoAll.Text != "")
            {
                SaveD1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                SaveD1.FileName = "BILLFILE";

                if (SaveD1.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(SaveD1.FileName, MemoAll.Text);
                }
            }
        }

        private void txtEmpNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = clsF.qDtbl("DECLARE @LNo VARCHAR(20);" +
                    $" SET @LNo = (SELECT LoanNo FROM tblLoan WHERE BorrowersID='{txtEmpNo.Text}' AND Status = 'Open');" +
                    " SELECT tbD.RegCode, a.[DivCode], a.StationNo, a.FirstName, a.MI, a.LastName, b.Term, b.TermStart, b.LoanApplied, b.MonthlyAmrt, b.TInterest, b.LType, c.[Date] AS TEnd" +
                    " FROM (SELECT * FROM tblLoan WHERE LoanNo = @LNo) b LEFT JOIN [tblEmployee] a ON a.[EmpID] = b.BorrowersID LEFT JOIN tblDivision tbD ON a.DivCode = tbD.DivCode LEFT JOIN (SELECT [Date], Period FROM tblLedger WHERE LoanNo=@LNo) AS c ON b.Term = c.Period; ");

                txtRegion.Text = dt.Rows[0]["RegCode"].ToString();
                TxtDivision.Text = dt.Rows[0]["DivCode"].ToString();
                txtStation.Text = dt.Rows[0]["StationNo"].ToString();
                txtFName.Text = dt.Rows[0]["FirstName"].ToString();
                txtMI.Text = dt.Rows[0]["MI"].ToString();
                txtLName.Text = dt.Rows[0]["LastName"].ToString();
                txtTerms.Text = dt.Rows[0]["Term"].ToString();
                txtEFFDate.DateTime = DateTime.Parse(dt.Rows[0]["TermStart"].ToString());
                txtTERMdate.DateTime = DateTime.Parse(dt.Rows[0]["TEnd"].ToString());
                txtAppAmt.Text = dt.Rows[0]["LoanApplied"].ToString();
                txtMDed.Text = dt.Rows[0]["MonthlyAmrt"].ToString();
                txtTInterest.Text = dt.Rows[0]["TInterest"].ToString();
                txtType.Text = dt.Rows[0]["LType"].ToString();
            }
            catch { }            
        }

        private void txtEmpNo_DoubleClick(object sender, EventArgs e)
        {
            frmEmpLookUp fELookUp = new frmEmpLookUp();
            fELookUp.ShowDialog();
            txtEmpNo.Text = "";
            txtEmpNo.Text = fELookUp.SelEmpID;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            //RegionCode + DivCode = 6, StationCode = 3, Emp# = 7, FirstName = 20 + (1),
            //MI = 1 + (2), LastName = 25 + (1), RegionCode-v2 = 4 = (1),  Emp#-NAGA = 12 + (2)
            //EFFDATE(yyyymm) = 6, TERDATE(yyyymm) = 6, Monthly = 8, LoanApplied = 8,
            //TotalInterest = 8 + (16), TypeOfLoan = N, R R
            StringBuilder myText = new StringBuilder();
            EmpNo = clsF.toDbl(txtEmpNo.Text).ToString("0000000");
            strTerm = txtEFFDate.DateTime.ToString("yyyyMM") + txtTERMdate.DateTime.ToString("yyyyMM");

            //myText.Clear();
            myText.Append($"{clsF.toDbl(txtRegion.Text).ToString("00")} {clsF.toDbl(TxtDivision.Text).ToString("000")}{clsF.toDbl(txtStation.Text).ToString("000")}{EmpNo}{fillTxt(txtFName.Text, 20)} ");
            myText.Append($"{txtMI.Text}  {fillTxt(txtLName.Text, 24)} {clsF.toDbl(txtRegion.Text).ToString("0000")} {EmpNo}-NAGA  ");
            myText.Append($"{strTerm}{(clsF.toDbl(txtMDed.Text) * 100).ToString("00000000")}{clsF.toDbl(txtAppAmt.Text).ToString("00000000")}");
            myText.Append($"{(clsF.toDbl(txtTInterest.Text) * 100).ToString("00000000")}                ");

            if (txtType.Text == "New")
            {
                Type = "N";
            }
            else if (txtType.Text == "Reloan")
            {
                Type = "R    R";
            }
            else
            {
                txtType.Text = "Delete";
                Type = "D    D";
            }

            myText.Append(Type);

            if (MemoAll.Text.Length == 0)
            {
                MemoAll.Text += myText.ToString().ToUpper();
            }
            else
            {
                MemoAll.Text += "\r\n" + myText.ToString().ToUpper();
            }

            txtStation.Text = "";
            txtEmpNo.Text = "";
            txtFName.Text = "";
            txtMI.Text = "";
            txtLName.Text = "";
        }
    }
}