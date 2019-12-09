using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using  Model.Dao;
using Model.Entities;

namespace ShopOnlineVer2.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult LoadData(int pageNum, int pageSize)
        {

            var listData = new CategoryDao().getListAll().Skip((pageNum - 1) * pageSize).Take(pageSize);
            int totalRow = new CategoryDao().getListAll().Count();
            return Json(new
            {
                data = listData,
                total = totalRow,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult InsertCategory(string model)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Category category = serializer.Deserialize<Category>(model);
            var res = new CategoryDao().InsertCategory(category);
            if (res)
            {
                return Json(new
                {
                    status = true
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    status = false
                }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpGet]
        public JsonResult LoadDetail(int id)
        {

            var model = new CategoryDao().getCategoryById(id);

            return Json(new
            {
                data = model,

                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult updateCategory(string model)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Category category = serializer.Deserialize<Category>(model);
            var res = new CategoryDao().UpdateCategory(category);
            if (res)
            {
                return Json(new
                {
                    status = true
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    status = false
                }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult DeleteCategory(int id)
        {
   
            var res = new CategoryDao().Delete(id);
            if (res)
            {
                return Json(new
                {
                    status = true
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    status = false
                }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}