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
    public sealed class NetWorkUtil
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


        public void addDevice(string device_id) {

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
               // DeviceDataSql.CreateDeviceTable();
                DeviceDataSql.Insert(device.data);
            } else {

            }
        }
    }
}
