using System;
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
        private string oldTMax, oldTMin, oldHMax, oldHMin;
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

            if (!string.IsNullOrEmpty(tMax.Text) || !string.IsNullOrEmpty(tMin.Text) ||
                !string.IsNullOrEmpty(hMax.Text) || !string.IsNullOrEmpty(hMin.Text)) {
                string mTMax = null, mTMin = null,mHMax=null,mHMin=null;
                if (!string.IsNullOrEmpty(tMax.Text)) {
                    if (string.IsNullOrEmpty(oldTMax)) {
                        mTMax = tMax.Text;
                    } else
                    {
                        if (!oldTMax.Equals(tMax.Text))
                        {
                            mTMax = tMax.Text;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(tMin.Text))
                {
                    if (string.IsNullOrEmpty(oldTMin))
                    {
                        mTMin = tMin.Text;
                    }
                    else
                    {
                        if (!oldTMin.Equals(tMin.Text))
                        {
                            mTMin = tMin.Text;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(hMax.Text))
                {
                    if (string.IsNullOrEmpty(oldHMax))
                    {
                        mHMax = hMax.Text;
                    }
                    else
                    {
                        if (!oldHMax.Equals(hMax.Text))
                        {
                            mHMax = hMax.Text;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(hMin.Text))
                {
                    if (string.IsNullOrEmpty(oldHMin))
                    {
                        mHMin = hMin.Text;
                    }
                    else
                    {
                        if (!oldHMin.Equals(hMin.Text))
                        {
                            mHMin = hMin.Text;
                        }
                    }
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
            Warning warning=WarningDao.Instance.GetWarningById(deviceData.id);
            if (warning != null)
            {
                tMax.Text = warning.temperatureMax;
                oldTMax = warning.temperatureMax;
                tMin.Text = warning.temperatureMin;
                oldTMin = warning.temperatureMin;
                hMax.Text = warning.humidityMax;
                oldHMax = warning.humidityMax;
                hMin.Text = warning.humidityMin;
                oldHMin = warning.humidityMin;
            }
        }
    }

    interface IUpdateDeviceResult
    {
        void OnSuccess(string item);

        void OnFailure(string error);
    }
}
