using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;
using Model.ModelView;

namespace Model.Dao
{
     public class ProductDetailDao
     {
         private NhocGiftShopDbEntities db = null;

         public ProductDetailDao()
         {
            db = new NhocGiftShopDbEntities();
         }

         public List<DetailProductMv> getListAll(int idProduct)
         {
             var dataList = db.DetailProducts.Where(x => x.ProductId == idProduct).Select(x => new DetailProductMv
             {
                 ID = x.ID,
                 Color = x.Color,
                 Size = x.Size,
                 DateCreate = (DateTime) x.DateCreate,
                 Price = (decimal) x.Price,
                 Status = x.Status,
                 ProductName = x.Product.Name,
                 ProductId = x.Product.ID,
                 
                 

             }).ToList();
             return dataList;
         }

     }
}
