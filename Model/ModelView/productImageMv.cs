using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;

namespace Model.ModelView
{
   public class ProductImageMv
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public bool Status { get; set; }
        
        public  Product Product { get; set; }
    }
}
