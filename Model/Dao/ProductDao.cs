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
    }
}
