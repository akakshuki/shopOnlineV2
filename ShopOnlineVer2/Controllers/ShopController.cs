using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;

namespace ShopOnlineVer2.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index()
        {
            ViewBag.defaultProduct = new ProductDao().getListProduct();
            return View();
        }

        [ChildActionOnly]
        public ActionResult CategoryMenu()
        {
            var model = new CategoryDao().ListCategories();

            return PartialView(model);
        }

        public ActionResult LoadProductByCategory(int id)
        {
            ViewBag.defaultProductCategory = new ProductDao().getListProductByCategory(id);
            return View();
        }
        public ActionResult LoadProductBySubCategory(int id)
        {
            ViewBag.defaultProductSubCategory = new ProductDao().getListProductBySubCategory(id);
            return View();
        }
          public ActionResult ProductVIew(int id)
        {
            ViewBag.productDetail = new ProductDao().getProductById(id);
            return View();
        }
    }

}