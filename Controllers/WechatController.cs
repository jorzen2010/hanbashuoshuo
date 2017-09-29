using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wechat;


namespace hanbashuoshuo.Controllers
{
    public class WechatController : Controller
    {
        //
        // GET: /Wechat/
        public ActionResult Setting()
        {
            WechatSetting wechatSetting = new WechatSetting();
            wechatSetting.WechatID = ConfigService.GetValueByKey("WechatID");
            wechatSetting.AppID = ConfigService.GetValueByKey("AppID");
            wechatSetting.AppSecret = ConfigService.GetValueByKey("AppSecret");
            wechatSetting.WechatToken = ConfigService.GetValueByKey("WechatToken");
            wechatSetting.WechatEncodingAESKey = ConfigService.GetValueByKey("WechatEncodingAESKey");


            return View(wechatSetting);
        }

        public ActionResult Test()
        {
            return View();
        }
	
	}
}