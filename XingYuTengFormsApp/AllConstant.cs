using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XingYuTengFormsApp
{
    class AllConstant
    {
        public static string panel = "detail";//动态显示的容器

        /// <summary>
        /// 以下为数据库常量
        /// </summary>
        public static string DB = "db_xingyuteng";//数据库名
        public static string DEVICEDATA_TABLE = "DeviceData";//表名
        public static string WARNING_TABLE = "Warning";//表名
        public static string REMARKS_TABLE = "Remarks";//表名
        public static string POINTS = "500";//首次绘制图表获取的点数
        public static string IS_TEMP = @"^(\-)?\d+(\.\d{1,2})?$";//报警值是否符合温度输入规定
        public static string IS_HUM = @"^\d+(\.\d+)?$";//报警值是否符合湿度输入规定
    }
}
