﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XingYuTengFormsApp.Entity
{
    class ItemPoint
    {
        public string deviceId { set; get; }
        public string title { set; get; }
        public List<DataStreams> dataStreamsList { set; get; }
        public List<DeviceDataStreams> deviceDatastreams { get; set; }
        public string dataStrams { set; get; }

        public string delete { get {
                return "×";
            } }
    }
}
