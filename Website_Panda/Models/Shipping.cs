using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Website_Panda.Models
{
    public class Shipping
    {
        [Key]
        public int ShipID { get; set; }

        [ForeignKey("Order")]
        public long IDOrder { get; set; }
        public virtual Order Order { get; set; }

        [ForeignKey("User")]
        public long IDUser { get; set; }
        public virtual User User { get; set; }

        public DateTime? ShippingDate { get; set; }
        public bool? Status { get; set; }
        public string Issue { get; set; }
    }
}