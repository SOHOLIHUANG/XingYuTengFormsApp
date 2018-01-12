using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using XingYuTengFormsApp.Util;
using XingYuTengFormsApp.Util.SQLiteUtil;

namespace XingYuTengFormsApp
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            CreateOrUpdateDB();
            Application.Run(new Form());
        }

        /// <summary>
        /// 创建表
        /// </summary>
        private static void CreateOrUpdateDB()
        {
            DeviceDataDao.Instance.CreateDeviceTable();
        }
    }
}
