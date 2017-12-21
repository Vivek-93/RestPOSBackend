using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApies.ViewModel
{
    public class RestaurantMenuEntity
    {
        public int id { get; set; }
        public string itemname { get; set; }
        public string shortcode { get; set; }
        public string onlinedisplayname { get; set; }
        public string subcategory { get; set; }
        public string price { get; set; }
        public string minimumpreparationtime { get; set; }
        public string hsncode { get; set; }
        public string description { get; set; }
        public string available { get; set; }
        public string category { get; set; }
        public string mealtype { get; set; }
        public string image_name { get; set; }
        public string image_path { get; set; }
    }

    public class subMenuModel
    {
        public string category { get; set; }
    }
    public class ItemDetail
    {
        public string subcategory { get; set; }
    }
}