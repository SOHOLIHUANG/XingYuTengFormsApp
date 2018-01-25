namespace XingYuTengFormsApp
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.deviceId = new System.Windows.Forms.Label();
            this.propertyList = new BrightIdeasSoftware.ObjectListView();
            this.columnName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.columnValue = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.label3 = new System.Windows.Forms.Label();
            this.remark = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.confirm = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.property = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.propertyList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "设备ID";
            // 
            // deviceId
            // 
            this.deviceId.Location = new System.Drawing.Point(0, 0);
            this.deviceId.Name = "deviceId";
            this.deviceId.Size = new System.Drawing.Size(100, 23);
            this.deviceId.TabIndex = 32;
            // 
            // propertyList
            // 
            this.propertyList.AllColumns.Add(this.columnName);
            this.propertyList.AllColumns.Add(this.columnValue);
            this.propertyList.AllowColumnReorder = true;
            this.propertyList.AllowDrop = true;
            this.propertyList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyList.CellEditUseWholeCell = false;
            this.propertyList.CheckedAspectName = "";
            this.propertyList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnValue});
            this.propertyList.Cursor = System.Windows.Forms.Cursors.Default;
            this.propertyList.FullRowSelect = true;
            this.propertyList.HeaderWordWrap = true;
            this.propertyList.HideSelection = false;
            this.propertyList.IncludeColumnHeadersInCopy = true;
            this.propertyList.Location = new System.Drawing.Point(14, 26);
            this.propertyList.Name = "propertyList";
            this.propertyList.OverlayText.Alignment = System.Drawing.ContentAlignment.BottomLeft;
            this.propertyList.OverlayText.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.propertyList.OverlayText.BorderWidth = 2F;
            this.propertyList.OverlayText.Rotation = -20;
            this.propertyList.OverlayText.Text = "";
            this.propertyList.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu;
            this.propertyList.ShowCommandMenuOnRightClick = true;
            this.propertyList.ShowGroups = false;
            this.propertyList.ShowHeaderInAllViews = false;
            this.propertyList.ShowItemToolTips = true;
            this.propertyList.Size = new System.Drawing.Size(300, 503);
            this.propertyList.SortGroupItemsByPrimaryColumn = false;
            this.propertyList.TabIndex = 30;
            this.propertyList.UseAlternatingBackColors = true;
            this.propertyList.UseCellFormatEvents = true;
            this.propertyList.UseCompatibleStateImageBehavior = false;
            this.propertyList.UseFilterIndicator = true;
            this.propertyList.UseFiltering = true;
            this.propertyList.UseHotItem = true;
            this.propertyList.View = System.Windows.Forms.View.Details;
            // 
            // columnName
            // 
            this.columnName.AspectName = "typeId";
            this.columnName.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnName.MaximumWidth = 200;
            this.columnName.MinimumWidth = 100;
            this.columnName.Text = "测量属性";
            this.columnName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnName.ToolTipText = "This is a long tooltip text that should appear when the mouse is over this column" +
    " header but contains absolutely no useful information :)";
            this.columnName.UseInitialLetterForGroup = true;
            this.columnName.Width = 150;
            // 
            // columnValue
            // 
            this.columnValue.AspectName = "remarks";
            this.columnValue.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnValue.Hyperlink = true;
            this.columnValue.MaximumWidth = 180;
            this.columnValue.MinimumWidth = 50;
            this.columnValue.Text = "备注信息";
            this.columnValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnValue.Width = 150;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(425, 386);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "备注信息";
            // 
            // remark
            // 
            this.remark.Location = new System.Drawing.Point(542, 385);
            this.remark.Name = "remark";
            this.remark.Size = new System.Drawing.Size(258, 21);
            this.remark.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(562, 133);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(159, 137);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // confirm
            // 
            this.confirm.Location = new System.Drawing.Point(799, 492);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(75, 23);
            this.confirm.TabIndex = 6;
            this.confirm.Text = "确定";
            this.confirm.UseVisualStyleBackColor = true;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(596, 273);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "点击上图选择色彩";
            // 
            // property
            // 
            this.property.BackColor = System.Drawing.SystemColors.Control;
            this.property.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.property.Enabled = false;
            this.property.Font = new System.Drawing.Font("宋体", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.property.ForeColor = System.Drawing.SystemColors.WindowText;
            this.property.Location = new System.Drawing.Point(386, 26);
            this.property.Name = "property";
            this.property.Size = new System.Drawing.Size(506, 39);
            this.property.TabIndex = 31;
            this.property.Text = "请在左边列表中选择要备注的属性";
            this.property.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 33;
            this.label2.Text = "设备ID";
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(82, 11);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(47, 12);
            this.labelId.TabIndex = 34;
            this.labelId.Text = "4656512";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(904, 541);
            this.Controls.Add(this.labelId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.property);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.remark);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.propertyList);
            this.Controls.Add(this.deviceId);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "修改备注信息";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.propertyList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label deviceId;
        private BrightIdeasSoftware.ObjectListView propertyList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox remark;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.Label label4;
        private BrightIdeasSoftware.OLVColumn columnName;
        private BrightIdeasSoftware.OLVColumn columnValue;
        private System.Windows.Forms.TextBox property;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelId;
    }
}