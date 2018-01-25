using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XingYuTengFormsApp.Entity
{
    class RemarksID
    {
        public string deviceId { set; get; }
        public string typeId { set; get; }
        /// <summary>
        /// deviceId(4656512)+typeId(T)作为该数据库id(46565123T),本质为字符串拼接
        /// </summary>
        public string id { set; get; }
        public string remarks { set; get; }
        public string A { set; get; }
        public string R { set; get; }
        public string G { set; get; }
        public string B { set; get; }
    }
}
