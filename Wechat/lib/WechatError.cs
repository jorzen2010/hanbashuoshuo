using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wechat
{
    public class WechatError
    {
        public string errcode { get; set; }
        public string errmsg { get; set; }
    }

    public class WechatResult
    {
        public int errcode { get; set; }
        public string errmsg { get; set; }

    }

}