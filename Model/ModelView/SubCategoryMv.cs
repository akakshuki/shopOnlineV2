using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModelView
{
    public class SubCategoryMv
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public bool Status { get; set; }
        public int CategoryId { get; set; }
    }
}
