using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BrightIdeasSoftware;
using XingYuTengFormsApp.Entity;
using XingYuTengFormsApp.Util.SQLiteUtil;

namespace XingYuTengFormsApp
{
    public partial class Form3 : System.Windows.Forms.Form
    {
        private string id;
        private Form form;
        private RemarksID remarks;
        private List<RemarksID> list;
        public Form3(String deviceId, Form form1)
        {
            InitializeComponent();
            form = form1;
            id = deviceId;
            this.propertyList.FormatCell += propertyList_FormatCell;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            labelId.Text = id;
            list = RemarksDao.Instance.GetAll(id);
            if (list != null && list.Count > 0)
            {
                propertyList.SetObjects(list);
            }

            this.propertyList.SelectionChanged += delegate (object listSender, EventArgs args)
            {
                HandleSelectionChanged(propertyList);
            };
        }

        private void HandleSelectionChanged(ObjectListView propertyList)
        {
            if (propertyList.SelectedObject is RemarksID remarksID)
            {
                property.Text = remarksID.typeId;
                remark.Text = remarksID.remarks;
                remarks = remarksID;
                if (string.IsNullOrEmpty(remarks.A) && string.IsNullOrEmpty(remarks.B) && string.IsNullOrEmpty(remarks.G) && string.IsNullOrEmpty(remarks.R))
                {
                    pictureBox1.BackColor = Color.Black;
                }
                else
                {
                    pictureBox1.BackColor = Color.FromArgb(int.Parse(remarks.A), int.Parse(remarks.R),
                    int.Parse(remarks.G), int.Parse(remarks.B));
                    
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            pictureBox1.BackColor = colorDialog.Color;
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            if (remarks == null)
            {
                MessageBox.Show("您还未选择属性");
            }
            else
            {
                remarks.A = pictureBox1.BackColor.A.ToString();
                remarks.R = pictureBox1.BackColor.R.ToString();
                remarks.G = pictureBox1.BackColor.G.ToString();
                remarks.B = pictureBox1.BackColor.B.ToString();
                remarks.remarks = remark.Text;
                RemarksDao.Instance.Update(remarks);
                propertyList.SetObjects(list);
                form.UpdateList(remarks.id,remarks.deviceId,remarks.typeId);
                MessageBox.Show("修改成功");
            }
        }

        private void propertyList_FormatCell(object sender, FormatCellEventArgs e)
        {
            RemarksID remarksID = (RemarksID)e.Model;
            if(string.IsNullOrEmpty(remarksID.A)&& string.IsNullOrEmpty(remarksID.R)&& string.IsNullOrEmpty(remarksID.G)&& string.IsNullOrEmpty(remarksID.B))
            {
                e.SubItem.ForeColor = Color.Black;
            }
            else
            {
                e.SubItem.ForeColor = Color.FromArgb(int.Parse(remarksID.A), int.Parse(remarksID.R), int.Parse(remarksID.G), int.Parse(remarksID.B));
            }
        }
    }
}
