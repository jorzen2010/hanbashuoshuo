using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Wechat;

namespace hanbashuoshuo.Controllers
{
    public class WechatMaterialController : Controller
    {
        //
        // GET: /WechatMaterial/
        public ActionResult AddTempMaterial()
        {
            return View();
        }      
        public ActionResult UploadTempMaterial()
        {
            string type = Request.Form["MaterialType"];

            var file = Request.Files["MaterialFile"];
            string token = AccessTokenService.GetAccessToken();

            var media_id = WechatMaterialService.UploadTempMedia(token, type, file.FileName, file.InputStream);
            string filename = file.FileName;
            ViewBag.filename = filename;
            ViewBag.type = type;
            ViewBag.info = media_id;
            return View();
        }

        public ActionResult GetForeverMaterialList(string type="image",int offset=0,int count=20)
        {
            string token = AccessTokenService.GetAccessToken();
            ForeverMaterialCount materialCount = WechatMaterialService.GetForeverMaterialCount(token);

            ViewBag.voice_count = materialCount.voice_count;
            ViewBag.video_count = materialCount.video_count;
            ViewBag.image_count = materialCount.image_count;
            ViewBag.news_count = materialCount.news_count;

            MaterialListPost materialListPost = new MaterialListPost();
            materialListPost.type = type;
            materialListPost.offset = offset;
            materialListPost.count = count;
            string postdata = JsonConvert.SerializeObject(materialListPost);
            string result=WechatMaterialService.GetMaterialList(token, postdata);

            if (type == "news")
            {
                ViewBag.type = type;
                ViewBag.count = count;
                ViewBag.nextoffset = offset * count + 1;
                ForeverNewsMaterial foreverNewsMaterial = JsonConvert.DeserializeObject<ForeverNewsMaterial>(result);
                ViewData["NewsMaterialItems"] = foreverNewsMaterial.item;
            }
            else
            {
                ForeverMaterial foreverMaterial = JsonConvert.DeserializeObject<ForeverMaterial>(result);
                ViewBag.total_count = foreverMaterial.total_count;
                ViewBag.item_count = foreverMaterial.item_count;
                ViewBag.nextoffset = offset * count + 1;
                ViewBag.count=count;
                ViewBag.type=type;
                ViewData["MaterialItems"] = foreverMaterial.item;
            }


            return View();
 
        }




	}
}