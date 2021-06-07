namespace iProvident
{
    partial class frmDedrecs
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
            this.lblctr = new DevExpress.XtraEditors.LabelControl();
            this.btnAnalyze = new DevExpress.XtraEditors.SimpleButton();
            this.gvDEDRECS = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcDEDRECS = new DevExpress.XtraGrid.GridControl();
            this.ssm1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::iProvident.WaitFrm), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.gvDEDRECS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDEDRECS)).BeginInit();
            this.SuspendLayout();
            // 
            // lblctr
            // 
            this.lblctr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblctr.Location = new System.Drawing.Point(13, 428);
            this.lblctr.Name = "lblctr";
            this.lblctr.Size = new System.Drawing.Size(13, 13);
            this.lblctr.TabIndex = 18;
            this.lblctr.Text = "ctr";
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnalyze.Location = new System.Drawing.Point(633, 437);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(93, 23);
            this.btnAnalyze.TabIndex = 17;
            this.btnAnalyze.Text = "Parse";
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // gvDEDRECS
            // 
            this.gvDEDRECS.GridControl = this.gcDEDRECS;
            this.gvDEDRECS.Name = "gvDEDRECS";
            this.gvDEDRECS.OptionsBehavior.Editable = false;
            this.gvDEDRECS.OptionsBehavior.ReadOnly = true;
            this.gvDEDRECS.OptionsSelection.MultiSelect = true;
            this.gvDEDRECS.OptionsView.ShowGroupPanel = false;
            this.gvDEDRECS.RowCountChanged += new System.EventHandler(this.gvDEDRECS_RowCountChanged);
            // 
            // gcDEDRECS
            // 
            this.gcDEDRECS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcDEDRECS.Location = new System.Drawing.Point(13, 13);
            this.gcDEDRECS.MainView = this.gvDEDRECS;
            this.gcDEDRECS.Name = "gcDEDRECS";
            this.gcDEDRECS.Size = new System.Drawing.Size(713, 409);
            this.gcDEDRECS.TabIndex = 16;
            this.gcDEDRECS.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDEDRECS});
            // 
            // ssm1
            // 
            this.ssm1.ClosingDelay = 500;
            // 
            // frmDedrecs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 473);
            this.Controls.Add(this.lblctr);
            this.Controls.Add(this.btnAnalyze);
            this.Controls.Add(this.gcDEDRECS);
            this.Name = "frmDedrecs";
            this.Text = "frmDedrecs";
            this.Shown += new System.EventHandler(this.frmDedrecs_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gvDEDRECS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDEDRECS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblctr;
        private DevExpress.XtraEditors.SimpleButton btnAnalyze;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDEDRECS;
        private DevExpress.XtraGrid.GridControl gcDEDRECS;
        private DevExpress.XtraSplashScreen.SplashScreenManager ssm1;
    }
}