namespace BiTools
{
    partial class AddTask
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTask));
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem4 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip5 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem5 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip6 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem6 = new DevExpress.Utils.ToolTipItem();
            this.taskimmagelist = new DevExpress.Utils.ImageCollection(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bar_confirm = new DevExpress.XtraBars.BarButtonItem();
            this.bar_cancel = new DevExpress.XtraBars.BarButtonItem();
            this.bar_addshuj = new DevExpress.XtraBars.BarButtonItem();
            this.bar_progress = new DevExpress.XtraBars.BarEditItem();
            this.progresscontro = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bar_reverse = new DevExpress.XtraBars.BarButtonItem();
            this.repositoryItemMarqueeProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar();
            this.pict_display = new DevExpress.XtraEditors.PictureEdit();
            this.task_list = new DevExpress.XtraEditors.ListBoxControl();
            this.message_edit = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.taskimmagelist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progresscontro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMarqueeProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_display.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.task_list)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.message_edit.Properties)).BeginInit();
            this.SuspendLayout();
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
            this.taskimmagelist.Images.SetKeyName(13, "checkbox_16x16.png");
            this.taskimmagelist.Images.SetKeyName(14, "sendbehindtext_16x16.png");
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
            this.barManager1.Images = this.taskimmagelist;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bar_confirm,
            this.bar_cancel,
            this.bar_reverse,
            this.bar_addshuj,
            this.bar_progress});
            this.barManager1.MaxItemId = 9;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMarqueeProgressBar1,
            this.progresscontro});
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.FloatLocation = new System.Drawing.Point(152, 112);
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_confirm),
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_cancel),
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_addshuj),
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_progress)});
            this.bar1.Text = "Tools";
            // 
            // bar_confirm
            // 
            this.bar_confirm.Id = 1;
            this.bar_confirm.ImageOptions.ImageIndex = 9;
            this.bar_confirm.Name = "bar_confirm";
            toolTipItem4.Text = "保存";
            superToolTip4.Items.Add(toolTipItem4);
            this.bar_confirm.SuperTip = superToolTip4;
            this.bar_confirm.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Bar_confirm_ItemClick);
            // 
            // bar_cancel
            // 
            this.bar_cancel.Id = 2;
            this.bar_cancel.ImageOptions.ImageIndex = 6;
            this.bar_cancel.Name = "bar_cancel";
            toolTipItem5.Text = "取消";
            superToolTip5.Items.Add(toolTipItem5);
            this.bar_cancel.SuperTip = superToolTip5;
            this.bar_cancel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Bar_cancel_ItemClick);
            // 
            // bar_addshuj
            // 
            this.bar_addshuj.Caption = "barButtonItem1";
            this.bar_addshuj.Id = 5;
            this.bar_addshuj.ImageOptions.ImageIndex = 3;
            this.bar_addshuj.Name = "bar_addshuj";
            toolTipItem6.Text = "添加任务";
            superToolTip6.Items.Add(toolTipItem6);
            this.bar_addshuj.SuperTip = superToolTip6;
            this.bar_addshuj.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Bar_addshuj_ItemClick);
            // 
            // bar_progress
            // 
            this.bar_progress.Caption = "bar_progress";
            this.bar_progress.Edit = this.progresscontro;
            this.bar_progress.Id = 7;
            this.bar_progress.Name = "bar_progress";
            this.bar_progress.Size = new System.Drawing.Size(150, 0);
            // 
            // progresscontro
            // 
            this.progresscontro.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.progresscontro.Name = "progresscontro";
            this.progresscontro.ShowTitle = true;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1300, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 829);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1300, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 798);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1300, 31);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 798);
            // 
            // bar_reverse
            // 
            this.bar_reverse.Id = 8;
            this.bar_reverse.Name = "bar_reverse";
            // 
            // repositoryItemMarqueeProgressBar1
            // 
            this.repositoryItemMarqueeProgressBar1.Name = "repositoryItemMarqueeProgressBar1";
            // 
            // pict_display
            // 
            this.pict_display.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pict_display.Location = new System.Drawing.Point(269, 31);
            this.pict_display.MenuManager = this.barManager1;
            this.pict_display.Name = "pict_display";
            this.pict_display.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pict_display.Size = new System.Drawing.Size(1031, 502);
            this.pict_display.TabIndex = 5;
            // 
            // task_list
            // 
            this.task_list.Dock = System.Windows.Forms.DockStyle.Left;
            this.task_list.Location = new System.Drawing.Point(0, 31);
            this.task_list.Name = "task_list";
            this.task_list.Size = new System.Drawing.Size(269, 502);
            this.task_list.TabIndex = 11;
            this.task_list.SelectedValueChanged += new System.EventHandler(this.Task_list_SelectedValueChanged);
            // 
            // message_edit
            // 
            this.message_edit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.message_edit.Location = new System.Drawing.Point(0, 533);
            this.message_edit.MenuManager = this.barManager1;
            this.message_edit.Name = "message_edit";
            this.message_edit.Size = new System.Drawing.Size(1300, 296);
            this.message_edit.TabIndex = 12;
            // 
            // AddTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 829);
            this.Controls.Add(this.pict_display);
            this.Controls.Add(this.task_list);
            this.Controls.Add(this.message_edit);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddTask";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "添加任务";
            this.Load += new System.EventHandler(this.AddTask_Load);
            ((System.ComponentModel.ISupportInitialize)(this.taskimmagelist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progresscontro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMarqueeProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_display.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.task_list)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.message_edit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.Utils.ImageCollection taskimmagelist;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem bar_confirm;
        private DevExpress.XtraBars.BarButtonItem bar_cancel;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PictureEdit pict_display;
        private DevExpress.XtraBars.BarButtonItem bar_reverse;
        private DevExpress.XtraBars.BarButtonItem bar_addshuj;
        private DevExpress.XtraEditors.ListBoxControl task_list;
        private DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar repositoryItemMarqueeProgressBar1;
        private DevExpress.XtraBars.BarEditItem bar_progress;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar progresscontro;
        private DevExpress.XtraEditors.MemoEdit message_edit;
    }
}