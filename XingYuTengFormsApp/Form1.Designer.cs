using BrightIdeasSoftware;
using System.Drawing;

namespace XingYuTengFormsApp
{
    partial class Form
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.AddDevice = new System.Windows.Forms.PictureBox();
            this.deviceID = new System.Windows.Forms.TextBox();
            this.labelAdd = new System.Windows.Forms.Label();
            this.pictureBoxSmall = new System.Windows.Forms.PictureBox();
            this.pictureBoxSize = new System.Windows.Forms.PictureBox();
            this.pictureBoxClose = new System.Windows.Forms.PictureBox();
            this.Panel = new System.Windows.Forms.Panel();
            this.olvColumnDesk = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.columnName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.columnValue = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnDelete = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.detail = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.updateTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.detailObject = new BrightIdeasSoftware.ObjectListView();
            this.detailInfo = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.设备ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改设备ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.备注信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deviceList = new BrightIdeasSoftware.ObjectListView();
            this.loading = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddDevice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).BeginInit();
            this.Panel.SuspendLayout();
            this.detail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailObject)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deviceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loading)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
            this.pictureBox.InitialImage = null;
            this.pictureBox.Location = new System.Drawing.Point(21, 30);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(42, 42);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("宋体", 15F);
            this.label.ForeColor = System.Drawing.Color.White;
            this.label.Location = new System.Drawing.Point(85, 43);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(109, 20);
            this.label.TabIndex = 1;
            this.label.Text = "兴宇腾测控";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.AddDevice);
            this.panel1.Controls.Add(this.deviceID);
            this.panel1.Controls.Add(this.labelAdd);
            this.panel1.Location = new System.Drawing.Point(240, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(434, 32);
            this.panel1.TabIndex = 2;
            // 
            // AddDevice
            // 
            this.AddDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddDevice.Image = ((System.Drawing.Image)(resources.GetObject("AddDevice.Image")));
            this.AddDevice.Location = new System.Drawing.Point(407, 4);
            this.AddDevice.Name = "AddDevice";
            this.AddDevice.Size = new System.Drawing.Size(23, 23);
            this.AddDevice.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.AddDevice.TabIndex = 2;
            this.AddDevice.TabStop = false;
            this.AddDevice.Click += new System.EventHandler(this.AddDevice_Click);
            // 
            // deviceID
            // 
            this.deviceID.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deviceID.BackColor = System.Drawing.Color.White;
            this.deviceID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.deviceID.Font = new System.Drawing.Font("宋体", 15F);
            this.deviceID.Location = new System.Drawing.Point(115, 5);
            this.deviceID.Name = "deviceID";
            this.deviceID.Size = new System.Drawing.Size(266, 23);
            this.deviceID.TabIndex = 0;
            // 
            // labelAdd
            // 
            this.labelAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.labelAdd.AutoSize = true;
            this.labelAdd.Font = new System.Drawing.Font("宋体", 15F);
            this.labelAdd.ForeColor = System.Drawing.Color.Black;
            this.labelAdd.Location = new System.Drawing.Point(7, 5);
            this.labelAdd.Name = "labelAdd";
            this.labelAdd.Size = new System.Drawing.Size(89, 20);
            this.labelAdd.TabIndex = 0;
            this.labelAdd.Text = "添加设备";
            // 
            // pictureBoxSmall
            // 
            this.pictureBoxSmall.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxSmall.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxSmall.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxSmall.Image")));
            this.pictureBoxSmall.Location = new System.Drawing.Point(787, 34);
            this.pictureBoxSmall.Name = "pictureBoxSmall";
            this.pictureBoxSmall.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxSmall.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxSmall.TabIndex = 3;
            this.pictureBoxSmall.TabStop = false;
            this.pictureBoxSmall.Click += new System.EventHandler(this.PictureBoxSmall_Click);
            // 
            // pictureBoxSize
            // 
            this.pictureBoxSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxSize.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxSize.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxSize.Image")));
            this.pictureBoxSize.Location = new System.Drawing.Point(826, 34);
            this.pictureBoxSize.Name = "pictureBoxSize";
            this.pictureBoxSize.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxSize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxSize.TabIndex = 4;
            this.pictureBoxSize.TabStop = false;
            this.pictureBoxSize.Click += new System.EventHandler(this.PictureBoxLagest_Click);
            // 
            // pictureBoxClose
            // 
            this.pictureBoxClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxClose.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxClose.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxClose.Image")));
            this.pictureBoxClose.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxClose.InitialImage")));
            this.pictureBoxClose.Location = new System.Drawing.Point(873, 36);
            this.pictureBoxClose.Name = "pictureBoxClose";
            this.pictureBoxClose.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxClose.TabIndex = 5;
            this.pictureBoxClose.TabStop = false;
            this.pictureBoxClose.Click += new System.EventHandler(this.PictureBoxClose_Click);
            // 
            // Panel
            // 
            this.Panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel.AutoSize = true;
            this.Panel.BackColor = System.Drawing.Color.DodgerBlue;
            this.Panel.Controls.Add(this.pictureBoxClose);
            this.Panel.Controls.Add(this.pictureBoxSize);
            this.Panel.Controls.Add(this.pictureBoxSmall);
            this.Panel.Controls.Add(this.panel1);
            this.Panel.Controls.Add(this.label);
            this.Panel.Controls.Add(this.pictureBox);
            this.Panel.Location = new System.Drawing.Point(2, 2);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(916, 104);
            this.Panel.TabIndex = 3;
            this.Panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            // 
            // olvColumnDesk
            // 
            this.olvColumnDesk.AspectName = "设备列表";
            this.olvColumnDesk.MinimumWidth = 40;
            this.olvColumnDesk.Text = "设备列表";
            this.olvColumnDesk.ToolTipText = "";
            this.olvColumnDesk.Width = 245;
            // 
            // columnName
            // 
            this.columnName.AspectName = "Name";
            this.columnName.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnName.MaximumWidth = 200;
            this.columnName.MinimumWidth = 100;
            this.columnName.Text = "测量属性";
            this.columnName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnName.ToolTipText = "This is a long tooltip text that should appear when the mouse is over this column" +
    " header but contains absolutely no useful information :)";
            this.columnName.UseInitialLetterForGroup = true;
            this.columnName.Width = 120;
            // 
            // columnValue
            // 
            this.columnValue.AspectName = "Value";
            this.columnValue.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnValue.Hyperlink = true;
            this.columnValue.MaximumWidth = 180;
            this.columnValue.MinimumWidth = 50;
            this.columnValue.Text = "测量值";
            this.columnValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnValue.Width = 120;
            // 
            // olvColumnDelete
            // 
            this.olvColumnDelete.AspectName = "delete";
            this.olvColumnDelete.ButtonSize = new System.Drawing.Size(35, 20);
            this.olvColumnDelete.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.FixedBounds;
            this.olvColumnDelete.EnableButtonWhenItemIsDisabled = true;
            this.olvColumnDelete.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumnDelete.IsButton = true;
            this.olvColumnDelete.Text = "删除";
            this.olvColumnDelete.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumnDelete.Width = 55;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Location = new System.Drawing.Point(299, 106);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(619, 472);
            this.tabControl1.TabIndex = 4;
            // 
            // detail
            // 
            this.detail.BackColor = System.Drawing.Color.RoyalBlue;
            this.detail.Controls.Add(this.pictureBox1);
            this.detail.Controls.Add(this.updateTime);
            this.detail.Controls.Add(this.label1);
            this.detail.Controls.Add(this.detailObject);
            this.detail.Controls.Add(this.detailInfo);
            this.detail.Controls.Add(this.menuStrip1);
            this.detail.Location = new System.Drawing.Point(290, 152);
            this.detail.Name = "detail";
            this.detail.Size = new System.Drawing.Size(240, 307);
            this.detail.TabIndex = 0;
            this.detail.Visible = false;
            this.detail.MouseLeave += new System.EventHandler(this.Panel_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(220, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(13, 13);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // updateTime
            // 
            this.updateTime.AutoSize = true;
            this.updateTime.Location = new System.Drawing.Point(62, 278);
            this.updateTime.Name = "updateTime";
            this.updateTime.Size = new System.Drawing.Size(65, 12);
            this.updateTime.TabIndex = 4;
            this.updateTime.Text = "2012.12.31";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 278);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "更新时间";
            // 
            // detailObject
            // 
            this.detailObject.AllColumns.Add(this.columnName);
            this.detailObject.AllColumns.Add(this.columnValue);
            this.detailObject.AllowColumnReorder = true;
            this.detailObject.AllowDrop = true;
            this.detailObject.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.detailObject.CellEditUseWholeCell = false;
            this.detailObject.CheckedAspectName = "";
            this.detailObject.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnValue});
            this.detailObject.Cursor = System.Windows.Forms.Cursors.Default;
            this.detailObject.FullRowSelect = true;
            this.detailObject.HeaderWordWrap = true;
            this.detailObject.HideSelection = false;
            this.detailObject.IncludeColumnHeadersInCopy = true;
            this.detailObject.Location = new System.Drawing.Point(0, 52);
            this.detailObject.Name = "detailObject";
            this.detailObject.OverlayText.Alignment = System.Drawing.ContentAlignment.BottomLeft;
            this.detailObject.OverlayText.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.detailObject.OverlayText.BorderWidth = 2F;
            this.detailObject.OverlayText.Rotation = -20;
            this.detailObject.OverlayText.Text = "";
            this.detailObject.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu;
            this.detailObject.ShowCommandMenuOnRightClick = true;
            this.detailObject.ShowGroups = false;
            this.detailObject.ShowHeaderInAllViews = false;
            this.detailObject.ShowItemToolTips = true;
            this.detailObject.Size = new System.Drawing.Size(240, 223);
            this.detailObject.SortGroupItemsByPrimaryColumn = false;
            this.detailObject.TabIndex = 30;
            this.detailObject.UseAlternatingBackColors = true;
            this.detailObject.UseCellFormatEvents = true;
            this.detailObject.UseCompatibleStateImageBehavior = false;
            this.detailObject.UseFilterIndicator = true;
            this.detailObject.UseFiltering = true;
            this.detailObject.UseHotItem = true;
            this.detailObject.View = System.Windows.Forms.View.Details;
            this.detailObject.MouseLeave += new System.EventHandler(this.Panel_MouseLeave);
            // 
            // detailInfo
            // 
            this.detailInfo.BackColor = System.Drawing.Color.RoyalBlue;
            this.detailInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.detailInfo.ForeColor = System.Drawing.Color.White;
            this.detailInfo.Location = new System.Drawing.Point(0, 28);
            this.detailInfo.Name = "detailInfo";
            this.detailInfo.Size = new System.Drawing.Size(240, 14);
            this.detailInfo.TabIndex = 1;
            this.detailInfo.Text = "eeeeee";
            this.detailInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.detailInfo.MouseLeave += new System.EventHandler(this.Panel_MouseLeave);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.RoyalBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设备ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(240, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.MouseLeave += new System.EventHandler(this.Panel_MouseLeave);
            // 
            // 设备ToolStripMenuItem
            // 
            this.设备ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.修改设备ToolStripMenuItem,
            this.备注信息ToolStripMenuItem});
            this.设备ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.设备ToolStripMenuItem.Name = "设备ToolStripMenuItem";
            this.设备ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.设备ToolStripMenuItem.Text = "设置";
            // 
            // 修改设备ToolStripMenuItem
            // 
            this.修改设备ToolStripMenuItem.Name = "修改设备ToolStripMenuItem";
            this.修改设备ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.修改设备ToolStripMenuItem.Text = "修改设备";
            // 
            // 备注信息ToolStripMenuItem
            // 
            this.备注信息ToolStripMenuItem.Name = "备注信息ToolStripMenuItem";
            this.备注信息ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.备注信息ToolStripMenuItem.Text = "备注信息";
            // 
            // deviceList
            // 
            this.deviceList.AllColumns.Add(this.olvColumnDesk);
            this.deviceList.AllColumns.Add(this.olvColumnDelete);
            this.deviceList.AllowColumnReorder = true;
            this.deviceList.AllowDrop = true;
            this.deviceList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deviceList.BackColor = System.Drawing.Color.White;
            this.deviceList.CellEditUseWholeCell = false;
            this.deviceList.CheckBoxes = true;
            this.deviceList.CheckedAspectName = "";
            this.deviceList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnDesk,
            this.olvColumnDelete});
            this.deviceList.Cursor = System.Windows.Forms.Cursors.Default;
            this.deviceList.EmptyListMsg = "未添加设备";
            this.deviceList.FullRowSelect = true;
            this.deviceList.HeaderWordWrap = true;
            this.deviceList.HideSelection = false;
            this.deviceList.IncludeColumnHeadersInCopy = true;
            this.deviceList.Location = new System.Drawing.Point(2, 106);
            this.deviceList.Name = "deviceList";
            this.deviceList.OverlayText.Alignment = System.Drawing.ContentAlignment.BottomLeft;
            this.deviceList.OverlayText.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.deviceList.OverlayText.BorderWidth = 2F;
            this.deviceList.OverlayText.Rotation = -20;
            this.deviceList.OverlayText.Text = "";
            this.deviceList.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu;
            this.deviceList.ShowCommandMenuOnRightClick = true;
            this.deviceList.ShowGroups = false;
            this.deviceList.ShowHeaderInAllViews = false;
            this.deviceList.ShowItemToolTips = true;
            this.deviceList.Size = new System.Drawing.Size(299, 472);
            this.deviceList.SortGroupItemsByPrimaryColumn = false;
            this.deviceList.TabIndex = 2;
            this.deviceList.TriStateCheckBoxes = true;
            this.deviceList.UseAlternatingBackColors = true;
            this.deviceList.UseCellFormatEvents = true;
            this.deviceList.UseCompatibleStateImageBehavior = false;
            this.deviceList.UseFilterIndicator = true;
            this.deviceList.UseFiltering = true;
            this.deviceList.UseHotItem = true;
            this.deviceList.UseTranslucentHotItem = true;
            this.deviceList.View = System.Windows.Forms.View.Details;
            // 
            // loading
            // 
            this.loading.BackColor = System.Drawing.Color.White;
            this.loading.ErrorImage = null;
            this.loading.Image = global::XingYuTengFormsApp.Properties.Resources.waiting;
            this.loading.Location = new System.Drawing.Point(91, 233);
            this.loading.Name = "loading";
            this.loading.Size = new System.Drawing.Size(128, 128);
            this.loading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.loading.TabIndex = 5;
            this.loading.TabStop = false;
            this.loading.Visible = false;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 245000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(920, 580);
            this.ControlBox = false;
            this.Controls.Add(this.loading);
            this.Controls.Add(this.detail);
            this.Controls.Add(this.deviceList);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.Panel);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(920, 580);
            this.Name = "Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.Color.Lavender;
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddDevice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).EndInit();
            this.Panel.ResumeLayout(false);
            this.Panel.PerformLayout();
            this.detail.ResumeLayout(false);
            this.detail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailObject)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deviceList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox AddDevice;
        private System.Windows.Forms.TextBox deviceID;
        private System.Windows.Forms.Label labelAdd;
        private System.Windows.Forms.PictureBox pictureBoxSmall;
        private System.Windows.Forms.PictureBox pictureBoxSize;
        private System.Windows.Forms.PictureBox pictureBoxClose;
        private System.Windows.Forms.Panel Panel;
        private BrightIdeasSoftware.OLVColumn columnName;
        private BrightIdeasSoftware.OLVColumn olvColumnDesk;
        private BrightIdeasSoftware.OLVColumn columnValue;
        private BrightIdeasSoftware.OLVColumn olvColumnDelete;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Panel detail;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设备ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改设备ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 备注信息ToolStripMenuItem;
        private System.Windows.Forms.Label updateTime;
        private System.Windows.Forms.Label label1;
        private BrightIdeasSoftware.ObjectListView detailObject;
        private System.Windows.Forms.TextBox detailInfo;
        private BrightIdeasSoftware.ObjectListView deviceList;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox loading;
        private System.Windows.Forms.Timer timer;
    }
}

