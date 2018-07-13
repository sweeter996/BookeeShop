using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookeeShop.Areas.Admin.Models
{
    public class cast_LoginCustomerModel
    {
        [EmailAddress]
        [Required(ErrorMessage = "Emmail is not empty")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Emmail is not empty")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}