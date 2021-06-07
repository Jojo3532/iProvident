using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace iProvident
{
    public partial class frmEditTable : DevExpress.XtraEditors.XtraForm
    {
        public string qq;
        DataTable dtbl;
        SqlDataAdapter sqlDa;
        SqlCommandBuilder sqlcb;
        private void loadData()
        {
            sqlDa = new SqlDataAdapter(qq, clsF.Conn);
            dtbl = new DataTable();
            sqlDa.Fill(dtbl);

            gcTbl.DataSource = dtbl;
            lblCtr.Text = gvTbl.RowCount.ToString() + " Record(s) Found";
            gvTbl.BestFitColumns();
        }
        public frmEditTable()
        {
            InitializeComponent();
        }
   
        private void frmEditTable_Shown(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            sqlcb = new SqlCommandBuilder(sqlDa);
            sqlDa.Update(dtbl);
            MessageBox.Show($"Successfully {btnSave.Text}d!");
            btnSave.Text = "Update";
        }
    }
}