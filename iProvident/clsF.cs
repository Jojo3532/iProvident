using DevExpress.DataAccess.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace iProvident
{
    class clsF
    {
        public static double CIRpMonth, minNetP, maxLoan, maxMonth;
        public static Boolean is_fActive = false, is_fApproval = false, is_fCancelled = false, is_fUnpaid = false, is_fEmployee = false, refApproval = false;
        public static DataTable dtUser, dtDefV, dtActiveL;
        public static SqlConnection Conn;
        static SqlDataAdapter mDA;
        public static mtest fTest = new mtest();
        public static frmMain fMain;
        public static string dB = "iProvD";
        public static Boolean OPChanged = false;

        public static DataTable getActiveLoan() {
            dtActiveL = new DataTable();
            dtActiveL = qDtbl("EXEC getLoans 'Open';");
            return dtActiveL;
        }
        
        public static int toint(string nn)
        {
            try
            {
                return int.Parse(nn);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        
        public static double toDbl(string nn)
        {
            try
            {
                return double.Parse(nn);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static Boolean rQry(string Q)
        {
            try
            {
                Conn.Open();
                SqlTransaction qTrans = Conn.BeginTransaction();
                SqlCommand mCmd = new SqlCommand(Q, Conn, qTrans);
                try
                {
                    mCmd.ExecuteNonQuery();
                    qTrans.Commit();
                    Conn.Close();
                    return true;
                }
                catch (Exception ee)
                {
                    qTrans.Rollback();
                    Conn.Close();
                    MessageBox.Show(ee.Message.ToString());
                    return false;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
                return false;
            }
        }

        public static bool rNTQ(string Q, bool Msg = true)
        {
            Conn.Open();
            SqlCommand sqlCmd = new SqlCommand(Q, Conn);
            try
            {
                sqlCmd.ExecuteNonQuery();
                Conn.Close();
                return true;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
                Conn.Close();
                return false;
            }
        }

        public static DataTable qDtbl(string Q)
        {
            DataTable dtbl = new DataTable();
            try
            {
                mDA = new SqlDataAdapter(Q, Conn);
                mDA.Fill(dtbl);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }

            return dtbl;
        }
        public static void mTest(String msg)
        {
            fTest.txtMsg.Text = msg;
            fTest.ShowDialog();
        }

        public static void Restore(string Filepath)
        {
            try
            {
                if (Conn.State == ConnectionState.Closed)
                {
                    Conn.Open();
                }
                SqlCommand cmd1 = new SqlCommand("ALTER DATABASE [iProvD] SET SINGLE_USER WITH ROLLBACK IMMEDIATE ", Conn);
                cmd1.ExecuteNonQuery();
                SqlCommand cmd2 = new SqlCommand("USE MASTER RESTORE DATABASE [iProvD] FROM DISK='" + Filepath + "' WITH REPLACE", Conn);
                cmd2.ExecuteNonQuery();
                SqlCommand cmd3 = new SqlCommand("ALTER DATABASE [iProvD] SET MULTI_USER", Conn);
                cmd3.ExecuteNonQuery();
                Conn.Close();
                MessageBox.Show("Back-up was successfully restored!", "Restore:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Conn.Close();
        }

        public static void showDcV(DevExpress.XtraReports.UI.XtraReport a, string Capt)
        {
            docViewer dcV = new docViewer();
            dcV.dcViewer.DocumentSource = a;
            a.DisplayName = Capt;
            dcV.Text = Capt;
            dcV.ShowDialog();
        }


        public static string NumToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumToWords(number / 1000000) + " Million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumToWords(number / 1000) + " Thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumToWords(number / 100) + " Hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                //if (words != "")
                //    words += "and ";

                var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                var tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }

        public static string CurToWords(double number)
        {
            number += 0.006;

            if (number == 0)
                return "Zero";

            if (number < 0)
                return "Negative " + CurToWords(Math.Abs(number));

            string words = "";

            int intPortion = (int)number;
            double fraction = (number - intPortion) * 100;
            int decPortion = (int)fraction;

            words = NumToWords(intPortion);

            if (number > 0)
                words += " Pesos";

            if (decPortion > 0)
            {
                words += " and ";
                words += NumToWords(decPortion) + " Cents";
            }
            return words;
        }

        public static DataTable ToDataTable(ExcelDataSource excelDataSource)
        {
            IList list = ((IListSource)excelDataSource).GetList();
            DevExpress.DataAccess.Native.Excel.DataView dataView = (DevExpress.DataAccess.Native.Excel.DataView)list;
            List<DevExpress.DataAccess.Native.Excel.ViewColumn> props = dataView.Columns;

            DataTable table = new DataTable();
            for (int i = 0; i <= props.Count - 1; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count - 1 + 1];
            foreach (DevExpress.DataAccess.Native.Excel.ViewRow item in list)
            {
                for (int i = 0; i <= values.Length - 1; i++)
                    values[i] = props[i].GetValue(item);
                table.Rows.Add(values);
            }
            return table;
        }

        public static string getVal(string Q)
        {
            try
            {
                SqlDataAdapter sqlDa = new SqlDataAdapter(Q, Conn);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                return dtbl.Rows[0][0].ToString();
            }
            catch (Exception)
            {                
                return "";
            }

        }
    }
}
