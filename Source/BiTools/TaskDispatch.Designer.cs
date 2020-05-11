namespace BiTools
{
    partial class TaskDispatch
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
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bar_save = new DevExpress.XtraBars.BarButtonItem();
            this.bar_cancel = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.bar_status = new DevExpress.XtraBars.BarEditItem();
            this.combo_status = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.taskname = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.taskstatus = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.firstinput = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.firstuser = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.secondinput = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.seconduser = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.jiaoyan = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.rep_jiaoyanren = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_status)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstuser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seconduser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_jiaoyanren)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bar_save,
            this.bar_cancel,
            this.bar_status,
            this.barStaticItem1});
            this.barManager1.MaxItemId = 4;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.combo_status});
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_save),
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_cancel),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_status)});
            this.bar1.Text = "Tools";
            // 
            // bar_save
            // 
            this.bar_save.Caption = "保存";
            this.bar_save.Id = 0;
            this.bar_save.Name = "bar_save";
            this.bar_save.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Bar_save_ItemClick);
            // 
            // bar_cancel
            // 
            this.bar_cancel.Caption = "关闭";
            this.bar_cancel.Id = 1;
            this.bar_cancel.Name = "bar_cancel";
            this.bar_cancel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Bar_cancel_ItemClick);
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "任务状态";
            this.barStaticItem1.Id = 3;
            this.barStaticItem1.Name = "barStaticItem1";
            // 
            // bar_status
            // 
            this.bar_status.Caption = "barEditItem1";
            this.bar_status.Edit = this.combo_status;
            this.bar_status.EditWidth = 100;
            this.bar_status.Id = 2;
            this.bar_status.Name = "bar_status";
            this.bar_status.Size = new System.Drawing.Size(100, 0);
            this.bar_status.EditValueChanged += new System.EventHandler(this.Bar_status_EditValueChanged);
            // 
            // combo_status
            // 
            this.combo_status.AutoHeight = false;
            this.combo_status.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combo_status.Name = "combo_status";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1300, 29);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 842);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1300, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 29);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 813);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1300, 29);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 813);
            // 
            // treeList1
            // 
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.taskname,
            this.taskstatus,
            this.firstinput,
            this.secondinput,
            this.jiaoyan});
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Location = new System.Drawing.Point(0, 29);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsView.ShowIndicator = false;
            this.treeList1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.firstuser,
            this.seconduser,
            this.rep_jiaoyanren});
            this.treeList1.Size = new System.Drawing.Size(1300, 813);
            this.treeList1.TabIndex = 4;
            this.treeList1.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.TreeList1_ValidatingEditor);
            this.treeList1.CellValueChanging += new DevExpress.XtraTreeList.CellValueChangedEventHandler(this.TreeList1_CellValueChanging);
            this.treeList1.Validating += new System.ComponentModel.CancelEventHandler(this.TreeList1_Validating);
            // 
            // taskname
            // 
            this.taskname.Caption = "名称";
            this.taskname.FieldName = "nodename";
            this.taskname.Name = "taskname";
            this.taskname.OptionsColumn.AllowEdit = false;
            this.taskname.OptionsColumn.ReadOnly = true;
            this.taskname.Visible = true;
            this.taskname.VisibleIndex = 0;
            // 
            // taskstatus
            // 
            this.taskstatus.Caption = "任务状态";
            this.taskstatus.FieldName = "taskstatus";
            this.taskstatus.Name = "taskstatus";
            this.taskstatus.OptionsColumn.AllowEdit = false;
            this.taskstatus.OptionsColumn.ReadOnly = true;
            this.taskstatus.Visible = true;
            this.taskstatus.VisibleIndex = 1;
            // 
            // firstinput
            // 
            this.firstinput.Caption = "一录人员";
            this.firstinput.ColumnEdit = this.firstuser;
            this.firstinput.FieldName = "firstuserid";
            this.firstinput.Name = "firstinput";
            this.firstinput.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.String;
            this.firstinput.Visible = true;
            this.firstinput.VisibleIndex = 2;
            // 
            // firstuser
            // 
            this.firstuser.AutoHeight = false;
            this.firstuser.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.firstuser.Name = "firstuser";
            // 
            // secondinput
            // 
            this.secondinput.Caption = "二录人员";
            this.secondinput.ColumnEdit = this.seconduser;
            this.secondinput.FieldName = "seconduserid";
            this.secondinput.Name = "secondinput";
            this.secondinput.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.String;
            this.secondinput.Visible = true;
            this.secondinput.VisibleIndex = 3;
            // 
            // seconduser
            // 
            this.seconduser.AutoHeight = false;
            this.seconduser.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seconduser.Name = "seconduser";
            // 
            // jiaoyan
            // 
            this.jiaoyan.Caption = "校验人";
            this.jiaoyan.ColumnEdit = this.rep_jiaoyanren;
            this.jiaoyan.FieldName = "jiaoyanren";
            this.jiaoyan.Name = "jiaoyan";
            this.jiaoyan.Visible = true;
            this.jiaoyan.VisibleIndex = 4;
            // 
            // rep_jiaoyanren
            // 
            this.rep_jiaoyanren.AutoHeight = false;
            this.rep_jiaoyanren.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rep_jiaoyanren.Name = "rep_jiaoyanren";
            // 
            // TaskDispatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 842);
            this.Controls.Add(this.treeList1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "TaskDispatch";
            this.Text = "分配任务";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TaskDispatch_FormClosing);
            this.Load += new System.EventHandler(this.TaskDispatch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_status)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstuser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seconduser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_jiaoyanren)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem bar_save;
        private DevExpress.XtraBars.BarButtonItem bar_cancel;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn taskname;
        private DevExpress.XtraTreeList.Columns.TreeListColumn taskstatus;
        private DevExpress.XtraTreeList.Columns.TreeListColumn firstinput;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox firstuser;
        private DevExpress.XtraTreeList.Columns.TreeListColumn secondinput;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox seconduser;
        private DevExpress.XtraTreeList.Columns.TreeListColumn jiaoyan;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox rep_jiaoyanren;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarEditItem bar_status;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox combo_status;
    }
}