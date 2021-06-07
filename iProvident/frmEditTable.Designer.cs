namespace iProvident
{
    partial class frmEditTable
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
            this.gcTbl = new DevExpress.XtraGrid.GridControl();
            this.gvTbl = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblCtr = new DevExpress.XtraEditors.LabelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcTbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTbl)).BeginInit();
            this.SuspendLayout();
            // 
            // gcTbl
            // 
            this.gcTbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcTbl.Location = new System.Drawing.Point(1, 0);
            this.gcTbl.MainView = this.gvTbl;
            this.gcTbl.Name = "gcTbl";
            this.gcTbl.Size = new System.Drawing.Size(854, 441);
            this.gcTbl.TabIndex = 8;
            this.gcTbl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTbl});
            // 
            // gvTbl
            // 
            this.gvTbl.GridControl = this.gcTbl;
            this.gvTbl.Name = "gvTbl";
            this.gvTbl.OptionsFind.AlwaysVisible = true;
            this.gvTbl.OptionsView.ShowGroupPanel = false;
            // 
            // lblCtr
            // 
            this.lblCtr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCtr.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCtr.Appearance.Options.UseFont = true;
            this.lblCtr.Location = new System.Drawing.Point(1, 454);
            this.lblCtr.Name = "lblCtr";
            this.lblCtr.Size = new System.Drawing.Size(20, 13);
            this.lblCtr.TabIndex = 9;
            this.lblCtr.Text = "Ctr:";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(744, 449);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmEditTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 477);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblCtr);
            this.Controls.Add(this.gcTbl);
            this.Name = "frmEditTable";
            this.Text = "frmEditTable";
            this.Shown += new System.EventHandler(this.frmEditTable_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gcTbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTbl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gcTbl;
        private DevExpress.XtraEditors.LabelControl lblCtr;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        public DevExpress.XtraGrid.Views.Grid.GridView gvTbl;
    }
}