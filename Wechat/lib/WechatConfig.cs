using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wechat
{
    public class WechatConfig
    {
        public string Appid { get; set; }
        public string AppSecret { get; set; }
        public string AccessToken { get; set; }
        public string AccessTokenExpiredTime { get; set; }

    }
    public class WechatSetting
    {
        public string WechatID { get; set; }
        public string AppID { get; set; }
        public string AppSecret { get; set; }
        public string WechatToken { get; set; }
        public string WechatEncodingAESKey { get; set; }

    
    }
}