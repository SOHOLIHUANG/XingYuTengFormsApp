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
    public partial class Form3 : System.Windows.Forms.Form
    {
        private DeviceData deviceData;
        private Form form;
        public Form3(String deviceId, Form form1)
        {
            InitializeComponent();
            form = form1;
            deviceData = DeviceDataDao.Instance.GetDeviceDataById(deviceId);
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
        }
    }
}
