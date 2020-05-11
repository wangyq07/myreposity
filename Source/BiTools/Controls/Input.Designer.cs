namespace BiTools.Controls
{
    partial class Input
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Input));
            this.IputControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.taskpicture = new System.Windows.Forms.PictureBox();
            this.inputSpread = new DevExpress.XtraSpreadsheet.SpreadsheetControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.L_startrow = new DevExpress.XtraBars.BarStaticItem();
            this.span_startrow = new DevExpress.XtraBars.BarEditItem();
            this.rspan_startrow = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.l_startcolumn = new DevExpress.XtraBars.BarStaticItem();
            this.span_startcolumn = new DevExpress.XtraBars.BarEditItem();
            this.rspan_startcolumn = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.l_endcolumns = new DevExpress.XtraBars.BarStaticItem();
            this.span_endcolumn = new DevExpress.XtraBars.BarEditItem();
            this.rspan_endcolumn = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.bar_endrow = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.standaloneBarDockControl1 = new DevExpress.XtraBars.StandaloneBarDockControl();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            this.taskimmagelist = new DevExpress.Utils.ImageCollection(this.components);
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.l_keycolumns = new DevExpress.XtraBars.BarStaticItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.redit_keycolumns = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.tr_content = new DevExpress.XtraTreeList.TreeList();
            this.tc_nodecolumn = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.IputControl)).BeginInit();
            this.IputControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taskpicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspan_startrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspan_startcolumn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspan_endcolumn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskimmagelist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redit_keycolumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tr_content)).BeginInit();
            this.SuspendLayout();
            // 
            // IputControl
            // 
            this.IputControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IputControl.Location = new System.Drawing.Point(238, 0);
            this.IputControl.Name = "IputControl";
            this.IputControl.Panel1.AutoScroll = true;
            this.IputControl.Panel1.Controls.Add(this.taskpicture);
            this.IputControl.Panel1.Text = "Panel1";
            this.IputControl.Panel1.SizeChanged += new System.EventHandler(this.IputControl_Panel1_SizeChanged);
            this.IputControl.Panel2.Controls.Add(this.inputSpread);
            this.IputControl.Panel2.Controls.Add(this.standaloneBarDockControl1);
            this.IputControl.Panel2.Text = "Panel2";
            this.IputControl.Size = new System.Drawing.Size(1187, 835);
            this.IputControl.SplitterPosition = 539;
            this.IputControl.TabIndex = 1;
            this.IputControl.Visible = false;
            // 
            // taskpicture
            // 
            this.taskpicture.Location = new System.Drawing.Point(0, 0);
            this.taskpicture.Name = "taskpicture";
            this.taskpicture.Size = new System.Drawing.Size(435, 740);
            this.taskpicture.TabIndex = 0;
            this.taskpicture.TabStop = false;
            this.taskpicture.RegionChanged += new System.EventHandler(this.Taskpicture_RegionChanged);
            this.taskpicture.SizeChanged += new System.EventHandler(this.Taskpicture_SizeChanged);
            this.taskpicture.Paint += new System.Windows.Forms.PaintEventHandler(this.Taskpicture_Paint);
            this.taskpicture.DoubleClick += new System.EventHandler(this.Taskpicture_DoubleClick);
            this.taskpicture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureEdit1_MouseDown);
            this.taskpicture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Taskpicture_MouseMove);
            this.taskpicture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Taskpicture_MouseUp);
            // 
            // inputSpread
            // 
            this.inputSpread.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputSpread.Location = new System.Drawing.Point(0, 38);
            this.inputSpread.MenuManager = this.barManager1;
            this.inputSpread.Name = "inputSpread";
            this.inputSpread.Size = new System.Drawing.Size(643, 797);
            this.inputSpread.TabIndex = 0;
            this.inputSpread.Text = "spreadsheetControl1";
            this.inputSpread.CellValueChanged += new DevExpress.XtraSpreadsheet.CellValueChangedEventHandler(this.InputSpread_CellValueChanged);
            this.inputSpread.Click += new System.EventHandler(this.InputSpread_Click);
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControl1);
            this.barManager1.DockControls.Add(this.barDockControl2);
            this.barManager1.DockControls.Add(this.barDockControl3);
            this.barManager1.DockControls.Add(this.barDockControl4);
            this.barManager1.DockControls.Add(this.standaloneBarDockControl1);
            this.barManager1.Form = this;
            this.barManager1.Images = this.taskimmagelist;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem2,
            this.L_startrow,
            this.span_startrow,
            this.l_startcolumn,
            this.span_startcolumn,
            this.l_endcolumns,
            this.l_keycolumns,
            this.span_endcolumn,
            this.bar_endrow,
            this.barStaticItem1});
            this.barManager1.MaxItemId = 15;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2,
            this.rspan_startrow,
            this.rspan_startcolumn,
            this.rspan_endcolumn,
            this.redit_keycolumns,
            this.repositoryItemSpinEdit1});
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.bar1.FloatLocation = new System.Drawing.Point(463, 169);
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.L_startrow),
            new DevExpress.XtraBars.LinkPersistInfo(this.span_startrow),
            new DevExpress.XtraBars.LinkPersistInfo(this.l_startcolumn),
            new DevExpress.XtraBars.LinkPersistInfo(this.span_startcolumn),
            new DevExpress.XtraBars.LinkPersistInfo(this.l_endcolumns),
            new DevExpress.XtraBars.LinkPersistInfo(this.span_endcolumn),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_endrow)});
            this.bar1.Offset = 13;
            this.bar1.StandaloneBarDockControl = this.standaloneBarDockControl1;
            this.bar1.Text = "Tools";
            // 
            // L_startrow
            // 
            this.L_startrow.Caption = "起始行:";
            this.L_startrow.Id = 2;
            this.L_startrow.Name = "L_startrow";
            // 
            // span_startrow
            // 
            this.span_startrow.Caption = "barEditItem1";
            this.span_startrow.Edit = this.rspan_startrow;
            this.span_startrow.Enabled = false;
            this.span_startrow.Id = 5;
            this.span_startrow.Name = "span_startrow";
            // 
            // rspan_startrow
            // 
            this.rspan_startrow.AutoHeight = false;
            this.rspan_startrow.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rspan_startrow.Name = "rspan_startrow";
            // 
            // l_startcolumn
            // 
            this.l_startcolumn.Caption = "起始列:";
            this.l_startcolumn.Id = 6;
            this.l_startcolumn.Name = "l_startcolumn";
            // 
            // span_startcolumn
            // 
            this.span_startcolumn.Caption = "barEditItem1";
            this.span_startcolumn.Edit = this.rspan_startcolumn;
            this.span_startcolumn.Enabled = false;
            this.span_startcolumn.Id = 7;
            this.span_startcolumn.Name = "span_startcolumn";
            // 
            // rspan_startcolumn
            // 
            this.rspan_startcolumn.AutoHeight = false;
            this.rspan_startcolumn.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rspan_startcolumn.Name = "rspan_startcolumn";
            // 
            // l_endcolumns
            // 
            this.l_endcolumns.Caption = "结束列:";
            this.l_endcolumns.Id = 8;
            this.l_endcolumns.Name = "l_endcolumns";
            // 
            // span_endcolumn
            // 
            this.span_endcolumn.Caption = "barEditItem1";
            this.span_endcolumn.Edit = this.rspan_endcolumn;
            this.span_endcolumn.Enabled = false;
            this.span_endcolumn.Id = 11;
            this.span_endcolumn.Name = "span_endcolumn";
            // 
            // rspan_endcolumn
            // 
            this.rspan_endcolumn.AutoHeight = false;
            this.rspan_endcolumn.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rspan_endcolumn.Name = "rspan_endcolumn";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "结束行:";
            this.barStaticItem1.Id = 14;
            this.barStaticItem1.Name = "barStaticItem1";
            // 
            // bar_endrow
            // 
            this.bar_endrow.Caption = "barEditItem1";
            this.bar_endrow.Edit = this.repositoryItemSpinEdit1;
            this.bar_endrow.Enabled = false;
            this.bar_endrow.Id = 13;
            this.bar_endrow.Name = "bar_endrow";
            this.bar_endrow.EditValueChanged += new System.EventHandler(this.Bar_endrow_EditValueChanged);
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // standaloneBarDockControl1
            // 
            this.standaloneBarDockControl1.CausesValidation = false;
            this.standaloneBarDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.standaloneBarDockControl1.Location = new System.Drawing.Point(0, 0);
            this.standaloneBarDockControl1.Manager = this.barManager1;
            this.standaloneBarDockControl1.Name = "standaloneBarDockControl1";
            this.standaloneBarDockControl1.Size = new System.Drawing.Size(643, 38);
            this.standaloneBarDockControl1.Text = "standaloneBarDockControl1";
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl1.Location = new System.Drawing.Point(0, 0);
            this.barDockControl1.Manager = this.barManager1;
            this.barDockControl1.Size = new System.Drawing.Size(1425, 0);
            // 
            // barDockControl2
            // 
            this.barDockControl2.CausesValidation = false;
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl2.Location = new System.Drawing.Point(0, 835);
            this.barDockControl2.Manager = this.barManager1;
            this.barDockControl2.Size = new System.Drawing.Size(1425, 0);
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl3.Location = new System.Drawing.Point(0, 0);
            this.barDockControl3.Manager = this.barManager1;
            this.barDockControl3.Size = new System.Drawing.Size(0, 835);
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl4.Location = new System.Drawing.Point(1425, 0);
            this.barDockControl4.Manager = this.barManager1;
            this.barDockControl4.Size = new System.Drawing.Size(0, 835);
            // 
            // taskimmagelist
            // 
            this.taskimmagelist.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("taskimmagelist.ImageStream")));
            this.taskimmagelist.Images.SetKeyName(0, "sales_32x32.png");
            this.taskimmagelist.Images.SetKeyName(1, "employee_32x32.png");
            this.taskimmagelist.Images.SetKeyName(2, "checkbox2_32x32.png");
            this.taskimmagelist.Images.SetKeyName(3, "add_32x32.png");
            this.taskimmagelist.Images.SetKeyName(4, "cancel_32x32.png");
            this.taskimmagelist.Images.SetKeyName(5, "left_32x32.png");
            this.taskimmagelist.Images.SetKeyName(6, "right_32x32.png");
            this.taskimmagelist.Images.SetKeyName(7, "trash_32x32.png");
            this.taskimmagelist.Images.SetKeyName(8, "save_32x32.png");
            this.taskimmagelist.Images.SetKeyName(9, "saveall_32x32.png");
            this.taskimmagelist.Images.SetKeyName(10, "bofolder_32x32.png");
            this.taskimmagelist.Images.SetKeyName(11, "bofileattachment_32x32.png");
            this.taskimmagelist.Images.SetKeyName(12, "format_32x32.png");
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Id = 1;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // l_keycolumns
            // 
            this.l_keycolumns.Caption = "关键列：";
            this.l_keycolumns.Id = 9;
            this.l_keycolumns.Name = "l_keycolumns";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // redit_keycolumns
            // 
            this.redit_keycolumns.AutoHeight = false;
            this.redit_keycolumns.Name = "redit_keycolumns";
            // 
            // tr_content
            // 
            this.tr_content.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.tc_nodecolumn});
            this.tr_content.Dock = System.Windows.Forms.DockStyle.Left;
            this.tr_content.Location = new System.Drawing.Point(0, 0);
            this.tr_content.Name = "tr_content";
            this.tr_content.OptionsBehavior.Editable = false;
            this.tr_content.OptionsBehavior.ReadOnly = true;
            this.tr_content.OptionsView.ShowColumns = false;
            this.tr_content.OptionsView.ShowIndicator = false;
            this.tr_content.SelectImageList = this.taskimmagelist;
            this.tr_content.Size = new System.Drawing.Size(238, 835);
            this.tr_content.StateImageList = this.taskimmagelist;
            this.tr_content.TabIndex = 0;
            this.tr_content.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Tr_content_MouseClick);
            // 
            // tc_nodecolumn
            // 
            this.tc_nodecolumn.Caption = "treeListColumn1";
            this.tc_nodecolumn.FieldName = "nodename";
            this.tc_nodecolumn.Name = "tc_nodecolumn";
            this.tc_nodecolumn.Visible = true;
            this.tc_nodecolumn.VisibleIndex = 0;
            // 
            // Input
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.IputControl);
            this.Controls.Add(this.tr_content);
            this.Controls.Add(this.barDockControl3);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControl2);
            this.Controls.Add(this.barDockControl1);
            this.Name = "Input";
            this.Size = new System.Drawing.Size(1425, 835);
            ((System.ComponentModel.ISupportInitialize)(this.IputControl)).EndInit();
            this.IputControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.taskpicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspan_startrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspan_startcolumn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspan_endcolumn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskimmagelist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redit_keycolumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tr_content)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SplitContainerControl IputControl;
        private DevExpress.XtraSpreadsheet.SpreadsheetControl inputSpread;
        private DevExpress.XtraTreeList.TreeList tr_content;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tc_nodecolumn;
        private DevExpress.XtraBars.StandaloneBarDockControl standaloneBarDockControl1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarStaticItem L_startrow;
        private DevExpress.XtraBars.BarEditItem span_startrow;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit rspan_startrow;
        private DevExpress.XtraBars.BarStaticItem l_startcolumn;
        private DevExpress.XtraBars.BarEditItem span_startcolumn;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit rspan_startcolumn;
        private DevExpress.XtraBars.BarStaticItem l_endcolumns;
        private DevExpress.XtraBars.BarEditItem span_endcolumn;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit rspan_endcolumn;
        private DevExpress.XtraBars.BarStaticItem l_keycolumns;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit redit_keycolumns;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarEditItem bar_endrow;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.Utils.ImageCollection taskimmagelist;
        private System.Windows.Forms.PictureBox taskpicture;
    }
}
