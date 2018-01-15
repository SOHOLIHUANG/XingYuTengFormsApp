using System;
using System.Collections.Generic;
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
            SQLiteHelper.Instance.CreateTable(AllConstant.DEVICEDATA_TABLE,
                new string[] { "auth_info", "create_time", "id", "location", "online", "isPrivate", "protocol", "title", "desc",
                    "datastreams" },
                new string[] { "VARCHAR(255)", "VARCHAR(255)", "INT PRIMARY KEY NOT NULL", " VARCHAR(255)", "BOOLEAN", "BOOLEAN",
                    " VARCHAR(255)", "VARCHAR(255)", "VARCHAR(255)", "VARCHAR(255)" });
        }

        public void Insert(DeviceData deviceData)
        {
            string location = JsonHelper.SerializeObject(deviceData.location);
            string datastreams = JsonHelper.SerializeObject(deviceData.datastreams);

            if (SQLiteHelper.Instance.HasRow(AllConstant.DEVICEDATA_TABLE, deviceData.id)) {

                SQLiteHelper.Instance.DeleteValuesOR(AllConstant.DEVICEDATA_TABLE, new string[] { "id" }, new string[] { deviceData.id }, new string[] { "=" });
                

                SQLiteHelper.Instance.InsertValues(AllConstant.DEVICEDATA_TABLE, new string[] {deviceData.auth_info,
                deviceData.create_time,deviceData.id,location,deviceData.online.ToString(),deviceData.isPrivate.ToString(),
                deviceData.protocol,deviceData.title,deviceData.desc,datastreams});
            } else
            {
                
                SQLiteHelper.Instance.InsertValues(AllConstant.DEVICEDATA_TABLE, new string[] {deviceData.auth_info,
                deviceData.create_time,deviceData.id,location,deviceData.online.ToString(),deviceData.isPrivate.ToString(),
                deviceData.protocol,deviceData.title,deviceData.desc,datastreams});
            }
            
            
        }
    }
}
