using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;
using Model.ModelView;

namespace Model.Dao
{
    public class ProductDao
    {

        private NhocGiftShopDbEntities db = null;

        public ProductDao()
        {
            db = new NhocGiftShopDbEntities();
            db.Configuration.ProxyCreationEnabled = false;
        }

        public List<ProductMv> getListAll()
        {
            var list = db.Products.ToList();

            var data = db.Products.Select(x => new ProductMv()
            {
                ID = x.ID,
                Name = x.Name,
                CategoryName = x.SubCategory.Category.Name,
                SubCategoryName = x.SubCategory.Name,
                CategoryId = x.SubCategory.Category.ID,
                SubCategoryId = x.SubCategory.ID,
                Image = x.Image,
                Status = x.Status,
                DateCreate = x.DateCreate
                
            }).OrderByDescending(x => x.ID).ToList( );
            return data;
        }

        public List<ProductMv> getListProduct()
        {
          

            var data = db.Products.Select(x => new ProductMv()
            {
                ID = x.ID,
                Name = x.Name,
                CategoryName = x.SubCategory.Category.Name,
                SubCategoryName = x.SubCategory.Name,
                CategoryId = x.SubCategory.Category.ID,
                SubCategoryId = x.SubCategory.ID,
                Price = string.IsNullOrEmpty(x.DetailProducts.Where(k => k.ProductId == x.ID).FirstOrDefault().Price.ToString())?"Liên hệ" : x.DetailProducts.Where(k => k.ProductId == x.ID).FirstOrDefault().Price.ToString()+"vnd",
                Image = x.Image,
                Status = x.Status,
                DateCreate = x.DateCreate

            }).OrderByDescending(x => x.ID).ToList();
            return data;
        }

        public ProductMv getDetailById(int id)
        {
            var dataList = db.Products.Where(x=>x.ID==id).Select(x => new ProductMv()
            {
                ID = x.ID,
                Name = x.Name,
                CategoryName = x.SubCategory.Category.Name,
                SubCategoryName = x.SubCategory.Name,
                CategoryId = x.SubCategory.Category.ID,
                SubCategoryId = x.SubCategory.ID,
                Detail = x.Detail,
                Image = x.Image,
                Status = x.Status,
                DateCreate = x.DateCreate

            }).SingleOrDefault();
            return dataList;
        }

        public bool InsertProduct(Product model)
        {
            var data = db.Products.Add(model);
            if (db.SaveChanges()>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(Product model)
        {
            var data = db.Products.Find(model.ID);
            data.Name = model.Name;
            data.Detail = model.Detail;
            data.SubCategory = db.SubCategories.Find(model.SubCategoryId);
            data.CategoryId = model.CategoryId;
            data.Status = model.Status;             
            if (!string.IsNullOrEmpty(model.Image))
            {
                data.Image = model.Image;

            }

            data.Status = model.Status;
            data.ModifyDate = DateTime.Now;
            if (db.SaveChanges() > 0)
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            var data = db.Products.Find(id);
            db.Products.Remove(data);
            if (db.SaveChanges()>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<ProductMv> getListProductByCategory(int id)
        {
            var data = db.Products.Where(x=>x.SubCategory.Category.ID == id).Select(x => new ProductMv()
            {
                ID = x.ID,
                Name = x.Name,
                CategoryName = x.SubCategory.Category.Name,
                SubCategoryName = x.SubCategory.Name,
                CategoryId = x.SubCategory.Category.ID,
                SubCategoryId = x.SubCategory.ID,
                Price = string.IsNullOrEmpty(x.DetailProducts.Where(k => k.ProductId == x.ID).FirstOrDefault().Price.ToString()) ? "Liên hệ" : x.DetailProducts.Where(k => k.ProductId == x.ID).FirstOrDefault().Price.ToString() + "vnd",
                Image = x.Image,
                Status = x.Status,
                DateCreate = x.DateCreate

            }).OrderByDescending(x => x.DateCreate).Take(20).ToList();
            return data;

        }

        public object getListProductBySubCategory(int id)
        {
            var data = db.Products.Where(x => x.SubCategory.ID == id).Select(x => new ProductMv()
            {
                ID = x.ID,
                Name = x.Name,
                CategoryName = x.SubCategory.Category.Name,
                SubCategoryName = x.SubCategory.Name,
                CategoryId = x.SubCategory.Category.ID,
                SubCategoryId = x.SubCategory.ID,
                Price = string.IsNullOrEmpty(x.DetailProducts.Where(k => k.ProductId == x.ID).FirstOrDefault().Price.ToString()) ? "Liên hệ" : x.DetailProducts.Where(k => k.ProductId == x.ID).FirstOrDefault().Price.ToString() + "vnd",
                Image = x.Image,
                Status = x.Status,
                DateCreate = x.DateCreate

            }).OrderByDescending(x => x.DateCreate).Take(20).ToList();
            return data;
        }

        public ProductMv getProductById(int id)
        {
            var data = db.Products.Where(x => x.ID == id).Select(x => new ProductMv()
            {
                ID = x.ID,
                Name = x.Name,
                CategoryName = x.SubCategory.Category.Name,
                SubCategoryName = x.SubCategory.Name,
                CategoryId = x.SubCategory.Category.ID,
                SubCategoryId = x.SubCategory.ID,
                DetailProducts = x.DetailProducts.Where(k=>k.ProductId == x.ID).ToList(),
                Detail = x.Detail,
                ProductImages = x.ProductImages.Where(k=>k.ProductId==x.ID).ToList(),
                Price = string.IsNullOrEmpty(x.DetailProducts.Where(k => k.ProductId == x.ID).FirstOrDefault().Price.ToString()) ? "Liên hệ" : x.DetailProducts.Where(k => k.ProductId == x.ID).OrderByDescending(k=>k.Price).FirstOrDefault().Price.ToString() + "vnd",
                Status = x.Status,
                DateCreate = x.DateCreate

            }).SingleOrDefault();
            return data;
        }
    }

    
}
