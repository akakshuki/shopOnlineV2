using System.Collections.Generic;
using System.Linq;
using Model.Entities;
using Model.ModelView;

namespace Model.Dao
{
    public class MoreImageDao
    {
        private NhocGiftShopDbEntities db = null;

        public MoreImageDao()
        {
            db = new NhocGiftShopDbEntities();
            db.Configuration.ProxyCreationEnabled = false;
        }

        public List<MoreImageMv> getListAllById(int id)
        {
            var imageList = db.ProductImages.Where(x => x.ProductId == id).Select(x => new MoreImageMv
            {
                ID = x.ID,
                Name = x.Name,
                Product = x.Product,
                ProductId = x.Product.ID,
                ProductName = x.Product.Name

            }).ToList();
            return imageList;
        }

        public bool InsertImage(MoreImageMv model)
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
    }
}