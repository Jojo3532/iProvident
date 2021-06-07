using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.DataAccess.Excel;
using DevExpress.XtraGrid.Columns;

namespace iProvident
{
    public partial class frmDedrecs : DevExpress.XtraEditors.XtraForm
    {
        public string xlsFile, strParse, strEmpNo, strLN, strMonth;

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            String strCol; 
            DataTable dt = new DataTable();
            DataTable dtLN = new DataTable();
            ssm1.ShowWaitForm();
            btnAnalyze.Enabled = false;
            if (btnAnalyze.Text == "Parse")
            {

                for (int i = 0; i < gvDEDRECS.RowCount; i++)
                {
                    strCol = "";
                    strParse = "Ok";
                    //check empID
                    strEmpNo = gvDEDRECS.GetRowCellDisplayText(i, gvDEDRECS.Columns["EMPNO"]);
                    strCol = clsF.getVal($"SELECT CollectionID FROM tblEmployee WHERE EmpID='{strEmpNo}';");
                    if (strCol == "")
                    {
                        strParse = "Error: EmpNo";
                    }
                    else
                    {
                        gvDEDRECS.SetRowCellValue(i, gvDEDRECS.Columns["COLL"], strCol);

                        //check existing loan
                        dtLN = clsF.qDtbl($"SELECT LoanNo, FORMAT(TermStart, 'yyyyMM') AS tStart FROM tblLoan WHERE Status = 'Open' AND BorrowersID='{strEmpNo}';");
                        strLN = dtLN.Rows[0]["LoanNo"].ToString();
                        dt = clsF.qDtbl($"SELECT FORMAT([Date], 'MM/dd/yyyy') AS [Date], CashFlow, FORMAT(Principal, '#,#0.00') AS Principal, FORMAT(Interest, '#,#0.00') AS Interest," +
                            $" FORMAT(Balance, '#,#0.00') AS Balance, Period, Remarks FROM tblLedger WHERE LoanNo= '{strLN}' AND Remarks='Unpaid' ORDER BY Period ASC; ");
                  
                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0]["Date"].ToString() == strMonth)
                            {
                                //check TermStart
                                if (dtLN.Rows[0]["tStart"].ToString() == gvDEDRECS.GetRowCellDisplayText(i, gvDEDRECS.Columns["EFFYY"]).ToString() + gvDEDRECS.GetRowCellDisplayText(i, gvDEDRECS.Columns["EFFMM"]).ToString()) {
                                    double amrtChecker = clsF.toDbl(gvDEDRECS.GetRowCellDisplayText(i, gvDEDRECS.Columns["DEDAMT"]).ToString()) - clsF.toDbl(dt.Rows[0]["CashFlow"].ToString());
                                    if (amrtChecker < 1 && amrtChecker > -2)
                                    {
                                        gvDEDRECS.SetRowCellValue(i, gvDEDRECS.Columns["LoanNo"], strLN);
                                        gvDEDRECS.SetRowCellValue(i, gvDEDRECS.Columns["PRINCIPAL"], dt.Rows[0]["Principal"].ToString());
                                        gvDEDRECS.SetRowCellValue(i, gvDEDRECS.Columns["INTEREST"], dt.Rows[0]["Interest"].ToString());
                                        gvDEDRECS.SetRowCellValue(i, gvDEDRECS.Columns["BALANCE"], dt.Rows[0]["Balance"].ToString());
                                        gvDEDRECS.SetRowCellValue(i, gvDEDRECS.Columns["PRD"], dt.Rows[0]["Period"].ToString());
                                    } 
                                    else strParse = "Error: DEDAMT";
                                }
                                else strParse = "Error: Term Start";
                            }
                            else strParse = "Error: PayMonth";                            
                        }
                        else strParse = "No Loan exist";                                        
                    }
                    gvDEDRECS.SetRowCellValue(i, gvDEDRECS.Columns["Parse"], strParse);
                }

                for (int i = 0; i < gvDEDRECS.RowCount; i++)
                {
                    if (gvDEDRECS.GetRowCellDisplayText(i, gvDEDRECS.Columns["Parse"]).ToString() == "Ok")
                    {
                        btnAnalyze.Enabled = true;
                        btnAnalyze.Text = "Accept";
                        break;
                    }
                }                    
            }
            else
            {
                //Record payments
                string LN, Col;
                for (int i = 0; i < gvDEDRECS.RowCount; i++)
                {
                    if (gvDEDRECS.GetRowCellDisplayText(i, gvDEDRECS.Columns["Parse"]) == "Ok")
                    {
                        LN = gvDEDRECS.GetRowCellDisplayText(i, gvDEDRECS.Columns["LoanNo"]);
                        Col = gvDEDRECS.GetRowCellDisplayText(i, gvDEDRECS.Columns["COLL"]); ;
                        clsF.rQry($"UPDATE tblLedger SET Remarks = 'Paid', CollectionID = '{Col}' WHERE LoanNo='{LN}' AND [Date] ='{strMonth}';");
                        gvDEDRECS.SetRowCellValue(i, gvDEDRECS.Columns["Action"], "Recorded");
                    }
                    else
                    {
                        gvDEDRECS.SetRowCellValue(i, gvDEDRECS.Columns["Action"], "Skipped");
                    }                    
                }
            }
            ssm1.CloseWaitForm();
        }
        private void gvDEDRECS_RowCountChanged(object sender, EventArgs e)
        {
            lblctr.Text = $"Item(s) found: {gvDEDRECS.RowCount}";
        }

        DateTime tMonth = new DateTime();
        public frmDedrecs()
        {
            InitializeComponent();
        }

        private void frmDedrecs_Shown(object sender, EventArgs e)
        {
            try
            {
                ExcelDataSource source = new ExcelDataSource();
                source.FileName = xlsFile;
                var worksheetSettings = new ExcelWorksheetSettings("DEDRECS");
                source.SourceOptions = new ExcelSourceOptions(worksheetSettings);
                source.Fill();
                DataTable dt = clsF.ToDataTable(source);
                dt.Columns.Add("BALANCE", typeof(double));
                dt.Columns.Add("PRD");
                dt.Columns.Add("COLL");
                dt.Columns.Add("LoanNo");
                dt.Columns.Add("Parse");
                dt.Columns.Add("Action");
                gcDEDRECS.DataSource = dt;
                foreach (GridColumn col in gvDEDRECS.Columns)
                    col.Visible = false;

                gvDEDRECS.Columns["Action"].Visible = true;
                gvDEDRECS.Columns["Parse"].Visible = true;
                gvDEDRECS.Columns["COLL"].Visible = true;
                gvDEDRECS.Columns["PRD"].Visible = true;
                gvDEDRECS.Columns["BALANCE"].Visible = true;
                gvDEDRECS.Columns["PAYMONTH"].Visible = true;
                gvDEDRECS.Columns["INTEREST"].Visible = true;
                gvDEDRECS.Columns["PRINCIPAL"].Visible = true;
                gvDEDRECS.Columns["DEDAMT"].Visible = true;
                gvDEDRECS.Columns["EFFYY"].Visible = true;
                gvDEDRECS.Columns["EFFMM"].Visible = true;
                gvDEDRECS.Columns["FNAME"].Visible = true;
                gvDEDRECS.Columns["MI"].Visible = true;
                gvDEDRECS.Columns["LNAME"].Visible = true;
                gvDEDRECS.Columns["EMPNO"].Visible = true;
                gvDEDRECS.Columns["LoanNo"].Visible = true;
                gvDEDRECS.Columns["DEDAMT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gvDEDRECS.Columns["DEDAMT"].DisplayFormat.FormatString = "#,#.00";

                gvDEDRECS.BestFitColumns();
                int rowC = gvDEDRECS.RowCount;
                tMonth = DateTime.Parse(gvDEDRECS.GetRowCellDisplayText(0, gvDEDRECS.Columns["PAYMONTH"]));
                strMonth = DateTime.Parse(dt.Rows[1]["PAYMONTH"].ToString()).ToString("MM/01/yyyy");
            }
            catch (Exception)
            {
                btnAnalyze.Enabled = false;
                gcDEDRECS.DataSource = null;
                foreach (GridColumn col in gvDEDRECS.Columns) col.Visible = false;
                MessageBox.Show("Please make sure that you rename your worksheet as \"DEDRECS\" and the following columns are present:\r\n\r\n PAYMONTH, INTEREST, PRINCIPAL, DEDAMT, FNAME, MI, LNAME and EMPNO");
            }

        }
    }
}