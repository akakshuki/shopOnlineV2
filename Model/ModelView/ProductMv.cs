using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;

namespace Model.ModelView
{
    public class ProductMv
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public string Image { get; set; }
        public string Price { get; set; }
        public decimal PriceDe { get; set; }
        public ProductImage ProductImage { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public DetailProduct DetailProduct { get; set; }
        public List<DetailProduct> DetailProducts { get; set; }public int CreateBy { get; set; }
        public DateTime DateCreate { get; set; }
        public int ModifyBy { get; set; }
        public DateTime ModifyDate { get; set; }
        public bool Status { get; set; }
        public SubCategory SubCategory { get; set; }
    }
}
