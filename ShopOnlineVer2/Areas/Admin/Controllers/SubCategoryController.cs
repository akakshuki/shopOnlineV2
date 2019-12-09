using Model.Dao;
using Model.Entities;
using ShopOnlineVer2.Areas.Admin.Models.ModelView;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ShopOnlineVer2.Areas.Admin.Controllers
{
    public class SubCategoryController : BaseController
    {
        // GET: Admin/SubCategoty
        public ActionResult Index()
        {
            setViewBag();
            return View();
        }

        [HttpGet]
        public JsonResult LoadData(int pageNum, int pageSize)
        {
            var listData = new SubCategoryDao().getListAll().Skip((pageNum - 1) * pageSize).Take(pageSize);
            int totalRow = new SubCategoryDao().getListAll().Count();
            return Json(new
            {
                data = listData,
                total = totalRow,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Insert()
        {
            setViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult Insert(string model)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            SubCategory subCategory = serializer.Deserialize<SubCategory>(model);
            var res = new SubCategoryDao().InsertCategory(subCategory);
            var url = new UrlHelper(Request.RequestContext).Action("Index","SubCategory");
            if (res > 0)
            {
                setAlbert("Thêm sản phẩm thành công", "success");
                return Json(new
                {
                    Status = true,
                    Url = url
                });

            }
            else
            { setAlbert("Thêm sản phẩm thất bại", "error");
                return Json(new
                {
                    Status = false,
                    Url = url
                });
            }

            
        }
        [HttpPost]
        public JsonResult DeleteSubCategory(int id)
        {

            var res = new SubCategoryDao().Delete(id);
            if (res)
            {
                setAlbert("Xóa sản phẩm thành công", "success");
                return Json(new
                {
                    status = true
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                setAlbert("Xóa sản phẩm thất bại", "error");
                return Json(new
                {
                    status = false
                }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult LoadDetail(int id)
        {
            var model = new SubCategoryDao().getSubCategoryById(id);

            return Json(new
            {
                data = model,

                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        public void setViewBag()
        {
            var dataCategories = new CategoryDao().getListAll().Select(x => new SubCategoryMv
            {
                CategoryId = x.ID,
                CategoryName = x.Name
            });
            ViewBag.category = new SelectList(dataCategories, "CategoryId", "CategoryName");
        }
    }
}