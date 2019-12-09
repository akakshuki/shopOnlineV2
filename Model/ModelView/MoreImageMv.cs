using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Model.Entities;

namespace Model.ModelView
{
    public class MoreImageMv
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }
        public string  ProductName { get; set; }
        public bool Status { get; set; }
        public HttpPostedFileBase ImagePath { get; set; }
        public Product Product { get; set; }
    }
}
