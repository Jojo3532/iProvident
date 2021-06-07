using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace iProvident
{
    public partial class frmServer : DevExpress.XtraEditors.XtraForm
    {
        frmLogIn fLogIn = new frmLogIn();
        public frmServer()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string suffix = "";
            string port = txtPort.Text == "" ? "" : "," + txtPort.Text;
            suffix = txtUname.Text == "" ? " Integrated Security = True" : " User Id=" + txtUname.Text + "; ";
            suffix += txtPass.Text == "" ? "" : " Password=" + txtPass.Text + "; ";

            string strCon = $"Data Source={txtServer.Text}{port}; Initial Catalog={clsF.dB}; " + suffix + ";";
            clsF.Conn = new SqlConnection(strCon);
            if(clsF.rQry("use iProvD"))
            {
                Properties.Settings.Default.conn = clsHash.Encrypt(strCon);
                this.Hide();
                fLogIn.ShowDialog();
                this.Dispose();
            }            
        }

        private void frmServer_Shown(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.conn != "")
            {
                clsF.Conn = new SqlConnection(clsHash.Decrypt(Properties.Settings.Default.conn));
                if (clsF.rQry($"USE {clsF.dB};"))
                {
                    string Username = Properties.Settings.Default.Username, Password = Properties.Settings.Default.Password;
                    if (Username != "" && Password != "" && Properties.Settings.Default.KeepMeSign)
                    {
                        this.Hide();
                        fLogIn.logIn(Username, Password);
                        this.Dispose();
                    }
                    else
                    {
                        this.Hide();
                        fLogIn.ShowDialog();
                        this.Dispose();
                    }
                }
            }


        }
    }
}