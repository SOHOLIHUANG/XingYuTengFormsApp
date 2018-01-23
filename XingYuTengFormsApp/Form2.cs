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
    public partial class Form2 : System.Windows.Forms.Form
    {
        
        public static Form2 SingleForm = null;

        private string Id;
        public Form2(String deviceId)
        {
            InitializeComponent();

            Id = deviceId;
        }

        public static Form2 GetSingle(String deviceId)
        {
            if (SingleForm == null || SingleForm.IsDisposed)
            {
                SingleForm = new Form2(deviceId);
            }
            return SingleForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label2.Text = Id;
            DeviceData deviceData=DeviceDataDao.Instance.GetDeviceDataById(Id);
            textBox1.Text = deviceData.title;
            richTextBox1.Text = deviceData.desc;
        }
    }
}
