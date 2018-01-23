using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XingYuTengFormsApp.Entity;
using XingYuTengFormsApp.Util.SQLiteUtil;

namespace XingYuTengFormsApp
{
    public partial class Form2 : System.Windows.Forms.Form, IUpdateDeviceResult
    {

        private DeviceData deviceData;
        private string oldTitle;
        private string oldDesc;
        public Form2(String deviceId)
        {
            InitializeComponent();

            deviceData = DeviceDataDao.Instance.GetDeviceDataById(deviceId);
        }

        public void OnFailure(string error)
        {
            MessageBox.Show(error);
        }

        public void OnSuccess(string item)
        {
            MessageBox.Show(item);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(title.Text) || !string.IsNullOrEmpty(desc.Text)) {
                string mTitle=null,mDesc=null;
                if (!string.IsNullOrEmpty(title.Text))
                {
                    if (string.IsNullOrEmpty(oldTitle)) {
                        mTitle = title.Text;
                    }
                    else
                    {
                        if (!title.Text.Equals(oldTitle))
                        {
                            mTitle = title.Text;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(desc.Text))
                {
                    if (string.IsNullOrEmpty(oldDesc))
                    {
                        mDesc = desc.Text;
                    }
                    else
                    {
                        if (!desc.Text.Equals(oldDesc))
                        {
                            mDesc = desc.Text;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(mTitle) || !string.IsNullOrEmpty(mDesc))
                {
                    NetWorkUtil.Instance.UpdateDevice(deviceData.id, mTitle, mDesc, this);
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label2.Text = deviceData.id;
            title.Text = deviceData.title;
            oldTitle = deviceData.title;
            desc.Text = deviceData.desc;
            oldDesc = deviceData.desc;
        }
    }

    interface IUpdateDeviceResult
    {
        void OnSuccess(string item);

        void OnFailure(string error);
    }
}
