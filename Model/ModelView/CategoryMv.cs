using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;

namespace Model.ModelView
{
    public class CategoryMv
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public SubCategory SubCategory { get; set; }
        public List<SubCategory> SubCategories { get; set; }
    }
}
