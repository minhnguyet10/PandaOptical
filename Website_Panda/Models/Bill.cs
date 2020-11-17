using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Website_Panda.Models
{
    public class Bill
    {
        [Key]
        public long IDBill { get; set; }

        [ForeignKey("Order")]
        public long IDOrder { get; set; }
        public virtual Order Order { get; set; }

        [ForeignKey("Customer")]
        public long IdCus { get; set; }
        public virtual Customer Customer { get; set; }
        public DateTime? CreateDay { get; set; }
        public decimal? ShippingPrice { get; set; }
        public decimal? TotalPrice { get; set; }
    }
}