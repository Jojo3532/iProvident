namespace iProvident
{
    partial class frmOrderPmt
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lkStation = new DevExpress.XtraEditors.LookUpEdit();
            this.ckFull = new System.Windows.Forms.CheckBox();
            this.btnProceed = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtORN = new DevExpress.XtraEditors.TextEdit();
            this.txtAmount = new DevExpress.XtraEditors.TextEdit();
            this.txtParticular = new DevExpress.XtraEditors.TextEdit();
            this.txtMos = new DevExpress.XtraEditors.TextEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.txtSerial = new DevExpress.XtraEditors.TextEdit();
            this.txtLN = new DevExpress.XtraEditors.TextEdit();
            this.txtBal = new DevExpress.XtraEditors.TextEdit();
            this.dtDate = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkStation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtORN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtParticular.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.lkStation);
            this.panelControl1.Controls.Add(this.ckFull);
            this.panelControl1.Controls.Add(this.btnProceed);
            this.panelControl1.Controls.Add(this.labelControl10);
            this.panelControl1.Controls.Add(this.labelControl9);
            this.panelControl1.Controls.Add(this.labelControl8);
            this.panelControl1.Controls.Add(this.labelControl7);
            this.panelControl1.Controls.Add(this.labelControl6);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.txtORN);
            this.panelControl1.Controls.Add(this.txtAmount);
            this.panelControl1.Controls.Add(this.txtParticular);
            this.panelControl1.Controls.Add(this.txtMos);
            this.panelControl1.Controls.Add(this.txtName);
            this.panelControl1.Controls.Add(this.txtSerial);
            this.panelControl1.Controls.Add(this.txtLN);
            this.panelControl1.Controls.Add(this.txtBal);
            this.panelControl1.Controls.Add(this.dtDate);
            this.panelControl1.Location = new System.Drawing.Point(15, 37);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(482, 278);
            this.panelControl1.TabIndex = 1;
            // 
            // lkStation
            // 
            this.lkStation.Location = new System.Drawing.Point(70, 114);
            this.lkStation.Name = "lkStation";
            this.lkStation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkStation.Size = new System.Drawing.Size(395, 20);
            this.lkStation.TabIndex = 15;
            // 
            // ckFull
            // 
            this.ckFull.AutoSize = true;
            this.ckFull.Location = new System.Drawing.Point(169, 138);
            this.ckFull.Name = "ckFull";
            this.ckFull.Size = new System.Drawing.Size(42, 17);
            this.ckFull.TabIndex = 14;
            this.ckFull.Text = "Full";
            this.ckFull.UseVisualStyleBackColor = true;
            this.ckFull.CheckedChanged += new System.EventHandler(this.ckFull_CheckedChanged);
            // 
            // btnProceed
            // 
            this.btnProceed.Enabled = false;
            this.btnProceed.Location = new System.Drawing.Point(365, 242);
            this.btnProceed.Name = "btnProceed";
            this.btnProceed.Size = new System.Drawing.Size(100, 23);
            this.btnProceed.TabIndex = 11;
            this.btnProceed.Text = "Proceed";
            this.btnProceed.Click += new System.EventHandler(this.btnProceed_Click);
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(11, 213);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(39, 13);
            this.labelControl10.TabIndex = 1;
            this.labelControl10.Text = "OR No.:";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(11, 187);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(41, 13);
            this.labelControl9.TabIndex = 1;
            this.labelControl9.Text = "Amount:";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(11, 162);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(49, 13);
            this.labelControl8.TabIndex = 1;
            this.labelControl8.Text = "Particular:";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(11, 140);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(56, 13);
            this.labelControl7.TabIndex = 1;
            this.labelControl7.Text = "No. of Mos:";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(11, 118);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(38, 13);
            this.labelControl6.TabIndex = 1;
            this.labelControl6.Text = "Station:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(11, 93);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(31, 13);
            this.labelControl5.TabIndex = 1;
            this.labelControl5.Text = "Name:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(282, 70);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(46, 13);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "Serial No:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(11, 70);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(43, 13);
            this.labelControl4.TabIndex = 1;
            this.labelControl4.Text = "Loan No:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(288, 27);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(27, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Date:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(288, 5);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(41, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Balance:";
            // 
            // txtORN
            // 
            this.txtORN.Location = new System.Drawing.Point(70, 206);
            this.txtORN.Name = "txtORN";
            this.txtORN.Properties.Mask.EditMask = "n2";
            this.txtORN.Properties.ReadOnly = true;
            this.txtORN.Size = new System.Drawing.Size(395, 20);
            this.txtORN.TabIndex = 8;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(70, 180);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Properties.Mask.EditMask = "n2";
            this.txtAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtAmount.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtAmount.Size = new System.Drawing.Size(395, 20);
            this.txtAmount.TabIndex = 8;
            // 
            // txtParticular
            // 
            this.txtParticular.EditValue = "";
            this.txtParticular.Location = new System.Drawing.Point(70, 158);
            this.txtParticular.Name = "txtParticular";
            this.txtParticular.Size = new System.Drawing.Size(395, 20);
            this.txtParticular.TabIndex = 7;
            // 
            // txtMos
            // 
            this.txtMos.EditValue = "";
            this.txtMos.Location = new System.Drawing.Point(70, 136);
            this.txtMos.Name = "txtMos";
            this.txtMos.Properties.Mask.EditMask = "##";
            this.txtMos.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtMos.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtMos.Size = new System.Drawing.Size(93, 20);
            this.txtMos.TabIndex = 5;
            this.txtMos.EditValueChanged += new System.EventHandler(this.txtMos_EditValueChanged);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(70, 92);
            this.txtName.Name = "txtName";
            this.txtName.Properties.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(395, 20);
            this.txtName.TabIndex = 3;
            // 
            // txtSerial
            // 
            this.txtSerial.Location = new System.Drawing.Point(334, 69);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Properties.Mask.EditMask = "000000";
            this.txtSerial.Properties.ReadOnly = true;
            this.txtSerial.Size = new System.Drawing.Size(131, 20);
            this.txtSerial.TabIndex = 1;
            this.txtSerial.EditValueChanged += new System.EventHandler(this.txtLN_EditValueChanged);
            // 
            // txtLN
            // 
            this.txtLN.Location = new System.Drawing.Point(70, 69);
            this.txtLN.Name = "txtLN";
            this.txtLN.Properties.Mask.EditMask = "000000";
            this.txtLN.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtLN.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtLN.Properties.ReadOnly = true;
            this.txtLN.Size = new System.Drawing.Size(113, 20);
            this.txtLN.TabIndex = 1;
            this.txtLN.EditValueChanged += new System.EventHandler(this.txtLN_EditValueChanged);
            // 
            // txtBal
            // 
            this.txtBal.Location = new System.Drawing.Point(334, 4);
            this.txtBal.Name = "txtBal";
            this.txtBal.Properties.Mask.EditMask = "n2";
            this.txtBal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtBal.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtBal.Properties.ReadOnly = true;
            this.txtBal.Size = new System.Drawing.Size(131, 20);
            this.txtBal.TabIndex = 12;
            // 
            // dtDate
            // 
            this.dtDate.EditValue = null;
            this.dtDate.Location = new System.Drawing.Point(334, 26);
            this.dtDate.Name = "dtDate";
            this.dtDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtDate.Properties.EditFormat.FormatString = "";
            this.dtDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtDate.Properties.Mask.EditMask = "MMMM dd, yyyy";
            this.dtDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtDate.Size = new System.Drawing.Size(131, 20);
            this.dtDate.TabIndex = 13;
            // 
            // frmOrderPmt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 330);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmOrderPmt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order Payment";
            this.Shown += new System.EventHandler(this.frmOrderPmt_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkStation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtORN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtParticular.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnProceed;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtAmount;
        private DevExpress.XtraEditors.TextEdit txtParticular;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.TextEdit txtLN;
        private DevExpress.XtraEditors.TextEdit txtBal;
        private DevExpress.XtraEditors.DateEdit dtDate;
        private System.Windows.Forms.CheckBox ckFull;
        private DevExpress.XtraEditors.LookUpEdit lkStation;
        private DevExpress.XtraEditors.TextEdit txtMos;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        public DevExpress.XtraEditors.TextEdit txtSerial;
        public DevExpress.XtraEditors.TextEdit txtORN;
    }
}