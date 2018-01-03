namespace XingYuTengFormsApp
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listView2 = new System.Windows.Forms.ListView();
            this.deviceList = new BrightIdeasSoftware.ObjectListView();
            this.olvColumnDesk = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.deviceList)).BeginInit();
            this.SuspendLayout();
            // 
            // listView2
            // 
            this.listView2.Location = new System.Drawing.Point(313, 12);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(936, 683);
            this.listView2.TabIndex = 1;
            this.listView2.UseCompatibleStateImageBehavior = false;
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
            this.deviceList.Location = new System.Drawing.Point(12, 12);
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
            this.deviceList.Size = new System.Drawing.Size(295, 683);
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
            // 
            // olvColumnDesk
            // 
            this.olvColumnDesk.AspectName = "设备列表";
            this.olvColumnDesk.MinimumWidth = 40;
            this.olvColumnDesk.Text = "设备列表";
            this.olvColumnDesk.ToolTipText = "";
            this.olvColumnDesk.Width = 292;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 707);
            this.Controls.Add(this.deviceList);
            this.Controls.Add(this.listView2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XingYuTeng";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.deviceList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView listView2;
        private BrightIdeasSoftware.ObjectListView deviceList;
        private BrightIdeasSoftware.OLVColumn olvColumnDesk;
    }
}

