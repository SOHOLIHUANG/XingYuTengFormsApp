using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XingYuTengFormsApp.Entity;

namespace XingYuTengFormsApp.Util.SQLiteUtil
{
    public class DeviceDataSql
    {
        public static void CreateDeviceTable()
        {
            string sql = "CREATE TABLE DeviceData(auth_info VARCHAR(255),create_time VARCHAR(255),id INT PRIMARY KEY NOT NULL," +
                "location VARCHAR(255),online BOOLEAN,isPrivate BOOLEAN,protocol VARCHAR(255),title VARCHAR(255),desc VARCHAR(255)," +
                "datastreams VARCHAR(255))";
            SQLiteHelper.Instance.Open().ExecuteNonQuery(sql, null);
            SQLiteHelper.Instance.Close();
        }

        public static void Insert(DeviceData deviceData) {
            string location = JsonHelper.SerializeObject(deviceData.location);
            string datastreams = JsonHelper.SerializeObject(deviceData.datastreams);
            string sql = "INSERT INTO DeviceData ("+deviceData.auth_info+","+deviceData.create_time+","+deviceData.id+","+location+","+
                deviceData.online+","+deviceData.isPrivate+","+deviceData.protocol+","+deviceData.title+","+deviceData.desc+","+datastreams+")";
            //SQLiteHelper.Instance.Open().ExecuteNonQuery(sql, null);
            //SQLiteHelper.Instance.Close();
        }
    }
}
