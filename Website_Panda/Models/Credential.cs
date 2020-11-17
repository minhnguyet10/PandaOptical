using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Website_Panda.Models
{
    public class Credential
    {

        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string UserGroupID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string RoleName { get; set; }
    }
}