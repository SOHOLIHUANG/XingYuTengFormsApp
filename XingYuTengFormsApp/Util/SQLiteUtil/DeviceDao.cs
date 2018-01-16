using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XingYuTengFormsApp.Entity;

namespace XingYuTengFormsApp.Util.SQLiteUtil
{
    public class DeviceDataDao
    {
        private static DeviceDataDao instance;
        private static readonly object obj = new object();


        public static DeviceDataDao Instance
        {
            get
            {
                if (null == instance)
                {
                    lock (obj)
                    {
                        if (null == instance)
                        {
                            instance = new DeviceDataDao();
                        }
                    }

                }
                return instance;
            }
        }

        public void CreateDeviceTable()
        {
            string sql = "CREATE TABLE IF NOT EXISTS DeviceData (auth_info VARCHAR(255),create_time VARCHAR(255),id INT PRIMARY KEY NOT NULL," +
                        "location  VARCHAR(255), online BOOLEAN, isPrivate BOOLEAN, protocol VARCHAR(255),title VARCHAR(255)," +
                        "[desc] VARCHAR(255),datastreams VARCHAR(255));";
            SQLiteHelper.ExecuteNonQuery(SQLiteHelper.LocalDbConnectionString,sql,CommandType.Text);
        }

        public void Insert(DeviceData deviceData)
        {
            string location = JsonHelper.SerializeObject(deviceData.location);
            string datastreams = JsonHelper.SerializeObject(deviceData.datastreams);
            string sql = "INSERT OR REPLACE INTO DeviceData VALUES('" + deviceData.auth_info+"','"+deviceData.create_time+"',"+deviceData.id+",'"+location+"','"
                +deviceData.online+"','"+deviceData.isPrivate+"','"+deviceData.protocol+"','"+deviceData.title+"','"+deviceData.desc+"','"+datastreams+"');";
            SQLiteHelper.ExecuteNonQuery(SQLiteHelper.LocalDbConnectionString, sql, CommandType.Text);

        }
    }
}
