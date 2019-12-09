using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;
using Model.ModelView;

namespace Model.Dao
{
    public class SubCategoryDao
    {
        private NhocGiftShopDbEntities db = null;
        public SubCategoryDao()
        {
            db = new NhocGiftShopDbEntities();
            db.Configuration.ProxyCreationEnabled = false;
        }

        public List<SubCategoryMv> getListAll()
        {
            var dataList = db.SubCategories.Select(x => new SubCategoryMv
            {
                ID = x.ID,
                Name = x.Name,
                CategoryName = x.Category.Name,
                Status = x.Status,
                CategoryId = x.Category.ID
            }).OrderByDescending(x=>x.ID).Take(500).ToList();
      
            return dataList;
        }

        public List<ProductMv> getListAllbyCategory(int id)
        {
            var dataList = db.SubCategories.Where(x=>x.CategoryId== id && x.Status == true).Select(x => new ProductMv
            {
                SubCategoryId = x.ID,
                SubCategoryName = x.Name,
                Status = x.Status,
              
            }).ToList();

            return dataList;
        }
        public int InsertCategory(SubCategory subCategory)
        {
            db.SubCategories.Add(subCategory);
            db.SaveChanges();

            return subCategory.ID;
        }

        public bool Delete(int id)
        {
            var data = db.SubCategories.Find(id);
            db.SubCategories.Remove(data);
            if (db.SaveChanges()>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public SubCategoryMv getSubCategoryById(int id)
        {
            var data = db.SubCategories.Where(x=>x.ID == id).Select(x => new SubCategoryMv
            {
                ID = x.ID,
                Name = x.Name,
                CategoryName = x.Category.Name,
                Status = x.Status,
                CategoryId = x.Category.ID
            }).SingleOrDefault();
            return data;
        }
    }
}
