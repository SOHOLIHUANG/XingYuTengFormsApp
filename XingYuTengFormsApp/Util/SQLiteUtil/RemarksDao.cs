
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;
using XingYuTengFormsApp.Entity;

namespace XingYuTengFormsApp.Util.SQLiteUtil
{
    class RemarksDao
    {
        private static RemarksDao instance;
        private static readonly object obj = new object();


        public static RemarksDao Instance
        {
            get
            {
                if (null == instance)
                {
                    lock (obj)
                    {
                        if (null == instance)
                        {
                            instance = new RemarksDao();
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
            string sql = "CREATE TABLE IF NOT EXISTS Remarks (id VARCHAR(255) PRIMARY KEY NOT NULL,deviceId VARCHAR(255)," +
                "typeId VARCHAR(255),remarks VARCHAR(255),A VARCHAR(255),R VARCHAR(255),G VARCHAR(255), B VARCHAR(255));";
            SQLiteHelper.Instance.ExecuteNonQuery(sql, CommandType.Text);
        }

        public void Insert(DeviceData deviceData)
        {
            foreach (DeviceDataStreams streams in deviceData.datastreams) {
                string sql = "INSERT OR REPLACE INTO Remarks(id,deviceId,typeId) VALUES('"+deviceData.id+streams.id+"','"+deviceData.id+"','"+streams.id+"');";
                SQLiteHelper.Instance.ExecuteNonQuery(sql, CommandType.Text);
            }
        }

        public RemarksID GetDeviceDataById(string Id)
        {
            RemarksID remarksId = null;
            string sql = "select * from " + AllConstant.REMARKS_TABLE + " WHERE id = '" + Id + "';";
            SQLiteDataReader dataReader = (SQLiteDataReader)SQLiteHelper.Instance.ExecuteReader(sql, CommandType.Text);
            while (dataReader.Read())
            {
                remarksId = new RemarksID();
                remarksId.id = dataReader["id"].ToString();
                remarksId.deviceId = dataReader["deviceId"].ToString();
                remarksId.typeId = dataReader["typeId"].ToString();
                remarksId.remarks = dataReader["remarks"].ToString();
                remarksId.A = dataReader["A"].ToString();
                remarksId.R = dataReader["R"].ToString();
                remarksId.G = dataReader["G"].ToString();
                remarksId.B = dataReader["B"].ToString();

            }
            dataReader.Close();
            return remarksId;
        }

        public List<RemarksID> GetAll(string deviceId)
        {
            List<RemarksID> remarksIdList = new List<RemarksID>();
            string sql = "select * from " + AllConstant.REMARKS_TABLE +" WHERE deviceId = "+deviceId+";";
            SQLiteDataReader dataReader = (SQLiteDataReader)SQLiteHelper.Instance.ExecuteReader(sql, CommandType.Text);
            while (dataReader.Read())
            {
                RemarksID remarksId = new RemarksID();
                remarksId.id = dataReader["id"].ToString();
                remarksId.deviceId = dataReader["deviceId"].ToString();
                remarksId.typeId = dataReader["typeId"].ToString();
                remarksId.remarks = dataReader["remarks"].ToString();
                remarksId.A = dataReader["A"].ToString();
                remarksId.R = dataReader["R"].ToString();
                remarksId.G = dataReader["G"].ToString();
                remarksId.B = dataReader["B"].ToString();
                remarksIdList.Add(remarksId);
            }
            dataReader.Close();
            return remarksIdList;
        }

        public void Update(RemarksID remarksID)
        {
            StringBuilder builder = new StringBuilder("UPDATE " + AllConstant.REMARKS_TABLE + " SET ");
            if (!string.IsNullOrEmpty(remarksID.remarks)) {
                builder.Append("remarks = '" + remarksID.remarks + "',");
            }

            if (!string.IsNullOrEmpty(remarksID.A))
            {
                builder.Append("A = '" + remarksID.A+ "',");
            }

            if (!string.IsNullOrEmpty(remarksID.R))
            {
                builder.Append("R = '" + remarksID.R + "',");
            }

            if (!string.IsNullOrEmpty(remarksID.G))
            {
                builder.Append("G = '" + remarksID.G + "',");
            }

            if (!string.IsNullOrEmpty(remarksID.B))
            {
                builder.Append("B = '" + remarksID.B + "'");
            }
            builder.Append(" WHERE id = '" + remarksID.id + "'");
            SQLiteHelper.Instance.ExecuteNonQuery(builder.ToString(), CommandType.Text);
        }

        public void Delete(string deviceId)
        {
            string sql = "DELETE FROM " + AllConstant.REMARKS_TABLE + " WHERE deviceId = " + deviceId;
            SQLiteHelper.Instance.ExecuteNonQuery(sql, CommandType.Text);
        }
    }
}
