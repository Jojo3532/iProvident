
namespace iProvident
{
    partial class frmEmpLookUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmpLookUp));
            this.gcTbl = new DevExpress.XtraGrid.GridControl();
            this.gvTbl = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.picRef = new DevExpress.XtraEditors.PictureEdit();
            this.lblCtr = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcTbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRef.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcTbl
            // 
            this.gcTbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcTbl.Location = new System.Drawing.Point(9, 12);
            this.gcTbl.MainView = this.gvTbl;
            this.gcTbl.Name = "gcTbl";
            this.gcTbl.Size = new System.Drawing.Size(549, 320);
            this.gcTbl.TabIndex = 11;
            this.gcTbl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTbl});
            // 
            // gvTbl
            // 
            this.gvTbl.GridControl = this.gcTbl;
            this.gvTbl.Name = "gvTbl";
            this.gvTbl.OptionsBehavior.Editable = false;
            this.gvTbl.OptionsFind.AlwaysVisible = true;
            this.gvTbl.OptionsView.ShowGroupPanel = false;
            this.gvTbl.DoubleClick += new System.EventHandler(this.gvTbl_DoubleClick);
            // 
            // picRef
            // 
            this.picRef.EditValue = ((object)(resources.GetObject("picRef.EditValue")));
            this.picRef.Location = new System.Drawing.Point(486, 26);
            this.picRef.Name = "picRef";
            this.picRef.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.picRef.Properties.Appearance.Options.UseBackColor = true;
            this.picRef.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picRef.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picRef.Size = new System.Drawing.Size(28, 20);
            this.picRef.TabIndex = 13;
            // 
            // lblCtr
            // 
            this.lblCtr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCtr.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCtr.Appearance.Options.UseFont = true;
            this.lblCtr.Location = new System.Drawing.Point(-131, 306);
            this.lblCtr.Name = "lblCtr";
            this.lblCtr.Size = new System.Drawing.Size(20, 13);
            this.lblCtr.TabIndex = 12;
            this.lblCtr.Text = "Ctr:";
            // 
            // frmEmpLookUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 344);
            this.Controls.Add(this.picRef);
            this.Controls.Add(this.lblCtr);
            this.Controls.Add(this.gcTbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmEmpLookUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Employees";
            this.Shown += new System.EventHandler(this.frmEmpLookUp_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gcTbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRef.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraGrid.GridControl gcTbl;
        public DevExpress.XtraGrid.Views.Grid.GridView gvTbl;
        public DevExpress.XtraEditors.PictureEdit picRef;
        private DevExpress.XtraEditors.LabelControl lblCtr;
    }
}