using Model.Dao;
using Model.Entities;
using Model.ModelView;
using System;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ShopOnlineVer2.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        public ActionResult Index()
        {
            setViewBag();
            return View();
        }

        [HttpGet]
        public ActionResult Insert()
        {
            setViewBag();
            return View();
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var res = new ProductDao().Delete(id);
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
                setAlbert("Xóa sản phẩm Thất bại", "Error");
                return Json(new
                {
                    status = false
                }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult Update(Product model, HttpPostedFileBase Image)
        {
            if (Image.FileName != null)
            {
                string nameFile = DateTime.Now.Ticks + Path.GetFileName(Image.FileName);
                string path = Path.Combine(Server.MapPath("~/Acess/Admin/img/product"), nameFile);
                model.Image = nameFile;
                model.DateCreate = DateTime.Now;
                Image.SaveAs(path);
            }

            var res = new ProductDao().Update(model);

            if (res)
            {
                setAlbert("Thêm sản phẩm thành công", "success");
                setViewBag();
                return View("Index");
            }
            else
            {
                setAlbert("Thêm sản phẩm thất bại", "error");

                return View("Insert");
            }
        }

        [HttpGet]
        public JsonResult LoadDetail(int id)
        {
            var model = new ProductDao().getDetailById(id);
            return Json(new
            {
                data = model,

                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Insert(Product model, HttpPostedFileBase Image)
        {
            string nameFile = DateTime.Now.Ticks + Path.GetFileName(Image.FileName);
            string path = Path.Combine(Server.MapPath("~/Acess/Admin/img/product"), nameFile);
            model.Image = nameFile;
            model.DateCreate = DateTime.Now;
            Image.SaveAs(path);

            var res = new ProductDao().InsertProduct(model);
            if (res)
            {
                setAlbert("Thêm sản phẩm thành công", "success");
                setViewBag();
                return View("Index");
            }
            else
            {
                setAlbert("Thêm sản phẩm thất bại", "error");

                return View("Insert");
            }
        }

        [HttpGet]
        public JsonResult LoadData(int pageNum, int pageSize)
        {
            var listData = new ProductDao().getListAll().Skip((pageNum - 1) * pageSize).Take(pageSize);
            int totalRow = new ProductDao().getListAll().Count();
            return Json(new
            {
                data = listData,
                total = totalRow,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        public void setViewBag()
        {
            var dataCategories = new CategoryDao().getListAll().Select(x => new ProductMv()
            {
                CategoryId = x.ID,
                CategoryName = x.Name
            });
            ViewBag.category = new SelectList(dataCategories, "CategoryId", "CategoryName");
        }

        public JsonResult setViewBagSubCategory(int idCategory)
        {
            var dataSubCategories = new SubCategoryDao().getListAllbyCategory(idCategory);
            return Json(dataSubCategories, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult MoreImage(int id)
        {
            @ViewBag.idProduct = id;
            return View();
        }

        [HttpGet]
        public JsonResult LoadProductImages(int id)
        {
            var dataList = new ImageProductDao().listImage(id);


            return Json(new
            {
                data = dataList,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult InsertMoreImage(ProductImageMv model)
        {
           var ImageString = model.Name;
           byte[] imageBytes = Convert.FromBase64String(ImageString);   
           MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);


            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            string nameImage = DateTime.Now.Ticks.ToString()+ ".jpg";
            string path = Path.Combine(Server.MapPath("~/Acess/Admin/img/product"), nameImage);
            image.Save(path,ImageFormat.Jpeg);
            model.Name = nameImage;



            var res = new ImageProductDao().InsertNewImage(model);
            if (res)
            {
                setAlbert("Thêm sản phẩm thành công", "success");
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                setAlbert("Thêm sản phẩm thất bại", "error");

                return Json(new
                {
                    status = true
                });
            }


           

        }

        [HttpPost]
        public ActionResult DeleteImageProduct(int id)
        {
            var res = new ImageProductDao().DeleteImage(id);
            if (res)
            {
                setAlbert("xóa sản phẩm thành công", "success");
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                setAlbert("xóa sản phẩm thất bại", "error");
                return Json(new
                {
                    status = false
                });

            }
          
        }

        public ActionResult DetailProduct(int id)
        {
            @ViewBag.productId = id;
            return View();
        }

        [HttpGet]
        public JsonResult LoadDetailProduct( int id)
        {
            var dataList = new ProductDetailDao().getListAll(id);

            return Json(new
            {
                data = dataList,
                status = true
            },JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult InsertDetailProduct(DetailProductMv model)
        {

            model.DateCreate = DateTime.Now;
            var res = new ProductDetailDao().insertDetail(model);
            if (res)
            {
                setAlbert("thêm loại sản phẩm thành công", "success");
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                setAlbert("thêm loại sản phẩm thất bại", "error");
                return Json(new
                {
                    status = false
                });
            }
        }
    }
}