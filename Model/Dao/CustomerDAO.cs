using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class CustomerDAO
    {
        public List<Customer> GetAllCus()
        {
            NhocGiftShopDbEntities db = new NhocGiftShopDbEntities();
            var list = db.Customers.OrderByDescending(s=>s.ID).ToList();
            return list;
        }

        public static Customer SelectByIDCus(int idCus)
        {
            NhocGiftShopDbEntities db = new NhocGiftShopDbEntities();
            var list = db.Customers.Where(s => s.ID == idCus).SingleOrDefault();
            return list;
        }

        public static bool UpdateCus(Customer customer)
        {
            NhocGiftShopDbEntities db = new NhocGiftShopDbEntities();
            var update = db.Customers.Where(w => w.ID == customer.ID).SingleOrDefault();
            update.UserName = customer.UserName;
            update.Name = customer.Name;
            update.Phone = customer.Phone;
            update.Email = customer.Email;
            update.Birth = customer.Birth;
            if (db.SaveChanges() > 0 )
            {
                return true;
            }
            return false;

        }

        public static bool DeleteCus(int idCus)
        {
            NhocGiftShopDbEntities db = new NhocGiftShopDbEntities();
            var item = db.Customers.Where(s => s.ID == idCus).SingleOrDefault();
            db.Customers.Remove(item);
            if (db.SaveChanges() > 0 )
            {
                return true;
            }
            return false;
        }
    }
}
