using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Model.ModelView;

namespace Model.Dao
{
    public class CategoryDao
    {
        private NhocGiftShopDbEntities db = null;

        public CategoryDao()
        {
            db = new NhocGiftShopDbEntities();
            db.Configuration.ProxyCreationEnabled = false;
        }

        public List<Category> getListAll()
        {
            return db.Categories.ToList();
        }



        public Category getCategoryById(int id)
        {
            return db.Categories.Find(id);
        }

        public bool UpdateCategory(Category model)
        {
            var data = db.Categories.Find(model.ID);
            data.Name = model.Name;
            data.Status = model.Status;
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool Delete(int id)
        {
            var data = db.Categories.Find(id);
            var res = db.Categories.Remove(data);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool InsertCategory(Category category)
        {
            var data = db.Categories.Add(category);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<CategoryMv> ListCategories()
        {
            var data = db.Categories.Select(x => new CategoryMv
            {
                ID = x.ID,
                Name = x.Name,
                SubCategories = x.SubCategories.Where(k=> k.CategoryId == x.ID).ToList()
                }).ToList();

            return data;
        }
    }
}