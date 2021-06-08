namespace iProvident
{
    partial class frmView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmView));
            this.gcTbl = new DevExpress.XtraGrid.GridControl();
            this.gvTbl = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblCtr = new DevExpress.XtraEditors.LabelControl();
            this.picRef = new DevExpress.XtraEditors.PictureEdit();
            this.pmApproval = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnUpdate = new DevExpress.XtraBars.BarButtonItem();
            this.btnApprove = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancel = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnPLedger = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.btnRoadTo = new DevExpress.XtraBars.BarButtonItem();
            this.btnVwAmrt = new DevExpress.XtraBars.BarButtonItem();
            this.btnVDV = new DevExpress.XtraBars.BarButtonItem();
            this.btnUndoApp = new DevExpress.XtraBars.BarButtonItem();
            this.btnOrderPmt = new DevExpress.XtraBars.BarButtonItem();
            this.btnOPEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnOPDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnOPClean = new DevExpress.XtraBars.BarButtonItem();
            this.pmActive = new DevExpress.XtraBars.PopupMenu(this.components);
            this.pmCancelled = new DevExpress.XtraBars.PopupMenu(this.components);
            this.pmOP = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gcTbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRef.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmApproval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmActive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmCancelled)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmOP)).BeginInit();
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
            this.gcTbl.Size = new System.Drawing.Size(847, 408);
            this.gcTbl.TabIndex = 8;
            this.gcTbl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTbl});
            // 
            // gvTbl
            // 
            this.gvTbl.GridControl = this.gcTbl;
            this.gvTbl.Name = "gvTbl";
            this.gvTbl.OptionsBehavior.Editable = false;
            this.gvTbl.OptionsFind.AlwaysVisible = true;
            this.gvTbl.OptionsSelection.MultiSelect = true;
            this.gvTbl.OptionsView.ShowFooter = true;
            this.gvTbl.OptionsView.ShowGroupPanel = false;
            this.gvTbl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvTbl_KeyDown);
            this.gvTbl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gvTbl_MouseUp);
            this.gvTbl.DoubleClick += new System.EventHandler(this.gvTbl_DoubleClick);
            this.gvTbl.RowCountChanged += new System.EventHandler(this.gvTbl_RowCountChanged);
            // 
            // lblCtr
            // 
            this.lblCtr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCtr.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCtr.Appearance.Options.UseFont = true;
            this.lblCtr.Location = new System.Drawing.Point(1, 414);
            this.lblCtr.Name = "lblCtr";
            this.lblCtr.Size = new System.Drawing.Size(20, 13);
            this.lblCtr.TabIndex = 9;
            this.lblCtr.Text = "Ctr:";
            // 
            // picRef
            // 
            this.picRef.EditValue = ((object)(resources.GetObject("picRef.EditValue")));
            this.picRef.Location = new System.Drawing.Point(473, 14);
            this.picRef.Name = "picRef";
            this.picRef.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.picRef.Properties.Appearance.Options.UseBackColor = true;
            this.picRef.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picRef.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picRef.Size = new System.Drawing.Size(28, 20);
            this.picRef.TabIndex = 10;
            this.picRef.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picRef_MouseClick);
            // 
            // pmApproval
            // 
            this.pmApproval.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnUpdate),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnApprove),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCancel)});
            this.pmApproval.Manager = this.barManager1;
            this.pmApproval.Name = "pmApproval";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Caption = "Edit";
            this.btnUpdate.Id = 0;
            this.btnUpdate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.ImageOptions.Image")));
            this.btnUpdate.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnUpdate.ImageOptions.LargeImage")));
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUpdate_ItemClick);
            // 
            // btnApprove
            // 
            this.btnApprove.Caption = "Approve";
            this.btnApprove.Id = 1;
            this.btnApprove.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnApprove.ImageOptions.LargeImage")));
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(16, 16);
            this.btnApprove.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnApprove_ItemClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Caption = "Cancel";
            this.btnCancel.Id = 3;
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.LargeImage")));
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCancel_ItemClick);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnUpdate,
            this.btnApprove,
            this.btnCancel,
            this.btnPLedger,
            this.barButtonItem4,
            this.btnRoadTo,
            this.btnVwAmrt,
            this.btnVDV,
            this.btnUndoApp,
            this.btnOrderPmt,
            this.btnOPEdit,
            this.btnOPDelete,
            this.btnOPClean});
            this.barManager1.MaxItemId = 21;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(849, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 429);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(849, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 429);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(849, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 429);
            // 
            // btnPLedger
            // 
            this.btnPLedger.Caption = "View Ledger";
            this.btnPLedger.Id = 7;
            this.btnPLedger.Name = "btnPLedger";
            this.btnPLedger.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPLedger_ItemClick);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Move to Approval";
            this.barButtonItem4.Id = 9;
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick);
            // 
            // btnRoadTo
            // 
            this.btnRoadTo.Caption = "Road to %";
            this.btnRoadTo.Id = 10;
            this.btnRoadTo.Name = "btnRoadTo";
            this.btnRoadTo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRoadTo_ItemClick);
            // 
            // btnVwAmrt
            // 
            this.btnVwAmrt.Caption = "View Amrt Sched";
            this.btnVwAmrt.Id = 12;
            this.btnVwAmrt.Name = "btnVwAmrt";
            this.btnVwAmrt.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnVwAmrt_ItemClick);
            // 
            // btnVDV
            // 
            this.btnVDV.Caption = "View DV";
            this.btnVDV.Id = 13;
            this.btnVDV.Name = "btnVDV";
            this.btnVDV.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnVDV_ItemClick);
            // 
            // btnUndoApp
            // 
            this.btnUndoApp.Caption = "Undo Approval";
            this.btnUndoApp.Id = 14;
            this.btnUndoApp.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnUndoApp.ImageOptions.SvgImage")));
            this.btnUndoApp.Name = "btnUndoApp";
            this.btnUndoApp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUndoApp_ItemClick);
            // 
            // btnOrderPmt
            // 
            this.btnOrderPmt.Caption = "Order Payment";
            this.btnOrderPmt.Id = 15;
            this.btnOrderPmt.Name = "btnOrderPmt";
            this.btnOrderPmt.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOrderPmt_ItemClick);
            // 
            // btnOPEdit
            // 
            this.btnOPEdit.Caption = "Edit";
            this.btnOPEdit.Id = 18;
            this.btnOPEdit.Name = "btnOPEdit";
            this.btnOPEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOPEdit_ItemClick);
            // 
            // btnOPDelete
            // 
            this.btnOPDelete.Caption = "Delete";
            this.btnOPDelete.Id = 19;
            this.btnOPDelete.Name = "btnOPDelete";
            // 
            // btnOPClean
            // 
            this.btnOPClean.Caption = "Clean";
            this.btnOPClean.Id = 20;
            this.btnOPClean.Name = "btnOPClean";
            this.btnOPClean.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOPClean_ItemClick);
            // 
            // pmActive
            // 
            this.pmActive.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnUpdate),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnUndoApp),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPLedger),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnVwAmrt),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnVDV),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnOrderPmt),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRoadTo)});
            this.pmActive.Manager = this.barManager1;
            this.pmActive.Name = "pmActive";
            // 
            // pmCancelled
            // 
            this.pmCancelled.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem4)});
            this.pmCancelled.Manager = this.barManager1;
            this.pmCancelled.Name = "pmCancelled";
            // 
            // pmOP
            // 
            this.pmOP.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnOPEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnOPDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnOPClean)});
            this.pmOP.Manager = this.barManager1;
            this.pmOP.Name = "pmOP";
            // 
            // frmView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 429);
            this.Controls.Add(this.picRef);
            this.Controls.Add(this.lblCtr);
            this.Controls.Add(this.gcTbl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmView";
            this.Text = "frmEditTable";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmView_FormClosed);
            this.Shown += new System.EventHandler(this.frmView_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gcTbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRef.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmApproval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmActive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmCancelled)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmOP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl lblCtr;
        public DevExpress.XtraGrid.GridControl gcTbl;
        public DevExpress.XtraGrid.Views.Grid.GridView gvTbl;
        public DevExpress.XtraEditors.PictureEdit picRef;
        private DevExpress.XtraBars.PopupMenu pmApproval;
        private DevExpress.XtraBars.BarButtonItem btnUpdate;
        public DevExpress.XtraBars.BarButtonItem btnApprove;
        public DevExpress.XtraBars.BarButtonItem btnCancel;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnPLedger;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem btnRoadTo;
        private DevExpress.XtraBars.PopupMenu pmActive;
        private DevExpress.XtraBars.PopupMenu pmCancelled;
        private DevExpress.XtraBars.BarButtonItem btnVwAmrt;
        private DevExpress.XtraBars.BarButtonItem btnVDV;
        private DevExpress.XtraBars.BarButtonItem btnUndoApp;
        private DevExpress.XtraBars.BarButtonItem btnOrderPmt;
        private DevExpress.XtraBars.PopupMenu pmOP;
        private DevExpress.XtraBars.BarButtonItem btnOPEdit;
        private DevExpress.XtraBars.BarButtonItem btnOPDelete;
        private DevExpress.XtraBars.BarButtonItem btnOPClean;
    }
}