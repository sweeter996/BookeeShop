using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookeeShop.Models
{
    [Table("Customer")]
    public class CustomerModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }

        //[Required(ErrorMessage = "LastName is not empty")]
        //[MaxLength(30)]
        //public string LastName { get; set; }

        //[Required(ErrorMessage = "FirstName is not empty")]
        //[MaxLength(30)]
        //public string FirstName { get; set; }

        //[Required(ErrorMessage = "Address is not empty")]
        //public string Address { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Emmail is not empty")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Emmail is not empty")]
        //public string Password { get; set; }
        public Boolean isActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastDateModified { get; set; }
    }
}