using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hanbashuoshuo.Models
{
    public class WechatConfig
    {
        public string wechatID { get; set; }
        public string appID { get; set; }
        public string appsecret { get; set; }
        public string appURL { get; set; }
        public string appToken { get; set; }

        public string JsToken { get; set; }
        public string JsDomain { get; set; }
        public string JsReturnDomain { get; set; }
        public string AccessToken { get; set; }
        public string AccessTokenExpiredTime { get; set; }

    }
}