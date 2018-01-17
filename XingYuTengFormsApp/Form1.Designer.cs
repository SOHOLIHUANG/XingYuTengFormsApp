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
            this.deviceList = new BrightIdeasSoftware.ObjectListView();
            this.listView2 = new System.Windows.Forms.ListView();
            this.detail = new System.Windows.Forms.Panel();
            this.detailInfo = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改设备ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.备注信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddDevice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).BeginInit();
            this.Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deviceList)).BeginInit();
            this.detail.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
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
            this.label.ForeColor = System.Drawing.Color.WhiteSmoke;
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
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.AddDevice);
            this.panel1.Controls.Add(this.deviceID);
            this.panel1.Controls.Add(this.labelAdd);
            this.panel1.Location = new System.Drawing.Point(252, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(422, 32);
            this.panel1.TabIndex = 2;
            // 
            // AddDevice
            // 
            this.AddDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddDevice.Image = ((System.Drawing.Image)(resources.GetObject("AddDevice.Image")));
            this.AddDevice.Location = new System.Drawing.Point(395, 4);
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
            this.deviceID.BackColor = System.Drawing.Color.WhiteSmoke;
            this.deviceID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.deviceID.Font = new System.Drawing.Font("宋体", 15F);
            this.deviceID.Location = new System.Drawing.Point(115, 5);
            this.deviceID.Name = "deviceID";
            this.deviceID.Size = new System.Drawing.Size(254, 23);
            this.deviceID.TabIndex = 0;
            // 
            // labelAdd
            // 
            this.labelAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.labelAdd.AutoSize = true;
            this.labelAdd.Font = new System.Drawing.Font("宋体", 15F);
            this.labelAdd.Location = new System.Drawing.Point(1, 5);
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
            this.pictureBoxSmall.Click += new System.EventHandler(this.pictureBoxSmall_Click);
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
            this.pictureBoxSize.Click += new System.EventHandler(this.pictureBoxLagest_Click);
            // 
            // pictureBoxClose
            // 
            this.pictureBoxClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxClose.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxClose.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxClose.Image")));
            this.pictureBoxClose.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxClose.InitialImage")));
            this.pictureBoxClose.Location = new System.Drawing.Point(873, 36);
            this.pictureBoxClose.Name = "pictureBoxClose";
            this.pictureBoxClose.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxClose.TabIndex = 5;
            this.pictureBoxClose.TabStop = false;
            this.pictureBoxClose.Click += new System.EventHandler(this.pictureBoxClose_Click);
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
            this.Panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            // 
            // olvColumnDesk
            // 
            this.olvColumnDesk.AspectName = "设备列表";
            this.olvColumnDesk.MinimumWidth = 40;
            this.olvColumnDesk.Text = "设备列表";
            this.olvColumnDesk.ToolTipText = "";
            this.olvColumnDesk.Width = 302;
            // 
            // deviceList
            // 
            this.deviceList.AllColumns.Add(this.olvColumnDesk);
            this.deviceList.AllowColumnReorder = true;
            this.deviceList.AllowDrop = true;
            this.deviceList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.deviceList.BackColor = System.Drawing.SystemColors.Window;
            this.deviceList.CellEditUseWholeCell = false;
            this.deviceList.CheckBoxes = true;
            this.deviceList.CheckedAspectName = "";
            this.deviceList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnDesk});
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
            // listView2
            // 
            this.listView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listView2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listView2.Location = new System.Drawing.Point(299, 106);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(619, 472);
            this.listView2.TabIndex = 1;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // detail
            // 
            this.detail.BackColor = System.Drawing.Color.RoyalBlue;
            this.detail.Controls.Add(this.label2);
            this.detail.Controls.Add(this.label1);
            this.detail.Controls.Add(this.objectListView1);
            this.detail.Controls.Add(this.detailInfo);
            this.detail.Controls.Add(this.menuStrip1);
            this.detail.ForeColor = System.Drawing.Color.Black;
            this.detail.Location = new System.Drawing.Point(307, 112);
            this.detail.Name = "detail";
            this.detail.Size = new System.Drawing.Size(281, 380);
            this.detail.TabIndex = 4;
            this.detail.Visible = false;
            // 
            // detailInfo
            // 
            this.detailInfo.AutoSize = true;
            this.detailInfo.BackColor = System.Drawing.Color.RoyalBlue;
            this.detailInfo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.detailInfo.ForeColor = System.Drawing.Color.White;
            this.detailInfo.Location = new System.Drawing.Point(86, 25);
            this.detailInfo.Name = "detailInfo";
            this.detailInfo.Size = new System.Drawing.Size(104, 16);
            this.detailInfo.TabIndex = 0;
            this.detailInfo.Text = "温湿度测试仪";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.RoyalBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(281, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.修改设备ToolStripMenuItem,
            this.备注信息ToolStripMenuItem});
            this.设置ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // 修改设备ToolStripMenuItem
            // 
            this.修改设备ToolStripMenuItem.Name = "修改设备ToolStripMenuItem";
            this.修改设备ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.修改设备ToolStripMenuItem.Text = "修改设备";
            // 
            // 备注信息ToolStripMenuItem
            // 
            this.备注信息ToolStripMenuItem.Name = "备注信息ToolStripMenuItem";
            this.备注信息ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.备注信息ToolStripMenuItem.Text = "备注信息";
            // 
            // objectListView1
            // 
            this.objectListView1.CellEditUseWholeCell = false;
            this.objectListView1.Location = new System.Drawing.Point(0, 70);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.Size = new System.Drawing.Size(281, 273);
            this.objectListView1.TabIndex = 2;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 346);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "更新时间";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(62, 346);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "2017.12.13";
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(920, 580);
            this.ControlBox = false;
            this.Controls.Add(this.detail);
            this.Controls.Add(this.Panel);
            this.Controls.Add(this.deviceList);
            this.Controls.Add(this.listView2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(920, 580);
            this.Name = "Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.Color.LavenderBlush;
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
            ((System.ComponentModel.ISupportInitialize)(this.deviceList)).EndInit();
            this.detail.ResumeLayout(false);
            this.detail.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
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
        private BrightIdeasSoftware.OLVColumn olvColumnDesk;
        private BrightIdeasSoftware.ObjectListView deviceList;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Panel detail;
        private System.Windows.Forms.Label detailInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private BrightIdeasSoftware.ObjectListView objectListView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改设备ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 备注信息ToolStripMenuItem;
    }
}

