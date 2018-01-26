

using System.Data;
using System.Data.SQLite;
using XingYuTengFormsApp.Entity;

namespace XingYuTengFormsApp.Util.SQLiteUtil
{
    class WarningDao
    {
        private static WarningDao instance;
        private static readonly object obj = new object();


        public static WarningDao Instance
        {
            get
            {
                if (null == instance)
                {
                    lock (obj)
                    {
                        if (null == instance)
                        {
                            instance = new WarningDao();
                        }
                    }

                }
                return instance;
            }
        }

        /// <summary>
        /// 创建表
        /// </summary>
        public void CreateWarnningTable()
        {
            string sql = "CREATE TABLE IF NOT EXISTS Warning (id INT PRIMARY KEY NOT NULL,temperatureMax  VARCHAR(255)," +
                "temperatureMin VARCHAR(255),humidityMax VARCHAR(255),humidityMin VARCHAR(255));";
            SQLiteHelper.ExecuteNonQuery(SQLiteHelper.LocalDbConnectionString, sql, CommandType.Text);
        }

        public void Insert(Warning warning)
        {
            string sql = "INSERT OR REPLACE INTO Warning VALUES(" + warning.id+",'"+warning.temperatureMax+"','"+warning.temperatureMin+"','"+warning.humidityMax+"','"+warning.humidityMin+"');";
            SQLiteHelper.ExecuteNonQuery(SQLiteHelper.LocalDbConnectionString, sql, CommandType.Text);
        }

        public Warning GetWarningById(string deviceId)
        {
            Warning warning = null;
            string sql = "select * from " + AllConstant.WARNING_TABLE + " WHERE id = " + deviceId + ";";
            SQLiteDataReader dataReader = (SQLiteDataReader)SQLiteHelper.ExecuteReader(SQLiteHelper.LocalDbConnectionString, sql, CommandType.Text);
            while (dataReader.Read())
            {
                warning = new Warning();
                warning.id = dataReader["id"].ToString();
                warning.temperatureMax= dataReader["temperatureMax"].ToString();
                warning.temperatureMin = dataReader["temperatureMin"].ToString();
                warning.humidityMax = dataReader["humidityMax"].ToString();
                warning.humidityMin = dataReader["humidityMin"].ToString();
            }
            dataReader.Close();
            return warning;
        }

        public void Delete(string deviceId)
        {
            string sql = "DELETE FROM " + AllConstant.WARNING_TABLE + " WHERE id = " + deviceId;
            SQLiteHelper.ExecuteNonQuery(SQLiteHelper.LocalDbConnectionString, sql, CommandType.Text);
        }
    }
}
