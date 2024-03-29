//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Web.Mvc;

namespace Model.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.DetailProducts = new HashSet<DetailProduct>();
            this.OrderDetails = new HashSet<OrderDetail>();
            this.ProductImages = new HashSet<ProductImage>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        [AllowHtml]
        public string Detail { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Nullable<int> SubCategoryId { get; set; }
        public string Image { get; set; }
        public Nullable<int> CreateBy { get; set; }
        public System.DateTime DateCreate { get; set; }
        public Nullable<int> ModifyBy { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public bool Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetailProduct> DetailProducts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductImage> ProductImages { get; set; }
    }
}
