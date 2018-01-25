using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XingYuTengFormsApp.Entity;
using XingYuTengFormsApp.Util;
using XingYuTengFormsApp.Util.SQLiteUtil;

namespace XingYuTengFormsApp
{
    sealed class NetWorkUtil
    {
        private RestClient client;
        private static NetWorkUtil instance;
        private static readonly object obj = new object();
        public const string URL="http://api.heclouds.com/";

        public static NetWorkUtil Instance
        {
            get
            {
                if (null == instance)
                {
                    lock (obj)
                    {
                        if (null == instance)
                        {
                            instance = new NetWorkUtil();
                        }
                    }

                }
                return instance;
            }
        }

        private NetWorkUtil()
        {
            client = new RestClient(URL);
        }

        /// <summary>
        /// 添加设备
        /// </summary>
        /// <param name="device_id"></param>
        /// <param name="result"></param>
        public void AddDevice(string device_id,INetworkResult result) {

            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("devices/{device_id}", Method.GET);
            request.AddUrlSegment("device_id", device_id); // replaces matching token in request.Resource

            // add parameters for all properties on an object
            //request.AddObject(object);

            // or just whitelisted properties
            //request.AddObject(object, "PersonId", "Name", ...);

            // easily add HTTP Headers
            request.AddHeader("api-key", "VtaeS4yK3Fk6xiOljgw69lYcH9k=");

            IRestResponse response = client.Execute(request);
            var content = response.Content; // raw content as string
            if (response.IsSuccessful) {
                Device device=JsonHelper.DeserializeJsonToObject<Device>(content);
                if (device.error.Equals("succ"))
                {
                    DeviceDataDao.Instance.Insert(device.data);
                    RemarksDao.Instance.Insert(device.data);
                    GetDataPoints(device.data, result, null, AllConstant.POINTS, null, null, null, null);
                }
                else {
                    result.OnFailure(device.error);
                }
                
            } else {
                result.OnFailure("获取设备信息失败");
            }
        }

        /// <summary>
        /// 更新设备信息
        /// </summary>
        /// <param name="device_id"></param>
        /// <param name="result"></param>
        public void UpdateDevice(string device_id,string title,string desc, IUpdateDeviceResult result)
        {

            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("devices/{device_id}", Method.PUT);
            request.AddUrlSegment("device_id", device_id); // replaces matching token in request.Resource

            // add parameters for all properties on an object
            //request.AddObject(object);

            // or just whitelisted properties
            //request.AddObject(object, "PersonId", "Name", ...);

            // easily add HTTP Headers
            request.AddHeader("api-key", "VtaeS4yK3Fk6xiOljgw69lYcH9k=");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            string[] keys = null;
            string[] values = null;
            if (!string.IsNullOrEmpty(title)&& !string.IsNullOrEmpty(desc))
            {
                UpdateDevice updateDevice = new Entity.UpdateDevice();
                updateDevice.title = title;
                updateDevice.desc = desc;
                keys= new string[] {"title","desc"};
                values= new string[] { title, desc };
                request.AddJsonBody(updateDevice);
            }
            else if (!string.IsNullOrEmpty(title))
            {
                UpdateTitle updateTitle = new Entity.UpdateTitle();
                updateTitle.title = title;
                keys = new string[] {"title"};
                values = new string[] {title};
                request.AddJsonBody(updateTitle);
            }else if(!string.IsNullOrEmpty(desc))
            {
                UpdateDesc updateDesc = new UpdateDesc();
                updateDesc.desc = desc;
                keys = new string[] { "desc" };
                values = new string[] { desc };
                request.AddJsonBody(updateDesc);
            }

            IRestResponse response = client.Execute(request);
            var content = response.Content; // raw content as string
            if (response.IsSuccessful)
            {
                UpdateResponse updateResponse= JsonHelper.DeserializeJsonToObject<UpdateResponse>(content);
                if (updateResponse.error.Equals("succ"))
                {
                    DeviceDataDao.Instance.Update(device_id, keys, values);
                    result.OnSuccess("更新成功");
                }
                else
                {
                    result.OnFailure(updateResponse.error);
                }
            }
            else
            {
                result.OnFailure("更新设备信息失败");
            }
        }
        /// <summary>
        /// 获取绘制图表的数据点
        /// </summary>
        /// <param name="deviceData"></param>
        /// <param name="result"></param>
        public void GetDataPoints(DeviceData deviceData, INetworkResult result,string datastream_id,
            string limit,string start,string end,string cursor,string duration)
        {

            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("devices/{device_id}/datapoints", Method.GET);
            request.AddUrlSegment("device_id", deviceData.id); // replaces matching token in request.Resource

            // add parameters for all properties on an object
            //request.AddObject(object);

            // or just whitelisted properties
            //request.AddObject(object, "PersonId", "Name", ...);

            // easily add HTTP Headers
            request.AddHeader("api-key", "VtaeS4yK3Fk6xiOljgw69lYcH9k=");

            if (!string.IsNullOrEmpty(datastream_id))
            {
                request.AddParameter("datastream_id", datastream_id);
            }

            if (!string.IsNullOrEmpty(limit))
            {
                request.AddParameter("limit", limit);
            }

            if (!string.IsNullOrEmpty(start))
            {
                request.AddParameter("start", start);
            }

            if (!string.IsNullOrEmpty(end))
            {
                request.AddParameter("end", end);
            }

            if (!string.IsNullOrEmpty(cursor))
            {
                request.AddParameter("cursor", cursor);
            }

            if (!string.IsNullOrEmpty(duration))
            {
                request.AddParameter("duration", duration);
            }

            IRestResponse response = client.Execute(request);
            var content = response.Content; // raw content as string
            if (response.IsSuccessful)
            {
                AppPoint point = JsonHelper.DeserializeJsonToObject<AppPoint>(content);

                if (point.error.Equals("succ"))
                {
                    ItemPoint item = new ItemPoint
                    {
                        deviceId = deviceData.id,
                        title = deviceData.title
                    };
                    StringBuilder builder = new StringBuilder();
                    foreach (DataStreams dataStream in point.data.datastreams)
                    {
                        RemarksID remarksID = RemarksDao.Instance.GetDeviceDataById(item.deviceId + dataStream.id);
                        foreach (DataPoints dataPoints in dataStream.datapoints)
                        {
                            dataPoints.at = dataPoints.at.Substring(0, dataPoints.at.Length - 4);
                        }
                        if (dataStream.id.Equals("P") || dataStream.id.Equals("T") || dataStream.id.Equals("H"))
                        {
                            //只获取最新的一个点在列表里显示
                            bool m = false;
                            foreach (DataPoints dataPoints in dataStream.datapoints)
                            {
                                if (m) {
                                    break;
                                }
                                if (string.IsNullOrEmpty(remarksID.remarks))
                                {
                                    builder.Append(dataStream.id + "=" + dataPoints.value);
                                }
                                else
                                {
                                    builder.Append(remarksID.remarks + "=" + dataPoints.value);
                                }
                                
                                foreach (DeviceDataStreams stream in deviceData.datastreams)
                                {
                                    if (dataStream.id.Equals(stream.id))
                                    {
                                        builder.Append(stream.unit + "  ");
                                        m = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    item.dataStreamsList = point.data.datastreams;
                    item.deviceDatastreams = deviceData.datastreams;
                    item.dataStrams = builder.ToString();

                    result.OnSuccess(item);

                }
                else
                {
                    result.OnFailure(point.error);
                }

            }
            else
            {
                result.OnFailure("获取" + deviceData.title + "的数据失败");
            }
        }
    }
}
