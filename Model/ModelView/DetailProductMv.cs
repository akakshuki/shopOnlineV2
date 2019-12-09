﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;

namespace Model.ModelView
{
    public class DetailProductMv
    {
        public int ID { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }
        public string Size { get; set; }
        public  decimal  Price { get; set; }
        public  int  Quantity { get; set; }
        public  int  CreateBy { get; set; }
        public  DateTime  DateCreate { get; set; }
        public  int  ModifyBy { get; set; }
        public  DateTime  ModifyDate { get; set; }
        public bool Status { get; set; }
        public  int  ProductId { get; set; }
        public string ProductName { get; set; }
      

        public Product Product { get; set; }
       
    }
}