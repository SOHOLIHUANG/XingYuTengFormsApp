﻿using RestSharp;
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
        public void addDevice(string device_id,InetworkResult result) {

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
                    GetDataPoint(device.data, result);
                }
                else {
                    result.onFailure(device.error);
                }
                
            } else {
                result.onFailure("获取设备信息失败");
            }
        }

        public void GetDataPoint(DeviceData deviceData, InetworkResult result)
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

            request.AddParameter("newadd", "true");

            IRestResponse response = client.Execute(request);
            var content = response.Content; // raw content as string
            if (response.IsSuccessful)
            {
                AppPoint point = JsonHelper.DeserializeJsonToObject<AppPoint>(content);

                if (point.error.Equals("succ"))
                {
                    ItemPoint item = new ItemPoint();
                    item.deviceId = deviceData.id;
                    item.title = deviceData.title+deviceData.id;
                    StringBuilder builder = new StringBuilder();
                    foreach (DataStreams dataStream in point.data.datastreams) {
                        if(dataStream.id.Equals("P")|| dataStream.id.Equals("T")|| dataStream.id.Equals("H"))
                        {
                            foreach (DataPoints dataPoints in dataStream.datapoints)
                            {
                                dataPoints.at = dataPoints.at.Substring(0, dataPoints.at.Length - 4);
                                builder.Append(dataStream.id + "=" + dataPoints.value);
                                foreach (DeviceDataStreams stream in deviceData.datastreams) {
                                    if (dataStream.id.Equals(stream.id)) {
                                        builder.Append(stream.unit + "  ");
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    item.dataStreamsList = point.data.datastreams;
                    item.deviceDatastreams = deviceData.datastreams;
                    item.dataStrams = builder.ToString();

                    result.onSuccess(item);

                }
                else
                {
                    result.onFailure(point.error);
                }

            }
            else
            {
                result.onFailure("获取"+deviceData.title+"的数据失败");
            }
        }
    }
}
