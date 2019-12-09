using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;
using Model.ModelView;
namespace Model.Dao
{
  public  class ImageProductDao
    {
        private NhocGiftShopDbEntities db = null;

        public ImageProductDao()
        {
            db = new NhocGiftShopDbEntities();
            db.Configuration.ProxyCreationEnabled = false;
        }

        public List<ProductImageMv> listImage(int id)
        {
            var dataList = db.ProductImages.Where(x => x.ProductId == id).Select(x => new ProductImageMv
            {
                ID = x.ID,
                Name = x.Name,
                ProductId =  x.Product.ID,
                ProductName =  x.Product.Name,
                Status =  x.Status
            }).ToList();

            return dataList;
        }

        public bool InsertNewImage(ProductImageMv model)
        {
            var data = new ProductImage();
            data.Name = model.Name;
            data.ProductId = model.ProductId;
            data.Status = model.Status;
            db.ProductImages.Add(data);
            if (db.SaveChanges()>0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool DeleteImage(int id)
        {
            var data = db.ProductImages.Find(id);
            db.ProductImages.Remove(data);
            if (db.SaveChanges() > 0)
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
