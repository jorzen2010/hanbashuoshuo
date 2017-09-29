using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wechat
{
    public class ForeverMaterialList
    {
        public string type { get; set; }
        public string offset { get; set; }
        public int count { get; set; }
    }

    public class ForeverMaterialCount
    {
        public int voice_count { get; set; }
        public int video_count { get; set; }
        public int image_count { get; set; }
        public int news_count { get; set; }
    }

    public class MaterialListPost
    {
        public string type { get; set; }
        public int offset { get; set; }
        public int count { get; set; }
 
    }
    public class ForeverMaterial
    {
        public int total_count { get; set; }
        public int item_count { get; set; }
        public List<ForeverMaterialItem> item { get; set; }
    }

    public class ForeverMaterialItem
    {
        public string media_id { get; set; }
        public string name { get; set; }
        public string update_time { get; set; }
        public string url { get; set; }
    }





    //以下三个是图文消息
    public class ForeverNewsMaterial
    {
        public int total_count { get; set; }
        public int item_count { get; set; }
        public List<ForeverNewsMaterialItem> item { get; set; }
      
    }

    public class ForeverNewsMaterialItem
    {
        public string media_id { get; set; }
        public Content content { get; set; }
        public string update_time { get; set; }

    }
    public class Content
    {
        public List<news_item> news_item { get; set; }
    }

    public class news_item
    {
        public string title { get; set; }
        public string thumb_media_id { get; set; }
        public string show_cover_pic { get; set; }
        public string author { get; set; }
        public string digest { get; set; }
        public string content { get; set; }
        public string url { get; set; }
        public string content_source_url { get; set; }

    }




}