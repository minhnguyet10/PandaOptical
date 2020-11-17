using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website_Panda.Models
{
    public class Customer
    {
        [Key]
        public long IdCus { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Please enter UserName!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter Password!")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm Password!")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [StringLength(100)]
        public string Email_Cus { get; set; }

        [StringLength(10)]
        public string FirstName { get; set; }

        [StringLength(10)]
        public string LastName { get; set; }

        [StringLength(200)]
        public string Address_Cus { get; set; }

        [StringLength(15)]
        public string Phone_Cus { get; set; }
        public DateTime? CreatedDay { get; set; }
        public int? Score { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
    }
}