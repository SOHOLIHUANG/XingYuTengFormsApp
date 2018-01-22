using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
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

        /// <summary>
        /// 创建表
        /// </summary>
        public void CreateDeviceTable()
        {
            string sql = "CREATE TABLE IF NOT EXISTS DeviceData (auth_info VARCHAR(255),create_time VARCHAR(255),id INT PRIMARY KEY NOT NULL," +
                        "location  VARCHAR(255), online BOOLEAN, isPrivate BOOLEAN, protocol VARCHAR(255),title VARCHAR(255)," +
                        "[desc] VARCHAR(255),datastreams VARCHAR(255));";
            SQLiteHelper.ExecuteNonQuery(SQLiteHelper.LocalDbConnectionString,sql,CommandType.Text);
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="deviceData"></param>
        public void Insert(DeviceData deviceData)
        {
            string location = JsonHelper.SerializeObject(deviceData.location);
            string datastreams = JsonHelper.SerializeObject(deviceData.datastreams);
            string sql = "INSERT OR REPLACE INTO DeviceData VALUES('" + deviceData.auth_info+"','"+deviceData.create_time+"',"+deviceData.id+",'"+location+"','"
                +deviceData.online+"','"+deviceData.isPrivate+"','"+deviceData.protocol+"','"+deviceData.title+"','"+deviceData.desc+"','"+datastreams+"');";
            SQLiteHelper.ExecuteNonQuery(SQLiteHelper.LocalDbConnectionString, sql, CommandType.Text);
        }

        /// <summary>
        /// 获取表中所有信息
        /// </summary>
        /// <returns></returns>
        public List<DeviceData> GetAll()
        {
            List<DeviceData> deviceDataList = new List<DeviceData>();
            string sql = "select * from "+AllConstant.DEVICEDATA_TABLE+";";
            SQLiteDataReader dataReader =(SQLiteDataReader)SQLiteHelper.ExecuteReader(SQLiteHelper.LocalDbConnectionString, sql, CommandType.Text);
            while (dataReader.Read()) {
                DeviceData deviceData = new DeviceData();
                deviceData.auth_info = dataReader["auth_info"].ToString();
                deviceData.create_time = dataReader["create_time"].ToString();
                deviceData.id = dataReader["id"].ToString();
                string location = dataReader["location"].ToString();
                deviceData.location =(Location) JsonHelper.DeserializeJsonToObject<Location>(location);
                deviceData.online = bool.Parse(dataReader["online"].ToString());
                deviceData.isPrivate= bool.Parse(dataReader["isPrivate"].ToString());
                deviceData.protocol = dataReader["protocol"].ToString();
                deviceData.title = dataReader["title"].ToString();
                deviceData.desc = dataReader["desc"].ToString();
                string datastreams = dataReader["datastreams"].ToString();
                deviceData.datastreams = JsonHelper.DeserializeJsonToList<DeviceDataStreams>(datastreams);
                deviceDataList.Add(deviceData);
            }
            dataReader.Close();
            return deviceDataList;
        }

        /// <summary>
        /// 判断该id的设备是否存在
        /// </summary>
        /// <returns></returns>
        public bool HasId(string id)
        {
            bool hasId = false;
            string sql = "select * from " + AllConstant.DEVICEDATA_TABLE + " WHERE id ="+id+";";
            SQLiteDataReader dataReader = (SQLiteDataReader)SQLiteHelper.ExecuteReader(SQLiteHelper.LocalDbConnectionString, sql, CommandType.Text);
            hasId = dataReader.HasRows;
            dataReader.Close();
            return hasId;
        }

        public void Delete(string deviceId)
        {
            string sql = "DELETE FROM "+AllConstant.DEVICEDATA_TABLE+" WHERE id = "+deviceId;
            SQLiteHelper.ExecuteNonQuery(SQLiteHelper.LocalDbConnectionString, sql, CommandType.Text);
        }
    }
}
