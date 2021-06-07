namespace iProvident
{
    partial class frmLoan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoan));
            this.gcTbl = new DevExpress.XtraGrid.GridControl();
            this.gvTbl = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.lblCtr = new DevExpress.XtraEditors.LabelControl();
            this.txtBorrower = new DevExpress.XtraEditors.TextEdit();
            this.txtCoMaker = new DevExpress.XtraEditors.TextEdit();
            this.txtAmrt = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtBContact = new DevExpress.XtraEditors.TextEdit();
            this.txtCContact = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lbl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtNote = new DevExpress.XtraEditors.MemoEdit();
            this.pcInfo = new DevExpress.XtraEditors.PictureEdit();
            this.cbStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcTbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBorrower.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCoMaker.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmrt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBContact.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCContact.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcInfo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbStatus.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcTbl
            // 
            this.gcTbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcTbl.Location = new System.Drawing.Point(12, 82);
            this.gcTbl.MainView = this.gvTbl;
            this.gcTbl.Name = "gcTbl";
            this.gcTbl.Size = new System.Drawing.Size(859, 302);
            this.gcTbl.TabIndex = 11;
            this.gcTbl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTbl});
            this.gcTbl.EditorKeyDown += new System.Windows.Forms.KeyEventHandler(this.gcTbl_EditorKeyDown);
            // 
            // gvTbl
            // 
            this.gvTbl.GridControl = this.gcTbl;
            this.gvTbl.Name = "gvTbl";
            this.gvTbl.OptionsCustomization.AllowSort = false;
            this.gvTbl.OptionsFind.AllowFindPanel = false;
            this.gvTbl.OptionsMenu.ShowGroupSortSummaryItems = false;
            this.gvTbl.OptionsView.ShowGroupPanel = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(771, 390);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblCtr
            // 
            this.lblCtr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCtr.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCtr.Appearance.Options.UseFont = true;
            this.lblCtr.Location = new System.Drawing.Point(12, 400);
            this.lblCtr.Name = "lblCtr";
            this.lblCtr.Size = new System.Drawing.Size(20, 13);
            this.lblCtr.TabIndex = 12;
            this.lblCtr.Text = "Ctr:";
            // 
            // txtBorrower
            // 
            this.txtBorrower.Location = new System.Drawing.Point(73, 12);
            this.txtBorrower.Name = "txtBorrower";
            this.txtBorrower.Properties.ReadOnly = true;
            this.txtBorrower.Size = new System.Drawing.Size(219, 20);
            this.txtBorrower.TabIndex = 14;
            // 
            // txtCoMaker
            // 
            this.txtCoMaker.Location = new System.Drawing.Point(73, 34);
            this.txtCoMaker.Name = "txtCoMaker";
            this.txtCoMaker.Properties.ReadOnly = true;
            this.txtCoMaker.Size = new System.Drawing.Size(219, 20);
            this.txtCoMaker.TabIndex = 14;
            // 
            // txtAmrt
            // 
            this.txtAmrt.Location = new System.Drawing.Point(447, 56);
            this.txtAmrt.Name = "txtAmrt";
            this.txtAmrt.Properties.Appearance.Options.UseTextOptions = true;
            this.txtAmrt.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtAmrt.Properties.ReadOnly = true;
            this.txtAmrt.Size = new System.Drawing.Size(154, 20);
            this.txtAmrt.TabIndex = 14;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 13);
            this.labelControl1.TabIndex = 15;
            this.labelControl1.Text = "Borrower:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 38);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(50, 13);
            this.labelControl3.TabIndex = 15;
            this.labelControl3.Text = "Co-Maker:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(323, 60);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(105, 13);
            this.labelControl4.TabIndex = 15;
            this.labelControl4.Text = "Monthly Amortization:";
            // 
            // txtBContact
            // 
            this.txtBContact.Location = new System.Drawing.Point(447, 12);
            this.txtBContact.Name = "txtBContact";
            this.txtBContact.Properties.ReadOnly = true;
            this.txtBContact.Size = new System.Drawing.Size(154, 20);
            this.txtBContact.TabIndex = 14;
            // 
            // txtCContact
            // 
            this.txtCContact.Location = new System.Drawing.Point(447, 34);
            this.txtCContact.Name = "txtCContact";
            this.txtCContact.Properties.ReadOnly = true;
            this.txtCContact.Size = new System.Drawing.Size(154, 20);
            this.txtCContact.TabIndex = 14;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(325, 15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(116, 13);
            this.labelControl2.TabIndex = 15;
            this.labelControl2.Text = "Borrower\'s Contact No.:";
            // 
            // lbl2
            // 
            this.lbl2.Location = new System.Drawing.Point(323, 38);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(118, 13);
            this.lbl2.TabIndex = 15;
            this.lbl2.Text = "Co-Maker\'s Contact No.:";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(623, 12);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(27, 13);
            this.labelControl6.TabIndex = 15;
            this.labelControl6.Text = "Note:";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(623, 31);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(219, 45);
            this.txtNote.TabIndex = 14;
            // 
            // pcInfo
            // 
            this.pcInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pcInfo.EditValue = ((object)(resources.GetObject("pcInfo.EditValue")));
            this.pcInfo.Location = new System.Drawing.Point(845, 3);
            this.pcInfo.Name = "pcInfo";
            this.pcInfo.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pcInfo.Properties.Appearance.Options.UseBackColor = true;
            this.pcInfo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pcInfo.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pcInfo.Size = new System.Drawing.Size(20, 22);
            this.pcInfo.TabIndex = 17;
            this.pcInfo.ToolTip = "ctr + Enter: to Bulk adjust calculation\r\nctr + D: to Bulk adjust Date\r\nctr + R: t" +
    "o Add new Row\r\nctr + Delete: to Delete selected data";
            // 
            // cbStatus
            // 
            this.cbStatus.Location = new System.Drawing.Point(73, 56);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbStatus.Properties.Items.AddRange(new object[] {
            "Close",
            "Open",
            "Reloaned"});
            this.cbStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbStatus.Size = new System.Drawing.Size(219, 20);
            this.cbStatus.TabIndex = 18;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 60);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(35, 13);
            this.labelControl5.TabIndex = 15;
            this.labelControl5.Text = "Status:";
            // 
            // frmLoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 425);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.pcInfo);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtAmrt);
            this.Controls.Add(this.txtCContact);
            this.Controls.Add(this.txtCoMaker);
            this.Controls.Add(this.txtBContact);
            this.Controls.Add(this.txtBorrower);
            this.Controls.Add(this.gcTbl);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblCtr);
            this.Controls.Add(this.txtNote);
            this.IconOptions.Image = global::iProvident.Properties.Resources.iP;
            this.Name = "frmLoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLoan";
            this.Load += new System.EventHandler(this.frmLoan_Load);
            this.Shown += new System.EventHandler(this.frmLoan_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gcTbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBorrower.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCoMaker.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmrt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBContact.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCContact.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcInfo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbStatus.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcTbl;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTbl;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.LabelControl lblCtr;
        public DevExpress.XtraEditors.TextEdit txtBorrower;
        private DevExpress.XtraEditors.TextEdit txtCoMaker;
        public DevExpress.XtraEditors.TextEdit txtAmrt;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        public DevExpress.XtraEditors.TextEdit txtBContact;
        private DevExpress.XtraEditors.TextEdit txtCContact;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lbl2;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.MemoEdit txtNote;
        private DevExpress.XtraEditors.PictureEdit pcInfo;
        private DevExpress.XtraEditors.ComboBoxEdit cbStatus;
        private DevExpress.XtraEditors.LabelControl labelControl5;
    }
}