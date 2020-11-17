using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Website_Panda.Models
{
    public class Product
    {
        [Key]
        public long IDProduct { get; set; }

        [StringLength(250)]
        public string ProductName { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(250)]
        public string Image { get; set; }
        public string MoreImage1 { get; set; }
        public string MoreImage2 { get; set; }
        public decimal? Price { get; set; }
        public decimal? PromotionPrice { get; set; }
        public int? Quantity { get; set; }
        public string Color { get; set; }

        [ForeignKey("Category")]
        public long? CategoryID { get; set; }
        public virtual Category Category { get; set; }
        
        [ForeignKey("Brand")]
        public long? BrandID { get; set; }
        public virtual Brand Brand { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
    }
}