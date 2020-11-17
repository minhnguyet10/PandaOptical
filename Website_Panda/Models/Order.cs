using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Website_Panda.Models
{
    public class Order
    {
        [Key]
        public long IDOrder { get; set; }
        public DateTime? OrderDate { get; set; }

        [StringLength(500)]
        public string Descriptions { get; set; }
        
        [ForeignKey("Customer")]
        public long? IdCus { get; set; }
        public virtual Customer Customer { get; set; }
        
        public bool? Status { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<Shipping> Shippings { get; set; }
    }
}