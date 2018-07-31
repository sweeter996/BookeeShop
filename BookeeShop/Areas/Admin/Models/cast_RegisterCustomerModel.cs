using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BookeeShop.Areas.Admin.Models
{
    public class cast_RegisterCustomerModel
    {
        [Required(ErrorMessage = "Chưa nhập họ")]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Chưa nhập tên")]
        [MaxLength(30)]
        public string FirstName { get; set; }

        
        public string Address { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Chưa nhập email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Chưa nhập password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}