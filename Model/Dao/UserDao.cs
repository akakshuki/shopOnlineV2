using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;

namespace Model.Dao
{
    public class UserDao
    {
        private NhocGiftShopDbEntities db = null;

        public UserDao()
        {
            db = new NhocGiftShopDbEntities();
        }

        public int Login(string userName, string password)
        {
            var result = db.Users.Where(x => x.UserName == userName && x.Password == password).FirstOrDefault();
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.Password == password)
                    {
                        return 1;
                    }
                    else
                    {
                        return -2;
                    }
                }
            }
        }

        public User GetById(string userName)
        {
            return db.Users.Where(x => x.UserName == userName).SingleOrDefault();
        }
    }
}
