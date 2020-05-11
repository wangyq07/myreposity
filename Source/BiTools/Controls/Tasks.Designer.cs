namespace BiTools.Controls
{
    partial class Tasks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tasks));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            this.tr_content = new DevExpress.XtraTreeList.TreeList();
            this.tc_nodecolumn = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.taskbarmanager = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.standaloneBarDockControl1 = new DevExpress.XtraBars.StandaloneBarDockControl();
            this.taskimmagelist = new DevExpress.Utils.ImageCollection(this.components);
            this.bar_addnode = new DevExpress.XtraBars.BarButtonItem();
            this.bar_addtemplete = new DevExpress.XtraBars.BarButtonItem();
            this.bar_addtask = new DevExpress.XtraBars.BarButtonItem();
            this.btn_deleteNode = new DevExpress.XtraBars.BarButtonItem();
            this.bar_editTask = new DevExpress.XtraBars.BarButtonItem();
            this.templeteandtaskpicture = new DevExpress.XtraEditors.SplitContainerControl();
            this.task_picture = new DevExpress.XtraEditors.PictureEdit();
            this.spread_templete = new DevExpress.XtraSpreadsheet.SpreadsheetControl();
            this.taskpopup = new DevExpress.XtraBars.PopupMenu(this.components);
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
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.redit_keycolumns = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.span_endrow = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.tr_content)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskbarmanager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskimmagelist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.templeteandtaskpicture)).BeginInit();
            this.templeteandtaskpicture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.task_picture.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskpopup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspan_startrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspan_startcolumn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspan_endcolumn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redit_keycolumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // tr_content
            // 
            this.tr_content.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.tc_nodecolumn});
            this.tr_content.Dock = System.Windows.Forms.DockStyle.Left;
            this.tr_content.Location = new System.Drawing.Point(0, 0);
            this.tr_content.MenuManager = this.taskbarmanager;
            this.tr_content.Name = "tr_content";
            this.tr_content.OptionsView.ShowColumns = false;
            this.tr_content.OptionsView.ShowIndicator = false;
            this.tr_content.SelectImageList = this.taskimmagelist;
            this.tr_content.Size = new System.Drawing.Size(264, 820);
            this.tr_content.StateImageList = this.taskimmagelist;
            this.tr_content.TabIndex = 0;
            this.tr_content.NodeChanged += new DevExpress.XtraTreeList.NodeChangedEventHandler(this.Tr_content_NodeChanged);
            this.tr_content.CellValueChanged += new DevExpress.XtraTreeList.CellValueChangedEventHandler(this.Tr_content_CellValueChanged);
            this.tr_content.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.Tr_content_ShowingEditor);
            this.tr_content.DataSourceChanged += new System.EventHandler(this.Tr_content_DataSourceChanged);
            this.tr_content.TextChanged += new System.EventHandler(this.Tr_content_TextChanged);
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
            // taskbarmanager
            // 
            this.taskbarmanager.DockControls.Add(this.barDockControlTop);
            this.taskbarmanager.DockControls.Add(this.barDockControlBottom);
            this.taskbarmanager.DockControls.Add(this.barDockControlLeft);
            this.taskbarmanager.DockControls.Add(this.barDockControlRight);
            this.taskbarmanager.DockControls.Add(this.standaloneBarDockControl1);
            this.taskbarmanager.Form = this;
            this.taskbarmanager.Images = this.taskimmagelist;
            this.taskbarmanager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bar_addnode,
            this.bar_addtemplete,
            this.bar_addtask,
            this.btn_deleteNode,
            this.bar_editTask,
            this.barStaticItem1,
            this.span_endrow});
            this.taskbarmanager.MaxItemId = 11;
            this.taskbarmanager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemSpinEdit1});
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.taskbarmanager;
            this.barDockControlTop.Size = new System.Drawing.Size(1452, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 820);
            this.barDockControlBottom.Manager = this.taskbarmanager;
            this.barDockControlBottom.Size = new System.Drawing.Size(1452, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.taskbarmanager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 820);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1452, 0);
            this.barDockControlRight.Manager = this.taskbarmanager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 820);
            // 
            // standaloneBarDockControl1
            // 
            this.standaloneBarDockControl1.CausesValidation = false;
            this.standaloneBarDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.standaloneBarDockControl1.Location = new System.Drawing.Point(0, 0);
            this.standaloneBarDockControl1.Manager = this.taskbarmanager;
            this.standaloneBarDockControl1.Name = "standaloneBarDockControl1";
            this.standaloneBarDockControl1.Size = new System.Drawing.Size(1188, 45);
            this.standaloneBarDockControl1.Text = "standaloneBarDockControl1";
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
            // bar_addnode
            // 
            this.bar_addnode.Caption = "添加节点";
            this.bar_addnode.Id = 4;
            this.bar_addnode.ImageOptions.ImageIndex = 10;
            this.bar_addnode.Name = "bar_addnode";
            this.bar_addnode.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Bar_addnode_ItemClick);
            // 
            // bar_addtemplete
            // 
            this.bar_addtemplete.Caption = "添加模板";
            this.bar_addtemplete.Id = 5;
            this.bar_addtemplete.ImageOptions.ImageIndex = 12;
            this.bar_addtemplete.Name = "bar_addtemplete";
            this.bar_addtemplete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Bar_addtemplete_ItemClick);
            // 
            // bar_addtask
            // 
            this.bar_addtask.Caption = "添加新任务";
            this.bar_addtask.Id = 6;
            this.bar_addtask.ImageOptions.ImageIndex = 11;
            this.bar_addtask.Name = "bar_addtask";
            this.bar_addtask.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Bar_addtask_ItemClick);
            // 
            // btn_deleteNode
            // 
            this.btn_deleteNode.Caption = "删除";
            this.btn_deleteNode.Id = 7;
            this.btn_deleteNode.ImageOptions.ImageIndex = 7;
            this.btn_deleteNode.Name = "btn_deleteNode";
            this.btn_deleteNode.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btn_deleteNode.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Btn_deleteNode_ItemClick);
            // 
            // bar_editTask
            // 
            this.bar_editTask.Caption = "barButtonItem1";
            this.bar_editTask.Id = 8;
            this.bar_editTask.Name = "bar_editTask";
            // 
            // templeteandtaskpicture
            // 
            this.templeteandtaskpicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.templeteandtaskpicture.Horizontal = false;
            this.templeteandtaskpicture.Location = new System.Drawing.Point(264, 0);
            this.templeteandtaskpicture.Name = "templeteandtaskpicture";
            this.templeteandtaskpicture.Panel1.Controls.Add(this.task_picture);
            this.templeteandtaskpicture.Panel1.Text = "Panel1";
            this.templeteandtaskpicture.Panel2.Controls.Add(this.spread_templete);
            this.templeteandtaskpicture.Panel2.Controls.Add(this.standaloneBarDockControl1);
            this.templeteandtaskpicture.Panel2.Text = "Panel2";
            this.templeteandtaskpicture.Size = new System.Drawing.Size(1188, 820);
            this.templeteandtaskpicture.SplitterPosition = 236;
            this.templeteandtaskpicture.TabIndex = 1;
            // 
            // task_picture
            // 
            this.task_picture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.task_picture.Location = new System.Drawing.Point(0, 0);
            this.task_picture.Name = "task_picture";
            this.task_picture.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.task_picture.Size = new System.Drawing.Size(1188, 236);
            this.task_picture.TabIndex = 0;
            // 
            // spread_templete
            // 
            this.spread_templete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spread_templete.Location = new System.Drawing.Point(0, 45);
            this.spread_templete.MenuManager = this.taskbarmanager;
            this.spread_templete.Name = "spread_templete";
            this.spread_templete.Size = new System.Drawing.Size(1188, 534);
            this.spread_templete.TabIndex = 1;
            this.spread_templete.Text = "spreadsheetControl1";
            // 
            // taskpopup
            // 
            this.taskpopup.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_addnode),
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_addtemplete),
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_addtask),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_deleteNode)});
            this.taskpopup.Manager = this.taskbarmanager;
            this.taskpopup.Name = "taskpopup";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControl1);
            this.barManager1.DockControls.Add(this.barDockControl2);
            this.barManager1.DockControls.Add(this.barDockControl3);
            this.barManager1.DockControls.Add(this.barDockControl4);
            this.barManager1.Form = this;
            this.barManager1.Images = this.taskimmagelist;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem2,
            this.L_startrow,
            this.span_startrow,
            this.l_startcolumn,
            this.span_startcolumn,
            this.l_endcolumns,
            this.barButtonItem1,
            this.span_endcolumn});
            this.barManager1.MaxItemId = 13;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2,
            this.rspan_startrow,
            this.rspan_startcolumn,
            this.rspan_endcolumn,
            this.redit_keycolumns});
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
            new DevExpress.XtraBars.LinkPersistInfo(this.span_endrow),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1)});
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
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 10;
            this.barButtonItem1.ImageOptions.ImageIndex = 8;
            this.barButtonItem1.Name = "barButtonItem1";
            toolTipItem1.Text = "保存模板设定";
            superToolTip1.Items.Add(toolTipItem1);
            this.barButtonItem1.SuperTip = superToolTip1;
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItem1_ItemClick);
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl1.Location = new System.Drawing.Point(0, 0);
            this.barDockControl1.Manager = this.barManager1;
            this.barDockControl1.Size = new System.Drawing.Size(1452, 0);
            // 
            // barDockControl2
            // 
            this.barDockControl2.CausesValidation = false;
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl2.Location = new System.Drawing.Point(0, 820);
            this.barDockControl2.Manager = this.barManager1;
            this.barDockControl2.Size = new System.Drawing.Size(1452, 0);
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl3.Location = new System.Drawing.Point(0, 0);
            this.barDockControl3.Manager = this.barManager1;
            this.barDockControl3.Size = new System.Drawing.Size(0, 820);
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl4.Location = new System.Drawing.Point(1452, 0);
            this.barDockControl4.Manager = this.barManager1;
            this.barDockControl4.Size = new System.Drawing.Size(0, 820);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Id = 1;
            this.barButtonItem2.Name = "barButtonItem2";
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
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "结束行";
            this.barStaticItem1.Id = 9;
            this.barStaticItem1.Name = "barStaticItem1";
            // 
            // span_endrow
            // 
            this.span_endrow.Caption = "barEditItem1";
            this.span_endrow.Edit = this.repositoryItemSpinEdit1;
            this.span_endrow.Id = 10;
            this.span_endrow.Name = "span_endrow";
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // Tasks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.templeteandtaskpicture);
            this.Controls.Add(this.tr_content);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Controls.Add(this.barDockControl3);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControl2);
            this.Controls.Add(this.barDockControl1);
            this.Name = "Tasks";
            this.Size = new System.Drawing.Size(1452, 820);
            ((System.ComponentModel.ISupportInitialize)(this.tr_content)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskbarmanager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskimmagelist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.templeteandtaskpicture)).EndInit();
            this.templeteandtaskpicture.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.task_picture.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskpopup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspan_startrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspan_startcolumn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspan_endcolumn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redit_keycolumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList tr_content;
        private DevExpress.XtraEditors.SplitContainerControl templeteandtaskpicture;
        private DevExpress.XtraEditors.PictureEdit task_picture;
        private DevExpress.Utils.ImageCollection taskimmagelist;
        private DevExpress.XtraBars.BarManager taskbarmanager;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem bar_addnode;
        private DevExpress.XtraBars.BarButtonItem bar_addtemplete;
        private DevExpress.XtraBars.BarButtonItem bar_addtask;
        private DevExpress.XtraBars.PopupMenu taskpopup;
        private DevExpress.XtraBars.BarButtonItem btn_deleteNode;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tc_nodecolumn;
        private DevExpress.XtraBars.BarButtonItem bar_editTask;
        private DevExpress.XtraSpreadsheet.SpreadsheetControl spread_templete;
        private DevExpress.XtraBars.StandaloneBarDockControl standaloneBarDockControl1;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private DevExpress.XtraBars.BarStaticItem L_startrow;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.BarEditItem span_startrow;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit rspan_startrow;
        private DevExpress.XtraBars.BarStaticItem l_startcolumn;
        private DevExpress.XtraBars.BarEditItem span_startcolumn;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit rspan_startcolumn;
        private DevExpress.XtraBars.BarStaticItem l_endcolumns;
        private DevExpress.XtraBars.BarEditItem span_endcolumn;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit rspan_endcolumn;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit redit_keycolumns;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarEditItem span_endrow;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
    }
}
