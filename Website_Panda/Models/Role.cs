using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website_Panda.Models
{
    public class Role
    {
        [Key]
        public int IDRole { get; set; }

        [StringLength(50)]
        public string NameRole { get; set; }

        [StringLength(100)]
        public string Note { get; set; }
    }
}