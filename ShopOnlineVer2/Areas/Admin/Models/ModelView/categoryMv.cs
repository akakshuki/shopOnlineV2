using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Entities;

namespace ShopOnlineVer2.Areas.Admin.Models.ModelView
{
    public class CategoryMv
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public SubCategory SubCategory { get; set; }
    }
}