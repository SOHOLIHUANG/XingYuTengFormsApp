using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XingYuTengFormsApp.Util
{
    public class Utils
    {
        /// <summary>
        /// 获取路径,该路径为源码根路径
        /// </summary>
        /// <returns></returns>
        public static string GetPath()
        {
            return Application.StartupPath.Substring(0, Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf("\\")).LastIndexOf("\\")); ;
        }
    }
}
