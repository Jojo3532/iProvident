using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace iProvident
{
    public partial class frmLogIn : DevExpress.XtraEditors.XtraForm
    {
        
        public frmLogIn()
        {
            InitializeComponent();
        }
        
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            logIn(txtUname.Text, txtUpass.Text);
        }

        private void txtUpass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogIn_Click(sender, e);
            }
        }

        public void logIn(string Username, string Password)
        {
            clsF.dtUser = clsF.qDtbl("SELECT b.EmpID, a.Username, a.[Password], a.[Role], Concat(b.FirstName, ' ', b.MI, '. ', b.LastName) AS FullName, c.Position" +
                " FROM tblUser a INNER JOIN tblEmployee b ON a.EmpID = b.EmpID INNER JOIN tblPosition c ON b.PositionID = c.PositionID" +
                $" WHERE a.Username = '{Username}' AND a.Password='{Password}';");

            if (clsF.dtUser.Rows.Count == 1)
            {
                //save User if KeepMeSign is true
                    Properties.Settings.Default.conn = clsHash.Encrypt(clsF.Conn.ConnectionString.ToString());
                    Properties.Settings.Default.Username = Username;
                    Properties.Settings.Default.Password = Password;

                //load reusable values
                clsF.dtDefV = clsF.qDtbl("SELECT * FROM tblDefaultV;");                
                clsF.fMain = new frmMain();
                this.Hide();
                clsF.fMain.ShowDialog();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Incorrect Username or Password");
            }
            
        }

        private void frmLogIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}