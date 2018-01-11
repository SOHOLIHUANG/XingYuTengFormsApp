using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XingYuTengFormsApp.Entity
{
    public class DeviceData
    {
        public string auth_info { get; set; }
        public string create_time { get; set; }
        public string id { get; set; }
        public Location location { get; set; }
        public bool online { get; set; }
        public bool isPrivate { get; set; }
        public string protocol { get; set; }
        //public string tags { get; set; }
        public string title { get; set; }
        public string desc { get;set; }
        public List<DeviceDataStreams> datastreams { get; set; }
    }
}
