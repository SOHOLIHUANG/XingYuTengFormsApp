﻿namespace XingYuTengFormsApp
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
            this.listView2 = new System.Windows.Forms.ListView();
            this.deviceList = new BrightIdeasSoftware.ObjectListView();
            this.olvColumnDesk = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panel = new System.Windows.Forms.Panel();
            this.pictureBoxClose = new System.Windows.Forms.PictureBox();
            this.pictureBoxSize = new System.Windows.Forms.PictureBox();
            this.pictureBoxSmall = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.deviceID = new System.Windows.Forms.TextBox();
            this.labelAdd = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.deviceList)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSmall)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // listView2
            // 
            this.listView2.BackColor = System.Drawing.Color.White;
            this.listView2.Location = new System.Drawing.Point(371, 102);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(907, 625);
            this.listView2.TabIndex = 1;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DeviceList_MouseDown);
            this.listView2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ListView_MouseMove);
            // 
            // deviceList
            // 
            this.deviceList.AllColumns.Add(this.olvColumnDesk);
            this.deviceList.AllowColumnReorder = true;
            this.deviceList.AllowDrop = true;
            this.deviceList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deviceList.CellEditUseWholeCell = false;
            this.deviceList.CheckBoxes = true;
            this.deviceList.CheckedAspectName = "";
            this.deviceList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnDesk});
            this.deviceList.Cursor = System.Windows.Forms.Cursors.Default;
            this.deviceList.FullRowSelect = true;
            this.deviceList.HeaderWordWrap = true;
            this.deviceList.HideSelection = false;
            this.deviceList.IncludeColumnHeadersInCopy = true;
            this.deviceList.Location = new System.Drawing.Point(-2, 102);
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
            this.deviceList.Size = new System.Drawing.Size(377, 625);
            this.deviceList.SortGroupItemsByPrimaryColumn = false;
            this.deviceList.TabIndex = 2;
            this.deviceList.TriStateCheckBoxes = true;
            this.deviceList.UseAlternatingBackColors = true;
            this.deviceList.UseCellFormatEvents = true;
            this.deviceList.UseCompatibleStateImageBehavior = false;
            this.deviceList.UseFilterIndicator = true;
            this.deviceList.UseFiltering = true;
            this.deviceList.UseHotItem = true;
            this.deviceList.View = System.Windows.Forms.View.Details;
            this.deviceList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DeviceList_MouseDown);
            this.deviceList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DeviceList_MouseMove);
            // 
            // olvColumnDesk
            // 
            this.olvColumnDesk.AspectName = "设备列表";
            this.olvColumnDesk.MinimumWidth = 40;
            this.olvColumnDesk.Text = "设备列表";
            this.olvColumnDesk.ToolTipText = "";
            this.olvColumnDesk.Width = 325;
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel.Controls.Add(this.pictureBoxClose);
            this.panel.Controls.Add(this.pictureBoxSize);
            this.panel.Controls.Add(this.pictureBoxSmall);
            this.panel.Controls.Add(this.panel1);
            this.panel.Controls.Add(this.label);
            this.panel.Controls.Add(this.pictureBox);
            this.panel.Location = new System.Drawing.Point(-2, -1);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1280, 104);
            this.panel.TabIndex = 3;
            this.panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            // 
            // pictureBoxClose
            // 
            this.pictureBoxClose.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxClose.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxClose.Image")));
            this.pictureBoxClose.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxClose.InitialImage")));
            this.pictureBoxClose.Location = new System.Drawing.Point(1216, 43);
            this.pictureBoxClose.Name = "pictureBoxClose";
            this.pictureBoxClose.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxClose.TabIndex = 5;
            this.pictureBoxClose.TabStop = false;
            this.pictureBoxClose.Click += new System.EventHandler(this.pictureBoxClose_Click);
            // 
            // pictureBoxSize
            // 
            this.pictureBoxSize.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxSize.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxSize.Image")));
            this.pictureBoxSize.Location = new System.Drawing.Point(1166, 40);
            this.pictureBoxSize.Name = "pictureBoxSize";
            this.pictureBoxSize.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxSize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxSize.TabIndex = 4;
            this.pictureBoxSize.TabStop = false;
            this.pictureBoxSize.Click += new System.EventHandler(this.pictureBoxLagest_Click);
            // 
            // pictureBoxSmall
            // 
            this.pictureBoxSmall.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxSmall.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxSmall.Image")));
            this.pictureBoxSmall.Location = new System.Drawing.Point(1113, 40);
            this.pictureBoxSmall.Name = "pictureBoxSmall";
            this.pictureBoxSmall.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxSmall.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxSmall.TabIndex = 3;
            this.pictureBoxSmall.TabStop = false;
            this.pictureBoxSmall.Click += new System.EventHandler(this.pictureBoxSmall_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.deviceID);
            this.panel1.Controls.Add(this.labelAdd);
            this.panel1.Location = new System.Drawing.Point(399, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(427, 30);
            this.panel1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(390, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // deviceID
            // 
            this.deviceID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.deviceID.Font = new System.Drawing.Font("宋体", 15F);
            this.deviceID.Location = new System.Drawing.Point(95, 4);
            this.deviceID.Name = "deviceID";
            this.deviceID.Size = new System.Drawing.Size(279, 23);
            this.deviceID.TabIndex = 1;
            // 
            // labelAdd
            // 
            this.labelAdd.AutoSize = true;
            this.labelAdd.Font = new System.Drawing.Font("宋体", 15F);
            this.labelAdd.Location = new System.Drawing.Point(0, 5);
            this.labelAdd.Name = "labelAdd";
            this.labelAdd.Size = new System.Drawing.Size(89, 20);
            this.labelAdd.TabIndex = 0;
            this.labelAdd.Text = "添加设备";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("宋体", 15F);
            this.label.ForeColor = System.Drawing.Color.White;
            this.label.Location = new System.Drawing.Point(82, 43);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(109, 20);
            this.label.TabIndex = 1;
            this.label.Text = "兴宇腾测控";
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
            this.pictureBox.InitialImage = null;
            this.pictureBox.Location = new System.Drawing.Point(23, 31);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(42, 42);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1277, 723);
            this.ControlBox = false;
            this.Controls.Add(this.panel);
            this.Controls.Add(this.deviceList);
            this.Controls.Add(this.listView2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1277, 723);
            this.Name = "Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.Color.White;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DoubleClick += new System.EventHandler(this.Form1_DoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.deviceList)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSmall)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView listView2;
        private BrightIdeasSoftware.ObjectListView deviceList;
        private BrightIdeasSoftware.OLVColumn olvColumnDesk;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelAdd;
        private System.Windows.Forms.TextBox deviceID;
        private System.Windows.Forms.PictureBox pictureBoxClose;
        private System.Windows.Forms.PictureBox pictureBoxSize;
        private System.Windows.Forms.PictureBox pictureBoxSmall;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

