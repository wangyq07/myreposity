namespace BiTools
{
    partial class AddTempleteForm
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
            DevExpress.Utils.SuperToolTip superToolTip5 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem5 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip6 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem6 = new DevExpress.Utils.ToolTipItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTempleteForm));
            this.spread_templete = new DevExpress.XtraSpreadsheet.SpreadsheetControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bar_confirm = new DevExpress.XtraBars.BarButtonItem();
            this.bar_cancel = new DevExpress.XtraBars.BarButtonItem();
            this.taskimmagelist = new DevExpress.Utils.ImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskimmagelist)).BeginInit();
            this.SuspendLayout();
            // 
            // spread_templete
            // 
            this.spread_templete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spread_templete.Location = new System.Drawing.Point(0, 31);
            this.spread_templete.MenuManager = this.barManager1;
            this.spread_templete.Name = "spread_templete";
            this.spread_templete.Size = new System.Drawing.Size(1141, 682);
            this.spread_templete.TabIndex = 1;
            this.spread_templete.Text = "spreadsheetControl1";
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
            this.bar_cancel});
            this.barManager1.MaxItemId = 3;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1141, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 713);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1141, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 682);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1141, 31);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 682);
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.FloatLocation = new System.Drawing.Point(75, 118);
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_confirm),
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_cancel)});
            this.bar1.Offset = 20;
            this.bar1.Text = "Tools";
            // 
            // bar_confirm
            // 
            this.bar_confirm.Id = 1;
            this.bar_confirm.ImageOptions.ImageIndex = 9;
            this.bar_confirm.Name = "bar_confirm";
            toolTipItem5.Text = "保存";
            superToolTip5.Items.Add(toolTipItem5);
            this.bar_confirm.SuperTip = superToolTip5;
            this.bar_confirm.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Bar_confirm_ItemClick);
            // 
            // bar_cancel
            // 
            this.bar_cancel.Id = 2;
            this.bar_cancel.ImageOptions.ImageIndex = 6;
            this.bar_cancel.Name = "bar_cancel";
            toolTipItem6.Text = "取消";
            superToolTip6.Items.Add(toolTipItem6);
            this.bar_cancel.SuperTip = superToolTip6;
            this.bar_cancel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Bar_cancel_ItemClick);
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
            // AddTempleteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 713);
            this.ControlBox = false;
            this.Controls.Add(this.spread_templete);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddTempleteForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加模板";
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskimmagelist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraSpreadsheet.SpreadsheetControl spread_templete;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem bar_confirm;
        private DevExpress.XtraBars.BarButtonItem bar_cancel;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection taskimmagelist;
    }
}