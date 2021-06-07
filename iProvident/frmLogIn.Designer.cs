
namespace iProvident
{
    partial class frmLogIn
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtUname = new DevExpress.XtraEditors.TextEdit();
            this.txtUpass = new DevExpress.XtraEditors.TextEdit();
            this.btnLogIn = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtUname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUpass.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUname
            // 
            this.txtUname.Location = new System.Drawing.Point(142, 51);
            this.txtUname.Name = "txtUname";
            this.txtUname.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUname.Properties.Appearance.Options.UseFont = true;
            this.txtUname.Size = new System.Drawing.Size(274, 32);
            this.txtUname.TabIndex = 1;
            // 
            // txtUpass
            // 
            this.txtUpass.Location = new System.Drawing.Point(142, 89);
            this.txtUpass.Name = "txtUpass";
            this.txtUpass.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUpass.Properties.Appearance.Options.UseFont = true;
            this.txtUpass.Properties.PasswordChar = '•';
            this.txtUpass.Size = new System.Drawing.Size(274, 32);
            this.txtUpass.TabIndex = 2;
            this.txtUpass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUpass_KeyDown);
            // 
            // btnLogIn
            // 
            this.btnLogIn.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogIn.Appearance.Options.UseFont = true;
            this.btnLogIn.Location = new System.Drawing.Point(201, 140);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(143, 34);
            this.btnLogIn.TabIndex = 3;
            this.btnLogIn.Text = "LogI&n";
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(30, 54);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(101, 25);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Username:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(30, 92);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(95, 25);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Password:";
            // 
            // frmLogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 208);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnLogIn);
            this.Controls.Add(this.txtUpass);
            this.Controls.Add(this.txtUname);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.IconOptions.Image = global::iProvident.Properties.Resources.iP;
            this.Name = "frmLogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Please Log In";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLogIn_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.txtUname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUpass.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtUname;
        private DevExpress.XtraEditors.TextEdit txtUpass;
        private DevExpress.XtraEditors.SimpleButton btnLogIn;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}