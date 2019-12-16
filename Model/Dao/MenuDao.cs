using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;

namespace Model.Dao
{
    public class MenuDao
    {
        private NhocGiftShopDbEntities db = null;
        public MenuDao()
        {
            db = new NhocGiftShopDbEntities();
        }
        
    }
}
