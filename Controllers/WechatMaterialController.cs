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

        public ActionResult GetForeverMaterialList(int? page,string type="image",int offset=0,int count=20)
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

            page = page ?? 1;

            if (type == "news")
            {
                ForeverNewsMaterial foreverNewsMaterial = JsonConvert.DeserializeObject<ForeverNewsMaterial>(result);
                ViewData["NewsMaterialItems"] = foreverNewsMaterial.item;
                ViewBag.total_count = foreverNewsMaterial.total_count;
                ViewBag.item_count = foreverNewsMaterial.item_count;
                int totalPage = ((foreverNewsMaterial.total_count + count - 1) / count);
                bool prepage = false;
                bool nextpage = false;
                if (page >1)
                {
                    prepage = true;
                }
                if (totalPage > page)
                {
                    nextpage = true;
 
                }

                ViewBag.nextoffset = page * count;
                ViewBag.preoffset = (page - 2) * count;
                ViewBag.count = count;
                ViewBag.type = type;
                ViewBag.page = page;
                ViewBag.totalPage = totalPage;
                ViewBag.prepage = prepage;
                ViewBag.nextpage = nextpage;
               
            }
            else
            {
                ForeverMaterial foreverMaterial = JsonConvert.DeserializeObject<ForeverMaterial>(result);
                ViewBag.total_count = foreverMaterial.total_count;
                ViewBag.item_count = foreverMaterial.item_count;
                int totalPage = ((foreverMaterial.total_count+count-1)/ count) ;
                bool prepage = false;
                bool nextpage = false;
                if (type == "image")
                {
                    nextpage = true;
                }
                if (page > 1)
                {
                    prepage = true;
                }
                if (totalPage > page)
                {
                    nextpage = true;

                }
                ViewBag.prepage = prepage;
                ViewBag.nextpage = nextpage;
                ViewBag.nextoffset = page * count;
                ViewBag.preoffset = (page-2) * count;
                ViewBag.count=count;
                ViewBag.type=type;
                ViewBag.page = page;
                ViewBag.totalPage = totalPage;
                ViewData["MaterialItems"] = foreverMaterial.item;
            }


            return View();
 
        }




	}
}