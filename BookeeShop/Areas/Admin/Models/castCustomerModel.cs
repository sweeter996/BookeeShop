using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BookeeShop.Areas.Admin.Models
{
    public class castCustomerModel
    {
        [Required(ErrorMessage = "LastName is not empty")]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "FirstName is not empty")]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Address is not empty")]
        public string Address { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Emmail is not empty")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Emmail is not empty")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}