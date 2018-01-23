using System;
using System.Text.RegularExpressions;
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
        private Warning warning;
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

            if (warning == null)
            {
                warning = new Warning();
                warning.id = deviceData.id;
            }

            if (!string.IsNullOrEmpty(tMax.Text))
            {
                if (Regex.IsMatch(tMax.Text, AllConstant.IS_TEMP))
                {
                    warning.temperatureMax = tMax.Text;
                }
                else
                {
                    MessageBox.Show("请输入最多两位小数的数字");
                    return;
                }
            }

            if (!string.IsNullOrEmpty(tMin.Text))
            {
                if (Regex.IsMatch(tMin.Text, AllConstant.IS_TEMP))
                {
                    warning.temperatureMin = tMin.Text;
                }
                else
                {
                    MessageBox.Show("请输入最多两位小数的数字");
                    return;
                }
            }

            if(!string.IsNullOrEmpty(tMin.Text)&& !string.IsNullOrEmpty(tMax.Text))
            {
                if (double.Parse(tMin.Text)>double.Parse(tMax.Text))
                {
                    MessageBox.Show("温度最小值不能大于最大值");
                    return;
                }
            }

            if (!string.IsNullOrEmpty(hMax.Text))
            {
                if (Regex.IsMatch(hMax.Text, AllConstant.IS_HUM))
                {
                    if (double.Parse(hMax.Text) > 100)
                    {
                        MessageBox.Show("湿度警戒值不能大于100");
                        return;
                    }
                    else
                    {
                        warning.humidityMax = hMax.Text;
                    }
                }
                else
                {
                    MessageBox.Show("请输入0-100之间的数字");
                }
            }

            if (!string.IsNullOrEmpty(hMin.Text))
            {
                if (Regex.IsMatch(hMin.Text, AllConstant.IS_HUM))
                {
                    if (double.Parse(hMin.Text) > 100)
                    {
                        MessageBox.Show("湿度值在0-100之间");
                        return;
                    }
                    else
                    {
                        warning.humidityMin = hMin.Text;
                    }
                }
                else
                {
                    MessageBox.Show("湿度值在0-100之间");
                }
            }

            if(!string.IsNullOrEmpty(hMin.Text)&& !string.IsNullOrEmpty(hMax.Text))
            {
                if (double.Parse(hMin.Text) > double.Parse(hMax.Text))
                {
                    MessageBox.Show("湿度最小值不能大于湿度最大值");
                    return;
                }
            }

            WarningDao.Instance.Insert(warning);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label2.Text = deviceData.id;
            title.Text = deviceData.title;
            oldTitle = deviceData.title;
            desc.Text = deviceData.desc;
            oldDesc = deviceData.desc;
            warning=WarningDao.Instance.GetWarningById(deviceData.id);
            if (warning != null)
            {
                tMax.Text = warning.temperatureMax;
                tMin.Text = warning.temperatureMin;
                hMax.Text = warning.humidityMax;
                hMin.Text = warning.humidityMin;
            }
        }
    }

    interface IUpdateDeviceResult
    {
        void OnSuccess(string item);

        void OnFailure(string error);
    }
}
