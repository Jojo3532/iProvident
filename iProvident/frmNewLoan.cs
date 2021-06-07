using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace iProvident
{
    public partial class frmNewLoan : DevExpress.XtraEditors.XtraForm
    {
        public bool _Viewing;
        public string myLoan;
        string exLoanNo;

        public frmNewLoan()
        {
            InitializeComponent();
        }

        private void calcPMT()
        {
            try
            {
                double _pmt = Financial.Pmt(clsF.CIRpMonth, clsF.toDbl(txtTMos.Text), clsF.toDbl(txtAmtApp.Text) * -1);
                double _rUpmt = Math.Ceiling(_pmt * 100) / 100;
                txtMDed.Text = _rUpmt.ToString("#,#0.00");
                txtNAfter.Text = ((clsF.toDbl(txtNPay.Text) + clsF.toDbl(txtExAmrt.Text)) - clsF.toDbl(txtMDed.Text)).ToString("#,#0.00");
                txtNetProc.Text = (clsF.toDbl(txtAmtApp.Text) - clsF.toDbl(txtExBal.Text)).ToString("#,#0.00");
                txtNPay.Text = clsF.toDbl(txtNPay.Text).ToString("#,#0.00");
            }
            catch { }
        }

        private void calcMaxPMT()
        {
            double _appAm = clsF.toDbl(txtNPay.Text) - clsF.minNetP;
            double _sugAm = _appAm * (1 - Math.Pow(1 + clsF.CIRpMonth, clsF.toint(txtTMos.Text) * -1)) / clsF.CIRpMonth;

            _sugAm = Math.Floor(_sugAm / 1000) * 1000;

            if (_sugAm < 1000)
            {
                txtAmtApp.Text = "0.00";
                MessageBox.Show("Unable to compute suggested Amount");
            }
            else
            {
                _sugAm = _sugAm > clsF.maxLoan ? clsF.maxLoan : _sugAm;
                txtAmtApp.Text = _sugAm.ToString("#,#0.00");
            }
        }

        private void txtExBal_EditValueChanged(object sender, EventArgs e)
        {
            txtNetProc.Text = (clsF.toDbl(txtAmtApp.Text) - clsF.toDbl(txtExBal.Text)).ToString("#,#0.00");
        }

        private void txtAmtApp_EditValueChanged(object sender, EventArgs e)
        {
            calcPMT();
        }

        private void txtTMos_EditValueChanged(object sender, EventArgs e)
        {
            txtTYrs.Text = (clsF.toDbl(txtTMos.Text) / 12).ToString("#.##");
            calcPMT();
        }

        private void txtTYrs_EditValueChanged(object sender, EventArgs e)
        {
            txtTMos.Text = (clsF.toDbl(txtTYrs.Text) * 12).ToString();
            calcPMT();
        }

        private void txtAmtApp_Leave(object sender, EventArgs e)
        {
            if (clsF.toDbl(txtAmtApp.Text) > clsF.maxLoan | clsF.toDbl(txtAmtApp.Text) < 1000)
            {
                txtAmtApp.ForeColor = Color.Red;
                txtNAfter.Text = "0.00";
            }
            else
            {
                txtAmtApp.ForeColor = DefaultForeColor;
            }
        }

        private void txtTMos_Leave(object sender, EventArgs e)
        {
            if (clsF.toDbl(txtAmtApp.Text) > clsF.maxLoan | clsF.toDbl(txtAmtApp.Text) < 1000)
            {
                txtAmtApp.ForeColor = Color.Red;
                txtNAfter.Text = "0.00";
            }
            else
            {
                txtAmtApp.ForeColor = DefaultForeColor;
            }
        }

        private void txtTYrs_Leave(object sender, EventArgs e)
        {
            if (clsF.toDbl(txtTYrs.Text) > clsF.maxMonth / 12 | clsF.toDbl(txtTYrs.Text) < 0)
            {
                txtTYrs.ForeColor = Color.Red;
                txtNAfter.Text = "0.00";
            }
            else
            {
                txtTYrs.ForeColor = DefaultForeColor;
            }

            txtTYrs.Text = clsF.toDbl(txtTYrs.Text).ToString();
        }

        private void txtNAfter_TextChanged(object sender, EventArgs e)
        {
            if (clsF.toDbl(txtNAfter.Text) < clsF.minNetP | clsF.toDbl(txtAmtApp.Text) < 1000)
            {
                txtNAfter.ForeColor = Color.Red;
            }
            else
            {
                txtNAfter.ForeColor = DefaultForeColor;
            }
        }

        private void txtNHome_EditValueChanged(object sender, EventArgs e)
        {
            calcPMT();
        }

        private void txtNHome_Leave(object sender, EventArgs e)
        {
        }

        private void txtBID_DoubleClick(object sender, System.EventArgs e)
        {
            frmEmpLookUp fELookUp = new frmEmpLookUp();
            fELookUp.mode = "BID";
            fELookUp.ShowDialog();
            txtBID.Text = "";
            txtBID.Text = fELookUp.SelEmpID;
        }

        private void ckHosp_CheckedChanged(object sender, System.EventArgs e)
        {
            ckDHBill.Checked = ckHosp.Checked;
            ckDDrCrt.Checked = ckHosp.Checked;
        }

        private void ckHRepr_CheckedChanged(object sender, System.EventArgs e)
        {
            ckDHRepair.Checked = ckHRepr.Checked;
        }

        private void ckHArr_CheckedChanged(object sender, System.EventArgs e)
        {
            ckDHArr.Checked = ckHArr.Checked;
        }

        private void ckEdu_CheckedChanged(object sender, System.EventArgs e)
        {
            ckDTuition.Checked = ckEdu.Checked;
        }

        private void ckPLoan_CheckedChanged(object sender, System.EventArgs e)
        {
            ckDLending.Checked = ckPLoan.Checked;
        }

        private void txtCID_DoubleClick(object sender, System.EventArgs e)
        {
            frmEmpLookUp fELookUp = new frmEmpLookUp();
            fELookUp.mode = "CID";
            fELookUp.ShowDialog();
            txtCID.Text = "";
            txtCID.Text = fELookUp.SelEmpID;
        }

        private void txtCID_TextChanged(object sender, System.EventArgs e)
        {
            if (txtCID.Text == "" | txtCID.Text == txtBID.Text)
            {
                txtCID.Text = "";
                txtCFName.Text = "";
                txtCLName.Text = "";
                txtCMI.Text = "";
                txtCHAdd.Text = "";
                dtCBdate.EditValue = "";
                txtCAge.Text = "";
                txtCPos.Text = "";
                txtCOffice.Text = "";
                txtCMSal.Text = "";
                dtCFDServ.EditValue = "";
                txtCYrServ.Text = "";
                txtCContact.Text = "";
            }
            else
            {
                DataTable dtb = new DataTable();
                dtb = clsF.qDtbl($"EXEC getEmpInfo '{txtCID.Text}';");
                if (dtb.Rows.Count > 0)
                {
                    txtCFName.Text = dtb.Rows[0]["FirstName"].ToString();
                    txtCLName.Text = dtb.Rows[0]["LastName"].ToString();
                    txtCMI.Text = dtb.Rows[0]["MI"].ToString();
                    txtCHAdd.Text = dtb.Rows[0]["Address"].ToString();
                    dtCBdate.EditValue = dtb.Rows[0]["Birthdate"].ToString();
                    txtCAge.Text = dtb.Rows[0]["Age"].ToString();
                    txtCPos.Text = dtb.Rows[0]["Position"].ToString();
                    txtCOffice.Text = dtb.Rows[0]["Office"].ToString();
                    txtCMSal.Text = clsF.toDbl(dtb.Rows[0]["MonthlySal"].ToString()).ToString("#,0.00");
                    dtCFDServ.EditValue = dtb.Rows[0]["FirstDay"].ToString();
                    txtCYrServ.Text = dtb.Rows[0]["YrsNServ"].ToString();
                    txtCContact.Text = dtb.Rows[0]["ContactNo"].ToString();
                }
            }
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            //check: NetAfter > 5000, NetProceeds > 0 , BAge != "", CAge != ""
            if (clsF.toDbl(txtNAfter.Text) >= clsF.minNetP && clsF.toDbl(txtNetProc.Text) > 0 && txtBAge.Text != "" && txtCAge.Text != "")
            {
                string BGender = cboGender.Text == "MR" ? "Male" : "Female";
                
                //Update database
                string qry = $"EXEC updateBorCo @bEmpID = '{txtBID.Text}', @bLastName = '{txtBLName.Text}', @bFirstName = '{txtBFName.Text}', @bMI = '{txtBMI.Text}', @bGender = '{BGender}', @bBirthdate = '{dtBBdate.Text}', @bAddress = '{txtBHAdd.Text}', @bPosition = '{txtBPos.Text}'," +
                                $" @bStationNo = '{txtStaNo.Text}', @bOffice = '{txtBOffice.Text}', @bFirstDay = '{dtBFDServ.Text}', @bContactNo = '{txtBContact.Text}', @bMonthlySal = '{txtBMSal.Text.Replace(",", "")}', @bEmpStatus = '{txtEStat.Text}'," +
                                $" @bLoanStat = 'Waiting', @cEmpID = '{txtCID.Text}', @cLastName = '{txtCLName.Text}', @cFirstName = '{txtCFName.Text}', @cMI = '{txtCMI.Text}', @cBirthdate = '{dtCBdate.Text}', @cAddress = '{txtCHAdd.Text}', @cPosition = '{txtCPos.Text}'," +
                                $" @cOffice = '{txtCOffice.Text}', @cFirstDay = '{dtCFDServ.Text}', @cContactNo = '{txtCContact.Text}', @cMonthlySal = '{txtCMSal.Text.Replace(",","")}', @Note = '{txtExNote.Text}'; " +

                         $"EXEC insUpLoan @LoanNo = '{txtLoanNo.Text}', @BorrowersID = '{txtBID.Text}', @CoMakersID = '{txtCID.Text}', @LType = '{cbType.Text}', @Term = '{txtTMos.Text}', @LoanApplied = '{txtAmtApp.Text.Replace(",","")}', @MonthlyAmrt = '{txtMDed.Text.Replace(",", "")}'," +
                                $" @PrevBal = '{txtExBal.Text.Replace(",", "")}', @PrevAmrt = '{txtExAmt.Text.Replace(",", "")}', @NetPay = '{txtNPay.Text.Replace(",", "")}', @NetProceeds = '{txtNetProc.Text.Replace(",", "")}', @PHospital = '{ckHosp.Checked}', @PHouseRepair = '{ckHRepr.Checked}'," +
                                $" @PHouseArrears = '{ckHArr.Checked}', @PEducational = '{ckEdu.Checked}', @PPaymentOfLoan = '{ckPLoan.Checked}', @POther = '{txtPOther.Text}', @DcLetter = '{ckDLetter.Checked}', @DcDrCrt = '{ckDDrCrt.Checked}', @DcHospBill = '{ckDHBill.Checked}'," +
                                $" @DcTuition = '{ckDTuition.Checked}', @DcHouseArr = '{ckDHArr.Checked}', @DcLoanStat = '{ckDLending.Checked}', @DcHouseRepair = '{ckDHRepair.Checked}', @DcBrfyCrt = '{ckDBrgC.Checked}', @DcIDs = '{ckDvID.Checked}', @DcPayslips = '{ckDPayslip.Checked}', @DcOther = '{txtDocO.Text}'; ";

                if (clsF.rQry(qry))
                {
                    if (txtLoanNo.Text == "") txtLoanNo.Text = clsF.qDtbl("SELECT FORMAT(MAX(LoanNo), '000000') AS cLN FROM tblLoan;").Rows[0][0].ToString();
                    if(MessageBox.Show($"Do you want to proceed printing?", "Successfully Saved", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        printApplication();
                    }                  

                    btnSave.Text = "Update";
                    this.Text = $"LN {txtLoanNo.Text}";
                    txtBID.ReadOnly = true;
                }
            }
            else
            {
                MessageBox.Show("Please make sure that all fields are properly fill-in.");
            }
        }

        private void printApplication()
        {
            //Endorsement
            if (clsF.toDbl(txtAmtApp.Text) > clsF.toDbl(clsF.dtDefV.Rows[2][2].ToString()))
            {
                rptEndorsement rptEn = new rptEndorsement();
                rptEn.tBodytext.Text = "        Respectfully submitted to Regional Director, Office of the Regional Director, " +
                $"{clsF.dtDefV.Rows[6][2]}, the herein application for the Provident Loan of {cboGender.Text.ToUpper()}. {txtBFName.Text.ToUpper()} {txtBMI.Text.ToUpper()}. {txtBLName.Text.ToUpper()}, " +
                $"{txtBPos.Text}, of this Division, in the amount of {clsF.CurToWords(clsF.toDbl(txtAmtApp.Text)).ToUpper()} (₱ {txtAmtApp.Text}), for your favorable approval.";

                rptEn.tDate.Text = "1<sup>st</sup> Endorsement<br>" + DateTime.Now.ToString("MMMM d, yyyy");
                rptEn.tSDS.Text = clsF.dtDefV.Rows[8][2].ToString();

                clsF.showDcV(rptEn, "Endorsement Letter");
            }

            //printEvaluation
            if (cbType.Text == "New")
            {
                rptEvalNew rpt = new rptEvalNew();
                rpt.tName.Text = $"{txtBFName.Text} {txtBMI.Text}. {txtBLName.Text}";
                rpt.txtOffice.Text = txtBOffice.Text;
                rpt.tType.Text = cbType.Text;
                rpt.tAmt.Text = txtAmtApp.Text;
                rpt.tMosDed.Text = txtMDed.Text;
                rpt.tTerms.Text = txtTMos.Text + " Mos";
                rpt.tNet.Text = txtNPay.Text;
                rpt.tPrepBy.Text = clsF.dtUser.Rows[0]["FullName"].ToString();
                rpt.tPos1.Text = clsF.dtUser.Rows[0]["Position"].ToString();
                rpt.tNotedBy.Text = clsF.dtDefV.Rows[14]["Value"].ToString();
                rpt.tPos2.Text = clsF.dtDefV.Rows[15]["Value"].ToString();

                clsF.showDcV(rpt, "Evaluation");
            }else if (cbType.Text == "Reloan")
            {
                rptEvalReloan rpt = new rptEvalReloan();
                rpt.DataSource = gvExLoan.DataSource;
                rpt.tName.Text = $"{txtBFName.Text} {txtBMI.Text}. {txtBLName.Text}";
                rpt.tStation.Text = txtBOffice.Text;
                rpt.tType.Text = cbType.Text;
                rpt.tAmt.Text = txtAmtApp.Text;
                rpt.tMosDed.Text = txtMDed.Text;
                rpt.tTerms.Text = txtTMos.Text + " mos / " + txtTYrs.Text + " yr(s)";
                rpt.tNet.Text = txtNPay.Text;
                rpt.tEAmt.Text = txtExAmt.Text;
                rpt.tEMosDed.Text = txtExAmrt.Text;
                rpt.tETerms.Text = txtExTerms.Text + " mos";
                rpt.tEEAmt.Text = txtExBal.Text;
                rpt.tPrepBy.Text = clsF.dtUser.Rows[0]["FullName"].ToString();
                rpt.tPos1.Text = clsF.dtUser.Rows[0]["Position"].ToString();
                rpt.tNotedBy.Text = clsF.dtDefV.Rows[14]["Value"].ToString();
                rpt.tPos2.Text = clsF.dtDefV.Rows[15]["Value"].ToString();
                rpt.tNote.Text = txtExNote.Text;
                clsF.showDcV(rpt, "Evaluation (Reloan)");
            }

            //Application Form
            rptAppForm rptApp = new rptAppForm();
            rptApp.rNewLoan.Checked = cbType.Text == "New" ? true : false;
            rptApp.rReloan.Checked = cbType.Text == "Reloan" ? true : false;
            rptApp.rPMedical.Checked = ckHosp.Checked;
            rptApp.rPHouseR.Checked = ckHRepr.Checked;
            rptApp.rLoanPmt.Checked = ckPLoan.Checked;
            rptApp.rPEducational.Checked = ckEdu.Checked;
            rptApp.rPHouseArr.Checked = ckHArr.Checked;
            rptApp.rPOther.Text = txtPOther.Text;
            rptApp.rAmtApp.Text = txtAmtApp.Text;
            rptApp.rTMos.Text = $"{txtTMos.Text} mos / {txtTYrs.Text} yr(s)";
            rptApp.rBLName.Text = txtBLName.Text;
            rptApp.rBFName.Text = txtBFName.Text;
            rptApp.rBMI.Text = txtBMI.Text + ".";
            rptApp.rBHomeAdd.Text = txtBHAdd.Text;
            rptApp.rBBdate.Text = dtBBdate.Text;
            rptApp.rBAge.Text = txtBAge.Text;
            rptApp.rBPosition.Text = txtBPos.Text;
            rptApp.rBOffice.Text = txtBOffice.Text;
            rptApp.rBMSal.Text = txtBMSal.Text;
            rptApp.rBYrsServ.Text = txtBYrServ.Text;
            rptApp.rBContact.Text = txtBContact.Text;
            rptApp.rCLName.Text = txtCLName.Text;
            rptApp.rCFName.Text = txtCFName.Text;
            rptApp.rCMI.Text = txtCMI.Text + ".";
            rptApp.rCBdate1.Text = dtCBdate.Text;
            rptApp.rCAge.Text = txtCAge.Text;
            rptApp.rCHomeAdd.Text = txtCHAdd.Text;
            rptApp.rCPosition.Text = txtCPos.Text;
            rptApp.rCOffice.Text = txtCOffice.Text;
            rptApp.rCMSal.Text = txtCMSal.Text;
            rptApp.rCYrsServ.Text = txtCYrServ.Text;
            rptApp.rCContact.Text = txtCContact.Text;
            rptApp.rAmtApp2.Text = txtAmtApp.Text;
            rptApp.rEAmt.Text = clsF.toDbl(txtExBal.Text).ToString("#,#0.00");
            rptApp.rEAmt2.Text = rptApp.rEAmt.Text;
            rptApp.rNetProc.Text = txtNetProc.Text;
            rptApp.rAmrt.Text = txtMDed.Text;
            rptApp.rNetAfter.Text = txtNAfter.Text;
            String rAmrtWords = clsF.CurToWords(double.Parse(txtMDed.Text));
            String rAmtAppWords = clsF.CurToWords(double.Parse(txtAmtApp.Text));
            String amrMonth = txtTMos.Text;
            rptApp.rBName.Text = $"{txtBFName.Text.ToUpper()} {txtBMI.Text.ToUpper()}. {txtBLName.Text.ToUpper()}";
            rptApp.rEmpNo.Text = txtStaNo.Text + " / " + txtBID.Text;
            rptApp.rBPosition2.Text = txtBPos.Text;
            rptApp.rStatEmp.Text = txtEStat.Text;
            rptApp.rLoanNum.Text = txtLoanNo.Text;
            rptApp.rRelBy.Text = "";
            //rptApp.rRelBy.Text = cls.strUser + " " + DateTime.Now.ToString("d");

            //Application Form back
            rptApp.ckDocLet.Checked = ckDLetter.Checked;
            rptApp.ckDocMed.Checked = ckDDrCrt.Checked;
            rptApp.ckDocHosBill.Checked = ckDHBill.Checked;
            rptApp.ckDocHouseA.Checked = ckDHArr.Checked;
            rptApp.ckDocTuition.Checked = ckDTuition.Checked;
            rptApp.ckDocLend.Checked = ckDLending.Checked;
            rptApp.ckDocMatBill.Checked = ckDHRepair.Checked;
            rptApp.ckDocBrgyCrt.Checked = ckDBrgC.Checked;
            rptApp.ckDocPayslip.Checked = ckDPayslip.Checked;
            rptApp.ckDocIDs.Checked = ckDvID.Checked;
            rptApp.rDocOther.Text = txtDocO.Text;
            rptApp.rBOffice2.Text = rptApp.rBOffice.Text;

            String StrStart = dtPAmrt.DateTime.ToString("MMM yyyy"); 

            //Clean Calculation
            if (ckCalc.Checked)
            {
                rptApp.rEAmt.Text = "";
                rptApp.rEAmt2.Text = "";
                rptApp.rNetProc.Text = "";
                rptApp.rNetAfter.Text = "";
                StrStart = "____________";
            }

            rptApp.rLBody.Text = $"     I hereby authorize the deduction from my salary the amount of <u><b>{rAmrtWords} (P{rptApp.rAmrt.Text})</b></u> " +
                $" for <u><b>{rptApp.rTMos.Text}</b></u> starting  <u><b>{StrStart}</b></u>, or until my total amount of <u><b>{rAmtAppWords} (P{rptApp.rAmtApp.Text})</b></u> has been paid. " +
                "Amounts deducted shall be credited to the account of the DepEd Provident Fund.";

            clsF.showDcV(rptApp, $"Application - {rptApp.rBName.Text}");
        }

        private void frmNewLoan_Shown(object sender, EventArgs e)
        {
            txtBPos.Properties.DataSource = clsF.qDtbl("SELECT Position FROM tblPosition;");
            txtBPos.Properties.DisplayMember = "Position";
            txtEStat.Properties.DataSource = clsF.qDtbl("SELECT EmpStatus AS Status FROM tblEmpStatus;");
            txtEStat.Properties.DisplayMember = "Status";
            txtBOffice.Properties.DataSource = clsF.qDtbl("SELECT Office FROM tblOffice;");
            txtBOffice.Properties.DisplayMember = "Office";
            txtStaNo.Properties.DataSource = clsF.qDtbl("SELECT FORMAT(StationNo, '000') AS [Station No] FROM tblStationNo;");
            txtStaNo.Properties.DisplayMember = "Station No";
            dtPAmrt.DateTime = DateTime.Now.AddMonths(1);

            txtCPos.Properties.DataSource= txtBPos.Properties.DataSource;
            txtCOffice.Properties.DataSource = txtBOffice.Properties.DataSource;
            txtCPos.Properties.DisplayMember = txtBPos.Properties.DisplayMember;
            txtCOffice.Properties.DisplayMember = txtBOffice.Properties.DisplayMember;

            txtAmtApp.Focus();

            if (txtLoanNo.Text != "")
            {
                //get loan info
                DataTable dt = new DataTable();
                dt = clsF.qDtbl("SELECT BorrowersID, a.CoMakersID, a.Term, a.LoanApplied, a.NetPay, b.PHospital, b.PHouseRepair, " +
                    "b.PHouseArrears, b.PEducational, b.PPaymentOfLoan, b.POther, b.DcLetter, b.DcDrCrt, b.DcHospBill, b.DcTuition, " +
                    "b.DcHouseArr, b.DcLoanStat, b.DcHouseRepair, b.DcBrfyCrt, b.DcIDs, b.DcPayslips, b.DcOther " +
                    $"FROM tblLoan a LEFT JOIN tblLoanPurpDoc b ON a.LoanNo = b.LoanNo WHERE a.LoanNo = '{txtLoanNo.Text}';");

                txtBID.Text = dt.Rows[0]["BorrowersID"].ToString();
                txtCID.Text = dt.Rows[0]["CoMakersID"].ToString();
                txtTMos.Text = dt.Rows[0]["Term"].ToString();
                txtAmtApp.Text = dt.Rows[0]["LoanApplied"].ToString();
                txtNPay.Text = dt.Rows[0]["NetPay"].ToString();
                ckHosp.Checked = bool.Parse(dt.Rows[0]["PHospital"].ToString());
                ckHRepr.Checked = bool.Parse(dt.Rows[0]["PHouseRepair"].ToString());
                ckHArr.Checked = bool.Parse(dt.Rows[0]["PHouseArrears"].ToString());
                ckEdu.Checked = bool.Parse(dt.Rows[0]["PEducational"].ToString());
                ckPLoan.Checked = bool.Parse(dt.Rows[0]["PPaymentOfLoan"].ToString());
                txtPOther.Text = dt.Rows[0]["POther"].ToString();
                ckDLetter.Checked = bool.Parse(dt.Rows[0]["DcLetter"].ToString());
                ckDDrCrt.Checked = bool.Parse(dt.Rows[0]["DcDrCrt"].ToString());
                ckDHBill.Checked = bool.Parse(dt.Rows[0]["DcHospBill"].ToString());
                ckDTuition.Checked = bool.Parse(dt.Rows[0]["DcTuition"].ToString());
                ckDHArr.Checked = bool.Parse(dt.Rows[0]["DcHouseArr"].ToString());
                ckDLending.Checked = bool.Parse(dt.Rows[0]["DcLoanStat"].ToString());
                ckDHRepair.Checked = bool.Parse(dt.Rows[0]["DcHouseRepair"].ToString());
                ckDBrgC.Checked = bool.Parse(dt.Rows[0]["DcBrfyCrt"].ToString());
                ckDvID.Checked = bool.Parse(dt.Rows[0]["DcIDs"].ToString());
                ckDPayslip.Checked = bool.Parse(dt.Rows[0]["DcPayslips"].ToString());
                txtDocO.Text = dt.Rows[0]["DcOther"].ToString();
                cbType.Focus();
            }
        }

        private void hlMaxL_Click(object sender, EventArgs e)
        {
            double prefAmrt = clsF.toDbl(txtNPay.Text) - double.Parse(clsF.dtDefV.Rows[5][2].ToString());
            double LoanableAmt = Financial.PV(clsF.CIRpMonth, clsF.toDbl(txtTMos.Text), prefAmrt) * -1 / 1000;
            LoanableAmt = Math.Floor(LoanableAmt) * 1000;
            txtAmtApp.Text = LoanableAmt.ToString("#,#0.00");
            txtAmtApp.ForeColor = DefaultForeColor;
        }

        private void txtBID_EditValueChanged(object sender, EventArgs e)
        {
            if (txtBID.Text != "")
            {
                DataTable dtb = new DataTable();
                dtb = clsF.qDtbl($"EXEC getEmpInfo '{txtBID.Text}';");
                if (dtb.Rows.Count > 0)
                {
                    cboGender.Text = dtb.Rows[0]["Prefix"].ToString();
                    txtBFName.Text = dtb.Rows[0]["FirstName"].ToString();
                    txtBLName.Text = dtb.Rows[0]["LastName"].ToString();
                    txtBMI.Text = dtb.Rows[0]["MI"].ToString();
                    txtBHAdd.Text = dtb.Rows[0]["Address"].ToString();
                    dtBBdate.EditValue = dtb.Rows[0]["Birthdate"].ToString();
                    txtBAge.Text = dtb.Rows[0]["Age"].ToString();
                    txtBPos.Text = dtb.Rows[0]["Position"].ToString();
                    txtBOffice.Text = dtb.Rows[0]["Office"].ToString();
                    txtBMSal.Text = clsF.toDbl(dtb.Rows[0]["MonthlySal"].ToString()).ToString("#,0.00");
                    dtBFDServ.EditValue = dtb.Rows[0]["FirstDay"].ToString();
                    txtBYrServ.Text = dtb.Rows[0]["YrsNServ"].ToString();
                    txtBContact.Text = dtb.Rows[0]["ContactNo"].ToString();
                    txtStaNo.Text = dtb.Rows[0]["StationNo"].ToString();
                    txtEStat.Text = dtb.Rows[0]["EmpStatus"].ToString();
                    exLoanNo = dtb.Rows[0]["LoanNo"].ToString();

                    if (exLoanNo == "")
                    {
                        cbType.Text = "New";
                        txtExTerms.Text = "0.00";
                        txtExAmt.Text = "0.00";
                        txtExAmrt.Text = "0.00";
                        txtExBal.Text = "0.00";
                        txtExNote.Text = "";
                        gcExLoan.DataSource = null;

                    }
                    else
                    {
                        cbType.Text = "Reloan";

                        //get Existing Loan info
                        DataTable dtExLoan = new DataTable();
                        dtExLoan = clsF.qDtbl($"SELECT Term, LoanApplied, MonthlyAmrt, Note FROM tblLoan WHERE LoanNo='{exLoanNo}';");
                        txtExTerms.Text = dtExLoan.Rows[0]["Term"].ToString();
                        txtExAmt.Text = clsF.toDbl(dtExLoan.Rows[0]["LoanApplied"].ToString()).ToString("#,#0.00");
                        txtExAmrt.Text = clsF.toDbl(dtExLoan.Rows[0]["MonthlyAmrt"].ToString()).ToString("#,#0.00");
                        txtExNote.Text = dtExLoan.Rows[0]["Note"].ToString();

                        //get Existing Loan Summary
                        DataTable dtExLSum = new DataTable();
                        dtExLSum = clsF.qDtbl("SELECT FORMAT([Date], 'MMM yyyy') AS [Date], Period, Principal, Interest, CashFlow," +
                            $" Balance, Remarks FROM tblLedger WHERE Remarks !='Unpaid' AND LoanNo = '{exLoanNo}' ORDER BY Balance DESC;");
                        gcExLoan.DataSource = dtExLSum;
                        txtExBal.Text = clsF.toDbl(dtExLSum.Rows[dtExLSum.Rows.Count - 1]["Balance"].ToString()).ToString("#,#0.00");
                    }
                }
                else
                {
                    cboGender.Text = "";
                    txtBFName.Text = "";
                    txtBLName.Text = "";
                    txtBMI.Text = "";
                    txtBHAdd.Text = "";
                    dtBBdate.EditValue = "";
                    txtBAge.Text = "";
                    txtBPos.Text = "";
                    txtBOffice.Text = "";
                    txtBMSal.Text = "";
                    dtBFDServ.EditValue = "";
                    txtBYrServ.Text = "";
                    txtBContact.Text = "";
                    txtStaNo.Text = "";
                    txtEStat.Text = "";
                }
            }
        }
    }
}